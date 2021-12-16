import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import TrueFalse from './TrueFalse';

const testDetails = {
  title: 'Quiz 1',
  text: 'Luckytronics is the best!',
  choices: ['True', 'False'],
};

test('renders correct answer options', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Question`).reply(200, testDetails);
  render(<TrueFalse />);
  expect(await screen
    .findByText(testDetails.choices[0] && testDetails.choices[1]))
    .toBeInTheDocument();
});
