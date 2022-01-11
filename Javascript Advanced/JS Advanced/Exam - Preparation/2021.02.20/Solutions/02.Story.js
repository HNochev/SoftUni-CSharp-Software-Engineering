class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }

        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this story!`;
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error("You can't like the same story twice!");
        }

        if (username === this.creator) {
            throw new Error("You can't like your own story!");
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error("You can't dislike this story!");
        }

        this._likes = this._likes.filter(x => x !== username);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {

        if (this._comments.some(x => x.id === id)) {

            let currComment = this._comments.filter(x => x.id == id)[0];

            let replyObj = {
                id: undefined,
                username: username,
                content: content,
            };

            if (replyObj.id === undefined) {
                replyObj.id = `${currComment.id}.${currComment.replies.length + 1}`;
            }

            currComment.replies.push(replyObj);
            return `You replied successfully`;
        }

        if (id === undefined || !this._comments.some(x => x.id === id)) {
            let commentObj = {
                id: undefined,
                username: username,
                content: content,
                replies: [],
            };

            if (commentObj.id === undefined) {
                commentObj.id = this._comments.length + 1;
            }

            this._comments.push(commentObj);
            return `${username} commented on ${this.title}`;
        }
    }

    toString(sortingType) {
        if (sortingType === 'asc') {
            this._comments.sort((a, b) => a.id - b.id);
            for (const currComment of this._comments) {
                currComment.replies.sort((a, b) => a.id.localeCompare(b.id));
            }
        }
        else if (sortingType === 'desc') {
            this._comments.sort((a, b) => b.id - a.id);
            for (const currComment of this._comments) {
                currComment.replies.sort((a, b) => b.id.localeCompare(a.id));
            }
        }
        else if (sortingType === 'username') {
            this._comments.sort((a, b) => a.username.localeCompare(b.username));
            for (const currComment of this._comments) {
                currComment.replies.sort((a, b) => a.username.localeCompare(b.username));
            }
        }

        let text = `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:`;

        for (const comment of this._comments) {
            text = text + `\n-- ${comment.id}. ${comment.username}: ${comment.content}`;
            for (const reply of comment.replies) {
                text = text + `\n--- ${reply.id}. ${reply.username}: ${reply.content}`;
            }
        }

        return text;
    }
}



let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
