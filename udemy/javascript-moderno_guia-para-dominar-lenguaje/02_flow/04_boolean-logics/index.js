const returnTrue = () => {
  console.log('Returns true');
  return true;
};

const returnFalse = () => {
  console.log('Returns false');
  return false;
};

console.warn('Negation');
console.log({ 'true': true });
console.log({ '!true': !true });
console.log({ '!false': !false });
console.log({ '!!false': !!false });
console.log({ '!returnFalse()': !returnFalse() });

console.warn('AND');
console.log({ 'true && true': true && true });
console.log({ 'true && !false': true && !false });
console.log('');
console.log({ 'returnFalse() && returnTrue()': returnFalse() && returnTrue() });
console.log('');
console.log({ 'returnTrue() && returnFalse()': returnTrue() && returnFalse() });

console.warn('OR');
console.log({ 'true || true': true || true });
console.log({ 'false || false': false || false });
console.log({ 'true || false': true || false });
console.log('');
console.log({ 'returnFalse() || returnTrue()': returnFalse() || returnTrue() });
console.log('');
console.log({ 'returnTrue() || returnFalse()': returnTrue() || returnFalse() });
