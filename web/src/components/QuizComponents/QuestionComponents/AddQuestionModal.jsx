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
  // MenuItem,
  Paper,
  TextField,
  Typography,
} from '@mui/material';

const AddQuestionModal = ({ onSubmit }) => {
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
        Add questions
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
        <DialogTitle variant="h4">Add a new question</DialogTitle>
        <DialogContent>
          {!!errors.server && <Alert severity="error">{errors.server.message}</Alert>}
          <DialogContentText>
            Enter question info here.
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
                        label="Question Text"
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
              {/* <Controller
                name="questionType"
                control={control}
                render={({
                  field: {
                    value,
                  },
                }) => (
                  <FormControl>
                    <Select
                      id="questionType"
                      label="Question Type"
                      variant="outlined"
                      value={value}
                      select="true"
                      onChange={(e) => setValue('questionType', e.target.value, true)}
                    >
                      <MenuItem value={0}>Short Answer</MenuItem>
                      <MenuItem value={1}>True or False</MenuItem>
                      <MenuItem value={2}>Multilple Choice</MenuItem>
                    </Select>
                  </FormControl>
                )}
              />
              <br /> */}
              <Controller
                name="correctAnswer"
                control={control}
                render={({
                  field: {
                    onChange,
                  },
                }) => (
                  <>
                    <FormControl>
                      <TextField
                        margin="dense"
                        id="correctAnswer"
                        label="Correct Answer"
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
            onClose={handleClickClose}
            disabled={isSubmitting}
          >
            Add Question
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

AddQuestionModal.propTypes = {
  onSubmit: PropTypes.func.isRequired,
};

export default AddQuestionModal;
