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

const AddStudentModal = ({ onSubmit }) => {
  const [open, setOpen] = useState(false);

  const validationSchema = yup.object().shape({
    name: yup.string()
      .trim()
      .required('Please enter the full name'),
    email: yup.string()
      .trim()
      .required('Please enter the e-mail address'),
  });

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClickClose = () => {
    setOpen(false);
  };

  // const onClose = () => {
  //   handleClickClose();
  // };

  const {
    handleSubmit,
    control,
    formState: { errors, isSubmitting },
  } = useForm({ resolver: yupResolver(validationSchema) });

  return (
    <div>
      <Button variant="outlined" onClick={handleClickOpen}>
        Add a student
      </Button>
      <Dialog
        open={open}
        onClose={handleClickClose}
      >
        <Typography align="left">
          <Button onClick={handleClickClose}>
            Back
          </Button>
        </Typography>
        <DialogTitle variant="h4">Enroll New Student</DialogTitle>
        <DialogContent>
          {!!errors.server && <Alert severity="error">{errors.server.message}</Alert>}
          <DialogContentText>
            Add new student info here.
          </DialogContentText>
          <br />
          <Typography variant="h7">Personal Information</Typography>
          <Paper sx={{ p: 2 }}>
            <FormGroup>
              <Controller
                name="name"
                control={control}
                render={({
                  field: {
                    onChange, value,
                  },
                }) => (
                  <>
                    <FormControl>
                      <TextField
                        autoFocus
                        margin="dense"
                        id="name"
                        label="Name"
                        type="text"
                        fullWidth
                        variant="outlined"
                        value={value}
                        onChange={onChange}
                      />
                      {' '}

                    </FormControl>
                  </>
                )}
              />
              <br />
              <Controller
                name="email"
                control={control}
                render={({
                  field: {
                    onChange, value,
                  },
                }) => (
                  <>
                    <FormControl>
                      <TextField
                        autoFocus
                        margin="dense"
                        id="email"
                        label="Email"
                        type="email"
                        fullWidth
                        variant="outlined"
                        value={value}
                        onChange={onChange}
                      />
                      {' '}

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
            onClose={handleClickClose}
            disabled={isSubmitting}
          >
            Add Student

          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

AddStudentModal.propTypes = {
  onSubmit: PropTypes.func.isRequired,
};

export default AddStudentModal;
