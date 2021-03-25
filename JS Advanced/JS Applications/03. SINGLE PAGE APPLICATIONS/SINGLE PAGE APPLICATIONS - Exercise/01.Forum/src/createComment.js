import { showDetails } from "./details.js";

async function onSubmit(event) {
    event.preventDefault();
    const form = event.target;

    const formData = new FormData(form);

    const comment = formData.get('comment');
    const username = formData.get('username');
    const date = new Date().toLocaleString();

    if (comment == '' || username == '') {
        return alert('All fields are required!');
    }


    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ topicId ,comment, username, date })
    });

    if (response.ok) {
        document.getElementById('comment').value = '';
        document.getElementById('username').value = '';
     
       showDetails(event, topicId);

    } else {
        const error = await response.json();
        alert(error.message);
    }

}

let main;
let section;
let topicId;

export function setupCreateConmment(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    const from = section.querySelector('form');
    from.addEventListener('submit', onSubmit);
}

export function showCreateComment(id) {
    main.appendChild(section);
    topicId = id;

}