function solve(array, rotations) {
    let realRotations = Number(rotations) % array.length;

    for (let i = 0; i < realRotations; i++) {
        let lastElement = array.pop();
        array.unshift(lastElement);
    }

    console.log(array.join(' '));
}

solve(['1',
    '2',
    '3',
    '4'],
    2
);

solve(['Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15
);