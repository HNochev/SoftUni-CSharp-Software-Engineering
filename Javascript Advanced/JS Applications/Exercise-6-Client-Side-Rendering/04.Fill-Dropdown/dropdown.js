import { render } from "../node_modules/lit-html/lit-html.js";
import { allOptionsTemplate } from "./templates/optionTemplate.js";

let menuSelect = document.querySelector('#menu');

let addOptionForm = document.querySelector('#addOptionForm');
addOptionForm.addEventListener('submit', addItem);

let submitButton = document.querySelector('#submit');
submitButton.disabled = true;

loadOptions();

let options = [];

async function loadOptions() {
    let optionsResponse = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    let optionsObj = await optionsResponse.json();

    options = Object.values(optionsObj);
    render(allOptionsTemplate(options), menuSelect);
    submitButton.disabled = false;
}

async function addItem(e) {
    e.preventDefault();
    let form = e.target;
    let formData = new FormData(form);

    let newOption = { text: formData.get('text') }

    let createResponse = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        headers: { 'Content-Type': 'application/json' },
        method: 'Post',
        body: JSON.stringify(newOption)
    });

    if (createResponse.ok) {
        let createdOption = await createResponse.json();
        options.push(createdOption);
        render(allOptionsTemplate(options), menuSelect);
    }
}