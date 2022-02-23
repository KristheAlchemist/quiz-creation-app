import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Button from '@mui/material/Button';

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
      <Link to="/teachers">
        <Button>
          Add Student
        </Button>
      </Link>
      <ul>
        {students.map(({ id, name }) => (
          <Link to={`/student/${id}`}><li key={id}><Button>{name}</Button></li></Link>
        ))}
      </ul>
    </>
  );
};

export default StudentList;
