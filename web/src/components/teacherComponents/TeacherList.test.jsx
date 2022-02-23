import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import TeacherList from './TeacherList';

const userProfileDetails = {
  name: 'Kris Robinson',
};

test('renders teacher\'s name', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Teachers`).reply(200, userProfileDetails);
  render(<TeacherList />);
  expect(await screen.findByText('Mr. Robinson')).toBeInTheDocument();
});
