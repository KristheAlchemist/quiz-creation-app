import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Button from '@mui/material/Button';

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
      <Link to="/teachers">
        <Button>
          Add Student
        </Button>
      </Link>
      <ul>
        {teachers.map(({ id, name }) => (
          <Link to={`/teacher/${id}`}><li key={id}><Button>{name}</Button></li></Link>
        ))}
      </ul>
    </>
  );
};

export default TeacherList;
