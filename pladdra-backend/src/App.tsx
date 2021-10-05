import React from "react";
import Amplify from "aws-amplify";
import { Admin, Resource } from "react-admin";
import {
  CognitoGroupList,
  CognitoUserList,
  CognitoUserShow,
  buildAuthProvider,
  buildDataProvider,
} from "react-admin-amplify";

import { ThemeProvider } from "@material-ui/core/styles";
import { Person, People, PermMedia } from "@material-ui/icons";

import * as mutations from "@app/graphql/mutations";
import * as queries from "@app/graphql/queries";

import awsExports from "@app/aws-exports";
import i18nProvider from "@app/i18n/i18nProvider";
// import customRoutes from "@app/customRoutes";
import theme from "@theme";
import { Asset, Dialogue } from "@components";
// import Dashboard from './components/Dashboard/Dashboard'

Amplify.configure({
  ...awsExports,
  Auth: { authenticationFlowType: "USER_PASSWORD_AUTH" },
});

const App = (): React.ReactElement => (
  <ThemeProvider theme={theme}>
    <Admin
      disableTelemetry
      authProvider={buildAuthProvider({ authGroups: ["superadmin", "admin"] })}
      dataProvider={buildDataProvider(
        { queries, mutations },
        {
          storageBucket: awsExports.aws_user_files_s3_bucket,
          storageRegion: awsExports.aws_user_files_s3_bucket_region,
          enableAdminQueries: true,
        }
      )}
      theme={theme}
      i18nProvider={i18nProvider}
    >
      <Resource
        name="dialogues"
        list={Dialogue.List}
        create={Dialogue.Create}
        edit={Dialogue.Edit}
        options={{}}
      />

      <Resource
        name="assets"
        list={Asset.List}
        create={Asset.Create}
        edit={Asset.Edit}
        icon={PermMedia}
        options={{}}
      />

      <Resource
        name="cognitoUsers"
        list={CognitoUserList}
        show={CognitoUserShow}
        icon={Person}
        options={{}}
      />

      <Resource
        name="cognitoGroups"
        list={CognitoGroupList}
        icon={People}
        options={{}}
      />
    </Admin>
  </ThemeProvider>
);

export default App;
