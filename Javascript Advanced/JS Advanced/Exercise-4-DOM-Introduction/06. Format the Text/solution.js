function solve() {
  let textAreaElement = document.getElementById('input');

  let text = textAreaElement.value.trim();

  let sentences = text.split('.').filter(x => x).map(x => x + '.');

  let paragraphSentences = [];

  let paragraphsAll = Math.ceil(sentences.length / 3);

  let result = document.getElementById('output');

  for (let i = 0; i < paragraphsAll; i++) {
    result.innerHTML = result.innerHTML + `<p>${sentences.splice(0, 3).join('')}</p>`
  }
}