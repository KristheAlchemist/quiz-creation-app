import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Typography } from '@mui/material';
import StudentListDataGrid from './StudentListDataGrid';
import AddStudentModal from './AddStudentModal';

const StudentList = () => {
  const [error, setError] = useState(null);
  const [students, setStudents] = useState(null);
  const [loading, setLoading] = useState(false);
  const [isAddModalOpen, setIsAddModalOpen] = useState(true);
  const handleOpenAddModal = () => setIsAddModalOpen(true);
  const handleCloseAddModal = () => setIsAddModalOpen(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const { data } = await axios.get(`${process.env.REACT_APP_BASE_API}/api/Students`);
        setStudents(data);
      } catch (err) {
        setError(err);
      }
      setLoading(false);
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Oops! Could not fetch the student list.</div>;
  }

  if (loading || !students) {
    return <h1>Loading...</h1>;
  }

  const onSubmit = async (student) => {
    const { data } = await axios.post(`${process.env.REACT_APP_BASE_API}/api/Student`, student);
    setStudents([...students, data]);
  };

  // make onClose method

  return (
    <>
      <Typography variant="h4" sx={{ marginBottom: 2 }}>Students</Typography>
      {isAddModalOpen && (
        <AddStudentModal
          onSubmit={onSubmit}
          onClose={handleCloseAddModal}
          handleOpenAddModal={handleOpenAddModal}
        />
      )}
      <StudentListDataGrid
        students={students}
      />
    </>
  );
};

export default StudentList;
