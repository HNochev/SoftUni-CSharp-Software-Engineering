import { render } from "../node_modules/lit-html/lit-html.js";
import { allRowsTemplate } from "./templates/rowTemplates.js";

document.querySelector('#searchBtn').addEventListener('click', onClick);
let tableTBody = document.querySelector('.container tbody');

let rows = [];

loadRows();

async function loadRows() {
   let rowsResponse = await fetch('http://localhost:3030/jsonstore/advanced/table');
   let rowsObj = await rowsResponse.json();

   rows = Object.values(rowsObj).map(r => ({
      name: `${r.firstName} ${r.lastName}`,
      course: r.course,
      email: r.email
   }));

   render(allRowsTemplate(rows), tableTBody);
}

function onClick() {
   let searchInput = document.querySelector('#searchField');
   let searchText = searchInput.value.toLowerCase();

   let allRows = rows.map(r=> Object.assign({}, r));
   let matchedRows = allRows.filter(r=>Object.values(r).some(val => {
      return val.toLowerCase().includes(searchText);
   }));

   matchedRows.forEach(r=>r.class = 'select');

   searchInput.value = '';

   render(allRowsTemplate(allRows), tableTBody);
}
