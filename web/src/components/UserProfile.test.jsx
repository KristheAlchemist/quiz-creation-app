import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import UserProfile from './UserProfile';

const userProfileDetails = {
  name: 'Kris Robinson',
};

test('renders practice member name', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/User`).reply(200, userProfileDetails);
  render(<UserProfile />);
  expect(await screen.findByText('Kris Robinson')).toBeInTheDocument();
});
