import {
  FormControl, FormControlLabel, FormLabel, Radio, RadioGroup,
} from '@mui/material';
import React, { useEffect, useState } from 'react';

const MultipleChoice = () => {
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the choices.</div>;
  }

  if (loading) {
    return <h1>Loading...</h1>;
  }
  return (
    <FormControl>
      <FormLabel>Please select one:</FormLabel>
      <RadioGroup row>
        <FormControlLabel value="a" control={<Radio />} label="To not get eaten" />
        <FormControlLabel value="b" control={<Radio />} label="To get to the other side" />
        <FormControlLabel value="c" control={<Radio />} label="To avoid lame and outdated jokes" />
      </RadioGroup>
    </FormControl>
  );
};
export default MultipleChoice;
