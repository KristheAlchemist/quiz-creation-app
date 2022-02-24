import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Button from '@mui/material/Button';
import { Typography } from '@mui/material';
import AddStudent from '../studentComponents/AddStudent';
import TeacherDataGrid from './TeacherDataGrid';

const TeacherList = () => {
  const [error, setError] = useState(null);
  const [teachers, setTeachers] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Teachers`);
        setTeachers(data);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch practice member list.</div>;
  }

  if (loading || !teachers) {
    return <h1>Loading...</h1>;
  }

  return (
    <>
      <Typography variant="h4" sx={{ marginBottom: 2 }}>Teachers</Typography>
      <Link to={AddStudent}>
        <Button>
          Add Teacher
        </Button>
      </Link>
      <TeacherDataGrid
        teachers={teachers}
      />
    </>
  );
};

export default TeacherList;
