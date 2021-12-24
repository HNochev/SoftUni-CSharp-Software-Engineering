function solve(input) {
    let result = [];

    for (let i = 0; i < input.length; i++) {
        if (input[i] < 0) {
            result.unshift(input[i]);
        }
        else {
            result.push(input[i]);
        }
    }

    return result.join('\n');
}

console.log(solve([7, -2, 8, 9]));
console.log(solve([3, -2, 0, -1]));