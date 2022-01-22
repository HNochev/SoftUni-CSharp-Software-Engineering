import page from "./node_modules/page/page.mjs";
import createPage from "./pages/create/createPage.js";
import dashboardPage from "./pages/dashboard/dashboardPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import editPage from "./pages/edit/editPage.js";
import loginPage from "./pages/login/loginPage.js";
import myBooksPage from "./pages/myBooks/myBooksPage.js";
import nav from "./pages/nav/nav.js";
import registerPage from "./pages/register/registerPage.js";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import bookService from "./services/bookService.js";


let navElement = document.getElementById('site-header');
let appElement = document.getElementById('site-content');

let renderer = new LitRenderer();

let navRendererHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement)

nav.initialize(page, navRendererHandler, authService);
dashboardPage.initialize(page, appRenderHandler, bookService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
createPage.initialize(page, appRenderHandler, bookService);
detailsPage.initialize(page, appRenderHandler, bookService);
editPage.initialize(page, appRenderHandler, bookService);
myBooksPage.initialize(page, appRenderHandler, bookService);

page('/index.html', '/dashboard');
page('/', '/dashboard');

page(decorateContextWithUser);
page(nav.getView);

page('/dashboard', dashboardPage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/create', createPage.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:bookId', editPage.getView);
page('/myBooks', myBooksPage.getView);

page.start();

function decorateContextWithUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}