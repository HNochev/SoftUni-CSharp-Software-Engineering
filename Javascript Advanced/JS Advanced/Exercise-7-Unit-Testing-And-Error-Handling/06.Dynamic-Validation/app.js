function validate() {
    let emailInput = document.getElementById('email');
    emailInput.addEventListener('change', validateEmail)
    
    function validateEmail() {
        let emailRegex = /[a-z]+@[a-z]+\.[a-z]/;
    
        if(emailRegex.test(emailInput.value)){
            emailInput.classList.remove('error');
        } else {
            emailInput.classList.add('error');
        }
    }
}