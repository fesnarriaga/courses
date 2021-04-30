console.log('Hello World!');

let x = 31;

console.log(x);
console.warn(x);
console.info(x);
console.error(x);

let a = 1;
let b = 2;
console.log('a', a);
console.log('b', b);

console.log('a =>', a);
console.log('b =>', b);

console.log({ a });
console.log({ b });

console.log('%c Highlight hith CSS properties', 'background: white; color: blue; font-weight: bold');
console.log(x);

const person = {
  firstName: 'Felipe',
  lastName: 'Esnarriaga',

  fullName() {
    return `${this.firstName} ${this.lastName}`;
  }
};

var fullName = person.fullName();

console.log(person.fullName());
console.log({ fullName: person.fullName() });
console.log({ fullName });

const m = 10;
const n = 20;
const o = 'Hello';
const p = true;
const q = { a: 'a', b: 10, c: true };
const r = [1, 2, 3];
console.table({ m, n, o, p, q, r });

// alert('Some message');

var myVariable = 'Some VAR variable';
