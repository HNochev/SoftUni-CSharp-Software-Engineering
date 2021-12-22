function solve(input) {

    let numbers = input.map(Number);

    let sum = numbers.reduce((previos, current) => previos + current);

    let inversions = 0;
    for (i = 0; i < numbers.length; i++) {
        inversions = inversions + 1 / numbers[i];
    }
    let concat = "";
    for (i = 0; i < input.length; i++) {
        concat = concat + numbers[i];
    }
    console.log(sum);
    console.log(inversions);
    console.log(concat);
}

solve([1, 2, 3]);
console.log('');
solve([2, 4, 8, 16]);