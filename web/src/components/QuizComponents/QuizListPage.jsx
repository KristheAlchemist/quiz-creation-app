import { Typography } from '@mui/material';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import AddQuizModal from './AddQuizModal';
import QuizListDataGrid from './QuizListDataGrid';

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
    return <div>Oops! Could not fetch the quiz list page.</div>;
  }

  if (loading || !quizzes) {
    return <h1>Loading...</h1>;
  }

  const onSubmit = async (quiz) => {
    const { data } = await axios.post(`${process.env.REACT_APP_BASE_API}/api/Quiz`, quiz);
    setQuizzes([...quizzes, data]);
  };

  return (
    <>
      <Typography variant="h4" sx={{ marginBottom: 2 }}>Quizzes</Typography>
      <AddQuizModal onSubmit={onSubmit} />
      <QuizListDataGrid
        quizzes={quizzes}
      />
    </>
  );
};

export default QuizList;
