import React from "react"
import { Create, TextInput, SimpleForm } from "react-admin"

export const CreateTodo = (props: any): React.ReactElement => {
	console.log("create props", props)

	return (
		<Create {...props}>
			<SimpleForm>
				<TextInput source={'name'} />
				<TextInput source={'description'} />
			</SimpleForm>
		</Create>
	)
}