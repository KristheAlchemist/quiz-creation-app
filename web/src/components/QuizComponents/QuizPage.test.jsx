import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import QuizPage from './QuizPage';

const id = 1;

const testDetails = {
  id,
  title: 'Quiz 1',
};

jest.mock('react-router', () => ({
  ...jest.requireActual('react-router'),
  useParams: () => ({
    id,
  }),
}));

test('renders the quiz page', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Quiz/${id}`).reply(200, testDetails);
  render(
    <BrowserRouter>
      <QuizPage />
    </BrowserRouter>,
  );
  expect(await screen.findByText(testDetails.title)).toBeInTheDocument();
});

// test('renders a question', async () => {
//   const mockApi = new MockAdapter(axios);
//   mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Quiz`).reply(200, testDetails);
//   mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Question`).reply(200, testDetails);
//   render(<QuizPage />);
//   expect(await screen.findByText(testDetails.text)).toBeInTheDocument();
// });
