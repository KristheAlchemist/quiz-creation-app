import './App.css';
import React from 'react';
import { Route, Routes } from 'react-router';
import StudentProfile from './components/StudentComponents/StudentProfile';
import StudentList from './components/StudentComponents/StudentList';
import QuizPage from './components/QuizComponents/QuizPage';
import QuizListPage from './components/QuizComponents/QuizListPage';
import QuestionList from './components/QuizComponents/QuestionComponents/QuestionList';

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
      </header>
      <Routes>
        <Route path="/" element={<QuizListPage />} />
        <Route path="/students" element={<StudentList />} />
        <Route path="/student/:id" element={<StudentProfile />} />
        <Route path="/quizzes" element={<QuizListPage />} />
        <Route path="/quiz/:id" element={<QuizPage />} />
        <Route path="/questions" element={<QuestionList />} />
      </Routes>
    </div>
  );
}

export default App;
