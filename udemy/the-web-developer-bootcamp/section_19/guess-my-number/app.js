const target = Math.floor(Math.random() * 10 + 1);
let attempts = 1;

while (true) {
    const answer = prompt('Guess my number (1 - 10)');

    if (parseInt(answer) === target || answer === null) {
        break;
    }

    attempts++;
}

console.log(`Congrats... You won in ${attempts} chances`);
