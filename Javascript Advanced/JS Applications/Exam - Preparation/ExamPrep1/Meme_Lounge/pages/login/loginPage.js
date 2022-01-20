import { loginTemplate } from "./loginTemplate.js";

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

        let email = formData.get('email');

        if (email.trim() === '') {
            _form.errorMessages.push('Email is required');
        }

        let password = formData.get('password');

        if (password.trim() === '') {
            _form.errorMessages.push('Password is required');
        }

        if (_form.errorMessages.length > 0) {
           // let templateResult = loginTemplate(_form);
           // _form.errorMessages.forEach(x => _notification.createNotification(x));
            // _notification.createNotification(_form.errorMessages.join('\n'));
            return alert(_form.errorMessages.join('\n'));
           // return _renderHandler(templateResult);
        }

        let user = {
            email,
            password
        }

        let loginResult = await _authService.login(user);
        _router.redirect('/allMemes');
    } catch (err) {
        //       _notification.createNotification(`Error: ${err.message}`);

    }

}

async function getView(context) {
    _form = {
        submitHandler,
        //        errorMessages: []
    }
    let templateResult = loginTemplate(_form);
    _renderHandler(templateResult);
}

export default {
    getView,
    initialize
}