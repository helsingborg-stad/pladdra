import React from "react"
import { Edit, SimpleForm, TextInput } from "react-admin"

export const EditTodo = (props: any): React.ReactElement => {
	return (
		<Edit 
			{...props}
			transform={(data) => {
				const { owner, ...rest } = data
				return rest
			}}
		>
			<SimpleForm>
				<TextInput source={'id'} disabled />
				<TextInput source={'name'} />
				<TextInput source={'description'} />
			</SimpleForm>
		</Edit>
	)
}
