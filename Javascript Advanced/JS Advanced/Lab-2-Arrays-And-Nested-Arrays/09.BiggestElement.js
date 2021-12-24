function solve(matrix) {
    let maxNum = Number.MIN_SAFE_INTEGER;

    for (let row = 0; row < matrix.length; row++) {
        let currRow = Math.max(...matrix[row]);

        if (currRow > maxNum) {
            maxNum = currRow;
        }
    }

    return maxNum;
}

console.log(solve([[20, 50, 10],
[8, 33, 145]]
));

console.log(solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
   ));