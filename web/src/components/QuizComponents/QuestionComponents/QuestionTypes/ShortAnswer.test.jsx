import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import ShortAnswer from './ShortAnswer';

const testDetails = {
  name: 'Kris Robinson',
  text: 'Why did the chicken cross the road?',
  choices: '',
};

test('renders short answer input', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Question`).reply(200, testDetails);
  render(<ShortAnswer />);
  expect(await screen.findByText('Please answer here:')).toBeInTheDocument();
});
