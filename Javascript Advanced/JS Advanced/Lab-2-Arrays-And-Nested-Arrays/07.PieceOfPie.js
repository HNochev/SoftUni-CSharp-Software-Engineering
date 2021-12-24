function solve(pieArr, startPie, endPie) {

    let startPieIndex = pieArr.indexOf(startPie);
    let endPieIndex = pieArr.indexOf(endPie);

    let result = [];

    result = pieArr.slice(startPieIndex, endPieIndex + 1);

    return result;
}

console.log(solve(['Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
));