import React from 'react';
import PropTypes from 'prop-types';
import { DataGrid } from '@mui/x-data-grid';
import {
  Avatar,
  Link, Paper,
} from '@mui/material';

const StudentDataGrid = ({ students }) => {
  const columns = [
    {
      field: 'name',
      headerName: 'Name',
      width: 1800,
      renderCell: ({ row: { id, name } }) => (
        <>
          <Avatar sx={{ width: 24, height: 24, mr: 1 }} />
          <Link href={`/student/${id}`}>
            {name}
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
    }),
  ),
};

export default StudentDataGrid;
