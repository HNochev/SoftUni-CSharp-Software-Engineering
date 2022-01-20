import page from "./node_modules/page/page.mjs";
import allMemesPage from "./pages/allMemes/allMemesPage.js";
import createPage from "./pages/create/createPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import editPage from "./pages/edit/editPage.js";
import homePage from "./pages/home/homePage.js";
import loginPage from "./pages/login/loginPage.js";
import nav from "./pages/nav/nav.js";
import registerPage from "./pages/register/registerPage.js";
import userProfilePage from "./pages/userProfile/userProfilePage.js";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import memeService from "./services/memeService.js";



let navElement = document.getElementById('nav');
let appElement = document.getElementById('mainArea');

let renderer = new LitRenderer();

let navRendererHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement);

nav.initialize(page, navRendererHandler, authService);
homePage.initialize(page, appRenderHandler, authService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
allMemesPage.initialize(page, appRenderHandler, memeService);
createPage.initialize(page, appRenderHandler, memeService);
detailsPage.initialize(page, appRenderHandler, memeService);
editPage.initialize(page, appRenderHandler, memeService);
userProfilePage.initialize(page, appRenderHandler, memeService);

page('/index.html', '/home');
page('/', '/home');

page(decorateContextWithUser);
page(nav.getView);

page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/allMemes', allMemesPage.getView);
page('/create', createPage.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:memeId', editPage.getView);
page('/myProfile', userProfilePage.getView);


page.start();

function decorateContextWithUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}