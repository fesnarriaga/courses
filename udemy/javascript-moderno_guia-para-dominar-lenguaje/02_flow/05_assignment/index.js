console.warn('Assignments');

const isUndefined = undefined;
const isNull = null;
const isFalse = false;

const a1 = true && 'Hello' && 150;
console.log({ "true && 'Hello' && 150": a1 });

const a2 = false && 'Hello' && 150;
console.log({ "false && 'Hello' && 150": a2 });

const a3 = isFalse || 'Not false anymore';
console.log({ "isFalse || 'Not false anymore'": a3 });

const a4 = isFalse || isNull || isUndefined || 'Not false anymore, again';
console.log({ "isFalse || isNull || isUndefined || 'Not false anymore, again'": a4 });
