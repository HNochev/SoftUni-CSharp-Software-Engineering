function solve(array, number) {
    let result = [];

    result = array.filter((arr, i) => i % number === 0, 0);

    return result;
}

solve(['5',
    '20',
    '31',
    '4',
    '20'],
    2
);

solve(['dsa',
    'asd',
    'test',
    'tset'],
    2
);

solve(['1',
    '2',
    '3',
    '4',
    '5'],
    6
);