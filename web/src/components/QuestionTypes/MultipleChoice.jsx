import React, { useEffect, useState } from 'react';

const MultipleChoice = () => {
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the choices.</div>;
  }

  if (loading) {
    return <h1>Loading...</h1>;
  }
  return (
    <div>
      <form action="" method="post">
        <p>Please select one:</p>
        <input type="radio" id="a" name="chicken" value="a" />
        <label htmlFor="a">To not get eaten</label>
        <input type="radio" id="b" name="chicken" value="b" />
        <label htmlFor="b">To get to the other side</label>
        <input type="radio" id="c" name="chicken" value="c" />
        <label htmlFor="c">To avoid lame and outdated jokes</label>
        <input type="submit" />
      </form>
    </div>
  );
};
export default MultipleChoice;
