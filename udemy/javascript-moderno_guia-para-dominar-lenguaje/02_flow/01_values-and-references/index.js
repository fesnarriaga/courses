let a = 10;
let b = a;
console.log({ a, b });


let c = 10;
let d = c;
c = 30;
console.log({ c, d });


let john = { name: 'John' };
let jane = john;
console.table({ john, jane });


let mary = { name: 'Mary' };
let anne = mary;
anne.name = 'Anne';
console.table({ mary, anne });


const changeName = (person) => {
  person.name = 'Tony';

  return person;
};
let troy = { name: 'Troy' };
let tony = changeName(troy);
console.table({ troy, tony });


let paul = { name: 'Paul' };
let rose = { ...paul };
rose.name = 'Rose';
console.table({ paul, rose });


const changeNameByVal = ({ ...person }) => {
  person.name = 'Mara';

  return person;
};
let carl = { name: 'Carl' };
let mara = changeNameByVal(carl);
console.table({ carl, mara });


const colors = ['red', 'green', 'blue'];
const otherColors = colors;
otherColors.push('yellow');
console.table({ colors, otherColors });


const fruits = ['appler', 'grape', 'pine apple'];
const otherFruits = [...fruits];
otherFruits.push('mango');
console.table({ fruits, otherFruits });


const cars = ['vw', 'bmw', 'ferrari'];

console.time('slice');
const sliceOperation = cars.slice();
console.timeEnd('slice');

console.time('spread');
const spreadOperation = [...cars];
console.timeEnd('spread');
