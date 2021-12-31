function addItem() {
    let textElement = document.getElementById('newItemText');
    let valueElement = document.getElementById('newItemValue');
    let selectElement = document.getElementById('menu');
    let optionElement = document.createElement('option');

    optionElement.value = valueElement.value;
    optionElement.textContent = textElement.value;

    if (optionElement.value.length > 0 && optionElement.textContent.length > 0) {
        selectElement.appendChild(optionElement);
    }
    textElement.value = '';
    valueElement.value = '';
}