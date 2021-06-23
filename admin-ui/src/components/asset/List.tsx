import React from "react"
import { List, Datagrid, TextField, EditButton, FunctionField, useRecordContext } from "react-admin"

import {
	AmplifyFileField,
	AmplifyFileInput,
	AmplifyImageField,
	AmplifyImageInput,
} from "react-admin-amplify"

export const AssetList = (props: any): React.ReactElement => {
	return (
		<List {...props}>
			<Datagrid>
				<TextField source="id" />
				<TextField source="name" />
				<TextField source="type" />
				<TextField source="fileName" />
				<TextField source="fileSize" />
				<TextField source="fileFormat" />
				{/* <AmplifyImageField source={'source'} storageOptions={{ level: 'private' }} addLabel={true} /> */}
				{/* <EditButton basePath="/assets" /> */}
			</Datagrid>
		</List>
	)
}