const personFactory = (name, alias) => ({ name, alias });

const person = personFactory('Felipe', 'Sang');
console.log(person);

function printArguments() {
  console.table(arguments);
}
printArguments(10, true, false, 'Felipe', 'Hello');

// Do not implements arguments
const printArgumentsArrow = (...args) => console.table(args);
printArgumentsArrow(10, true, false, 'Felipe', 'Hello');

const returnArguments = (...args) => args;

const arguments = returnArguments(10, true, false, 'Felipe', 'Hello');
console.table(arguments);

const [age, married, happy, firstName, greeting] = returnArguments(10, true, false, 'Felipe', 'Hello');
console.table({ age, married, happy, firstName, greeting });

const { name: fullName, alias } = personFactory('Person Name', 'Person Alias');
console.table({ fullName, alias });

const tonyStark = {
  name: 'Tony Stark',
  alias: 'Ironman',
  alive: false,
  age: 40,
  suits: ['Mark I', 'Mark V', 'Hulkbuster'],
};

const printProperties = ({ alias, suits, notInObject = true }) => {
  console.log({ alias });
  console.log({ notInObject });
  console.table(suits);
};

printProperties(tonyStark);
