const todos = [];

function add(item) {

}

function list() {

}

function remove(index) {

}

let option;

while (option !== 'quit') {
    option = prompt('Choose an option');

    switch (option) {
        case 'new':
            const input = prompt('Enter new todo')
            todos.push(input);
            console.log(`${input} added to list`);
            break;

        case 'list':
            // console.log('\n***********************');
            // for (const [index, item] of todos.entries()) {
            //     console.log(`${index}: ${item}`);
            // }
            // console.log('***********************\n');
            // console.table(todos);
            console.log('\n***********************');
            for (let i = 0; i < todos.length; i++) {
                console.log(`${i}: ${todos[i]}`);
            }
            console.log('***********************\n');
            break;

        case 'delete':
            const index = parseInt(prompt('Enter todo index to remove'));

            if (index >= 0) {
                todos.splice(index, 1);
                console.log('Todo removed');
            }
            break;

        default:
            break;
    }
}

console.log('You quite the app :(');
