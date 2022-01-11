function solution() {
    let buttonElement = document.querySelector('.card button');

    buttonElement.addEventListener('click', (e) => {

        let inputElement = document.querySelector('.card input');

        if (!inputElement.value) {
            return;
        }

        let sendButtonElement = createElement('button', 'Send');
        sendButtonElement.setAttribute('id', 'sendButton');
        sendButtonElement.addEventListener('click', (e) => {
            let liElementNoButtons = e.target.parentElement;
            let toRemove = liElementNoButtons.querySelectorAll('button');
            toRemove[1].remove();
            toRemove[0].remove();

            let liElementToInput = createElement('li', liElementNoButtons.textContent, 'gift');

            liElementNoButtons.remove();

            let ulElement = document.querySelectorAll('.card ul')[1];
            ulElement.appendChild(liElementToInput);

        });

        let discardButtonElement = createElement('button', 'Discard');
        discardButtonElement.setAttribute('id', 'discardButton');
        discardButtonElement.addEventListener('click', (e) => {
            let liElementNoButtons = e.target.parentElement;

            let buttons = liElementNoButtons.querySelectorAll('button');
            buttons[1].remove();
            buttons[0].remove();

            let ulElement = document.querySelectorAll('.card ul')[2];
            ulElement.appendChild(liElementNoButtons);
        });

        let liElement = createElement('li', inputElement.value, 'gift');

        liElement.appendChild(sendButtonElement);
        liElement.appendChild(discardButtonElement);

        let ulElement = document.querySelectorAll('.card ul')[0];
        ulElement.appendChild(liElement);

        inputElement.value = ''; // cleaning

        switching = true;

        while (switching) {

            switching = false;
            b = ulElement.getElementsByTagName("LI");

            for (i = 0; i < (b.length - 1); i++) {

                shouldSwitch = false;

                if (b[i].innerHTML.toLowerCase() > b[i + 1].innerHTML.toLowerCase()) {

                    shouldSwitch = true;
                    break;
                }
            }
            if (shouldSwitch) {

                b[i].parentNode.insertBefore(b[i + 1], b[i]);
                switching = true;
            }
        }

    });


    function createElement(type, text, attr) {
        let result = document.createElement(type);

        if (text) {
            result.textContent = text;
        }

        if (attr) {
            result.className = attr;
        }
        return result;
    }
}