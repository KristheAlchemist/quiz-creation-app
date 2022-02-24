import './App.css';
import React from 'react';
import { Route, Routes } from 'react-router';
import TeacherProfile from './components/teacherComponents/TeacherProfile';
import TeacherList from './components/teacherComponents/TeacherList';
import StudentProfile from './components/studentComponents/StudentProfile';
import StudentList from './components/studentComponents/StudentList';
import QuizPage from './components/QuizPage';
import QuizListPage from './components/QuizListPage';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h3>
          Quiz Creation App
        </h3>
        <h4>
          <a href="/teachers" className="App-link">Teachers</a>
          |   |
          <a href="/students" className="App-link">Students</a>
          |   |
          <a href="/quizzes" className="App-link">Quizzes</a>
        </h4>
      </header>
      <Routes>
        <Route path="/" element={<QuizListPage />} />
        <Route path="/teachers" element={<TeacherList />} />
        <Route path="/teacher/:id" element={<TeacherProfile />} />
        <Route path="/students" element={<StudentList />} />
        <Route path="/student/:id" element={<StudentProfile />} />
        <Route path="/quizzes" element={<QuizListPage />} />
        <Route path="/quiz/:id" element={<QuizPage />} />
      </Routes>
    </div>
  );
}

export default App;
