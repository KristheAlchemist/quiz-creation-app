import { Button, Typography } from '@mui/material';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';

const StudentProfile = () => {
  const [error, setError] = useState(null);
  const [student, setStudent] = useState(null);
  const [loading, setLoading] = useState(false);
  const { id } = useParams();

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Student/${id}`);
        setStudent(data);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch student profile.</div>;
  }

  if (loading || !student) {
    return <h1>Loading...</h1>;
  }

  return (
    <div>
      <Typography align="left">
        <Button href="/students">
          Back
        </Button>
      </Typography>
      <Typography variant="h4">
        <br />
        {student.name}
        <br />
        <br />
        Email:
        {' '}
        {student.email}
      </Typography>
    </div>
  );
};

export default StudentProfile;
