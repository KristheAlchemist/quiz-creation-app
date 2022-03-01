import React from 'react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import { MemoryRouter, Route, Routes } from 'react-router';
import { render, screen } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import QuizListPage from './QuizListPage';

const testQuizzes = [{
  id: 1,
  title: 'Quiz 1',
  text: 'Why did the chicken cross the road?',
}];

const renderWithRoutes = () => render(
  <MemoryRouter initialEntries={['']}>
    <Routes>
      <Route exact path="/quiz/1" element="Quiz 1" />
      <Route exact path="/quiz/2" element="Quiz 2" />
      <Route exact path="/quiz/3" element="Quiz 3" />
      <Route path="*" element={<QuizListPage />} />
    </Routes>
  </MemoryRouter>,
);

describe('when quiz list is rendered', () => {
  beforeEach(async () => {
    const mockApi = new MockAdapter(axios);
    mockApi.onGet(`${process.env.REACT_APP_BASE_API}/api/Quizzes`).reply(200, testQuizzes);
    renderWithRoutes();

    expect(await screen.findByText(testQuizzes[0].title)).toBeInTheDocument();

    test('renders the quiz list', async () => {
      renderWithRoutes(
        <BrowserRouter>
          <QuizListPage />
        </BrowserRouter>,
      );
      expect(await screen.findByText(testQuizzes.title)).toBeInTheDocument();
    });
  });
});
