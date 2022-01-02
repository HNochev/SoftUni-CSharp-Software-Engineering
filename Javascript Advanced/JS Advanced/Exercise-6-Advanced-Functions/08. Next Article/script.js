function getArticleGenerator(articles) {
    let container = document.querySelector('#content');
    return function () {
        if (articles.length > 0) {
            let createArticle = document.createElement('article');
            let text = articles.shift();
            createArticle.textContent = text;
            container.appendChild(createArticle);
        }
    }
}