const container = document.querySelector('.container');
const openButton = document.getElementById('open');
const closeButton = document.getElementById('close');

openButton.addEventListener('click', () => {
  container.classList.add('show-nav');
});

closeButton.addEventListener('click', () => {
  container.classList.remove('show-nav');
});