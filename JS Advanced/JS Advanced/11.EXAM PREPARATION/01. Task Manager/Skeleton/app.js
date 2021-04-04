function solve() {
    const sections = document.querySelectorAll('section');
    const addBtn = document.getElementById('add');
    addBtn.addEventListener('click', addTask);


    function addTask(target) {
        target.preventDefault();

        const task = document.getElementById('task').value;
        const description = document.getElementById('description').value;
        const date = document.getElementById('date').value;

        if (task == '' || description == '' || date == '') {
            return;
        }

        const element = e('article', {},
            e('h3', {}, task),
            e('p', {}, `Description: ${description}`),
            e('p', {}, `Due Date: ${date}`),
            e('div', {className: 'flex'}, 
                e('button', {className: 'green'}, 'Start'),
                e('button', {className: 'red'}, 'Delete')
            )
        );

        const divToAdd = sections[1].querySelectorAll('div')[1];
        divToAdd.appendChild(element);

    }

    function startTask(target){
        const currentArticle = target.parentNode.parentNode;
        currentArticle.querySelector('.green').remove();
        const btn = e('button', {className: 'orange'}, 'Finish');
        const divToAddBtn = currentArticle.querySelector('.flex');
        divToAddBtn.appendChild(btn);


        const divToAddArticle = document.getElementById('in-progress');
        divToAddArticle.appendChild(currentArticle);
    }

    function deleteTask(target){
        target.parentNode.parentNode.remove();
    }

    function complateTask(target){
        const currentArticle = target.parentNode.parentNode;
        target.parentNode.remove();
        const divToAppend = document.querySelector('.green').parentNode;
        divToAppend.appendChild(currentArticle);
    }



    const main = document.querySelector('main');

    main.addEventListener('click', (e) => {
        e.preventDefault();

        if (e.target.className == 'green') {
            startTask(e.target);
        }

        if (e.target.className == 'red') {
            deleteTask(e.target);
        }

        if (e.target.className == 'orange') {
            complateTask(e.target);
        }
    })






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

}