import { Typography } from '@mui/material';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import QuizDataGrid from './QuizDataGrid';

const QuizList = () => {
  const [error, setError] = useState(null);
  const [quizzes, setQuizzes] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Quizzes`);
        setQuizzes(data);
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

  if (loading || !quizzes) {
    return <h1>Loading...</h1>;
  }

  return (
    <>
      <Typography variant="h4" sx={{ marginBottom: 2 }}>Quizzes</Typography>
      <QuizDataGrid
        quizzes={quizzes}
      />
    </>
  );
};

export default QuizList;
