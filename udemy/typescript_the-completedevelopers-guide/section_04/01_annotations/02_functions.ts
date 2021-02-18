const logNumber: (i: number) => void = (i: number) => {
  console.log(i);
};

const add = (a: number, b: number): number => {
  return a + b;
}

const subtract = (a: number, b: number) => {
  return a - b;
  // If you forget to return, Typescript will infer
  // that this function is VOID
  // ALWAYS SPECIFY THE RETURN TYPE
}

// Named function
function divide(a: number, b: number): number {
  return a / b;
}

// Anonymous function
const multiply = function (a: number, b: number): number {
  return a * b;
}
