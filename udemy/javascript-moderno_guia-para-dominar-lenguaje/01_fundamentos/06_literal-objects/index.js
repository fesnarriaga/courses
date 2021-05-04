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

console.log('Name: ', person.name);
console.log('Name: ', person['name']);

console.table(person);
console.log(person);

console.log('Coords: ', person.coords);
console.log('Lat: ', person.coords.lat);
console.log('Lng: ', person.coords.lng);

console.log('# of suits: ', person.suits.length);

console.log('Last suit: ', person.suits[person.suits.length - 1]);

const propName = 'live';
console.log('Live: ', person[propName]);

const lastMovie = 'last movie';
console.log('Last movie: ', person[lastMovie]);
