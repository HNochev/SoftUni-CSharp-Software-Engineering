import { editTemplate } from "./editTemplate.js";

let _router = undefined;
let _renderHandler = undefined;
let _memeService = undefined;
let _form = undefined;
let _notification = undefined;

function initialize(router, renderHandler, memeService, notification) {
    _router = router;
    _renderHandler = renderHandler;
    _memeService = memeService;
    _notification = notification;
}

async function submitHandler(id, e) {
    e.preventDefault();
    try {
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let title = formData.get('title');
        if (title.trim() === '') {
            _form.errorMessages.push('Title is required');
        }

        let description = formData.get('description');
        if (description.trim() === '') {
            _form.errorMessages.push('Description is required');
        }

        let imageUrl = formData.get('imageUrl');
        if (imageUrl.trim() === '') {
            _form.errorMessages.push('Image Url is required');
        }

        if (_form.errorMessages.length > 0) {
            //     let templateResult = editTemplate(_form);
            //    _notification.createNotification(_form.errorMessages.join('\n'));
            return alert(_form.errorMessages.join('\n'));
            //     return _renderHandler(templateResult);
        }

        let meme = {
            title,
            description,
            imageUrl
        }

        await _memeService.update(meme, id);
        _router.redirect(`/details/${id}`);
    } catch (err) {
        alert(err);
    }

}

async function getView(context) {
    let id = context.params.memeId;
    let meme = await _memeService.get(id);

    _form = {
        submitHandler,
        errorMessages: [],
        meme
    }
    let templateResult = editTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}