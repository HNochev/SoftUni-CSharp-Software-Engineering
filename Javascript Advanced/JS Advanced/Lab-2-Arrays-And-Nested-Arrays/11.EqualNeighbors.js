function solve(matrix) {
    let equalCouples = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[0].length; col++) {
            if (col + 1 < matrix[0].length & matrix[row][col] === matrix[row][col + 1]) {
                equalCouples++;
            }
            if (row + 1 < matrix.length && matrix[row][col] === matrix[row + 1][col]) {
                equalCouples++;
            }
        }
    }

    return equalCouples;
}

console.log(solve([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '0'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '5']]
));
console.log(solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
));