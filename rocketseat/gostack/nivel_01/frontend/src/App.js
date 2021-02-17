import React, { useState } from 'react';

import Header from './components/Header';

function App() {
  const [projects, setProjects] = useState(['Social media', 'Landing page']);

  function handleAddProject() {
    setProjects([...projects, `New Project ${Date.now()}`]);
  }

  return <>
    <Header title="Home Page">
      <ul>
        <li>Home</li>
        <li>Projects</li>
      </ul>
    </Header>

    <h2>Project List</h2>
    <ul>
      {projects.map((project, index) => <li key={index}>{project}</li>)}
    </ul>

    <button type="button" onClick={handleAddProject}>Add new project</button>
  </>
}

export default App;
