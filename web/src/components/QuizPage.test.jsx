import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import QuizPage from './QuizPage';

const testDetails = {
  id: 1,
  title: 'Quiz 1',
  text: 'Why did the chicken cross the road?',
};

test('renders the quiz page', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Quiz`).reply(200, testDetails);
  render(<QuizPage />);
  // Is this right? Or am I giving myself a false pass?
  expect(await screen.findByText(testDetails.title)).toBeInTheDocument();
});

// // Is this redundant since it's also in Question.test.jsx?
// test('renders a question', async () => {
//   const mockApi = new MockAdapter(axios);
//   mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Question`).reply(200, testDetails);
//   render(<TestPage />);
//   // Is this right? Or am I giving myself a false positive?
//   expect(await screen.findByText(testDetails.text)).toBeInTheDocument();
// });
