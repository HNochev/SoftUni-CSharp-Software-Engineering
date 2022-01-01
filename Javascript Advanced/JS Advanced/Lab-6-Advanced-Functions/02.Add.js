function solution(num) {
    return function (anotherNum) {
        return Number(num + anotherNum);
    };
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
