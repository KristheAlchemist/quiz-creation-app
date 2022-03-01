import React, { useState } from 'react';
import { Paper } from '@mui/material';
import AddStudentModal from './AddStudentModal';

const AddStudent = () => {
  const [state, setState] = useState({
    fname: '',
    lname: '',
  });
  const handleChange = (event) => {
    setState({
      ...state,
      [event.target.name]: event.target.value,
    });
  };
  return (
    <Paper>
      <div>
        <h1>React Form Handling</h1>
        <form>
          <label>
            First Name:
            {' '}
            <input
              type="text"
              name="fname"
              value={state.fname}
              onChange={handleChange}
            />
          </label>
          <label>
            Last Name:
            {' '}
            <input
              type="text"
              name="lname"
              value={state.lname}
              onChange={handleChange}
            />
          </label>
        </form>
        <h5>
          Name:
          {' '}
          {state.fname}
          {' '}
          {state.lname}
        </h5>
        <AddStudentModal />
      </div>
    </Paper>
  );
};

export default AddStudent;
