function greeting() {
  console.log('Hello World!');
}
greeting();
greeting();

const greetingAnonymousFunction = function () {
  console.log('Hello Anonymous Function!');
}
greetingAnonymousFunction();

const greetingPerson = function (name) {
  console.log(`Hello, ${name}!`);
}
greetingPerson('Felipe');
greetingPerson();
greetingPerson('Felipe', 40, true, 'Brazil');

const getFunctionArguments = function () {
  console.log(arguments);
  console.table(arguments);
}
getFunctionArguments('Felipe', 40, true, ['a', 'b']);

const greetingArrowFunction = (name) => {
  console.log(`Hello, ${name}`);
};
greetingArrowFunction('Arrow Function');
