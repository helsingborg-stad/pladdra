/* eslint-disable react/jsx-props-no-spreading */
import React from "react";
import {
  List,
  Datagrid,
  TextField,
  EditButton,
  FunctionField,
  NumberField,
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

export const DialogueList = (props: any): React.ReactElement => (
  <List {...props}>
    <Datagrid>
      <TextField source="id" />
      <TextField source="name" />
      <NumberField source="plannerArgs.workspace.dimensions.x" />
      <NumberField source="plannerArgs.workspace.dimensions.y" />
      <EditButton basePath="/Dialogues" />
    </Datagrid>
  </List>
);

export default { DialogueList };
