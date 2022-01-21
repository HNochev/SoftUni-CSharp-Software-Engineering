import { editTemplate } from "./editTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _carsService = undefined;
let _form = undefined;
let _notification = undefined;

function initialize(router, renderHandler, carsService, notification) {
    _router = router;
    _renderHandler = renderHandler;
    _carsService = carsService;
    _notification = notification;
}

async function submitHandler(id, e) {
    e.preventDefault();
    try {
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let brand = formData.get('brand');
        if (brand.trim() === '') {
            _form.errorMessages.push('Brand is required');
        }

        let model = formData.get('model');
        if (model.trim() === '') {
            _form.errorMessages.push('Model is required');
        }

        let description = formData.get('description');
        if (description.trim() === '') {
            _form.errorMessages.push('Description is required');
        }

        let year = formData.get('year');
        if (year.trim() === '') {
            _form.errorMessages.push('Year is required');
        }

        let imageUrl = formData.get('imageUrl');
        if (imageUrl.trim() === '') {
            _form.errorMessages.push('Image Url is required');
        }

        let price = formData.get('price');
        if (price.trim() === '') {
            _form.errorMessages.push('Price is required');
        }

        if (_form.errorMessages.length > 0) {
            //     let templateResult = editTemplate(_form);
            //    _notification.createNotification(_form.errorMessages.join('\n'));
            return alert(_form.errorMessages.join('\n'));
            //     return _renderHandler(templateResult);
        }

        year = Number(year);
        price = Number(price);

        let car = {
            brand,
            model,
            description,
            year,
            imageUrl,
            price

        }

        await _carsService.update(car, id);
        _router.redirect(`/details/${id}`);
    } catch (err) {
        alert(err);
    }

}

async function getView(context) {
    let id = context.params.carId;
    let car = await _carsService.get(id);

    _form = {
        submitHandler,
        errorMessages: [],
        car
    }
    let templateResult = editTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}