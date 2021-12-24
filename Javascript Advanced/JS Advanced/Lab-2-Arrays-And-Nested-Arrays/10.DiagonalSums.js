function solve(matrix) {
    let leftDiagonalSum = 0;
    let rightDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        leftDiagonalSum = leftDiagonalSum + Number(matrix[row][row]);

        rightDiagonalSum = rightDiagonalSum + Number(matrix[row][matrix[row].length - 1 - row]);
    }

    console.log(`${leftDiagonalSum} ${rightDiagonalSum}`);
}

solve([[20, 40],
[10, 60]]
);

solve([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]
);