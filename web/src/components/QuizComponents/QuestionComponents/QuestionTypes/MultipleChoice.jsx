import {
  FormControl, FormControlLabel, FormLabel, Radio, RadioGroup,
} from '@mui/material';
import React from 'react';

const MultipleChoice = () => (
  <FormControl>
    <FormLabel>Please select one:</FormLabel>
    <RadioGroup row>
      <FormControlLabel value="a" control={<Radio />} label="To not get eaten" />
      <FormControlLabel value="b" control={<Radio />} label="To get to the other side" />
      <FormControlLabel value="c" control={<Radio />} label="To avoid lame and outdated jokes" />
    </RadioGroup>
  </FormControl>
);
export default MultipleChoice;
