function solution() {

    const COMMENTS = [];
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`

        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = COMMENTS;
        }

        addComment(comment) {
            COMMENTS.push(comment);
        }

        toString() {
            let result = `Rating: ${this.likes - this.dislikes}\n`;
            if (COMMENTS.length > 0) {
                result += `Comments:\n`;
                for (let currComent of COMMENTS) {
                    result += ` * ${currComent}\n`;
                }
            }
            
            return super.toString() + '\n' + result.trim();

        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            return super.toString() + `\nViews: ${this.views}`
        }
    }

    return { Post, SocialMediaPost, BlogPost }
}

const classes = solution();
let test = new classes.SocialMediaPost("TestTitle", "TestContent", 5, 10);
console.log(test.toString());