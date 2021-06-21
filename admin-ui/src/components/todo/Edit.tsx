import React from "react"
import { Edit, SimpleForm, TextInput } from "react-admin"
import {
	AmplifyFileField,
	AmplifyFileInput,
	AmplifyImageField,
	AmplifyImageInput,
} from "react-admin-amplify"

export const EditTodo = (props: any): React.ReactElement => {
	console.log(props)
	return (
		<Edit
			{...props}
			transform={(data) => {
				console.log("🚀 ~ file: Edit.tsx ~ line 15 ~ data", data)
				const { owner, ...rest } = data
				return rest
			}}
			onFailure={(e) => {
				console.log(e)
			}}
		>
			<SimpleForm>
				<TextInput source={'id'} disabled />
				<TextInput source={'name'} />
				<TextInput source={'description'} />
				{/* <AmplifyImageInput
					source={'file'}
					accept="image/png"
					options={{
						onDropAccepted: (files: any, event: any) => {
							console.log(files)
							console.log(event)
						},
					}}
				/> */}
			</SimpleForm>
		</Edit>
	)
}
