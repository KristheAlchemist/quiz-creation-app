import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import Question from './Question';

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
    <div>
      {/* <form action="" method="post"> */}
      <form>
        <h1>{quiz.title}</h1>
        {quiz.questions.map(({
          text, questionType, id: questionId, choices,
        }) => (
          <Question
            text={text}
            questionType={questionType}
            key={questionId}
            choices={choices}
          />
        ))}
        <input type="submit" required />
      </form>
    </div>
  );
};

export default QuizPage;
