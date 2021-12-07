import axios from 'axios';
import React, { useEffect, useState } from 'react';

const UserProfile = () => {
  const [error, setError] = useState(null);
  const [name, setName] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/User`);
        setName(data.name);
      } catch (err) {
        setError(err);
      }
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch practice member profile.</div>;
  }

  return (
    <div>
      <h2>{name}</h2>
    </div>
  );
};

export default UserProfile;
