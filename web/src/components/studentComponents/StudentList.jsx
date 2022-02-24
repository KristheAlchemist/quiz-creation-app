import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Button from '@mui/material/Button';
import { Typography } from '@mui/material';
import AddStudent from './AddStudent';
import StudentDataGrid from './StudentDataGrid';

const StudentList = () => {
  const [error, setError] = useState(null);
  const [students, setStudents] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Students`);
        setStudents(data);
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

  if (loading || !students) {
    return <h1>Loading...</h1>;
  }

  return (
    <>
      <Typography variant="h4" sx={{ marginBottom: 2 }}>Students</Typography>
      <Link to={AddStudent}>
        <Button>
          Add Student
        </Button>
      </Link>
      <StudentDataGrid
        students={students}
      />
    </>
  );
};

export default StudentList;
