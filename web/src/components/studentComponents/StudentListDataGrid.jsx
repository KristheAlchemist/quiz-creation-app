import React from 'react';
import PropTypes from 'prop-types';
import { DataGrid } from '@mui/x-data-grid';
import {
  Avatar,
  // Button,
  Link, Paper, Typography,
} from '@mui/material';
// import DeleteForeverIcon from '@mui/icons-material/DeleteForever';

const StudentListDataGrid = ({ students }) => {
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
          <Typography>
            {/* <Button>
              <DeleteForeverIcon />
            </Button> */}
          </Typography>
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

StudentListDataGrid.defaultProps = {
  students: [],
};

StudentListDataGrid.propTypes = {
  students: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      name: PropTypes.string,
      email: PropTypes.string,
    }),
  ),
};

export default StudentListDataGrid;
