const today = new Date();
const weekDay = today.getDay();

const weekDayNames = {
  0: 'Sunday',
  1: 'Monday',
  2: 'Tuesday',
  3: 'Wednesday',
  4: 'Thursday',
  5: 'Friday',
  6: 'Saturday',
};

console.log('Day of week: ', weekDayNames[weekDay] || 'Invalid parameter');


const weekDayNamesAsFunctions = {
  0: () => `Sunday ${new Date()}`,
  1: () => `Monday ${new Date()}`,
  2: () => `Tuesday ${new Date()}`,
  3: () => `Wednesday ${new Date()}`,
  4: () => `Thursday ${new Date()}`,
  5: () => `Friday ${new Date()}`,
  6: () => `Saturday ${new Date()}`,
};

console.log('Day of week as function: ', weekDayNamesAsFunctions[weekDay] || 'Invalid parameter');
console.log('Day of week as function: ', weekDayNamesAsFunctions[weekDay]() || 'Invalid parameter');
