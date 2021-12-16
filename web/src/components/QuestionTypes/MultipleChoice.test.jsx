import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import MultipleChoice from './MultipleChoice';

const testDetails = {
  title: 'Quiz 1',
  text: 'Why did the chicken cross the road?',
  choices: ['To not get eaten', 'To get to the other side', 'To avoid lame and outdated jokes'],
};

test('renders correct answer options', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Question`).reply(200, testDetails);
  render(<MultipleChoice />);
  expect(await screen
    .findByText(testDetails.choices[0] && testDetails.choices[1] && testDetails.choices[2]))
    .toBeInTheDocument();
});
