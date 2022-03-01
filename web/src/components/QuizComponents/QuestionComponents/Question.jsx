import React from 'react';
import PropTypes from 'prop-types';
import Paper from '@mui/material/Paper';
import MultipleChoice from './QuestionTypes/MultipleChoice';
import ShortAnswer from './QuestionTypes/ShortAnswer';
import TrueFalse from './QuestionTypes/TrueFalse';

const Question = ({ text, questionType }) => {
  if (questionType === 2) {
    return (
      <div>
        <Paper
          elevation={7}
          sx={{
            width: 900,
            height: 200,
          }}
        >
          <h1>{text}</h1>
          <MultipleChoice />
        </Paper>
      </div>
    );
  }
  if (questionType === 1) {
    return (
      <div>
        <Paper
          elevation={7}
          sx={{
            width: 900,
            height: 200,
          }}
        >
          <h1>{text}</h1>
          <TrueFalse />
        </Paper>
      </div>
    );
  }
  return (
    <div>
      <Paper
        elevation={7}
        sx={{
          width: 900,
          height: 200,
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
