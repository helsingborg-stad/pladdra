import React, { useEffect, useState } from "react"
import { Create, TextInput, SimpleForm, FormDataConsumer } from "react-admin"
import {

	AmplifyFileField,
	AmplifyFileInput,
	AmplifyImageField,
	AmplifyImageInput,
} from "react-admin-amplify"


import { Storage } from "@aws-amplify/storage"
import { AssetFileFormat, AssetType } from "../../API"

const capitalize = (s: string) => (s && s[0].toUpperCase() + s.slice(1)) || ''

export const CreateAsset = (props: any): React.ReactElement => {
	const [ initialName, setInitialName ] = useState<string | null>(null)
	const [ fileName, setFileName ] = useState<string | null>(null)
	const [ fileSize, setFileSize ] = useState<number | null>(null)
	const [ assetType, setAssetType ] = useState<AssetType | null>(AssetType.MESH)
	const [ fileFormat, setFileFormat ] = useState<AssetFileFormat | null>(null)

	const handleDropFile = ([file]: [any]) => {
		const { path, name, size } = file

		const formatRegArr = (/[.]/.exec(path)) ? /[^.]+$/.exec(path) ?? [] : []
		const fileExstension = formatRegArr[0] ?? null

		setInitialName(capitalize(name.replace(`.${fileExstension}`, '')))
		setFileName(name)
		setFileSize(size)
		setFileFormat(AssetFileFormat[fileExstension.toUpperCase() as keyof typeof AssetFileFormat])
	}

	return (
		<Create {...props}>
			<SimpleForm>
				<FormDataConsumer>
					{({ formData, ...rest }) => (
						<>
							{formData.file && (
								<>
									<TextInput source="type" fullWidth initialValue={assetType} disabled />
									<TextInput source="name" initialValue={initialName ?? ''} fullWidth />

									{fileName && (
										<TextInput source="fileName" initialValue={fileName} disabled fullWidth />
									)}
																		
									{fileFormat && (
										<TextInput source="fileFormat" initialValue={fileFormat} disabled fullWidth />
									)}
									
									{fileSize && (
										<TextInput source="fileSize" initialValue={fileSize} disabled fullWidth />
									)}

								</>
							)}
							
							{
								!formData.file && (
									<AmplifyFileInput
										source={'file'}
										options={{
											onDrop: handleDropFile,
										}}
										accept=".glb, .gltf, .fbx, .obj, .dwg"
										storageOptions={{
											level: 'private',
										}}
									/>
								)
							}

							

						</>
					)}
				</FormDataConsumer>
			</SimpleForm>
		</Create>
	)
}