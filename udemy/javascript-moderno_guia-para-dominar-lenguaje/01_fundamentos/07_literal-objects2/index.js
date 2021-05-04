const person = {
  name: 'Tony Stark',
  alias: 'Iron Man',
  live: true,
  age: 40,
  coords: {
    lat: 34.034,
    lng: -118.70
  },
  suits: ['Mark I', 'Mark V', 'Hulkbuster'],
  direction: {
    zip: '10880,90265',
    location: 'Malibu, California',
  },
  'last movie': 'Infinity War',
};

delete person.age;
console.log(person);

person.married = true;
console.log('Married: ', person.married);

const entriesPairs = Object.entries(person);
console.table(entriesPairs);

Object.freeze(person);
person.money = 100000000;
person.married = false;
person.direction.location = 'Changed';
console.table(person);

const properties = Object.getOwnPropertyNames(person);
const values = Object.values(person);
console.table(properties);
console.table(values);
