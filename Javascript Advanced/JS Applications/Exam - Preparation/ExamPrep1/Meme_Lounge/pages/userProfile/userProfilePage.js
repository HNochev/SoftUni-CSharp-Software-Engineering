import { userProfileTemplate } from "./userProfileTemplate.js";


let _router = undefined;
let _renderHandler = undefined;
let _memeService = undefined;

function initialize(router, renderHandler, memeService) {
    _router = router;
    _renderHandler = renderHandler;
    _memeService = memeService;
}

async function getView(context) {
    let user = context.user;
    let myMemes = [];
    if(user !== undefined){
        myMemes = await _memeService.getMyMemes(user._id);
    }

    let model = {
        myMemes,
        user
    }

    let templateResult = userProfileTemplate(model);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}