import { detailsTemplate } from "./detailsTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _bookService = undefined;

function initialize(router, renderHandler, bookService) {
    _router = router;
    _renderHandler = renderHandler;
    _bookService = bookService;
}

async function deleteHandler(id, e){
    try{
        await _bookService.deleteItem(id);
        _router.redirect('/dashboard');
    } catch(err){
        alert(err);
    }
}

async function getView(context) {
    let id = context.params.id;
    let book = await _bookService.get(id);
    let user = context.user;
    let isOwner = false;
    if(user !== undefined && user._id === book._ownerId){
        isOwner = true;
    }
    let model = {
        book,
        deleteHandler,
        isOwner
    };
    let templateResult = detailsTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}