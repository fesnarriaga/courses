function functionThatReturnsOne() {
  return 1;

  console.log('I will never execute, I am after return');
}

var returnsOneResult = functionThatReturnsOne();
console.log({ returnsOneResult });

function sum(a, b) {
  return a + b;
}
console.log(sum(1, 2));

const sumArrow = (a, b) => a + b;
console.log(sumArrow(1, 2));

function getRandomNumber() {
  return Math.random();
}
console.log(getRandomNumber());

const getRandomNumberArrow = () => Math.random();
console.log(getRandomNumberArrow());
