function solve(matrix) {
    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;

    let newMatrix = [];

    for (let i = 0; i < matrix.length; i++) {

        let parseInt = matrix[i].split(' ').map(x => Number(x));
        newMatrix.push(parseInt);

        leftDiagonalSum = leftDiagonalSum + newMatrix[i][i];
        rightDiagonalSum = rightDiagonalSum + newMatrix[i][newMatrix[i].length - i - 1];
    }

    if (leftDiagonalSum === rightDiagonalSum) {
        for (let row = 0; row < newMatrix.length; row++) {
            for (let col = 0; col < newMatrix[row].length; col++) {
                if (!(row === col || col === newMatrix[row].length - row - 1)) {
                    newMatrix[row][col] = leftDiagonalSum;
                }
            }
        }

        for (let row = 0; row < newMatrix.length; row++) {
            console.log(newMatrix[row].join(' '));
        }
    }
    else {
        for (let row = 0; row < newMatrix.length; row++) {
            console.log(newMatrix[row].join(' '));
        }
    }
}


solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);
console.log();
solve(['1 1 1',
    '1 1 1',
    '1 1 0']
);