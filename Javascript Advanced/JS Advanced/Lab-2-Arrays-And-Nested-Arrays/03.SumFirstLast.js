function solve(input){
    let firstValue = Number(input.pop());
    let lastValue = Number(input.shift());

    return firstValue + lastValue;
}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));