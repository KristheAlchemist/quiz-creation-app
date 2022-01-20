import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';

const UserProfile = () => {
  const [error, setError] = useState(null);
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(false);
  const { id } = useParams();

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/User/${id}`);
        setUser(data);
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

  if (loading || !user) {
    return <h1>Loading...</h1>;
  }

  return (
    <div>
      <h2>{user.name}</h2>
    </div>
  );
};

export default UserProfile;
