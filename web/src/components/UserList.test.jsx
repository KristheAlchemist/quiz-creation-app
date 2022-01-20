import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import UserList from './UserList';

const userProfileDetails = {
  name: 'Kris Robinson',
};

test('renders practice member name', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Users`).reply(200, userProfileDetails);
  render(<UserList />);
  expect(await screen.findByText('Kris Robinson')).toBeInTheDocument();
});
