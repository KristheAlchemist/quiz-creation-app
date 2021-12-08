import axios from 'axios';
import React, { useEffect, useState } from 'react';

const UserProfile = () => {
  const [error, setError] = useState(null);
  const [name, setName] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/User`);
        setName(data.name);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch practice member profile.</div>;
  }

  if (loading) {
    return <h1>Loading...</h1>;
  }

  return (
    <div>
      <h2>{name}</h2>
    </div>
  );
};

export default UserProfile;
