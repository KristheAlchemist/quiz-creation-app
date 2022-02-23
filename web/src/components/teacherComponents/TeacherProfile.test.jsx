import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import TeacherProfile from './TeacherProfile';

const teacherProfileDetails = {
  name: 'Kris Robinson',
};

test('renders practice member name', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Teacher/1`).reply(200, teacherProfileDetails);
  render(<TeacherProfile />);
  expect(await screen.findByText('Kris Robinson')).toBeInTheDocument();
});
