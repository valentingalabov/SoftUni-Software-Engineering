import { showDetails } from './details.js';
import { e } from './dom.js';


async function getAllTopics() {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    const data = await response.json();
    return data;
}

async function onSubmit(event) {
    event.preventDefault();

    let title = document.getElementById('topicName');
    let username = document.getElementById('username');
    let post = document.getElementById('postText');
    let dateNow = new Date().toLocaleString();

    const topic = {
        title: title.value,
        post: post.value,
        username: username.value,
        date: dateNow.toString()
    };

    if (topic.title == '' || topic.username == '' || topic.post == '') {
        return alert('All fields are required!');
    }


    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(topic)
    });

    if (response.ok) {

        const topics = await response.json();
        document.getElementById('topicName').value = '';
        document.getElementById('username').value = '';
        document.getElementById('postText').value = '';
        showHome();

    } else {
        const error = await response.json();
        alert(error.message);
    }

}

function createTopicPreview(topic) {
    const el = e('div', { className: 'topic-title' },
        e('div', { className: 'topic-container' },
            e('div', { className: 'topic-name-wrapper' },
                e('div', { className: 'topic-name' },
                    e('a', { className: 'normal', href: '#', onClick: (e) => showDetails(e, topic._id) },
                        e('h2', {}, topic.title)
                    ),
                    e('div', { className: 'columns' },
                        e('div', {},
                            e('p', {}, 'Date: '),
                            e('div', { className: 'nick-name' },
                                e('p', {}, 'Username: '))))))));

    const p = el.querySelector('p');
    const time = e('time', {}, topic.date);
    p.appendChild(time);

    const p1 = el.querySelectorAll('p')[1];
    const span = e('span', {}, topic.username);
    p1.appendChild(span);

    return el;

}

let main;
let section;


export function setupHome(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    const cancel = section.querySelector('.cancel');

    cancel.addEventListener('click', (e) => {
        e.preventDefault();
        document.getElementById('topicName').value = '';
        document.getElementById('username').value = '';
        document.getElementById('postText').value = '';
    });

    const form = section.querySelector('.public');
    form.addEventListener('click', onSubmit);


}


export async function showHome() {
    // container.innerHTML = 'Loading&hellip;';
    main.innerHTML = '';
    main.appendChild(section);

    const topics = await getAllTopics();

    const elementsToAppend = Object.values(topics).map(createTopicPreview);



    elementsToAppend.forEach(element => {
        main.appendChild(element);
    });
}