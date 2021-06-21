import React from "react"
import { List, Datagrid, TextField, EditButton } from "react-admin"
import {
	AmplifyFileField,
	AmplifyFileInput,
	AmplifyImageField,
	AmplifyImageInput,
} from "react-admin-amplify"

export const TodoList = (props: any): React.ReactElement => {
	return (
		<List {...props}>
			<Datagrid>
				<TextField source="id" />
				<TextField source="name" />
				<TextField source="description" />
				{/* <AmplifyImageField source={'file'} title="Avatar" addLabel={true} /> */}
				<EditButton basePath="/todos" />
			</Datagrid>
		</List>
	)
}