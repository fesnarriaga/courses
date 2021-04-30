console.log({ myVariable }, 'FROM alerts.js');

var myVariable = 'Changed on alerts.js'

console.log({ myVariable });

testingVarWithoutKeyword = 'It will be placed on? Yes, on WINDOW!!!';
console.log({ testingVarWithoutKeyword });

alert('Normal alert');

const promptResponse = prompt('Normal prompt | Empty = "" | Cancel = null', 'Some default value');
console.log({ promptResponse });

const confirmResponse = confirm('Are you sure? Cancel = false');
console.log({ confirmResponse });

alert('REMAINDER: alert, prompt, confirm only in document (browser)');
alert('REMAINDER: NodeJs has GLOBAL objectqq');
