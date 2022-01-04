function solve(htmlObject) {
    validateMethod(htmlObject);
    validateUri(htmlObject);
    validateVersion(htmlObject);
    validateMessage(htmlObject);

    return htmlObject;

    function validateMessage(htmlObject) {
        let propName = 'message';
        let messageRegex = /^[^<>\\&'"]*$/;

        if (htmlObject[propName] === undefined || !messageRegex.test(htmlObject[propName])) {
            throw new Error('Invalid request header: Invalid Message');
        }
    }

    function validateMethod(htmlObject) {
        let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
        let propName = 'method';

        if (htmlObject[propName] === undefined || !validMethods.includes(htmlObject[propName])) {
            throw new Error('Invalid request header: Invalid Method');
        }
    }

    function validateUri(htmlObject) {
        let propName = 'uri';
        let uriRegex = /^\*$|^[a-zA-z0-9.]+$/;

        if (htmlObject[propName] === undefined || !uriRegex.test(htmlObject[propName])) {
            throw new Error('Invalid request header: Invalid URI');
        }
    }

    function validateVersion(htmlObject) {
        let validVersion = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
        let propName = 'version';

        if (htmlObject[propName] === undefined || !validVersion.includes(htmlObject[propName])) {
            throw new Error('Invalid request header: Invalid Version');
        }
    }
}


try {
    console.log(solve({
        method: 'POST',
        uri: 'home.bash',
        message: 'rm -rf /*'
    }
    ));
} catch (error) {
    console.log(error.message);
}