function extractText() {
    let texts = document.querySelectorAll('ul#items li');
    let textBoxContent = document.getElementById('result');

    let result = '';

    for (const text of texts) {
        result = result + text.textContent + '\n';
    }

    textBoxContent.value = result.trim();
}