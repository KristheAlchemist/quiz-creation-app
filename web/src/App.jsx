import './App.css';
import React from 'react';
import { Route, Routes } from 'react-router';
import UserProfile from './components/UserProfile';
import QuizPage from './components/QuizPage';
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
          <a href="/profile" className="App-link">Profile</a>
          | |
          <a href="/quiz" className="App-link">Test Page</a>
        </h4>
      </header>
      <Routes>
        <Route path="/" element={<UserProfile />} />
        <Route path="/profile" element={<UserProfile />} />
        <Route path="/quiz" element={<QuizPage />} />
      </Routes>
    </div>
  );
}

export default App;
