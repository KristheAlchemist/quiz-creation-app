import React from 'react';
import PropTypes from 'prop-types';
import { DataGrid } from '@mui/x-data-grid';
import {
  // Card,
  Link, Paper, Typography,
} from '@mui/material';

const QuestionListDataGrid = ({ questions }) => {
  const columns = [
    {
      field: 'text',
      headerName: 'Text',
      width: 1800,
      renderCell: ({ row: { id, text } }) => (
        <Link href={`/question/${id}`}>
          <Typography variant="h5">
            { id }
            { '. ' }
            { text }
          </Typography>
        </Link>
      ),
    },
  ];

  return (
    <Paper sx={{ height: 900 }}>
      <DataGrid
        rows={questions}
        columns={columns}
      />
    </Paper>
  );
};

QuestionListDataGrid.defaultProps = {
  questions: [],
};

QuestionListDataGrid.propTypes = {
  questions: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      text: PropTypes.string,
    }),
  ),
};

export default QuestionListDataGrid;
