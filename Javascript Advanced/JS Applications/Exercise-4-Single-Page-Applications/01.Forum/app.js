let container = document.querySelector(".container");
let form = document.querySelector("div.new-topic-border form");
let main = document.querySelector("main");
let homeBtn = document.querySelector("nav li:nth-child(1)");
homeBtn.addEventListener("click", mainView);

form.addEventListener("submit", async (ev) => {
    ev.preventDefault();
    let data = Object.fromEntries(new FormData(form));

    if (Object.values(data).some((e) => e === "")) {
        console.log("empty");
        return;
    }
    form.reset();

    try {
        let url = "http://localhost:3030/jsonstore/collections/myboard/posts";
        data.datePosted = new Date().toUTCString();
        let result = await fetch(url, {
            method: "post",
            body: JSON.stringify(data),
        });

        if (result.ok) {
            result = await result.json();
        } else {
            throw new Error(result.statusText);
        }

        let post = makePost(result);

        let div = document.querySelector("div.topic-title");
        div.appendChild(post);
    } catch (error) {
        console.error(error);
    }
});

(async function populatePosts() {
    let url = "http://localhost:3030/jsonstore/collections/myboard/posts";
    let posts = await fetch(url).then((r) => r.json());

    posts = Object.values(posts).reduce((acc, post) => {
        acc.push(makePost(post));
        return acc;
    }, []);
    document.querySelector("div.topic-title").innerHTML = "";
    document.querySelector("div.topic-title").append(...posts);
})();

async function postOnClick(ev) {
    if (ev.target.tagName !== "H2") {
        return;
    }
    let urlComment = "http://localhost:3030/jsonstore/collections/myboard/comments";
    let urlPost = "http://localhost:3030/jsonstore/collections/myboard/posts";
    let itemId = ev.target.dataset.id;

    let [infoP, infoC] = await Promise.all([
        fetch(`${urlPost}/${itemId}`).then((r) => r.json()),
        fetch(`${urlComment}`).then((r) => r.json()),
    ]);

    commentView(infoP, infoC);
}

function mainView() {
    container.innerHTML = "";
    container.appendChild(main);
}

function commentView(infoP, infoC) {
    main.remove();
    let themeTitle = e(
        "div",
        {},
        ["theme-title"],
        {},
        e(
            "div",
            {},
            ["theme-name-wrapper"],
            {},
            e("div", {}, ["theme-name"], {}, e("h2", {}, [], {}, infoP.topicName))
        )
    );
    let themeComments = e(
        "div",
        {},
        ["comment"],
        {},
        makeComentHeader(infoP),

        e(
            "div",
            { id: "user-comment" },
            [],
            {},
            ...Object.values(infoC)
                .filter((ce) => infoP._id === ce.originId)
                .map((ce) => makeUserComent(ce))
        )
    );

    let answerForm = e(
        "div",
        {},
        ["answer-comment"],
        {},
        e(
            "p",
            {},
            [],
            {},
            e("span", {}, [], {}, "currentUser"),
            document.createTextNode(" comment:"),
            e(
                "div",
                {},
                ["answer"],
                {},
                e(
                    "form",
                    {},
                    [],
                    {},
                    e("textarea", { name: "postText", id: "comment", cols: 30, rows: 10 }, [], {}, ""),
                    e(
                        "div",
                        {},
                        [],
                        {},
                        e(
                            "label",
                            { for: "username" },
                            [],
                            {},
                            document.createTextNode("Username "),
                            e("span", {}, ["red"], {}, "*")
                        ),
                        e("input", { type: "text", name: "username", id: "username" }, [], {}, "")
                    ),
                    e("button", {}, [], {}, "Post")
                )
            )
        )
    );

    let themeDiv = e("div", {}, ["theme-content"], {}, themeTitle, themeComments, answerForm);

    let commentForm = answerForm.querySelector("form");
    commentForm.addEventListener("submit", commentFormHandler.bind(commentForm, infoP));

    container.appendChild(themeDiv);
}

async function commentFormHandler(infP, ev) {
    ev.preventDefault();
    let data = new FormData(ev.target);

    let commentText = data.get("postText");
    let username = data.get("username");

    if (commentText === "" || username === "") {
        return;
    }

    let res = await fetch(`http://localhost:3030/jsonstore/collections/myboard/comments`, {
        headers: {
            "Content-Type": "Application/Json",
        },
        method: "post",
        body: JSON.stringify({
            username,
            commentText,
            originId: infP._id,
            dateCommented: new Date().toUTCString(),
        }),
    });

    if (res.ok) {
        res = await res.json();
        console.log(res);
        document.querySelector("#user-comment").appendChild(makeUserComent(res));
    }
    ev.target.reset();
}

function makeComentHeader(data) {
    let timeElement = e("time", {}, [], {}, data.datePosted);
    let spanElement = e("span", {}, [], {}, data.username);
    let pElement = e(
        "p",
        {},
        [],
        {},
        spanElement,
        document.createTextNode(" posted on"),
        timeElement
    );

    let header = e(
        "div",
        {},
        ["header"],
        {},
        e("img", { src: "./static/profile.png", alt: "avatar" }, [], {}, ""),
        pElement,
        e("p", {}, ["post-content"], {}, data.postText)
    );

    return header;
}

function makeUserComent(data) {
    let pElement = e(
        "p",
        {},
        [],
        {},
        e("span", {}, [], {}, data.username),
        document.createTextNode(" commented on"),
        e("time", {}, [], {}, data.dateCommented)
    );

    let result = e(
        "div",
        {},
        ["topic-name-wrapper"],
        {},
        e(
            "div",
            {},
            ["topic-name"],
            {},
            pElement,
            e("div", {}, ["post-content"], {}, e("p", {}, [], {}, data.commentText))
        )
    );

    return result;
}

function makePost(info) {
    return e(
        "div",
        {},
        ["topic-container"],
        { click: postOnClick },
        e(
            "div",
            {},
            ["topic-name-wrapper"],
            {},
            e(
                "div",
                {},
                ["topic-name"],
                {},
                e(
                    "a",
                    { href: "#" },
                    ["normal"],
                    {},
                    e("h2", { "data-id": info._id }, [], {}, info.topicName)
                ),
                e(
                    "div",
                    {},
                    ["columns"],
                    {},
                    e(
                        "div",
                        {},
                        [],
                        {},
                        e(
                            "p",
                            {},
                            [],
                            {},
                            document.createTextNode("Date "),
                            e("time", {}, [], {}, info.datePosted)
                        ),
                        e(
                            "div",
                            {},
                            ["nick-name"],
                            {},
                            e(
                                "p",
                                {},
                                [],
                                {},
                                document.createTextNode("Username: "),
                                e("span", {}, [], {}, info.username)
                            )
                        )
                    )
                )
            )
        )
    );
}

function e(tag, attr, classes, listeners, ...content) {
    let result = document.createElement(tag);
    if (Object.values(attr).length > 0) {
        Object.entries(attr).forEach(([ent, val]) => {
            result.setAttribute(ent, val);
        });
    }

    if (classes.length > 0) {
        classes.forEach((c) => result.classList.add(c));
    }

    if (Object.values(listeners).length > 0) {
        Object.entries(listeners).forEach(([typ, lis]) => {
            result.addEventListener(typ, lis);
        });
    }

    content.forEach((c) => {
        if (typeof c === "string" || typeof c === "number") {
            result.innerText = c;
        } else {
            result.appendChild(c);
        }
    });
    return result;
}