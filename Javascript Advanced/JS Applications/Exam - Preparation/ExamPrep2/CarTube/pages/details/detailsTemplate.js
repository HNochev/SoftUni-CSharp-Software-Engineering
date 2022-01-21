import { html } from "./../../node_modules/lit-html/lit-html.js";

export let detailsTemplate = (modell) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${modell.car.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${modell.car.brand}</li>
            <li><span>Model:</span>${modell.car.model}</li>
            <li><span>Year:</span>${modell.car.year}</li>
            <li><span>Price:</span>${modell.car.price}$</li>
        </ul>

        <p class="description-para">${modell.car.description}</p>

        ${modell.isOwner
        ? html`<div class="listings-buttons">
            <a href="/edit/${modell.car._id}" class="button-list">Edit</a>
            <a href="#" class="button-list" @click=${(e) => modell.deleteHandler(modell.car._id, e)}>Delete</a>
        </div> `
        : ''}
    </div>
</section>`;