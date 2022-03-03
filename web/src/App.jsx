import './App.css';
import React from 'react';
import { Route, Routes } from 'react-router';
import { Typography } from '@mui/material';
import StudentProfile from './components/StudentComponents/StudentProfile';
import StudentList from './components/StudentComponents/StudentList';
import QuizPage from './components/QuizComponents/QuizPage';
import QuizListPage from './components/QuizComponents/QuizListPage';
import QuestionList from './components/QuizComponents/QuestionComponents/QuestionList';
import QuestionInfoPage from './components/QuizComponents/QuestionComponents/QuestionInfoPage';
import QuizAdminPage from './components/QuizComponents/QuizAdminPage';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h3>
          Quiz Creation App
        </h3>
        <h4>
          <a href="/students" className="App-link">Students</a>
          |   |
          <a href="/quizzes" className="App-link">Quizzes</a>
        </h4>
        <Typography align="right" variant="string">
          <a href="/quizzesadmin" className="App-link">Admin</a>
        </Typography>
      </header>
      <Routes>
        <Route path="/" element={<QuizAdminPage />} />
        <Route path="/students" element={<StudentList />} />
        <Route path="/student/:id" element={<StudentProfile />} />
        <Route path="/quizzes" element={<QuizListPage />} />
        <Route path="/quiz/:id" element={<QuizPage />} />
        <Route path="/questions" element={<QuestionList />} />
        <Route path="/question/:id" element={<QuestionInfoPage />} />
        <Route path="/quizzesadmin" element={<QuizAdminPage />} />
      </Routes>
    </div>
  );
}

export default App;
