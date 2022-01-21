import { allListingsTemplate } from "./allListingsTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _carsService = undefined;

function initialize(router, renderHandler, carsService) {
    _router = router;
    _renderHandler = renderHandler;
    _carsService = carsService;
}

async function getView(context) {
    let allCars = await _carsService.getAllCars();

    let templateResult = allListingsTemplate(allCars);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}