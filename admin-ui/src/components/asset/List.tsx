import React from "react"
import { List, Datagrid, TextField, EditButton, FunctionField, useRecordContext } from "react-admin"

import {
	AmplifyFileField,
	AmplifyFileInput,
	AmplifyImageField,
	AmplifyImageInput,
} from "react-admin-amplify"
import { bytesToHumanReadable } from "../../utils/File"

const FileSizeField = ({source, ...rest}: any): React.ReactElement => <FunctionField 
	label={source}
	render={(record: any) => record[source] && Number.isInteger(record[source]) 
		? bytesToHumanReadable(record[source], {}) 
		: null
	}
	{...rest}
/>

export const AssetList = (props: any): React.ReactElement => {
	return (
		<List {...props}>
			<Datagrid>
				<TextField source="id" />
				<TextField source="name" />
				<TextField source="type" />
				<TextField source="fileName" />
				<FileSizeField source="fileSize" />
				<TextField source="fileFormat" />
				<EditButton basePath="/assets" />
			</Datagrid>
		</List>
	)
}