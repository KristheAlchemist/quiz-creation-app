import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

const UserList = () => {
  const [error, setError] = useState(null);
  const [users, setUsers] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Users`);
        setUsers(data);
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

  if (loading || !users) {
    return <h1>Loading...</h1>;
  }

  return (
    <ul>
      {users.map(({ id, name }) => (
        <Link to={`/user/${id}`}><li key={id}>{name}</li></Link>
      ))}
    </ul>
  );
};

export default UserList;
