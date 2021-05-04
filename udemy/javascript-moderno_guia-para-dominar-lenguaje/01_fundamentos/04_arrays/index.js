// const arr = new Array(10);
// const arr = [];

// console.log(arr);
// console.table(arr);

const games = ['Mario 3', 'Megaman', 'Chrono Triggers'];

console.table(games);
console.log(games[0]);

const mixedArray = [
  true,
  123,
  'Felipe',
  1 + 2,
  function () { },
  () => { },
  { a: 1 },
  ['X', 'Megaman', 'Zero', 'Dr. Light'],
];

console.log({ mixedArray });
console.table(mixedArray);
console.log(mixedArray[7][3]);

const multiArr = [
  [1, 2, 3],
  [4, 5, 6],
  [7, 8, 9],
];
console.table(multiArr);
