import { render } from "../node_modules/lit-html/lit-html.js";
import { allTownsTemplate } from "./templates/townTemplates.js";

let form = document.querySelector('#townForm');
form.addEventListener('submit', displayTowns);

let rootDiv = document.querySelector('#root');

function displayTowns(e) {
    e.preventDefault();
    let form = e.target;
    let formData = new FormData(form);

    let townsString = formData.get('towns');
    let towns = townsString.split(', ');

    render(allTownsTemplate(towns), rootDiv);
}