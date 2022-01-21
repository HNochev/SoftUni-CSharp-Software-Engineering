import page from "./node_modules/page/page.mjs";
import allListingsPage from "./pages/allListings/allListingsPage.js";
import createPage from "./pages/create/createPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import editPage from "./pages/edit/editPage.js";
import homePage from "./pages/home/homePage.js";
import loginPage from "./pages/login/loginPage.js";
import myListingsPage from "./pages/myListings/myListingsPage.js";
import nav from "./pages/nav/nav.js";
import registerPage from "./pages/register/registerPage.js";
import searchPage from "./pages/searchPage/searchPage.js";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import carsService from "./services/carsService.js";

let navElement = document.getElementById('header');
let appElement = document.getElementById('site-content');

let renderer = new LitRenderer();

let navRendererHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement)

nav.initialize(page, navRendererHandler, authService);
homePage.initialize(page, appRenderHandler, authService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
allListingsPage.initialize(page, appRenderHandler, carsService);
createPage.initialize(page, appRenderHandler, carsService);
detailsPage.initialize(page, appRenderHandler, carsService);
editPage.initialize(page, appRenderHandler, carsService);
myListingsPage.initialize(page, appRenderHandler, carsService);
searchPage.initialize(page, appRenderHandler, carsService);


page('/index.html', '/home');
page('/', '/home');

page(decorateContextWithUser);
page(nav.getView);

page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/allListings', allListingsPage.getView);
page('/create', createPage.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:carId', editPage.getView);
page('/myListings', myListingsPage.getView);
page('/searchPage', searchPage.getView);


page.start();

function decorateContextWithUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}