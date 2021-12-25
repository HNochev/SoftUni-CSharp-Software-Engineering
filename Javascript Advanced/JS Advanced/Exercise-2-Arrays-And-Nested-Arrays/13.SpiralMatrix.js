function solve(rows, cols) {

    let result = [];
    for (let i = 0; i < rows; i++) {
        result[i] = [];
        for (let j = 0; j < cols; j++) {
            result[i][j] = ' ';
        }
    }

    let counter = 1;
    let startRow = 0;
    let endRow = rows - 1;
    let startCol = 0;
    let endCol = cols - 1;

    while (startCol <= endCol && startRow <= endRow) {
        //Top Row
        for (let i = startCol; i <= endCol; i++) {
            result[startRow][i] = counter;
            counter++;
        }
        startRow++;

        //Right Column
        for (let i = startRow; i <= endRow; i++) {
            result[i][endCol] = counter;
            counter++;
        }
        endCol--;

        //Bottom Row
        for (let i = endCol; i >= startCol; i--) {
            result[endRow][i] = counter;
            counter++;
        }
        endRow--;

        //Left Column
        for (let i = endRow; i >= startRow; i--) {
            result[i][startCol] = counter;
            counter++;
        }
        startCol++;
    }


    for (let row = 0; row < result.length; row++) {
        console.log(result[row].join(' '));
    }
}

solve(5, 5);
console.log();
solve(3, 3);
console.log();
solve(2, 5);

