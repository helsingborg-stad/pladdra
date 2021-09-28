/* Amplify Params - DO NOT EDIT
	AUTH_PLADDRAF1727651F1727651_USERPOOLID
	ENV
	REGION
Amplify Params - DO NOT EDIT */

/* eslint-disable import/no-unresolved */
/* eslint-disable no-unused-vars */
/* eslint-disable no-param-reassign */
const AWS = require('aws-sdk');
const http = require('https');

exports.handler = function (event, context, callback) {
    const {userName, request} = event;
    const {password} = request;

	console.log(`User does not exist in User Pool, attempting migration: ${userName}`);

	const options = {
		host: 'intranat.helsingborg.se',
		path: `/ad-api/user/get/${userName}`,
		method: 'POST'
	};

	const req = http.request(options, response => {
		let str = '';

		response.on('data', chunk => {
			str += chunk;
		});

		response.on('end', () => { 
			try {
				const userObject = JSON.parse(str);
				const user = userObject[0] ?? false;

				if (user && 'displayname' in user) {
					event.response.userAttributes = {
						"email": user.userprincipalname,
						"email_verified": "true",
						"custom:department": user.department ?? '',
					};
					
	            	event.response.finalUserStatus = "CONFIRMED";
	            	event.response.messageAction = "SUPPRESS";
					context.succeed(event);
				} else {
					throw new Error("User not found.");
				}
			}
			catch (e) {
				console.log(e)
			}
		});
	});

	//  This is the data we are posting, it needs to be a string or a buffer
    
	req.write(JSON.stringify({ username: userName, password }));
	req.end();
};