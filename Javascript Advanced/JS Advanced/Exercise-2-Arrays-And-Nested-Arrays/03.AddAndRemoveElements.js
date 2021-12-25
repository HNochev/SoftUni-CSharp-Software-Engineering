function solve(input) {
    let result = [];

    for (let i = 0; i < input.length; i++) {
        if (input[i] === 'add') {
            result.push(i + 1);
        } else if (input[i] === 'remove') {
            result.pop();
        }
    }

    if (result.length > 0) {
        console.log(result.join('\n'));
    } else {
        console.log('Empty');
    }
}

solve(['add',
    'add',
    'add',
    'add']
);

solve(['add',
    'add',
    'remove',
    'add',
    'add']
);

solve(['remove',
    'remove',
    'remove']
);