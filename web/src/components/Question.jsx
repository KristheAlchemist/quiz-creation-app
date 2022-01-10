import axios from 'axios';
import React, { useEffect, useState } from 'react';
import MultipleChoice from './QuestionTypes/MultipleChoice';
import ShortAnswer from './QuestionTypes/ShortAnswer';
import TrueFalse from './QuestionTypes/TrueFalse';

const Question = () => {
  const [error, setError] = useState(null);
  const [text, setText] = useState('');
  const [questionType, setQuestionType] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Question`);
        setText(data.text);
        setQuestionType(data.questionType);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the question.</div>;
  }

  if (loading) {
    return <h1>Loading...</h1>;
  }

  if (questionType === 'MultipleChoice') {
    return (
      <div>
        <h1>{text}</h1>
        <MultipleChoice />
      </div>
    );
  }
  if (questionType === 'TrueFalse') {
    return (
      <div>
        <h1>{text}</h1>
        <TrueFalse />
      </div>
    );
  }
  return (
    <div>
      <h1>{text}</h1>
      <ShortAnswer />
    </div>
  );
};

export default Question;
