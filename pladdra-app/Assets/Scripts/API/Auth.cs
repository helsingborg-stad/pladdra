using UnityEngine;
using System.Collections.Generic;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System;
using System.Threading.Tasks;
using System.Net;


namespace Pladdra
{

    public class Auth : MonoBehaviour
    {

        private static Auth s_instance;

        // the AWS region of where your services live
        public static Amazon.RegionEndpoint Region = Amazon.RegionEndpoint.EUCentral1;

        // In production, should probably keep these in a config file

        [SerializeField] private string cognitoIdentityPoolID;
        [SerializeField] private string cognitoAppClientID;
        [SerializeField] private string cognitoUserPoolID;

        private AmazonCognitoIdentityProviderClient _provider;
        private CognitoAWSCredentials _cognitoAWSCredentials;
        private static string _userid = "";
        private CognitoUser _user;
        private App _app;

        public static async Task<bool> RefreshSession()
        {
            Debug.Log("RefreshSession");

            DateTime issued = DateTime.Now;
            UserSessionCache userSessionCache = new UserSessionCache();
            SaveDataManager.LoadJsonData(userSessionCache, true);

            try
            {
                CognitoUserPool userPool = new CognitoUserPool(s_instance.cognitoUserPoolID, s_instance.cognitoAppClientID, s_instance._provider);

                // apparently the username field can be left blank for a token refresh request
                CognitoUser user = new CognitoUser("", s_instance.cognitoAppClientID, userPool, s_instance._provider);

                // The "Refresh token expiration (days)" (Cognito->UserPool->General Settings->App clients->Show Details) is the
                // amount of time since the last login that you can use the refresh token to get new tokens. After that period the refresh
                // will fail Using DateTime.Now.AddHours(1) is a workaround for https://github.com/aws/aws-sdk-net-extensions-cognito/issues/24
                user.SessionTokens = new CognitoUserSession(
                   userSessionCache.getIdToken(),
                   userSessionCache.getAccessToken(),
                   userSessionCache.getRefreshToken(),
                   issued,
                   DateTime.Now.AddDays(30)); // TODO: need to investigate further. 
                                              // It was my understanding that this should be set to when your refresh token expires...

                // Attempt refresh token call
                AuthFlowResponse authFlowResponse = await user.StartWithRefreshTokenAuthAsync(new InitiateRefreshTokenAuthRequest
                {
                    AuthFlowType = AuthFlowType.REFRESH_TOKEN_AUTH
                })
                .ConfigureAwait(false);

                // Debug.Log("User Access Token after refresh: " + token);
                Debug.Log("User refresh token successfully updated!");

                // update session cache
                UserSessionCache userSessionCacheToUpdate = new UserSessionCache(
                   authFlowResponse.AuthenticationResult.IdToken,
                   authFlowResponse.AuthenticationResult.AccessToken,
                   authFlowResponse.AuthenticationResult.RefreshToken,
                   userSessionCache.getUserId());

                SaveDataManager.SaveJsonData(userSessionCacheToUpdate);

                // update credentials with the latest access token
                s_instance._cognitoAWSCredentials = user.GetCognitoAWSCredentials(s_instance.cognitoIdentityPoolID, Region);

                s_instance._user = user;

                return true;
            }
            catch (NotAuthorizedException ne)
            {
                // https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-using-tokens-with-identity-providers.html
                // refresh tokens will expire - user must login manually every x days (see user pool -> app clients -> details)
                Debug.Log("NotAuthorizedException: " + ne);
            }
            catch (WebException webEx)
            {
                // we get a web exception when we cant connect to aws - means we are offline
                Debug.Log("WebException: " + webEx);
            }
            catch (Exception ex)
            {
                Debug.Log("Exception: " + ex);
            }
            return false;
        }

