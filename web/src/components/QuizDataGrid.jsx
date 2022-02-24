import React from 'react';
import PropTypes from 'prop-types';
import { DataGrid } from '@mui/x-data-grid';
import {
  Link, Paper,
} from '@mui/material';

const QuizDataGrid = ({ quizzes }) => {
  const columns = [
    {
      field: 'title',
      headerName: 'Title',
      width: 1800,
      renderCell: ({ row: { id, title } }) => (
        <>
          <Link href={`/quiz/${id}`}>
            {title}
          </Link>
        </>
      ),
    },
  ];

  return (
    <>
      <Paper sx={{ height: 900 }}>
        <DataGrid
          rows={quizzes}
          columns={columns}
        />
      </Paper>
    </>
  );
};

QuizDataGrid.defaultProps = {
  quizzes: [],
};

QuizDataGrid.propTypes = {
  quizzes: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      title: PropTypes.string,
    }),
  ),
};

export default QuizDataGrid;
