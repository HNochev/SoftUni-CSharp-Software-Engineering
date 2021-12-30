function focused() {
    let allInputElements = document.querySelectorAll('input');

    for (const inputElement of allInputElements) {
        inputElement.addEventListener('focus', (e) => {
            e.currentTarget.parentNode.className = 'focused';
            //e.currentTarget.parentNode.className = 'focus';
        });

        inputElement.addEventListener('blur', (e) => {
            e.currentTarget.parentNode.className = '';
        })
    }
}