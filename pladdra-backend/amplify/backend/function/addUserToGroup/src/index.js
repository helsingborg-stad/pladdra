/* Amplify Params - DO NOT EDIT
	ENV
	REGION
	AUTH_PLADDRAF1727651F1727651_USERPOOLID
	GROUP
Amplify Params - DO NOT EDIT */

/* eslint-disable-line */ const aws = require('aws-sdk');

const cognitoidentityserviceprovider = new aws.CognitoIdentityServiceProvider({
    apiVersion: '2016-04-18',
  });

const UserHasExistingGroups = (userPoolId, userName) => new Promise((resolve, reject) => {
    const params = {
		UserPoolId: userPoolId,
		Username: userName,
	};

    cognitoidentityserviceprovider.adminListGroupsForUser(params, (err, data) => {
        if (err) {
            reject(err);
            return;
       }

       const { Groups } = data;
       resolve(Groups && Groups.length > 0);
    });
});
  
exports.handler = async (event, context, callback) => {
    try {
        const {userPoolId, userName} = event;
        const addUserParams = {
            GroupName: process.env.GROUP,
            UserPoolId: userPoolId,
            Username: userName,
        };

        const isMemberOfAnyGroup = await UserHasExistingGroups(userPoolId, userName);
    
        if (!isMemberOfAnyGroup)
            await cognitoidentityserviceprovider.adminAddUserToGroup(addUserParams).promise();
    } catch(e) {
        console.log(`Error in addUserToGroup Lambda ${e}`);
    }

    return event;
};


