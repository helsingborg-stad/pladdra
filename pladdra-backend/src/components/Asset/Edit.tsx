/* eslint-disable react/jsx-props-no-spreading */
import React, { useState } from "react";
import {
  Edit,
  TextInput,
  SimpleForm,
  FormDataConsumer,
  TextField,
} from "react-admin";
import { AmplifyFileField, AmplifyFileInput } from "react-admin-amplify";

import { AssetFileFormat, AssetType } from "API";
import { parseExtension } from "utils/file";
import { capitalize } from "utils/string";

const validateAssetCreation = (values: Record<string, any>) => {
  const errors: Record<string, any> = {};
  const { file } = values;

  if (file) {
    const { bucket, region, key } = file;

    if (!bucket || !region || !key) {
      errors.file = "Wait for file upload to finish!";
    }
  }

  return errors;
};

export const EditAsset = (props: any): React.ReactElement => {
  const [initialName, setInitialName] = useState<string | null>(null);
  const [fileName, setFileName] = useState<string | null>(null);
  const [fileSize, setFileSize] = useState<number | null>(null);
  const [assetType, setAssetType] = useState<AssetType | null>(AssetType.MESH);
  const [fileFormat, setFileFormat] = useState<AssetFileFormat | null>(null);

  const handleDropFile = ([file]: [any]) => {
    const { path, name, size } = file;
    const fileExstension = parseExtension(path) ?? "";
    setInitialName(capitalize(name.replace(`.${fileExstension}`, "")));
    setFileName(name);
    setFileSize(size);
    setFileFormat(
      AssetFileFormat[
        fileExstension.toUpperCase() as keyof typeof AssetFileFormat
      ]
    );
  };

  return (
    <Edit {...props}>
      <SimpleForm validate={validateAssetCreation}>
        <TextInput variant="standard" source="name" />
        <TextField source="fileName" />
        <TextField source="id" />
        <TextField source="type" />
        <TextField source="fileFormat" />

        <AmplifyFileField
          source="file"
          // onDropAccepted={handleDropFile}
          // options={{
          //   onDrop: handleDropFile,
          // }}
          // accept=".glb, .gltf, .fbx, .obj, .dwg"
          // storageOptions={{
          //   download: true,
          //   onDropAccepted: handleDropFile,
          //   level: "public",
          // }}
          // validate={() => {}}
        />
      </SimpleForm>
    </Edit>
  );
};

export default { EditAsset };
