import axios from 'axios';
import React, { useEffect, useState } from 'react';

const UserProfile = () => {
    const [error, setError] = useState(null);
    const [profile, setProfile] = useState({name: ''});

    useEffect(() => {
        const fetchData = async () => {
          try {
            const { data } = await axios.get(
              `${process.env.REACT_APP_BASE_API}/api/Profile`,
            );
            setProfile(data);
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
          <h2>{profile.name}</h2>
        </div>
      );
}

export default UserProfile;