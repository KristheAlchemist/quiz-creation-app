import React from 'react';
import PropTypes from 'prop-types';
import ShortAnswer from './QuestionTypes/ShortAnswer';
import TrueFalse from './QuestionTypes/TrueFalse';
import MultipleChoice from './QuestionTypes/MultipleChoice';

const QuestionType = ({ questionType, choices }) => {
  if (questionType === 2) {
    return (<MultipleChoice choices={choices} />);
  }
  if (questionType === 1) {
    return (<TrueFalse />);
  }
  return (<ShortAnswer />);
};

QuestionType.propTypes = {
  questionType: PropTypes.isRequired,
  choices: PropTypes.isRequired,
  key: PropTypes.isRequired,
}.isRequired;

export default QuestionType;
