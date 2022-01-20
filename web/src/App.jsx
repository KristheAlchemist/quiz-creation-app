import './App.css';
import React from 'react';
import { Route, Routes } from 'react-router';
import UserProfile from './components/UserProfile';
import UserList from './components/UserList';
import QuizPage from './components/QuizPage';
import QuizListPage from './components/QuizListPage';
import logo from './logo.svg';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h3>
          Quiz Creation App
        </h3>
        <h4>
          <a href="/users" className="App-link">Users</a>
          |   |
          <a href="/quizzes" className="App-link">Quizzes</a>
        </h4>
      </header>
      <Routes>
        <Route path="/" element={<QuizListPage />} />
        <Route path="/users" element={<UserList />} />
        <Route path="/user/:id" element={<UserProfile />} />
        <Route path="/quizzes" element={<QuizListPage />} />
        <Route path="/quiz/:id" element={<QuizPage />} />
      </Routes>
    </div>
  );
}

export default App;
