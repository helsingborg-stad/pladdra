import React, { useEffect, useState } from 'react'
import Amplify, { API, graphqlOperation } from 'aws-amplify'
import * as mutations from './graphql/mutations'
import * as queries from './graphql/queries'

import { Resource } from "react-admin"
import { AmplifyAdmin } from "react-admin-amplify"

import awsExports from "./aws-exports.js"
import { Todo } from './API'
import { withAuthenticator } from '@aws-amplify/ui-react'
import { TodoList } from './components/todo/List'

Amplify.configure(awsExports)


const App = (): React.ReactElement => {
	return (
		<AmplifyAdmin
			operations={{ queries, mutations }}
			options={{ authGroups: ["admin"] }}
		>
			<Resource name="todos" list={TodoList} />
		</AmplifyAdmin>
	)
}



export default App
