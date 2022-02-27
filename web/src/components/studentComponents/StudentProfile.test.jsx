import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import StudentProfile from './StudentProfile';

const studentProfileDetails = {
  name: 'Kris Robinson',
};

test('renders student name', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Student/1`).reply(200, studentProfileDetails);
  render(<StudentProfile />);
  expect(await screen.findByText('Kris Robinson')).toBeInTheDocument();
});
