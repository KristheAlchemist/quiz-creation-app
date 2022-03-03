import React from 'react';
import PropTypes from 'prop-types';
import Paper from '@mui/material/Paper';

import QuestionType from './QuestionType';

const Question = ({ text, questionType }) => (

  <>
    <div>
      <Paper
        elevation={5}
        sx={{
          width: 800,
          height: 200,
        }}
      >
        <h1>{text}</h1>
        <QuestionType questionType={questionType} />
      </Paper>
    </div>
  </>
);

Question.propTypes = {
  text: PropTypes.string.isRequired,
  questionType: PropTypes.isRequired,
  key: PropTypes.isRequired,
}.isRequired;

export default Question;
