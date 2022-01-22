import { dashboardTemplate } from "./dashboardTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _bookService = undefined;

function initialize(router, renderHandler, bookService) {
    _router = router;
    _renderHandler = renderHandler;
    _bookService = bookService;
}

async function getView(context) {
    let allBooks = await _bookService.getAllBooks();

    let templateResult = dashboardTemplate(allBooks);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}