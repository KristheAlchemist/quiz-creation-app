import axios from 'axios';
import React, { useEffect, useState } from 'react';
import Question from './Question';

const QuizPage = () => {
  const [error, setError] = useState(null);
  const [title, setTitle] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Quiz`);
        setTitle(data.title);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the test page.</div>;
  }

  if (loading) {
    return <h1>Loading...</h1>;
  }

  return (
    <div>
      <h1>{title}</h1>
      <Question />
    </div>

  );
};

export default QuizPage;
