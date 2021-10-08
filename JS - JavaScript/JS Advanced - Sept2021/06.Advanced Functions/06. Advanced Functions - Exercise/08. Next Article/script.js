function getArticleGenerator(articles) {
    const arr = articles;
    const content = document.getElementById('content');

    function showNext() {
        if (arr.length > 0) {
            const article = document.createElement('article');
            article.textContent = arr.shift();

            content.appendChild(article);
        }
    }

    return showNext;
}
