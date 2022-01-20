import { html } from "./../../node_modules/lit-html/lit-html.js";

export let navTemplate = (nav) => html`
    <a href="/allMemes">All Memes</a>
    ${nav.isLoggedIn
        ? loggedControls(nav)
        : guestControls()}`;

let loggedControls = (nav) => html`
<div class="user">
    <a href="/create">Create Meme</a>
    <div class="profile">
        <span>Welcome, ${nav.email}</span>
        <a href="myProfile">My Profile</a>
        <a href="javascript:void(0)" @click=${nav.logoutHandler}>Logout</a>
    </div>
</div>`;

let guestControls = () => html`
<div class="guest">
        <div class="profile">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>
        <a class="active" href="/home">Home Page</a>
    </div>`;