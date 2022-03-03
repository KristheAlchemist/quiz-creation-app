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

const InsertQuestionModal = ({ onSubmit }) => {
  const [open, setOpen] = useState(false);

  const validationSchema = yup.object().shape({
    text: yup.string()
      .trim()
      .required('Please enter the question text'),
    // questionType: yup.number()
    //   .required('Please enter the question type'),
    correctAnswer: yup.string()
      .trim()
      .required('Please enter an answer'),
  });

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClickClose = () => {
    setOpen(false);
  };

  const {
    handleSubmit,
    control,
    // setValue,
    formState: { errors, isSubmitting },
  } = useForm({ resolver: yupResolver(validationSchema) });

  return (
    <>
      <Button variant="outlined" onClick={handleClickOpen}>
        Insert questions
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
        <DialogTitle variant="h4">Add questions</DialogTitle>
        <DialogContent>
          {!!errors.server && <Alert severity="error">{errors.server.message}</Alert>}
          <DialogContentText>
            Pick a quiz here.
          </DialogContentText>
          <br />
          <Paper sx={{ p: 2 }}>
            <FormGroup>
              <Controller
                name="text"
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
                        id="text"
                        label="Quiz"
                        type="text"
                        fullWidth
                        variant="outlined"
                        onChange={onChange}
                      />
                      {' '}
                    </FormControl>
                  </>
                )}
              />
              <br />
            </FormGroup>
          </Paper>
        </DialogContent>
        <DialogActions>
          <Button
            onClick={handleSubmit(onSubmit)}
            onClose={handleClickClose}
            disabled={isSubmitting}
          >
            Add Questions
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

InsertQuestionModal.propTypes = {
  onSubmit: PropTypes.func.isRequired,
};

export default InsertQuestionModal;
