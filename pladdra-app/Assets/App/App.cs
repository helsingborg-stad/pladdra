using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

namespace Pladdra
{
    public class App : MonoBehaviour
    {
        public static string CachePath;

        public Button loginButton;
        public Button startButton;
        public Button assetsButton;
        public Button logoutButton;
        public TMP_InputField usernameFieldLogin;
        public TMP_InputField passwordFieldLogin;
        public TMP_Text loginNoticeText;

        public string appSyncApiUrl;
        public string appSyncApiKey;
        public string appSyncApiID;
        public string cognitoIdentityPoolID;
        public string cognitoAppClientID;
        public string cognitoUserPoolID;

        private GameObject _login;
        private GameObject _loginLoaderText;
        private GameObject _mainMenu;
        private GameObject _download;

        private Auth _auth;

        void Awake()
        {
            CachePath = Application.persistentDataPath;
            // DotEnv.SetEnvVariables();

            _login = GameObject.Find("Login");
            _mainMenu = GameObject.Find("MainMenu");
            _download = GameObject.Find("Download");


            _auth = FindObjectOfType<Auth>();
        }

        void Start()
        {
            Debug.Log("UIInputManager: Start");
            // check if user is already authenticated 
            // We perform the refresh here to keep our user's session alive so they don't have to keep logging in.
            RefreshToken();

            assetsButton.onClick.AddListener(onAssetsClick);
            loginButton.onClick.AddListener(onLoginClicked);
            startButton.onClick.AddListener(onStartClick);
            logoutButton.onClick.AddListener(onLogoutClick);
        }

        private void displayComponentsFromAuthStatus(bool loggedIn)
        {
            if (loggedIn)
            {
                _login.SetActive(false);
                _mainMenu.SetActive(true);
                _download.SetActive(false);
            }
            else
            {
                _login.SetActive(true);
                _mainMenu.SetActive(false);
                _download.SetActive(false);
            }

            // clear out passwords
            loginNoticeText.text = "";
            passwordFieldLogin.text = "";

            // set focus to email field on login form
            // _selectedFieldIndex = -1;
        }
        private async void RefreshToken()
        {
            bool successfulRefresh = await _auth.RefreshSession();
            displayComponentsFromAuthStatus(successfulRefresh);
        }

        private async void onLoginClicked()
        {
            _login.SetActive(false);
            loginNoticeText.text = "Loading ...";
            // Debug.Log("onLoginClicked: " + emailFieldLogin.text + ", " + passwordFieldLogin.text);
            bool successfulLogin = await _auth.Login(usernameFieldLogin.text, passwordFieldLogin.text);
            loginNoticeText.text = "";
            displayComponentsFromAuthStatus(successfulLogin);
        }

        private void onLogoutClick()
        {
            _auth.SignOut();
            displayComponentsFromAuthStatus(false);
        }

        private void onStartClick()
        {
            Debug.Log("onStartClick");

        }
        private void onAssetsClick()
        {
            Debug.Log("onAssetsClick");
        }
    }
}