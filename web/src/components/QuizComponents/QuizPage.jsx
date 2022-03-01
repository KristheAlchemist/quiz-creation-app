import {
  Button,
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

  return (
    <FormGroup>
      <Typography variant="h4">{quiz.title}</Typography>
      <Paper sx={{ p: 2, minHeight: 825 }}>
        <FormGroup>
          {quiz.questions.map(({
            text, questionType, id: questionId,
          }) => (
            <Question
              text={text}
              questionType={questionType}
              key={questionId}
            />
          ))}
        </FormGroup>
        <Button variant="contained" color="inherit">
          Submit
        </Button>
      </Paper>
      {/*
      <Controller
        name="fullName"
        control={control}
        render={({ field: { onChange, value } }) => (
          <Question text={text} label="Full Name" value={value} onChange={onChange} />
        )}
      /> */}

    </FormGroup>
  );
};

export default QuizPage;
