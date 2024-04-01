interface Comment {
    commentId: number;
    content: string;
    createdAt: Date;
    username: string;
    userId: number;
}

interface TupleIdModel {
    ContentType: string,
    Id: string
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
    if (!repliesBody) return;

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
                    <p>${new Date(comment.createdAt).toLocaleString()}</p>
                </div>
            </div>
            <div class="postContent">
                <p>${comment.content}</p>
            </div>
            <div class="votesContainer">
                <button type="button" class="upvoteBtn" id="btn-comment-upvote-${comment.commentId}">
                    <i class="bi bi-arrow-up-circle i-upvoteBtn"></i>
                </button>
                <span class="upvoteCount" id="comment-upvote-${comment.commentId}">0</span>
                <button type="button" class="downvoteBtn" id="btn-comment-downvote-${comment.commentId}">
                    <i class="bi bi-arrow-down-circle i-downvoteBtn"></i>
                </button>
                <span class="downvoteCount" id="comment-downvote-${comment.commentId}">0</span>   
            </div>
        </div>
        `;
    }

}

function refreshVoteCount(tupleVote): void {
    const voteSpanUpvote = <HTMLSpanElement>document.getElementById(`${tupleVote.contentType}-upvote-${tupleVote.id}`);
    const voteSpanDownvote = <HTMLSpanElement>document.getElementById(`${tupleVote.contentType}-downvote-${tupleVote.id}`);

    if (tupleVote.upvoteCount > 0) {
        voteSpanUpvote.innerText = tupleVote.upvoteCount;
    }

    if (tupleVote.downvoteCount > 0) {
        voteSpanDownvote.innerText = tupleVote.downvoteCount;
    }
    
}

async function refreshVotes(): Promise<void> {
    const modalActive = <HTMLDivElement>document.querySelector(".modal-show");
    const votesContainer = modalActive.querySelectorAll(".votesContainer") as NodeListOf<HTMLDivElement>;
    var idsTuples: TupleIdModel[] = [];

    votesContainer.forEach(vote => {
        const upvoteCount = <HTMLSpanElement>vote.querySelector(".upvoteCount");
        const upvoteCountId = <string>upvoteCount.getAttribute("id");
        const ids_split = upvoteCountId.split('-');
        idsTuples.push({ ContentType: ids_split[0], Id: ids_split[2] });
    });


    const response = await fetch("/GetVotes", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(idsTuples)
    })

    if (response.ok) {
        const data = await response.json();
        for (var i = 0; i < data.length; i++) {
            refreshVoteCount(data[i]);
        }
    } else {
        console.log("Something went wrong on refreshing votes count");
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
                    addCommentsOnThread(comments, threadId);
                    targetModal.classList.add("show");
                    targetModal.classList.add("modal-show");
                    targetModal.setAttribute("aria-hidden", "false");

                    refreshVotes();
                }
            }
            return;
        });
    });
});

async function addComment(target: HTMLElement, modalId: string): Promise<void> {
    const replyInput = <HTMLTextAreaElement>document.getElementById(`replyContent-${modalId}`);

    if (replyInput.value.length <= 5) {
        alert("your reply can't be shorter than 5 characters");
        return;
    }

    const response = await fetch("/NewReply", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            ThreadId: modalId,
            Content: replyInput.value
        })
    });

    if (response.ok) {
        console.log("reply posted");
        const comments: Comment[] = await getCommentsFromThread(Number(modalId));
        addCommentsOnThread(comments, modalId);
    } else {
        console.log("something went wrong");
    }

}


document.addEventListener("click", function (e): void {
    const target = <HTMLElement>e.target;
    const modalId = <string>target.getAttribute("id");

    if (target.classList.contains("i-upvoteBtn") || target.classList.contains("i-downvoteBtn")) {
        addVote(target);
        return;
    }

    if (target.classList.contains("replyBtn")) {
        addComment(target, modalId.split("-")[1]);
        return;
    }


    if (!target.classList.contains("modal") && !target.classList.contains("modalClose")) return;


    const modal = <HTMLDivElement>document.getElementById(modalId);

    if (target === modal && !target.classList.contains("modalClose")) {
        modal.classList.remove("show");
        modal.classList.remove("modal-show");
        return;
    }

    if (target.classList.contains("modalClose")) {
        const modalId = target.getAttribute("id");

        if (modalId === "createNewContent") {
            document.getElementById(modalId)?.classList.remove("show");
            document.getElementById(modalId)?.classList.remove("modal-show");
            return;
        }

        document.getElementById(`modal-${modalId}`)?.classList.remove("show");
        document.getElementById(`modal-${modalId}`)?.classList.remove("modal-show");
    } else {
        return;
    }
});


async function addVote(target: HTMLElement): Promise<void> {
    const buttonVoteId = target.parentElement?.getAttribute("id");
    const voteParts = buttonVoteId?.split("-");

    if (!voteParts) return;

    const contentType = voteParts[1];
    const voteType = voteParts[2];
    const voteId = parseInt(voteParts[3]);
    var payload;

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
    } else if (contentType === "review") {
        payload = {
            VoteType: voteType,
            ReviewId: voteId
        }
    }
    else {
        return;
    }

    const response = await fetch("/NewVote", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
    });

    if (response.ok) {
        refreshVotes();
    } else {
        console.log("some error ocurred");
    }
}


const postNewBtn = <HTMLButtonElement>document.querySelector(".postNewBtn");
const modalNewContent = <HTMLDivElement>document.getElementById("createNewContent");
const formsNewContent = <HTMLFormElement>document.getElementById("formsReviews") ||
                        <HTMLFormElement>document.getElementById("formsThreads");


postNewBtn.addEventListener("click", function (): void {
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