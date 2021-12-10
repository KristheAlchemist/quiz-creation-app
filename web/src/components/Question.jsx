import axios from 'axios';
import React, { useEffect, useState /* useForm */ } from 'react';

const Question = () => {
  const [error, setError] = useState(null);
  const [text, setText] = useState('');
  const [loading, setLoading] = useState(false);
  //   const { register, handleSubmit } = useForm();

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Question`);
        setText(data.text);
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
      <form>
        <h1>{text}</h1>
        <label>
          <input type="submit" />
        </label>
      </form>
    </div>
  );
};

export default Question;
