import { Typography } from '@mui/material';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import AddQuestionModal from './AddQuestionModal';
import QuestionListDataGrid from './QuestionListDataGrid';

const QuestionList = () => {
  const [error, setError] = useState(null);
  const [questions, setQuestions] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Questions`);
        setQuestions(data);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the question list page.</div>;
  }

  if (loading || !questions) {
    return <h1>Loading...</h1>;
  }

  const onSubmit = async (question) => {
    const { data } = await axios.post(`${process.env.REACT_APP_BASE_API}/api/Quiz`, question);
    setQuestions([...questions, data]);
  };

  return (
    <>
      <Typography variant="h4" sx={{ marginBottom: 2 }}>Question</Typography>
      <AddQuestionModal onSubmit={onSubmit} />
      <QuestionListDataGrid
        questions={questions}
      />
    </>
  );
};

export default QuestionList;
