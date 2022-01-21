import { html } from "./../../node_modules/lit-html/lit-html.js";

export let myListingsTemplate = (model) => html`
<!-- My Listings Page -->
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">

    ${model.myCars.length > 0
    ? model.myCars.map(m => carTemplate(m))
    : html`<p class="no-cars"> You haven't listed any cars yet.</p>`}
        
    </div>
</section>`;

let carTemplate = (car) => html`
    <div class="listing">
        <div class="preview">
            <img src="${car.imageUrl}">
            </div>
            <h2>${car.brand} ${car.model}</h2>
            <div class="info">
                <div class="data-info">
                    <h3>Year: ${car.year}</h3>
                    <h3>Price: ${car.price} $</h3>
                </div>
                <div class="data-buttons">
                    <a href="/details/${car._id}" class="button-carDetails">Details</a>
                </div>
            </div>
        </div>`;