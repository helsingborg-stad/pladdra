/* eslint-disable-line */ const aws = require('aws-sdk');

const lambda = new aws.Lambda({
  region: process.env.REGION,
});

exports.handler = async (event, _, callback) => {
  try {
    await lambda
      .invoke({
        FunctionName: `addUserToGroup-${process.env.ENV}`, // my other function
        Payload: JSON.stringify(event, null, 2),
      })
      .promise();
  } catch (error) {
     console.log(`Error in PostAuthentication Trigger: ${error}`);
    // callback(error);
  }

  // callback(null, event);
};