import React from 'react';
import ReactDOM from 'react-dom';

function getLabelText() {
  return 'Enter your name: ';
}

const App = () => {
  // const style = { backgroundColor: 'blue', color: 'white' };
  // style={style} => is possible to use like this in component

  let buttonText = 'Click Me!';
  buttonText = 123456;
  buttonText = ['Hi', 'There'];
  buttonText = [20, 10];
  buttonText = { text: 'Click Me!' };

  return (
    <div>
      {/* <label className="label" for="name">{getLabelText()}</label> */}
      <label className="label" htmlFor="name">{getLabelText()}</label>
      <input id="name" type="text" />
      <button style={{ backgroundColor: 'blue', color: 'white' }}>{buttonText.text}</button>
    </div>
  );
}

ReactDOM.render(<App />, document.getElementById('root'));
