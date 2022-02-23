import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import StudentList from './StudentList';

const userProfileDetails = {
  name: 'Kris Robinson',
};

test('renders student\'s name', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Students`).reply(200, userProfileDetails);
  render(<StudentList />);
  expect(await screen.findByText('Kris Robinson')).toBeInTheDocument();
});
