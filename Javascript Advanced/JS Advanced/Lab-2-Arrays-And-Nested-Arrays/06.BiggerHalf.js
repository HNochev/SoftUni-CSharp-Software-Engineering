function solve(input) {
    let result = [];

    input.sort((a, b) => b - a);
    let halfOfArray = Number(Math.ceil(input.length / 2));
    for (let i = 0; i < halfOfArray; i++) {
        result.push(input[i]);
    }

    result.sort((a, b) => a - b);
    
    return result;
}

console.log(solve([4, 7, 2, 5]).join(' '));
console.log(solve([3, 19, 14, 7, 2, 19, 6]).join(' '));