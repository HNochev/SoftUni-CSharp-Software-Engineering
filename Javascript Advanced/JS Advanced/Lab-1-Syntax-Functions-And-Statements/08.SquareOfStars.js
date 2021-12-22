function solve(num) {
    if (num == null) {
        num = 5;
    }

    for (let i = 0; i < num; i++) {
        console.log("* ".repeat(num));
    }
}

solve(3);