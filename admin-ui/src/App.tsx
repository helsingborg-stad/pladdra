import React from 'react'
import Amplify from 'aws-amplify'
import * as mutations from './graphql/mutations'
import * as queries from './graphql/queries'

import { Resource } from "react-admin"
import { AmplifyAdmin } from "react-admin-amplify"

import awsExports from "./aws-exports.js"
import { withAuthenticator } from '@aws-amplify/ui-react'
import { TodoList } from './components/todo/List'
import { CreateTodo } from './components/todo/Create'
import { EditTodo } from './components/todo/Edit'

Amplify.configure(awsExports)


const App = (): React.ReactElement => {
	return (
		<AmplifyAdmin
			operations={{ queries, mutations }}
			options={{ authGroups: ["admin"] }}
		>
			<Resource name="todos" list={TodoList} create={CreateTodo} edit={EditTodo} />
		</AmplifyAdmin>
	)
}



export default withAuthenticator(App)
