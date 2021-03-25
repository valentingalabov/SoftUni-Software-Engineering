import { showCreateComment } from "./createComment.js";
import { e } from "./dom.js";
async function getTopicById(id) {

    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts/' + id);

    const data = await response.json();

    return data;
}
async function getComments(id) {
    const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments/');

    const data = await response.json();

    const comments = Object.values(data).filter(c => c.topicId == id)

    return comments;

}

function createCommentElement(comment) {
    /* <div id="user-comment">
    <div class="topic-name-wrapper">
        <div class="topic-name">
            <p><strong>Daniel</strong> commented on <time>3/15/2021, 12:39:02 AM</time></p>
            <div class="post-content">
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Iure facere sint
                    dolorem quam.</p>
            </div>
        </div>
    </div>
</div> */
    const el = e('div', { id: 'user-comment' },
        e('div', { className: 'topic-name-wrapper' },
            e('div', { className: 'topic-name' },
                e('p', {},),
                e('div', { className: 'post-content' },
                    e('p', {}, comment.comment))
            )
        )
    );
    const p = el.querySelector('p');
    p.innerHTML = `<strong>${comment.username}</strong> commented on <time>${comment.date}</time>`

    return el;


}


let main;
let section;

export function setupDetails(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function showDetails(e, id) {
    e.preventDefault();
    main.innerHTML = '';
    main.appendChild(section);

    const topic = await getTopicById(id)

    const paragraphs = section.querySelectorAll('p');
    const p1 = paragraphs[0];
    p1.innerHTML = `<span>${topic.username}</span> posted on <time>${topic.date}</time>`;

    const p2 = paragraphs[1];
    p2.textContent = topic.post;

    const comments = await getComments(id);

    const itemsToAppend = comments.map(createCommentElement);

    const divToAddComment = document.getElementById('add-comment');
    divToAddComment.innerHTML = '';
    
    itemsToAppend.forEach(element => {
        divToAddComment.appendChild(element);
    });

    main.child = showCreateComment(id);

}