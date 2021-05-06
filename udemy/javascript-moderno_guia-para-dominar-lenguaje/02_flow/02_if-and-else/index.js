let a = 5;
if (a > 10) {
  console.log('A greather than 10');
}

if (a < 10) {
  console.log('A lower than 10');
}
console.log('End of task');


let b = 15;
if (b > 10) {
  console.log('B greather than 10');
}

if (b < 10) {
  console.log('B lower than 10');
}
console.log('End of task');

let c = 10;
if (c > 10) {
  console.log('C greather than 10');
}

if (c < 10) {
  console.log('C lower than 10');
}
console.log('End of task');


let d = 10;
if (d >= 10) {
  console.log('D greather than or equal 10');
}

if (d < 10) {
  console.log('D lower than 10');
}
console.log('End of task');


let e = 5;
if (e > 10) {
  console.log('E greather than 10');
} else {
  console.log('E lower than 10');
}
console.log('End of task');

/*
  =   assign
  ==  compare values, ignores data type
  === compare values and data type
*/

const today = new Date();
const weekDay = today.getDay();

if (weekDay === 0) {
  console.log('Sunday');
} else {
  if (weekDay === 1) {
    console.log('Monday');
  } else {
    if (weekDay === 2) {
      console.log('Tuesday');
    } else {
      if (weekDay === 3) {
        console.log('Wednesday');
      } else {
        if (weekDay === 4) {
          console.log('Thursday');
        } else {
          if (weekDay === 5) {
            console.log('Friday');
          } else {
            console.log('Saturday');
          }
        }
      }
    }
  }
}

if (weekDay === 0) {
  console.log('Sunday');
} else if (weekDay === 1) {
  console.log('Monday');
} else if (weekDay === 2) {
  console.log('Tuesday');
} else if (weekDay === 3) {
  console.log('Wednesday');
} else if (weekDay === 4) {
  console.log('Thursday');
} else if (weekDay === 5) {
  console.log('Friday');
} else {
  console.log('Saturday');
}
