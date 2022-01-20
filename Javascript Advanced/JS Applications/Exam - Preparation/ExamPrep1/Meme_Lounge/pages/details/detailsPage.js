import { detailsTemplate } from "./detailsTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _memeService = undefined;

function initialize(router, renderHandler, memeService) {
    _router = router;
    _renderHandler = renderHandler;
    _memeService = memeService;
}

async function deleteHandler(id, e){
    try{
        await _memeService.deleteItem(id);
        _router.redirect('/allMemes');
    } catch(err){
        alert(err);
    }
}

async function getView(context) {
    let id = context.params.id;
    let meme = await _memeService.get(id);
    let user = context.user;
    let isOwner = false;
    if(user !== undefined && user._id === meme._ownerId){
        isOwner = true;
    }
    let model = {
        meme,
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