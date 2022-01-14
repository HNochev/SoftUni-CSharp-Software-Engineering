function attachEvents() {
    document.querySelector('#btnLoadPosts').addEventListener('click', getPosts);
    document.querySelector('#btnViewPost').addEventListener('click', display);
}
async function getPosts() {
    const url = `http://localhost:3030/jsonstore/blog/posts`
    const response = await fetch(url);
    const data = await response.json();
    const selectOption = document.getElementById('posts');
    Object.values(data).map(makeAnOption).forEach(x => selectOption.appendChild(x));

}

function makeAnOption(post) {
    const option = document.createElement('option');
    option.textContent = post.title;
    option.value = post.id;
    return option;
}

function display() {
    const postId = document.getElementById('posts').value;
    postComments(postId)
}
async function postComments(postId) {
    const postResponse = await fetch(`http://localhost:3030/jsonstore/blog/posts/` + postId);
    const postData = await postResponse.json();

    document.querySelector('#post-title').textContent = postData.title;
    document.querySelector('#post-body').textContent = postData.body;

    const url = `http://localhost:3030/jsonstore/blog/comments`;
    const response = await fetch(url);
    const data = await response.json();
    const comments = Object.values(data).filter(i => i.postId == postId);
    const commentsUl = document.getElementById('post-comments');
    comments.map(createComment).forEach(c => commentsUl.appendChild(c));
}

function createComment(comment) {
    const res = document.createElement('li');
    res.textContent = comment.text;
    res.id = comment.id;
    return res
}
attachEvents();