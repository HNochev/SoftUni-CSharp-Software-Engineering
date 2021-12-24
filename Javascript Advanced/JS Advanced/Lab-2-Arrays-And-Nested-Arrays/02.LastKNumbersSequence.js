function solve(n, k) {

    let resultArr = [1];
    for (let i = 0; i < n - 1; i++) {
        let num = 0;

        for (let j = i; j > i - k; j--) {
            let currNum = resultArr[j];
            if (currNum == undefined) {
                currNum = 0;
            }
            num = num + currNum;
        }

        resultArr.push(num);
    }

    return resultArr;
}

console.log(solve(6, 3));
console.log(solve(8, 2));