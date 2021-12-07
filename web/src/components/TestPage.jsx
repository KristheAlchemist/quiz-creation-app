import axios from 'axios';
import React, { useEffect, useState } from 'react';

const TestPage = () => {
  const [error, setError] = useState(null);
  const [title, setTitle] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Test`);
        setTitle(data.title);
      } catch (err) {
        setError(err);
      }
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the test page.</div>;
  }

  return (
    <div>
      <h2>{title}</h2>
    </div>
  );
};

export default TestPage;
