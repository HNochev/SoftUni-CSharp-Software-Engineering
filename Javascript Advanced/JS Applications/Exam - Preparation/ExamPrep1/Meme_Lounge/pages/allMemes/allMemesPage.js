import { allMemesTemplate } from "./allMemesTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _memeServise = undefined;

function initialize(router, renderHandler, memeServise) {
    _router = router;
    _renderHandler = renderHandler;
    _memeServise = memeServise;
}

async function getView(context) {
    let allMemes = await _memeServise.getAllMemes();

    let templateResult = allMemesTemplate(allMemes);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}