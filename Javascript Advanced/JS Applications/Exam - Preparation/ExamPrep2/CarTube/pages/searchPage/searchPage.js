import { searchPageTemplate } from "./serchPageTemplate.js";


let _router = undefined;
let _renderHandler = undefined;
let _carsService = undefined;

function initialize(router, renderHandler, carsService) {
    _router = router;
    _renderHandler = renderHandler;
    _carsService = carsService;
}

async function getView(context) {
    let currentSearch = '';
    let allCars = [];

    const onSearch = (e) => {
        let year = Number(currentSearch);


        _carsService.searchCars(year)
            .then(cars => {
                templateResult = searchPageTemplate(cars, onSearch);
                _renderHandler(templateResult);
            })
    }
    
    let templateResult = searchPageTemplate(allCars, onSearch);
    _renderHandler(templateResult);




    //  let buttonElement = document.querySelector('.button-list');


    //  buttonElement.addEventListener('click', (e) => {
    //      year = document.getElementById('search-input').value;

    //      getView(context);
};


export default {
    getView,
    initialize
}