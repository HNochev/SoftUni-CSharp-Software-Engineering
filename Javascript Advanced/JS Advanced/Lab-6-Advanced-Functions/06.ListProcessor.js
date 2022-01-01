function solve(inputArr) {
    let result = [];
    for (const command of inputArr) {
        if (command.startsWith("add")) {
            result.push(command.split(' ')[1]);
        }
        else if (command.startsWith('remove')) {
            result = result.filter(x => x !== command.split(' ')[1]);
        }
        else if (command.startsWith('print')) {
            console.log(result.join(','));
        }
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);

solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);