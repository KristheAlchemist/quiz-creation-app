import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { render, screen } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import QuizListPage from './QuizListPage';

const testDetails = {
  id: 1,
  title: 'Quiz 1',
  text: 'Why did the chicken cross the road?',
};

test('renders the quiz list', async () => {
  const mockApi = new MockAdapter(axios);
  mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Quizzes`).reply(200, testDetails);
  render(
    <BrowserRouter>
      <QuizListPage />
    </BrowserRouter>,
  );
  expect(await screen.findByText(testDetails.title)).toBeInTheDocument();
});
