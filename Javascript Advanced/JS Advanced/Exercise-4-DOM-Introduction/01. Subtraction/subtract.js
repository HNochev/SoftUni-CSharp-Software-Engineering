function subtract() {
    let firstInputElement = document.getElementById('firstNumber');
    let secondInputElement = document.getElementById('secondNumber');
    let divElement = document.getElementById('result');

    let firstNumber = Number(firstInputElement.value);
    let secondNumber = Number(secondInputElement.value);

    let result = firstNumber - secondNumber;

    divElement.textContent = result;
}