        public static async Task<bool> Login(string userName, string password)
        {
            // Debug.Log("Login: " + userName + ", " + password);

            CognitoUserPool userPool = new CognitoUserPool(s_instance.cognitoUserPoolID, s_instance.cognitoAppClientID, s_instance._provider);
            CognitoUser user = new CognitoUser(userName, s_instance.cognitoAppClientID, userPool, s_instance._provider);

            InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest()
            {
                Password = password
            };

            try
            {
                AuthFlowResponse authFlowResponse = await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);

                _userid = await s_instance.GetUserIdFromProvider(authFlowResponse.AuthenticationResult.AccessToken);
                // Debug.Log("Users unique ID from cognito: " + _userid);

                UserSessionCache userSessionCache = new UserSessionCache(
                   authFlowResponse.AuthenticationResult.IdToken,
                   authFlowResponse.AuthenticationResult.AccessToken,
                   authFlowResponse.AuthenticationResult.RefreshToken,
                   _userid);

                SaveDataManager.SaveJsonData(userSessionCache);

                // This how you get credentials to use for accessing other services.
                // This IdentityPool is your Authorization, so if you tried to access using an
                // IdentityPool that didn't have the policy to access your target AWS service, it would fail.
                s_instance._cognitoAWSCredentials = user.GetCognitoAWSCredentials(s_instance.cognitoIdentityPoolID, Region);

                s_instance._user = user;

                return true;
            }
            catch (Exception e)
            {
                Debug.Log("Login failed, exception: " + e);
                return false;
            }
        }

        public static async Task<bool> Signup(string username, string email, string password)
        {
            // Debug.Log("SignUpRequest: " + username + ", " + email + ", " + password);

            SignUpRequest signUpRequest = new SignUpRequest()
            {
                ClientId = s_instance.cognitoAppClientID,
                Username = email,
                Password = password
            };

            // must provide all attributes required by the User Pool that you configured
            List<AttributeType> attributes = new List<AttributeType>()
            {
                new AttributeType(){
                    Name = "email", Value = email
                },
                new AttributeType(){
                    Name = "preferred_username", Value = username
                }
            };
            signUpRequest.UserAttributes = attributes;

            try
            {
                SignUpResponse sighupResponse = await s_instance._provider.SignUpAsync(signUpRequest);
                Debug.Log("Sign up successful");
                return true;
            }
            catch (Exception e)
            {
                Debug.Log("Sign up failed, exception: " + e);
                return false;
            }
        }

        // Make the user's unique id available for GameLift APIs, linking saved data to user, etc
        public static string GetUsersId()
        {
            // Debug.Log("GetUserId: [" + _userid + "]");
            if (_userid == null || _userid == "")
            {
                // load userid from cached session 
                UserSessionCache userSessionCache = new UserSessionCache();
                SaveDataManager.LoadJsonData(userSessionCache, true);
                _userid = userSessionCache.getUserId();
            }
            return _userid;
        }

        // we call this once after the user is authenticated, then cache it as part of the session for later retrieval 
        private async Task<string> GetUserIdFromProvider(string accessToken)
        {
            // Debug.Log("Getting user's id...");
            string subId = "";

            Task<GetUserResponse> responseTask =
               s_instance._provider.GetUserAsync(new GetUserRequest
               {
                   AccessToken = accessToken
               });

            GetUserResponse responseObject = await responseTask;

            // set the user id
            foreach (var attribute in responseObject.UserAttributes)
            {
                if (attribute.Name == "sub")
                {
                    subId = attribute.Value;
                    break;
                }
            }

            return subId;
        }

        // Limitation note: so this GlobalSignOutAsync signs out the user from ALL devices, and not just the game.
        // So if you had other sessions for your website or app, those would also be killed.  
        // Currently, I don't think there is native support for granular session invalidation without some work arounds.
        public static async void SignOut()
        {
            await s_instance._user.GlobalSignOutAsync();

            // Important! Make sure to remove the local stored tokens 
            UserSessionCache userSessionCache = new UserSessionCache("", "", "", "");
            SaveDataManager.SaveJsonData(userSessionCache);

            Debug.Log("user logged out.");
        }

        // access to the user's authenticated credentials to be used to call other AWS APIs
        public static CognitoAWSCredentials GetCredentials()
        {
            return s_instance._cognitoAWSCredentials;
        }

        // access to the user's access token to be used wherever needed - may not need this at all.
        public static string GetAccessToken()
        {
            UserSessionCache userSessionCache = new UserSessionCache();
            SaveDataManager.LoadJsonData(userSessionCache, true);
            return userSessionCache.getAccessToken();
        }

        void Awake()
        {
            s_instance = this;
            _provider = new AmazonCognitoIdentityProviderClient(new Amazon.Runtime.AnonymousAWSCredentials(), Region);
            Debug.Log("AuthenticationManager: Awake");
        }
    }
}