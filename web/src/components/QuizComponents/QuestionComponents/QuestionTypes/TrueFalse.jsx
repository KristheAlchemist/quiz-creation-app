import React from 'react';
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import FormLabel from '@mui/material/FormLabel';

const TrueFalse = () => (
  <FormControl>
    <FormLabel>Please select one:</FormLabel>
    <RadioGroup row>
      <FormControlLabel value="true" control={<Radio />} label="True" />
      <FormControlLabel value="false" control={<Radio />} label="False" />
    </RadioGroup>
  </FormControl>
);

export default TrueFalse;
