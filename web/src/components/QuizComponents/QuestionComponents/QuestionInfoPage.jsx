import { Button, Typography } from '@mui/material';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';

const QuestionInfoPage = () => {
  const [error, setError] = useState(null);
  const [question, setQuestion] = useState(null);
  const [loading, setLoading] = useState(false);
  const { id } = useParams();

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Question/${id}`);
        setQuestion(data);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch student profile.</div>;
  }

  if (loading || !question) {
    return <h1>Loading...</h1>;
  }

  return (
    <div>
      <Typography align="left">
        <Button href="/questions">
          Back
        </Button>
      </Typography>
      <Typography variant="h4">
        <br />
        Question Text:
        <br />
        {question.text}
        <br />
        <br />
        Correct Answer:
        <br />
        {question.correctAnswer}
        <br />
        <br />
        Question Type:
        <br />
        {question.questionType}
      </Typography>
    </div>
  );
};

export default QuestionInfoPage;
