import React from "react";
import Amplify from "aws-amplify";
import { Resource } from "react-admin";
import { AmplifyAdmin } from "react-admin-amplify";
import { withAuthenticator } from "@aws-amplify/ui-react";
import { AssetList } from "components/Asset/List";
import { EditAsset } from "components/Asset/Edit";
import { CreateAsset } from "components/Asset/Create";
import * as mutations from "graphql/mutations";
import * as queries from "graphql/queries";

import awsExports from "aws-exports";

// import Dashboard from './components/Dashboard/Dashboard'

Amplify.configure(awsExports);

const App = (): React.ReactElement => (
  <AmplifyAdmin
    // dashboard={Dashboard}
    operations={{ queries, mutations }}
    options={{
      authGroups: ["superadmin", "admin"],
      storageBucket: awsExports.aws_user_files_s3_bucket,
      storageRegion: awsExports.aws_user_files_s3_bucket_region,
    }}
  >
    <Resource
      name="assets"
      list={AssetList}
      create={CreateAsset}
      edit={EditAsset}
    />
  </AmplifyAdmin>
);

export default withAuthenticator(App);
