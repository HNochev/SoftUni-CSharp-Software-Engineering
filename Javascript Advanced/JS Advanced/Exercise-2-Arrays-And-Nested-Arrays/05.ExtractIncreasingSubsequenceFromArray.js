function solve(input) {
    let max = Number.MIN_SAFE_INTEGER;

    let result = input.reduce((acc, val) => {
        if (val >= max) {
            max = val;
            acc.push(max);
        }

        return acc;
    }, [])

    return result;
}

console.log(solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
).join(', '));
console.log(solve([1,
    2,
    3,
    4]
).join(', '));
console.log(solve([20,
    3,
    2,
    15,
    6,
    1]
).join(', '));