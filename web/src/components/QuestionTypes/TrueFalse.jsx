import axios from 'axios';
import React, { useEffect, useState } from 'react';

const TestPage = () => {
  const [answer, setAnswer] = useState('');
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Question`);
        setAnswer(data.answer);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the test page.</div>;
  }

  if (loading) {
    return <h1>Loading...</h1>;
  }

  return (
    <div>
      <form action="" method="post">
        <div>
          <input type="radio" id="tru" name="chicken" value="t" />
          <label htmlFor="tru">True</label>
          <input type="radio" id="fals" name="chicken" value="" />
          <label htmlFor="fals">False</label>
        </div>
        <div>
          <input type="submit" />
        </div>
      </form>
      <p>{answer}</p>
    </div>
  );
};

export default TestPage;
