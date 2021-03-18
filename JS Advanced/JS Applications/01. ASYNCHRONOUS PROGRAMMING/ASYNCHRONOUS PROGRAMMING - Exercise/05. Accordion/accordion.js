async function solution() {

    const articles = await getArticle();


    for (const a of articles) {
        const result = await details(a._id);


        const element = e('div', { className: 'accordion' },
            e('div', { className: 'head' },
                e('span', {}, result.title),
                e('button', { className: 'button', id: result._id }, 'More'),
            ),
            e('div', { className: 'extra' },
                e('p', {}, result.content)
            )

        );

        const main = document.getElementById('main');
        main.appendChild(element);
    }

    const btns = [...document.getElementsByTagName('button')];

    btns.forEach(btn => btn.addEventListener('click', showHide));

}

solution();

function showHide(event) {
    const button = event.target;
    const headDiv = button.parentNode;
    const accordionDiv = headDiv.parentNode;
    const divToChange = accordionDiv.getElementsByTagName('div')[1];

    if (button.value === 'Less') {
        button.value = 'More';
        divToChange.style.display = 'none';
    }
    else {
        button.value ='Less';
        divToChange.style.display = 'block'
    }

}

async function getArticle() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';

    const response = await fetch(url);
    const data = await response.json();
    return data;
}
async function details(id) {
    const currUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
    const detailResponse = await fetch(currUrl);
    const data = await detailResponse.json();
    return data;
}


function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}