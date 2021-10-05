/* eslint-disable react/jsx-props-no-spreading */
import React, { useState } from "react";
import {
  Create,
  TextInput,
  NumberInput,
  SimpleForm,
  FormDataConsumer,
  TextInputProps,
  InputProps,
  Labeled,
} from "react-admin";
import {
  Box,
  TextareaAutosize,
  TextareaAutosizeProps,
  Typography,
  Grid,
} from "@material-ui/core";
import { AmplifyFileInput } from "react-admin-amplify";
import { Dialogue, DialogueStatus, InventoryLimit } from "@app/API";

// type Props = InputProps<TextareaAutosizeProps> &
//     Omit<TextareaAutosizeProps, 'label' | 'helperText'>;

// const BoundedTextField = ({ name, label } : Props ) => {
//   const {
//       input: { onChange },
//       meta: { touched, error }
//   } = useField(name);
//   return (
//       <TextareaAutosize
//           name={name}
//           label={label}
//           onChange={onChange}
//           error={!!(touched && error)}
//           helperText={touched && error}
//       />
//   );
// };
export const CreateDialogue = (
  props: Record<string, any>
): React.ReactElement => {
  console.log("");
  const transform = (data: any) => ({
    ...data,
    status: DialogueStatus.DRAFT,
    usersCanWrite: [],
    usersCanAccess: [],
    groupsCanWrite: [],
    groupsCanAccess: [],
    plannerArgs: {
      workspace: {
        initialScale: 30,
        minScale: 10,
        maxScale: 100,
        pinchToScale: false,
        ...data.plannerArgs.workspace,
      },
      block: {
        collision: false,
      },
      inventory: {
        categories: false,
        limitBy: InventoryLimit.NO_LIMIT,
        limitValue: null,
      },
    },
  });
  return (
    <Create {...props} transform={transform}>
      <SimpleForm>
        <FormDataConsumer>
          {({ formData }) => (
            <>
              <Box maxWidth="600px">
                <Grid container spacing={0}>
                  <Grid item xs={12}>
                    <TextInput
                      source="name"
                      variant="standard"
                      margin="none"
                      fullWidth
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <TextInput
                      source="description"
                      variant="standard"
                      margin="none"
                      fullWidth
                      multiline
                      rows={4}
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <Typography variant="subtitle1">Arbetsyta</Typography>
                  </Grid>
                  <Grid item xs={12}>
                    <Box maxWidth="300px">
                      <Typography variant="subtitle2">
                        Dimensioner (m)
                      </Typography>
                      <Grid container spacing={4}>
                        <Grid item xs={6}>
                          <NumberInput
                            fullWidth
                            min={1}
                            max={100}
                            variant="outlined"
                            label="X (m)"
                            source="plannerArgs.workspace.dimensions.x"
                          />
                        </Grid>

                        <Grid item xs={6}>
                          <NumberInput
                            fullWidth
                            min={1}
                            max={100}
                            label="Y (m)"
                            variant="outlined"
                            source="plannerArgs.workspace.dimensions.y"
                          />
                        </Grid>
                      </Grid>
                    </Box>
                  </Grid>
                  <Grid item xs={12}>
                    <Box maxWidth="900px">
                      <Typography variant="subtitle2">Skalning</Typography>
                      <Grid container spacing={6}>
                        <Grid item xs={3}>
                          <NumberInput
                            fullWidth
                            min={1}
                            max={100}
                            variant="outlined"
                            label="Start (%)"
                            source="plannerArgs.workspace.initialScale"
                          />
                        </Grid>

                        <Grid item xs={3}>
                          <NumberInput
                            fullWidth
                            min={1}
                            max={99}
                            label="Min (%)"
                            variant="outlined"
                            source="plannerArgs.workspace.minScale"
                          />
                        </Grid>
                        <Grid item xs={3}>
                          <NumberInput
                            fullWidth
                            min={100}
                            max={400}
                            label="Max (%)"
                            variant="outlined"
                            source="plannerArgs.workspace.maxScale"
                          />
                        </Grid>
                      </Grid>
                    </Box>
                  </Grid>
                </Grid>
              </Box>
            </>
          )}
        </FormDataConsumer>
      </SimpleForm>
    </Create>
  );
};

export default { CreateDialogue };
