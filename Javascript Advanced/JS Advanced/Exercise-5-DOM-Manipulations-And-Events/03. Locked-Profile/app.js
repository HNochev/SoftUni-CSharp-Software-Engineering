function lockedProfile() {

    // Second Way 
    let buttonElements = Array.from(document.querySelectorAll('#main .profile button'));

    buttonElements.forEach(el => {
        el.addEventListener('click', toggleButton);
    })

    function toggleButton(e) {
        let button = e.target;
        let profile = button.parentElement;

        let radioButton = profile.querySelector('input:checked');

        if (radioButton.value === 'unlock') {
            // Get Hidden Field
            let hiddenFieldElement = button.previousElementSibling;

            // Toggle HIdden Field display
            hiddenFieldElement.style.display = hiddenFieldElement.style.display === 'block'
                ? 'none'
                : 'block';

            button.textContent = button.textContent === 'Show more'
                ? 'Hide it'
                : 'Show more';
        }
    }

    /*  First Way
    // 1. Select initial DOM Elements

    let profiles = document.querySelectorAll('#main .profile');
    let buttons = document.querySelectorAll('#main .profile button');

    // Attach Event Listeners to buttons

    for (let i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener('click', (e) => {
            //Get Radio Button for Profile

            let radioButtonName = `user${i + 1}Locked`;
            let radioButton = document.querySelector(`input[name="${radioButtonName}"]:checked`);
            console.log(radioButton);

            // Check if Profile is unlocked
            if (radioButton.value === 'unlock') {
                // Get Hidden Field
                let hiddenFieldElement = document.getElementById(`user${i + 1}HiddenFields`);

                // Toggle HIdden Field display
                hiddenFieldElement.style.display = hiddenFieldElement.style.display === 'block'
                    ? 'none'
                    : 'block';

                buttons[i].textContent = buttons[i].textContent === 'Show more'
                    ? 'Hide it'
                    : 'Show more';
            }
        })
    }
    */
}