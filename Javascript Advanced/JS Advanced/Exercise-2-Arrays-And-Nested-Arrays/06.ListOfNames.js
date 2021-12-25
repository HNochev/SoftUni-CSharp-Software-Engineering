function solve(input) {

    input.sort(function (a, b) {
        let x = a.toUpperCase(),
            y = b.toUpperCase();
        return x == y ? 0 : x > y ? 1 : -1;
    });
    // another way to sort
    // input.sort((a, b) => a.localeCompare(b));

    input.forEach((element, i) => {
        console.log(`${i + 1}.${element}`)
    });
}

solve(["John", "Bob", "Christina", "Ema"]);