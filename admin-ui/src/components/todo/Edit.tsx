import React from "react"
import { Edit, SimpleForm, TextInput, useResourceContext } from "react-admin"
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
				const { owner, image, ...rest } = data 
				
				if (image) {
					const keysToIgnore = ['_url']
					return {
						...rest,
						image: {
							...Object.entries(image).reduce((acc, [ key, value ]) => (!keysToIgnore.includes(key) ? {[key]:value, ...acc} : acc), {}),
						},
					}
				}

				return { ...rest }
			}}
			onFailure={(e) => {
				console.log(e)
			}}
		>
			<SimpleForm>
				<TextInput source={'id'} disabled />
				<TextInput source={'description'} />
				<TextInput source={'name'} />
				<AmplifyImageInput
					source={'image'}
					accept="image/png"
					storageOptions={{ level: 'protected' }}
				/>
			</SimpleForm>
		</Edit>
	)
}
