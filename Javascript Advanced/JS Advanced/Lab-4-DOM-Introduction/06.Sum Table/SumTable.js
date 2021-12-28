function sumTable() {
    let result = document.getElementById('sum');
    let nums = document.querySelectorAll('td:nth-of-type(2n)')

    let sum = 0;
    for (const num of nums) {
        sum = sum + Number(num.textContent);
    }

    result.textContent = sum;
}