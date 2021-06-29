/* eslint-disable react/jsx-props-no-spreading */
import React from "react";
import {
  List,
  Datagrid,
  TextField,
  EditButton,
  FunctionField,
} from "react-admin";

import { bytesToHumanReadable } from "utils/file";

const FileSizeField = ({ source, ...rest }: any): React.ReactElement => (
  <FunctionField
    label={source}
    render={(record: any) =>
      record[source] && Number.isInteger(record[source])
        ? bytesToHumanReadable(record[source], {})
        : null
    }
    {...rest}
  />
);

export const AssetList = (props: any): React.ReactElement => (
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
);

export default { AssetList };
