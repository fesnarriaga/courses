// Strings
// https://stackoverflow.com/questions/65379554/why-does-my-variable-show-its-deprecated
console.log(window.name, typeof window.name);

let person = 'Peter Parker';
console.log({ person });

person = 'Ben Parker';
console.log({ person });

person = "Aunt May";
person = `Aunt May`;
console.log({ person });


// Weakly Typed
person = 123;
console.log(typeof person);

// Booleans
const isMarvel = true;
const isDc = false;
console.log({ isMarvel, isDc });

// Numbers
let age = 33;
console.log(typeof age);

age = 33.001;
console.log(typeof age);

// Undefined
let superPower;
console.log(typeof superPower);

// Null
const iAmNull = null;
console.log(typeof iAmNull); // OBJECT

// Symbol
const symbolOne = Symbol('a');
console.log(symbolOne);
console.log({ symbolOne });
console.log(typeof symbolOne);

const symbolTwo = Symbol('a');
console.log({ symbolTwo });

console.log('symbolOne == symbolTwo ?', symbolOne == symbolTwo);
console.log('symbolOne === symbolTwo ?', symbolOne === symbolTwo);
