function encodeAndDecodeMessages() {
    const html = {
        firstTextarea: document.querySelectorAll('textarea')[0],
        secondTextarea: document.querySelectorAll('textarea')[1],
        decoder: function (text, code) {
            let decodeMessage = ''
            for (let i = 0; i < text.length; i++) {
                decodeMessage += `${String.fromCharCode(text.charCodeAt(i) + code)}`
            }
            return decodeMessage
        }
    }

    document.querySelectorAll('button')[0].addEventListener('click', function () {
        html.secondTextarea.value = html.decoder(html.firstTextarea.value, 1)
        html.firstTextarea.value = ''
    })

    document.querySelectorAll('button')[1].addEventListener('click', function () {
        html.secondTextarea.value = html.decoder(html.secondTextarea.value, -1)
    })
}