let games = ['Zelda', 'Mario', 'Metroid', 'Chrono'];

console.log({ length: games.length });

console.log({ first: games[0] });
console.log({ last: games[games.length - 1] });

games.forEach((game, index) => {
  console.log({ game: `[${index}] ${game}` });
});

games.push('F-Zero');
console.table(games);

games.unshift('Fire Emblem');
console.table(games);

games.pop();
console.table(games);

games.shift();
console.table(games);

games.splice(2, 1);
console.table(games);

const marioIndex = games.findIndex(x => x === 'Mario');
console.log({ marioIndex });
