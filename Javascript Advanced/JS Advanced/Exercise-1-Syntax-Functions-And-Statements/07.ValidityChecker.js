function solve(x1, y1, x2, y2) {

    function calucateDistance(x1, y1, x2, y2) {
        let distance = Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        return distance;
    }

    Number.isInteger(calucateDistance(x1, y1, 0, 0))
        ? console.log(`{${x1}, ${y1}} to {0, 0} is valid`)
        : console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    Number.isInteger(calucateDistance(x2, y2, 0, 0))
        ? console.log(`{${x2}, ${y2}} to {0, 0} is valid`)
        : console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    Number.isInteger(calucateDistance(x1, y1, x2, y2))
        ? console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
        : console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
}

solve(3, 0, 0, 4);
solve(2, 1, 1, 1);