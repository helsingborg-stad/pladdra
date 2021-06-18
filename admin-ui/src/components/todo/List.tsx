import React from "react"
import { List, Datagrid, TextField, EditButton } from "react-admin"


export const TodoList = (props: any): React.ReactElement => {
	return (
		<List {...props}>
			<Datagrid>
				<TextField source="id" />
				<TextField source="name" />
				<TextField source="description" />
				<EditButton basePath="/todo" />
			</Datagrid>
		</List>
	)
}