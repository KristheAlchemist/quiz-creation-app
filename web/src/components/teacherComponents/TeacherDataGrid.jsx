import React from 'react';
import PropTypes from 'prop-types';
import { DataGrid } from '@mui/x-data-grid';
import {
  Avatar,
  Link, Paper,
} from '@mui/material';

const TeacherDataGrid = ({ teachers }) => {
  const columns = [
    {
      field: 'name',
      headerName: 'Name',
      width: 1800,
      renderCell: ({ row: { id, name } }) => (
        <>
          <Avatar sx={{ width: 24, height: 24, mr: 1 }} />
          <Link href={`/teacher/${id}`}>
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
          rows={teachers}
          columns={columns}
        />
      </Paper>
    </>
  );
};

TeacherDataGrid.defaultProps = {
  teachers: [],
};

TeacherDataGrid.propTypes = {
  teachers: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      name: PropTypes.string,
    }),
  ),
};

export default TeacherDataGrid;
