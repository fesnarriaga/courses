/**
 * Weekdays - Open at 11
 * Weekends - Open at 9
 *
 * Show opening hours on a website
 */

let day = 0; // 0: Sunday, 1: Monday, ...
let hour = 10; // Current time

let openingTime;
let message; // Is Open! || Closed! Opens today at X

if (day === 0 || day === 6) {
  console.log('Weekend');
  openingTime = 9;
} else {
  console.log('Weekday');
  openingTime = 11;
}
console.log({ openingTime });

if (hour >= openingTime) {
  message = 'Is Open!';
} else {
  message = `Closed! Opens today at ${openingTime}`;
}
console.log({ message });

console.log('');

day = 4;
hour = 10;

openingTime = day === 0 || day === 6 ? 9 : 11;
message = hour >= openingTime ? 'Open!' : `Closed! Opens today at ${openingTime}`;

console.log({ openingTime });
console.log({ message });

console.log({ '[0, 6].includes(day)': [0, 6].includes(day) });
