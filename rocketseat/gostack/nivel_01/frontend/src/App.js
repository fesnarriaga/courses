import React, { useState, useEffect } from 'react';

import api from './services/api';

import './App.css';

// import backgroundImage from './assets/background.jpeg';

import Header from './components/Header';

function App() {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    api.get('/projects')
      .then(response => {
        setProjects(response.data);
      });
  }, []);

  // function handleAddProject() {
  //   // setProjects([...projects, `New Project ${Date.now()}`]);

  //   api.post('/projects', {
  //     title: `New Project ${Date.now()}`,
  //     ownder: 'Felipe Esnarriaga'
  //   })
  //     .then(response => {
  //       setProjects([...projects, response.data]);
  //     });
  // }

  async function handleAddProject() {
    const response = await api.post('/projects',
      {
        title: `New Project ${Date.now()}`,
        owner: 'Felipe Esnarriaga'
      }
    );

    const project = response.data;

    setProjects([...projects, project]);
  }

  return (
    <>
      <Header title="Projects" />
      {/* <ul>
        <li>Home</li>
        <li>Projects</li>
      </ul>
    </Header> */}

      {/* <img src={backgroundImage} alt="Background image" /> */}

      {/* <h2>Project List</h2> */}
      <ul>
        {projects.map((project, index) => <li key={project.id}>{project.title}</li>)}
      </ul>

      <button type="button" onClick={handleAddProject}>Add new project</button>
    </>
  );
}

export default App;
