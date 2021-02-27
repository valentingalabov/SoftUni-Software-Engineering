function getArticleGenerator(articles) {
    let content = document.querySelector('#content');
    let counter = 0;

    return function showNext() {
        if (counter > articles.length-1 || articles[counter] == '') {
            return;
        }
        let article = document.createElement("article");
        article.textContent = articles[counter];
        article.style.border = "thick solid #0000FF"
        content.appendChild(article);
        counter++;

    }




}

