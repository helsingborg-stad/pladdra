import React from "react"
import { Edit, SimpleForm, TextInput } from "react-admin"

export const EditTodo = (props: any): React.ReactElement => {
	return (
		<Edit {...props}>
			<SimpleForm>
				<TextInput source={'name'} />
				<TextInput source={'description'} />
			</SimpleForm>
		</Edit>
	)
}
