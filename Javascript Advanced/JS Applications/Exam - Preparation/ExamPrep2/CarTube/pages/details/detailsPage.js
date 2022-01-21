import { detailsTemplate } from "./detailsTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _carsService = undefined;

function initialize(router, renderHandler, carsService) {
    _router = router;
    _renderHandler = renderHandler;
    _carsService = carsService;
}

async function deleteHandler(id, e){
    try{
        await _carsService.deleteItem(id);
        _router.redirect('/allListings');
    } catch(err){
        alert(err);
    }
}

async function getView(context) {
    let id = context.params.id;
    let car = await _carsService.get(id);
    let user = context.user;
    let isOwner = false;
    if(user !== undefined && user._id === car._ownerId){
        isOwner = true;
    }
    let modell = {
        car,
        deleteHandler,
        isOwner
    };
    let templateResult = detailsTemplate(modell);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}