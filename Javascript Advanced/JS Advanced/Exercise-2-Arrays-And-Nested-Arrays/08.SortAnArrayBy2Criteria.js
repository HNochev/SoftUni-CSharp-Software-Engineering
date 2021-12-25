function solve(input) {
    input.sort((a, b) => {
        if (a.length < b.length) {
            return -1;
        } else if (a.length > b.length) {
            return 1;
        } else {
            let x = a.toUpperCase(),
                y = b.toUpperCase();
            if (x < y) {
                return -1;
            } else if (x > y) {
                return 1;
            } else {
                return 0;
            }
            //return x == y ? 0 : x > y ? 1 : -1;
        }
    });

    console.log(input.join('\n'));
}

solve(['alpha',
    'beta',
    'gamma']
);

solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
);

solve(['test',
    'Deny',
    'omen',
    'Default']
);