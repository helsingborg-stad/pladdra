import React from "react"
import { List, Datagrid, TextField, DateField, EditButton } from "react-admin"


export const TodoList = (props: any): React.ReactElement => {
	console.log("props", props)
	return (
		<List {...props}>
			<Datagrid>
				<TextField source="id" />
				<TextField source="name" />
				<DateField source="description" />
				<EditButton basePath="/todo" />
			</Datagrid>
		</List>
	)
}