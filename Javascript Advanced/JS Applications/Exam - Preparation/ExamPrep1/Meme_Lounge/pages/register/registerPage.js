import { registerTemplate } from "./registerTemplate.js";


let _router = undefined;
let _renderHandler = undefined;
let _authService = undefined;
let _form = undefined;
let _notification = undefined;

function initialize(router, renderHandler, authService, notification) {
    _router = router;
    _renderHandler = renderHandler;
    _authService = authService;
    _notification = notification;
}

async function submitHandler(e) {
    e.preventDefault();
    try {
        let formData = new FormData(e.target);
        _form.errorMessages = [];

        let username = formData.get('username');
        if (username.trim() === '') {
            _form.errorMessages.push('Username is required');
        }

        let email = formData.get('email');
        if (email.trim() === '') {
            _form.errorMessages.push('Email is required');
        }

        let password = formData.get('password');
        if (password.trim() === '') {
            _form.errorMessages.push('Password is required');
        }

        let repeatPass = formData.get('repeatPass');
        if (repeatPass.trim() === '') {
            _form.errorMessages.push('Repeat Password is required');
        }

        let gender = formData.get('gender');
        if (gender.trim() === '') {
            _form.errorMessages.push('Gender is required');
        }

        if (_form.errorMessages.length > 0) {
            //         let templateResult = registerTemplate(_form);
            //         _notification.createNotification(_form.errorMessages.join('\n'));
            return alert(_form.errorMessages.join('\n'));
            //       return _renderHandler(templateResult);
        }

        let user = {
            username,
            email,
            password,
            gender
        }

        await _authService.register(user);
        _router.redirect('/allMemes');
    } catch (err) {
        alert(err);
    }

}

async function getView(context) {
    _form = {
        submitHandler,
        errorMessages: []
    }
    let templateResult = registerTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}