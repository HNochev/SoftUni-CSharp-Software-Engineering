import { html } from "./../../node_modules/lit-html/lit-html.js";

export let detailsTemplate = (model) => html`
<section id="meme-details">
    <h1>Meme Title: ${model.meme.title}

    </h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src="${model.meme.imageUrl}">
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
            ${model.meme.description}
            </p>

            ${model.isOwner
        ? html`<a class="button warning" href="/edit/${model.meme._id}">Edit</a>
            <button @click="${(e) => model.deleteHandler(model.meme._id, e)}" class="button danger">Delete</button>`
        : ''}
        </div>
    </div>
</section>
`;