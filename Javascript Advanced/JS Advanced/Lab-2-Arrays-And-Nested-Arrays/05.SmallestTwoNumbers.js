function solve(input) {
    let result = [];

    input.sort((a, b) => a - b);

    result = input.slice(0, 2);
    console.log(result.join(' '));
}

//numArray.sort((a, b) => a - b); 
// For ascending sort

//numArray.sort((a, b) => b - a); 
// For descending sort

solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);