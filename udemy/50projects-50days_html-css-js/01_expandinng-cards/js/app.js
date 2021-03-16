const images = [
  'https://images.unsplash.com/photo-1613859243210-4c31cc57a482?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixlib=rb-1.2.1&q=80&w=1600',
  'https://images.unsplash.com/photo-1613524952841-d630936f6388?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixlib=rb-1.2.1&q=80&w=1600',
  'https://images.unsplash.com/photo-1614904781651-9a06992ad36f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixlib=rb-1.2.1&q=80&w=1600',
  'https://images.unsplash.com/photo-1613807871118-9e983601b759?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixlib=rb-1.2.1&q=80&w=1600',
  'https://images.unsplash.com/photo-1615440116355-527cb4dcafe2?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixlib=rb-1.2.1&q=80&w=1600'
];

const panels = document.querySelectorAll('.panel');

function removeActiveClass() {
  panels.forEach(panel => {
    if (panel.classList.contains('active')) {
      panel.classList.remove('active');

      return;
    }
  });
}

panels.forEach((panel, index) => {
  panel.setAttribute('style', `background-image: url('${images[index]}')`);
});

panels.forEach(panel => {
  panel.addEventListener('click', () => {
    removeActiveClass();

    panel.classList.add('active');
  });
});
