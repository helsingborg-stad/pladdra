import React from "react"
import { Create, TextInput, SimpleForm } from "react-admin"
import {
	AmplifyFileField,
	AmplifyFileInput,
	AmplifyImageField,
	AmplifyImageInput,
} from "react-admin-amplify"


export const CreateTodo = (props: any): React.ReactElement => {
	console.log("create props", props)

	return (
		<Create {...props}>
			<SimpleForm>
				<TextInput source={'name'} />
				<TextInput source={'description'} />
				<AmplifyImageInput
					source={'image'}
					accept="image/png"
					storageOptions={{level: 'protected'}}
					// options={{
					// 	onDropAccepted: (files: any, event: any) => {
					// 		console.log(files)
					// 		console.log(event)
					// 	},
					// }}
				/>
			</SimpleForm>
		</Create>
	)
}