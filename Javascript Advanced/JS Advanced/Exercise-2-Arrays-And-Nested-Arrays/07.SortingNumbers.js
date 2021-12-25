function solve(input) {
    input.sort((a, b) => a - b);
    let arrayLength = Number(input.length);
    let result = [];

    for (let i = 0; i < Math.ceil(arrayLength / 2); i++) {
        let firstElem = input.shift();
        let lastElem = input.pop();

        result.push(firstElem, lastElem);
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]).join(', '));