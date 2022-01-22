import { html } from "./../../node_modules/lit-html/lit-html.js";

export let navTemplate = (nav) => html`
<nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/dashboard">Dashboard</a>
        ${nav.isLoggedIn
        ? loggedControls(nav)
        : guestControls()} 
    </section>
</nav>`;

let loggedControls = (nav) => html`
<!-- Logged-in users -->
        <div id="user">
            <span>Welcome, ${nav.email}</span>
            <a class="button" href="/myBooks">My Books</a>
            <a class="button" href="/create">Add Book</a>
            <a class="button" href="javascript:void(0)" @click=${nav.logoutHandler}>Logout</a>
        </div>`;

let guestControls = () => html`
<!-- Guest users -->
        <div id="guest">
            <a class="button" href="/login">Login</a>
            <a class="button" href="/register">Register</a>
        </div>`;