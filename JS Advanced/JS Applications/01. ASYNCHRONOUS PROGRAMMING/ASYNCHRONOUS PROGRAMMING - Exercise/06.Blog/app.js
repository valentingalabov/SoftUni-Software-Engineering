const viewBtn = document.getElementById('btnViewPost');
function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click', getPosts);
    
    viewBtn.addEventListener('click', displayPost);
    viewBtn.disabled = true;

}

attachEvents();

async function getPosts() {
    viewBtn.disabled = false;
    const select = document.getElementById('posts');
    select.innerHTML = '';
    const url = `http://localhost:3030/jsonstore/blog/posts`;

    const response = await fetch(url);
    const data = await response.json();


    Object.values(data).map(createOption).forEach(o => select.appendChild(o));
}

function createOption(post) {
    const result = document.createElement('option');
    result.textContent = post.title;
    result.value = post.id;

    return result;
}

function displayPost() {
    const postId = document.getElementById('posts').value;

    getCommentsByPostId(postId);
}

async function getCommentsByPostId(postId) {
    const commentsUi = document.getElementById('post-comments');
    commentsUi.innerHTML = '';
    
    const postUrl = `http://localhost:3030/jsonstore/blog/posts/${postId}`;
    const commentUrl = `http://localhost:3030/jsonstore/blog/comments`;

    const [postReponse, commentsResponse] = await Promise.all([
        fetch(postUrl),
        fetch(commentUrl)
    ]);


    const postData = await postReponse.json();

    document.getElementById('post-title').textContent = postData.title;
    document.getElementById('post-body').textContent = postData.body;


    const commentsData = await commentsResponse.json();

    const comments = Object.values(commentsData).filter(c => c.postId == postId);


    comments.map(createComment).forEach(c => commentsUi.appendChild(c));


}

function createComment(comment) {
    const result = document.createElement('li');
    result.textContent = comment.text
    result.id = comment.idl
    return result;
}