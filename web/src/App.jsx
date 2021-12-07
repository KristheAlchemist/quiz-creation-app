import './App.css';
import React from 'react';
import { Route, Routes } from 'react-router';
import UserProfile from './components/UserProfile';
import TestPage from './components/TestPage';
import logo from './logo.svg';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h3>
          Quiz Creation App
        </h3>
      </header>
      <Routes>
        <Route path="/" element={<UserProfile />} />
        <Route path="/profile" element={<UserProfile />} />
        <Route path="/test" element={<TestPage />} />
      </Routes>
    </div>
  );
}

export default App;
