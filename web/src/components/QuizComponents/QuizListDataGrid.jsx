import React from 'react';
import PropTypes from 'prop-types';
import { DataGrid } from '@mui/x-data-grid';
import {
  Card,
  Link, Paper,
} from '@mui/material';

const QuizListDataGrid = ({ quizzes }) => {
  const columns = [
    {
      field: 'title',
      headerName: 'Title',
      width: 1800,
      renderCell: ({ row: { id, title } }) => (
        <>
          <Link href={`/quiz/${id}`}>
            <Card sx={{ minWidth: 121 }}>
              {title}
            </Card>
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

QuizListDataGrid.defaultProps = {
  quizzes: [],
};

QuizListDataGrid.propTypes = {
  quizzes: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      title: PropTypes.string,
    }),
  ),
};

export default QuizListDataGrid;
