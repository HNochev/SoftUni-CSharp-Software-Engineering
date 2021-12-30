function deleteByEmail() {
    let inputElement = document.querySelector('input');
    let allEmailElements = document.querySelectorAll('tbody tr td:nth-child(even)');
    let resultDivElement = document.getElementById('result');

    for (const emailElement of allEmailElements) {
        if (emailElement.textContent === inputElement.value) {
            emailElement.parentElement.remove();
            resultDivElement.textContent = 'Deleted';
        }
        else {
            resultDivElement.textContent = 'Not found.'
        }
    }

    inputElement.textContent = '';
}