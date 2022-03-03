import {
  Button,
  Dialog,
  FormGroup, Paper, Typography,
} from '@mui/material';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
// import { Controller } from 'react-hook-form';
import Question from './QuestionComponents/Question';

const QuizPage = () => {
  const [error, setError] = useState(null);
  const [quiz, setQuiz] = useState(null);
  const [open, setOpen] = useState(false);
  const [loading, setLoading] = useState(false);
  const { id } = useParams();

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Quiz/${id}`);
        setQuiz(data);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the quiz page.</div>;
  }

  if (loading || !quiz) {
    return <h1>Loading...</h1>;
  }

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClickClose = () => {
    setOpen(false);
  };

  // const {
  //   handleSubmit,
  //   control,
  //   setValue,
  //   formState: { errors, isSubmitting },
  // } = useForm({ resolver: yupResolver(validationSchema) });

  return (
    <>
      <div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <Button variant="outlined" onClick={handleClickOpen}>
          Start
        </Button>
      </div>
      <Dialog
        open={open}
        onClose={handleClickClose}
      >
        <Typography align="left">
          <Button href="/quizzes">
            Back
          </Button>
        </Typography>
        <FormGroup>
          <Typography variant="h4">{quiz.title}</Typography>
          <Paper sx={{ p: 2, minHeight: 700 }}>
            <FormGroup>
              {quiz.questions.map(({
                text, questionType, id: questionId,
              }) => (
                <FormGroup>
                  <Question
                    text={text}
                    questionType={questionType}
                    key={questionId}
                  />
                </FormGroup>
              ))}
            </FormGroup>
            <Button variant="contained" color="inherit">
              Submit
            </Button>
          </Paper>
        </FormGroup>
      </Dialog>
    </>
  );
};

export default QuizPage;
