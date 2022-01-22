import { myBooksTemplate } from "./myBooksTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _bookService = undefined;

function initialize(router, renderHandler, bookService) {
    _router = router;
    _renderHandler = renderHandler;
    _bookService = bookService;
}

async function getView(context) {
    let user = context.user;
    let myBooks = [];
    if(user !== undefined){
        myBooks = await _bookService.getMyBooks(user._id);
    }

    let model = {
        myBooks,
        user
    }

    let templateResult = myBooksTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}