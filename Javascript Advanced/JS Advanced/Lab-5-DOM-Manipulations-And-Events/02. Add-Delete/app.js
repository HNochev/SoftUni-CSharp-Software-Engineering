function addItem() {
    let newItemTextElement = document.getElementById('newItemText');
    let itemsElement = document.getElementById('items');
    let textOfElement = newItemTextElement.value;
    //let newElement = e('li', textOfElement);
    let newEl = document.createElement('li');
    newEl.textContent = textOfElement;
    let delBut = document.createElement('a');
    delBut.textContent = '[Delete]';
    //let deleteButon = e('a', '[Delete]');
    delBut.setAttribute('href', '#')
    newEl.appendChild(delBut);
    itemsElement.appendChild(newEl);
    newItemTextElement.value = '';

    itemsElement.addEventListener('click', (e) => {
        if (e.target.nodeName == 'A') {
            e.target.parentElement.remove()
        }
    });

    /* function e(type, content) {
        let element = document.createElement(type);

        if (typeof content === 'string') {
            element.textContent = content;
        } else {
            element.appendChild(content);
        }
        return element;
    } */
}