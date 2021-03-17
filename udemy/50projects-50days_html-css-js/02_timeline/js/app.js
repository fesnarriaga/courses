const progress = document.querySelector('.progress');
const btnPrev = document.querySelector('.btn.prev');
const btnNext = document.querySelector('.btn.next');
const circles = document.querySelectorAll('.circle');

let currentActive = 1;

btnPrev.addEventListener('click', () => {
  if (currentActive > 1) {
    currentActive--;
  }

  updateProgress();
});

btnNext.addEventListener('click', () => {
  if (currentActive < circles.length) {
    currentActive++;
  }

  updateProgress();
});

function updateProgress() {
  const activeCircles = [];

  circles.forEach((circle, index) => {
    if (index < currentActive) {
      circle.classList.add('active');
      activeCircles.push(circle);
    } else {
      circle.classList.remove('active');
    }
  });

  progress.style.width = `${(--activeCircles.length / --circles.length) * 100}%`;

  if (currentActive === 1) {
    btnPrev.disabled = true;
  } else if (currentActive === circles.length) {
    btnNext.disabled = true;
  } else {
    btnPrev.disabled = false;
    btnNext.disabled = false;
  }
}
