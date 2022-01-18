import { render } from "../node_modules/lit-html/lit-html.js";
import { matchesTemplate, townsTemplate } from "./templates/townTemplates.js";
import { towns } from "./towns.js";

let townDiv = document.querySelector('#towns');
let baseTowns = towns.map(t => ({ name: t }));
render(townsTemplate(baseTowns), townDiv);

let resultDiv = document.querySelector('#result');

let searchButton = document.querySelector('#searchButton');
searchButton.addEventListener('click', search);

function search() {
   let searchInput = document.querySelector('#searchText');
   let searchText = searchInput.value.toLowerCase();

   let allTowns = towns.map(t => ({ name: t }));
   let matchedTowns = allTowns.filter(t => t.name.toLowerCase().includes(searchText));

   matchedTowns.forEach(t => { t.class = 'active' });
   let matches = matchedTowns.length;

   render(townsTemplate(allTowns), townDiv);
   render(matchesTemplate(matches), resultDiv);
}
