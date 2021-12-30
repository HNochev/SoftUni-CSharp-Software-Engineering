function validate() {
    let regex = new RegExp(/[a-z]+@[a-z]+.[a-z]+/g);

    let emailElement = document.querySelector('#email');
    let emailValue = emailElement.value;

    emailElement.addEventListener('change', (e) => {
        if (regex.test(e.target.value)) {
            e.target.className = '';
        }
        else {
            e.target.className = 'error';
        }
    });
}