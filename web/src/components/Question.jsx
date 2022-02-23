import React from 'react';
import PropTypes from 'prop-types';
import Paper from '@mui/material/Paper';
import MultipleChoice from './QuestionTypes/MultipleChoice';
import ShortAnswer from './QuestionTypes/ShortAnswer';
import TrueFalse from './QuestionTypes/TrueFalse';

const Question = ({ text, questionType }) => {
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
      <Paper
        elevation={7}
        sx={{
          width: 900,
          height: 300,
        }}
      >
        <h1>{text}</h1>
        <ShortAnswer />
      </Paper>
    </div>
  );
};

Question.propTypes = {
  text: PropTypes.string.isRequired,
  questionType: PropTypes.isRequired,
}.isRequired;

export default Question;
