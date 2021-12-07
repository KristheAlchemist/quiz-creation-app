import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import TestPage from './TestPage';

const testDetails = {
  name: 'Test 1',
};

test('renders the test page', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Test`).reply(200, testDetails);
  render(<TestPage />);
  expect(await screen.findByText('Test 1')).toBeInTheDocument();
});
