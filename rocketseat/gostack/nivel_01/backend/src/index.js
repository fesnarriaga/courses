const express = require('express');
const cors = require('cors');
const { uuid, isUuid } = require('uuidv4');

const app = express();

app.use(cors());
app.use(express.json());

/**
 * Métodos HTTP
 * 
 * GET: Buscar informações
 * POST: Criar uma informação
 * PUT/PATCH: Alterar uma informação
 * DELETE: Excluir uma informação
 */

/**
 * Tipos de parâmetros
 * Query Params: Filtros e paginação
 * Route Params: Identificar recursos ao atualizar ou excluir
 * Request Body: Conteúdo ao criar ou alterar um recurso (JSON)
 */

/**
 * Middleware
 * Interceptador de requisições
 * Pode interromper totalmente a requisição
 * Pode alterar dados da requisição
 */

function logRequest(request, response, next) {
  const { method, url } = request;

  const logMessage = `[${method}] ${url}`;

  console.log(logMessage);

  return next();
}

function validateUUID(request, response, next) {
  const { id } = request.params;

  if (!isUuid(id))
    return response.status(400).json({ error: 'Invalid project ID' });

  return next();
}

app.use(logRequest);
app.use('/projects/:id', validateUUID);

const projects = [
  {
    id: '26d3af3c-62bc-436b-89c9-2f0bf1a42ac7',
    title: 'Title 1',
    owner: 'Owner 1'
  },
  {
    id: '7af120cf-ba2b-4f76-b22c-2db7ff4b8d8a',
    title: 'Title 2',
    owner: 'Owner 2'
  },
  {
    id: 'b89f276a-879d-4065-98bc-2c7291f8b456',
    title: 'Title 3',
    owner: 'Owner 3'
  }
];

app.get('/projects', (request, response) => {
  const { title } = request.query;

  const result = title ?
    projects.filter(project => project.title.toLocaleLowerCase().includes(title.toLocaleLowerCase())) :
    projects;

  return response.json(result);
});

app.post('/projects', (request, response) => {
  const { title, owner } = request.body;

  const project = {
    id: uuid(),
    title,
    owner
  }

  projects.push(project);

  return response.json(project);
});

app.put('/projects/:id', validateUUID, (request, response) => {
  const { id } = request.params;

  const projectIndex = projects.findIndex(project => project.id === id);

  if (projectIndex < 0) {
    return response.status(400).json({ error: 'Project not found!' });
  }

  const { title, owner } = request.body;
  const project = {
    id,
    title,
    owner
  }

  projects[projectIndex] = project;

  return response.json(project);
});

app.delete('/projects/:id', (request, response) => {
  const { id } = request.params;

  const projectIndex = projects.findIndex(project => project.id === id);

  if (projectIndex < 0) {
    return response.status(400).json({ error: 'Project not found!' });
  }

  projects.splice(projectIndex, 1);

  return response.send();
});

app.listen(3333, () => console.log("😈 Server running on port 3333"));
