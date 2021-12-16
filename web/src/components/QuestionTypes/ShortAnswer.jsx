// import axios from 'axios';
import React, { useEffect, useState } from 'react';

const ShortAnswer = () => {
  // const [answer, setAnswer] = useState('');
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        // const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Question`);
        // setAnswer(data.answer);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the input box.</div>;
  }

  if (loading) {
    return <h1>Loading...</h1>;
  }

  return (
    <div>
      <form action="" method="post">
        <p>Please answer here:</p>
        <input type="text" />
        <input type="submit" />
      </form>
    </div>
  );
};

export default ShortAnswer;
