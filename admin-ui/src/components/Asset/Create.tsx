/* eslint-disable react/jsx-props-no-spreading */
import React, { useEffect, useState } from "react";
import { Create, TextInput, SimpleForm, FormDataConsumer } from "react-admin";
import {
  AmplifyFileField,
  AmplifyFileInput,
  AmplifyImageField,
  AmplifyImageInput,
} from "react-admin-amplify";

import { capitalize } from "utils/string";
import {
  parseExtension,
  humanReadableToBytes,
  bytesToHumanReadable,
} from "utils/file";
import { AssetFileFormat, AssetType } from "API";

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

export const CreateAsset = (props: any): React.ReactElement => {
  const [initialName, setInitialName] = useState<string | null>(null);
  const [fileName, setFileName] = useState<string | null>(null);
  const [fileSize, setFileSize] = useState<number | null>(null);
  const [assetType, setAssetType] = useState<AssetType | null>(AssetType.MESH);
  const [fileFormat, setFileFormat] = useState<AssetFileFormat | null>(null);

  const handleDropFile = ([file]: [any], e: any) => {
    console.log("DROP IT LIKE ITS HOOOT", e);
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
    <Create {...props}>
      <SimpleForm validate={validateAssetCreation}>
        <FormDataConsumer>
          {({ formData, ...rest }) => (
            <>
              {console.log(formData)}
              {formData.file && fileSize && (
                <>
                  <TextInput
                    source="type"
                    fullWidth
                    initialValue={assetType}
                    disabled
                  />
                  <TextInput
                    source="name"
                    initialValue={initialName ?? ""}
                    fullWidth
                  />

                  <TextInput
                    source="fileName"
                    initialValue={fileName}
                    disabled
                    fullWidth
                  />

                  <TextInput
                    source="fileFormat"
                    initialValue={fileFormat}
                    disabled
                    fullWidth
                  />

                  <TextInput
                    source="fileSize"
                    initialValue={fileSize}
                    parse={humanReadableToBytes}
                    format={bytesToHumanReadable}
                    disabled
                    fullWidth
                  />
                </>
              )}

              <AmplifyFileInput
                source="file"
                onDropAccepted={handleDropFile}
                options={{
                  onDrop: handleDropFile,
                }}
                accept=".glb, .gltf, .fbx, .obj, .dwg"
                storageOptions={{
                  download: true,
                  onDropAccepted: handleDropFile,
                  level: "public",
                }}
                // validate={() => {}}
              />
            </>
          )}
        </FormDataConsumer>
      </SimpleForm>
    </Create>
  );
};

export default { CreateAsset };
