function solve(juiceArr) {
    let juiceAmount = new Map();
    let juiceBottles = new Map();

    for (let i = 0; i < juiceArr.length; i++) {
        let [juiceName, amount] = juiceArr[i].split(' => ');
        amount = Number(amount);

        if (!juiceAmount.has(juiceName)) {
            juiceAmount.set(juiceName, 0);
        }

        let totalAmount = juiceAmount.get(juiceName) + amount;

        if (totalAmount >= 1000) {
            if (!juiceBottles.has(juiceName)) {
                juiceBottles.set(juiceName, 0);
            }

            let newBottles = Math.trunc(totalAmount / 1000);
            let totalBottles = juiceBottles.get(juiceName) + newBottles;
            juiceBottles.set(juiceName, totalBottles);
        }

        juiceAmount.set(juiceName, totalAmount % 1000);
    }

    /*  return Array.from(juiceBottles)
          .map(([key, value]) => `${key} => ${value}`)
          .join('\n'); */

    for (const element of Array.from(juiceBottles)) {
        console.log(`${element[0]} => ${element[1]}`);
    }
}

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
);