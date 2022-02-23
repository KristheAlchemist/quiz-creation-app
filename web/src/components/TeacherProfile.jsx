import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';

const TeacherProfile = () => {
  const [error, setError] = useState(null);
  const [teacher, setTeacher] = useState(null);
  const [loading, setLoading] = useState(false);
  const { id } = useParams();

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Teacher/${id}`);
        setTeacher(data);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch teacher profile.</div>;
  }

  if (loading || !teacher) {
    return <h1>Loading...</h1>;
  }

  return (
    <div>
      <h2>{teacher.name}</h2>
    </div>
  );
};

export default TeacherProfile;
