import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import Question from './Question';

const testDetails = {
  title: 'Test 1',
  text: 'Why did the chicken cross the road?',
  choices: ['To not get eaten', 'To get to the other side', 'To avoid lame and outdated jokes'],
};

test('renders a question', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Question`).reply(200, testDetails);
  render(<Question />);
  expect(await screen.findByText(testDetails.text)).toBeInTheDocument();
});

test('renders answer options', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Question`).reply(200, testDetails);
  render(<Question />);
  expect(await screen
    .findByText(testDetails.choices[0] && testDetails.choices[1] && testDetails.choices[2]))
    .toBeInTheDocument();
});
