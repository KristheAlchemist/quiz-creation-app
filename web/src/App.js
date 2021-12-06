import logo from './logo.svg';
import './App.css';
import React from 'react';

import { Route, Routes } from 'react-router';
import UserProfile from './components/UserProfile'

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Quiz Creation App
        </p>
      </header>
      {/* <Routes>
        <Route path="/" element={<UserProfile />} />
        <Route path="/profile" element={<UserProfile />} />
      </Routes> */}
    </div>
  );
}

export default App;
