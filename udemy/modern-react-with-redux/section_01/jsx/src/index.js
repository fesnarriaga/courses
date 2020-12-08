// Import React and ReactDOM libraries
import React from 'react';
import ReactDOM from 'react-dom';

// Create a react component
function App() {
  return (
    <div>Hello world</div>
  );
}

const App1 = function () {
  return <div>Hello world</div>
}

const App2 = () => {
  return <div>Hello world</div>
}

// Render the component on screen
ReactDOM.render(<App />, document.getElementById('root'));
// ReactDOM.render(<App />, document.querySelector('#root'));
