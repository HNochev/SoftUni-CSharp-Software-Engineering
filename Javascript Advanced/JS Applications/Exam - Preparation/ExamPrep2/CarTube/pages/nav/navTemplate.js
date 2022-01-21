import { html } from "./../../node_modules/lit-html/lit-html.js";

export let navTemplate = (nav) => html`
<nav>
    <a class="active" href="/home">Home</a>
    <a href="/allListings">All Listings</a>
    <a href="/searchPage">By Year</a>
    ${nav.isLoggedIn
        ? loggedControls(nav)
        : guestControls()} 
</nav>`;

let loggedControls = (nav) => html`
    <div id="profile">
        <a>Welcome ${nav.username}</a>
        <a href="/myListings">My Listings</a>
        <a href="/create">Create Listing</a>
        <a href="javascript:void(0)" @click=${nav.logoutHandler}>Logout</a>
    </div>`;

let guestControls = () => html`
<div id="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>`;