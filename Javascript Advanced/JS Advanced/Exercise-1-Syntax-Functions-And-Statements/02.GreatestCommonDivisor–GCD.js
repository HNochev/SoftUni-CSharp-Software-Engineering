function solve(a, b) {
    while (b > 0) {
        let temp = b;
        b = a % b;
        a = temp;
    }

    return a;
}

console.log(solve(2154, 458));

