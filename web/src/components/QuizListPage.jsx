import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

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
    <ul>
      {quizzes.map(({ id, title }) => (
        <Link to={`/quiz/${id}`}><li key={id}>{title}</li></Link>
      ))}

    </ul>
  );
};

export default QuizList;
