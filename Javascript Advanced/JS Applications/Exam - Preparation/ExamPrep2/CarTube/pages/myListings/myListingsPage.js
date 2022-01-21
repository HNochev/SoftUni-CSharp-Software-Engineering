import { myListingsTemplate } from "./myListingsTemplate.js";


let _router = undefined;
let _renderHandler = undefined;
let _carsService = undefined;

function initialize(router, renderHandler, carsService) {
    _router = router;
    _renderHandler = renderHandler;
    _carsService = carsService;
}

async function getView(context) {
    let user = context.user;
    let myCars = [];
    if(user !== undefined){
        myCars = await _carsService.getMyCars(user._id);
    }

    let model = {
        myCars,
        user
    }

    let templateResult = myListingsTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}