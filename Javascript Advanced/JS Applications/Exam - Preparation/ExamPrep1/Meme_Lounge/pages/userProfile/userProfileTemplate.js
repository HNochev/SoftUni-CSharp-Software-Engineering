import { html } from "./../../node_modules/lit-html/lit-html.js";

export let userProfileTemplate = (model) => html`
<!-- Profile Page ( Only for logged users ) -->
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/${model.user.gender}.png">
        <div class="user-content">
            <p>Username: ${model.user.username}</p>
            <p>Email: ${model.user.email}</p>
            <p>My memes count: ${model.myMemes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
    ${model.myMemes.length > 0
        ? model.myMemes.map(c => memeTemplate(c))
        : html `<p class="no-memes">No memes in database.</p>`}
    </div>
</section>`;

let memeTemplate = (meme) => html`
<div class="user-meme">
            <p class="user-meme-title">${meme.title}</p>
            <img class="userProfileImage" alt="meme-img" src="${meme.imageUrl}">
            <a class="button" href="/details/${meme._id}">Details</a>
        </div>`;