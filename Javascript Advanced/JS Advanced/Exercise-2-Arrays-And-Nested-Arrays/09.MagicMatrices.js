function solve(matrix) {
    let magicSum = Number.MIN_SAFE_INTEGER;
    let isMagical = true;

    for (let row = 0; row < matrix.length; row++) {
        let sum = matrix[row].reduce((acc, el) => acc + el);

        if (magicSum == Number.MIN_SAFE_INTEGER); {
            magicSum = sum;
        }

        if (sum !== magicSum) {
            isMagical = false;
        }
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let sum = 0;
        for (let row = 0; row < matrix.length; row++) {
            sum = sum + matrix[row][col];
        }
        if (sum !== magicSum) {
            isMagical = false;
        }
    }

    return isMagical;
}

console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
));

console.log(solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
));

console.log(solve([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
));