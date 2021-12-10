import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import Question from './Question';

const testDetails = {
  title: 'Test 1',
  text: 'Why did the chicken cross the road?',
};

test('renders a question', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Question`).reply(200, testDetails);
  render(<Question />);
  expect(await screen.findByText('Why did the chicken cross the road?')).toBeInTheDocument();
});
