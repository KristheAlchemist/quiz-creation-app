import React from 'react';
import PropTypes from 'prop-types';
import { DataGrid } from '@mui/x-data-grid';
import {
  Avatar,
  Link, Paper, Typography,
} from '@mui/material';

const StudentDataGrid = ({ students }) => {
  const columns = [
    {
      field: 'name',
      headerName: 'Name',
      width: window.innerWidth,
      renderCell: ({ row: { id, name } }) => (
        <>
          <Avatar sx={{ width: 24, height: 24, mr: 1 }} />
          <Link href={`/student/${id}`}>
            <Typography variant="h5">
              {name}
            </Typography>
          </Link>
        </>
      ),
    },
    {
      field: 'email',
      headerName: 'Email',
      width: window.innerWidth,
      renderCell: ({ row: { id, email } }) => (
        <>
          <Link href={`/student/${id}`}>
            <Typography variant="h5">
              {email}
            </Typography>
          </Link>
        </>
      ),
    },
  ];

  return (
    <>
      <Paper sx={{ height: 900 }}>
        <DataGrid
          rows={students}
          columns={columns}
        />
      </Paper>
    </>
  );
};

StudentDataGrid.defaultProps = {
  students: [],
};

StudentDataGrid.propTypes = {
  students: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      name: PropTypes.string,
      email: PropTypes.string,
    }),
  ),
};

export default StudentDataGrid;
