import React, { useState } from 'react';
import { Controller, useForm } from 'react-hook-form';
import PropTypes from 'prop-types';

import * as yup from 'yup';
import { yupResolver } from '@hookform/resolvers/yup';
import {
  Alert,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  FormControl,
  FormGroup,
  Paper,
  TextField,
  Typography,
} from '@mui/material';

const AddQuizModal = ({ onSubmit }) => {
  const [open, setOpen] = useState(false);

  const validationSchema = yup.object().shape({
    title: yup.string()
      .trim()
      .required('Please enter a title'),
  });

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClickClose = () => {
    setOpen(false);
  };

  const onClose = () => {
    handleClickClose(true);
  };

  const {
    handleSubmit,
    control,
    formState: { errors, isSubmitting },
  } = useForm({ resolver: yupResolver(validationSchema) });

  return (
    <div>
      <Button variant="outlined" onClick={handleClickOpen}>
        Create a new quiz
      </Button>
      <Dialog
        open={open}
        onClose={onClose}
      >
        <Typography align="left">
          <Button onClick={handleClickClose}>
            Back
          </Button>
        </Typography>
        <DialogTitle variant="h4">Create a new quiz</DialogTitle>
        <DialogContent>
          {!!errors.server && <Alert severity="error">{errors.server.message}</Alert>}
          <DialogContentText>
            Add a title for your quiz here.
          </DialogContentText>
          <br />
          <Paper sx={{ p: 2 }}>
            <FormGroup>
              <Controller
                name="title"
                control={control}
                render={({
                  field: {
                    onChange,
                  },
                }) => (
                  <>
                    <FormControl>
                      <TextField
                        autoFocus
                        margin="dense"
                        id="title"
                        label="Title"
                        type="text"
                        fullWidth
                        variant="outlined"
                        onChange={onChange}
                      />
                    </FormControl>
                  </>
                )}
              />
            </FormGroup>
          </Paper>
        </DialogContent>
        <DialogActions>
          <Button
            onClick={handleSubmit(onSubmit)}
            onClose={onClose}
            disabled={isSubmitting}
          >
            Add Quiz
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

AddQuizModal.propTypes = {
  onSubmit: PropTypes.func.isRequired,
};

export default AddQuizModal;
