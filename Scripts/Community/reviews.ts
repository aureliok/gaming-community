interface Comment {
    commentId: number;
    content: string;
    createdAt: Date;
    username: string;
    userId: number;
}


async function getCommentsFromThread(threadId: Number): Promise<Comment[]> {

    const response = await fetch(`/GetCommentsFromThread?threadId=${threadId}`, {
        method: "GET",
        headers: {
            "Accept": "application/json"
        }
    });

    if (response.ok) {
        return await response.json() as Comment[];
    } else {
        throw new Error("Failed to fetch comments from thread");
    }
}

function addCommentsOnThread(comments: Comment[], threadId: string): void {
    const repliesBody = <HTMLDivElement>document.getElementById(`replies-${threadId}`);
    console.log(repliesBody);
    repliesBody.innerHTML = "";

    for (const comment of comments) {
        repliesBody.innerHTML += `
        <div class="reply post">
            <div class="postData row">
                <div class="col-9 postAuthor">
                    <img src="/imgs/user_avatars/conker.jpg" class="mini-avatar" alt="avatar image" />
                    <span><strong>${comment.username}</strong> says:</span>
                </div>
                <div class="col postDate">
                    <p>${comment.createdAt}</p>
                </div>
            </div>
            <div class="postContent">
                <p>${comment.content}</p>
            </div>
            <div class="votesContainer">
                <button type="button" class="upvoteBtn" id="thread-upvote-${comment.commentId}">
                    <i class="bi bi-arrow-up-circle upvoteBtn"></i>
                </button>
                <span class="upvoteCount">15</span>
                <button type="button" class="downvoteBtn" id="thread-downvote-${comment.commentId}">
                    <i class="bi bi-arrow-down-circle upvoteBtn"></i>
                </button>
                <span class="downvoteCount">-2</span>   
            </div>
        </div>
        `;
    }

}


document.addEventListener("DOMContentLoaded", function (): void {
    const tableRows = document.querySelectorAll(".table tbody tr");

    tableRows.forEach(row => {
        row.addEventListener("click", async function (this: HTMLTableRowElement) {
            const targetModalId = this.getAttribute("data-target");

            if (targetModalId) {
                const targetModal = document.querySelector(targetModalId);

                if (targetModal) {
                    const threadId: string = targetModalId.split("-")[1];
                    const comments: Comment[] = await getCommentsFromThread(Number(threadId));
                    console.log(comments);
                    addCommentsOnThread(comments, threadId);
                    targetModal.classList.add('show');
                    targetModal.setAttribute('aria-hidden', 'false');
                }
            }
            return;
        });
    });
});


document.addEventListener("click", function (e): void {
    const target = <HTMLElement>e.target;
    const modalId = <string>target.getAttribute("id");

    if (target.classList.contains("upvoteBtn") || target.classList.contains("downvoteBtn")) {
        addVote(target);
        //console.log(target);
        return;
    }

    if (!target.classList.contains("modal") && !target.classList.contains("modalClose")) return;


    const modal = <HTMLDivElement>document.getElementById(modalId);

    if (target === modal && !target.classList.contains("modalClose")) {
        modal.classList.remove("show");
        return;
    }

    if (target.classList.contains("modalClose")) {
        const modalId = target.getAttribute("id");

        if (modalId === "createNewContent") {
            document.getElementById(modalId)?.classList.remove("show");
            return;
        }

        document.getElementById(`modal-${modalId}`)?.classList.remove("show");
    } else {
        return;
    }
});


async function addVote(target: HTMLElement): Promise<void> {
    const buttonVoteId = target.parentElement?.getAttribute("id");
    const voteParts = buttonVoteId?.split("-");

    if (!voteParts) return;

    const contentType = voteParts[0];
    const voteType = voteParts[1];
    const voteId = parseInt(voteParts[2]);
    var payload;

   /* console.log(voteId, voteType, contentType);*/

    if (contentType === "thread") {
        payload = {
            VoteType: voteType,
            ThreadId: voteId
        }
    } else if (contentType === "comment") {
        payload = {
            VoteType: voteType,
            CommentId: voteId
        }
    } else {
        return;
    }

    console.log(payload);

    const response = await fetch("/NewVote", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
    });

    if (response.ok) {
        console.log("worked");
    } else {
        console.log("some error ocurred");
    }
}


const postNewBtn = <HTMLButtonElement>document.querySelector(".postNewBtn");
const modalNewContent = <HTMLDivElement>document.getElementById("createNewContent");
const formsNewContent = <HTMLFormElement>document.getElementById("formsReviews") ||
                        <HTMLFormElement>document.getElementById("formsThreads");


postNewBtn.addEventListener("click", function (): void {
    console.log("here");
    modalNewContent.classList.add("show");
    modalNewContent.setAttribute('aria-hidden', 'false');
});


formsNewContent.addEventListener("submit", async function (e): Promise<void> {
    // send data to route
    e.preventDefault();
    console.log(this.id);

    if (this.id === "formsReviews") {

        const inputGame = <HTMLInputElement>document.getElementById("inputGame");
        const inputPlatform = <HTMLInputElement>document.getElementById("inputPlatform");
        const inputContent = <HTMLInputElement>document.getElementById("inputContent");
        const inputScore = <HTMLInputElement>document.getElementById("inputScore");

        const response = await fetch("/NewReview", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                Game: inputGame.value,
                Platform: inputPlatform.value,
                Score: inputScore.value,
                Review: inputContent.value
            })
        });

        if (response.ok) {
            alert("Your review has been successfully posted!");
            window.location.href = "/Community/Reviews";
        } else {
            alert("Something went wrong, try again in a few seconds.");
        }
    } else if (this.id === "formsThreads") {
        const inputTitle= <HTMLInputElement>document.getElementById("inputTitle");
        const inputContent = <HTMLInputElement>document.getElementById("inputContent");

        const response = await fetch("/NewThread", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                Title: inputTitle.value,
                Content: inputContent.value
            })
        });

        if (response.ok) {
            alert("Your thread has been successfully posted!");
            window.location.href = "/Community/Gaming";
        } else {
            alert("Something went wrong, try again in a few seconds.");
        }
    }
});