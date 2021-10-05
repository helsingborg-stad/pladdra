/* eslint-disable react/jsx-props-no-spreading */
import { Box, Grid, Typography } from "@material-ui/core";
import React, { useState } from "react";
import {
  Edit,
  TextInput,
  SimpleForm,
  FormDataConsumer,
  NumberInput,
} from "react-admin";
import { AmplifyFileInput } from "react-admin-amplify";

import { parseExtension } from "utils/file";
import { capitalize } from "utils/string";

const validateDialogueCreation = (values: Record<string, any>) => {
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

export const EditDialogue = (props: any): React.ReactElement => (
  <Edit {...props}>
    <SimpleForm validate={validateDialogueCreation}>
      <FormDataConsumer>
        {({ formData, ...rest }) => (
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
                    rows={2}
                  />
                </Grid>
                <Grid item xs={12}>
                  <Typography variant="subtitle1">Arbetsyta</Typography>
                </Grid>
                <Grid item xs={12}>
                  <Box maxWidth="300px">
                    <Typography variant="subtitle2">Dimensioner (m)</Typography>
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
  </Edit>
);

export default { EditDialogue };
