"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
function getCommentsFromThread(threadId) {
    return __awaiter(this, void 0, void 0, function () {
        var response;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, fetch("/GetCommentsFromThread?threadId=".concat(threadId), {
                        method: "GET",
                        headers: {
                            "Accept": "application/json"
                        }
                    })];
                case 1:
                    response = _a.sent();
                    if (!response.ok) return [3 /*break*/, 3];
                    return [4 /*yield*/, response.json()];
                case 2: return [2 /*return*/, _a.sent()];
                case 3: throw new Error("Failed to fetch comments from thread");
            }
        });
    });
}
function addCommentsOnThread(comments, threadId) {
    var repliesBody = document.getElementById("replies-".concat(threadId));
    if (!repliesBody)
        return;
    repliesBody.innerHTML = "";
    for (var _i = 0, comments_1 = comments; _i < comments_1.length; _i++) {
        var comment = comments_1[_i];
        repliesBody.innerHTML += "\n        <div class=\"reply post\">\n            <div class=\"postData row\">\n                <div class=\"col-9 postAuthor\">\n                    <img src=\"/imgs/user_avatars/conker.jpg\" class=\"mini-avatar\" alt=\"avatar image\" />\n                        <strong><span class=\"userlink user-".concat(comment.userId, "\">").concat(comment.username, "</span></strong> says:\n                </div>\n                <div class=\"col postDate\">\n                    <p>").concat(new Date(comment.createdAt).toLocaleString(), "</p>\n                </div>\n            </div>\n            <div class=\"postContent\">\n                <p>").concat(comment.content, "</p>\n            </div>\n            <div class=\"votesContainer\">\n                <button type=\"button\" class=\"upvoteBtn\" id=\"btn-comment-upvote-").concat(comment.commentId, "\">\n                    <i class=\"bi bi-arrow-up-circle i-upvoteBtn\"></i>\n                </button>\n                <span class=\"upvoteCount\" id=\"comment-upvote-").concat(comment.commentId, "\">0</span>\n                <button type=\"button\" class=\"downvoteBtn\" id=\"btn-comment-downvote-").concat(comment.commentId, "\">\n                    <i class=\"bi bi-arrow-down-circle i-downvoteBtn\"></i>\n                </button>\n                <span class=\"downvoteCount\" id=\"comment-downvote-").concat(comment.commentId, "\">0</span>   \n            </div>\n        </div>\n        ");
    }
}
function refreshVoteCount(tupleVote) {
    var voteSpanUpvote = document.getElementById("".concat(tupleVote.contentType, "-upvote-").concat(tupleVote.id));
    var voteSpanDownvote = document.getElementById("".concat(tupleVote.contentType, "-downvote-").concat(tupleVote.id));
    if (tupleVote.upvoteCount > 0) {
        voteSpanUpvote.innerText = tupleVote.upvoteCount;
    }
    if (tupleVote.downvoteCount > 0) {
        voteSpanDownvote.innerText = tupleVote.downvoteCount;
    }
}
function refreshVotes() {
    return __awaiter(this, void 0, void 0, function () {
        var modalActive, votesContainer, idsTuples, response, data, i;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    modalActive = document.querySelector(".modal-show");
                    votesContainer = modalActive.querySelectorAll(".votesContainer");
                    idsTuples = [];
                    votesContainer.forEach(function (vote) {
                        var upvoteCount = vote.querySelector(".upvoteCount");
                        var upvoteCountId = upvoteCount.getAttribute("id");
                        var ids_split = upvoteCountId.split('-');
                        idsTuples.push({ ContentType: ids_split[0], Id: ids_split[2] });
                    });
                    return [4 /*yield*/, fetch("/GetVotes", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify(idsTuples)
                        })];
                case 1:
                    response = _a.sent();
                    if (!response.ok) return [3 /*break*/, 3];
                    return [4 /*yield*/, response.json()];
                case 2:
                    data = _a.sent();
                    for (i = 0; i < data.length; i++) {
                        refreshVoteCount(data[i]);
                    }
                    return [3 /*break*/, 4];
                case 3:
                    console.log("Something went wrong on refreshing votes count");
                    _a.label = 4;
                case 4: return [2 /*return*/];
            }
        });
    });
}
document.addEventListener("DOMContentLoaded", function () {
    var tableRows = document.querySelectorAll(".table tbody tr");
    tableRows.forEach(function (row) {
        row.addEventListener("click", function () {
            return __awaiter(this, void 0, void 0, function () {
                var targetModalId, targetModal, threadId, comments;
                return __generator(this, function (_a) {
                    switch (_a.label) {
                        case 0:
                            targetModalId = this.getAttribute("data-target");
                            if (!targetModalId) return [3 /*break*/, 2];
                            targetModal = document.querySelector(targetModalId);
                            if (!targetModal) return [3 /*break*/, 2];
                            threadId = targetModalId.split("-")[1];
                            return [4 /*yield*/, getCommentsFromThread(Number(threadId))];
                        case 1:
                            comments = _a.sent();
                            addCommentsOnThread(comments, threadId);
                            targetModal.classList.add("show");
                            targetModal.classList.add("modal-show");
                            targetModal.setAttribute("aria-hidden", "false");
                            refreshVotes();
                            _a.label = 2;
                        case 2: return [2 /*return*/];
                    }
                });
            });
        });
    });
});
function addComment(target, modalId) {
    return __awaiter(this, void 0, void 0, function () {
        var replyInput, response, comments;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    replyInput = document.getElementById("replyContent-".concat(modalId));
                    if (replyInput.value.length <= 5) {
                        alert("your reply can't be shorter than 5 characters");
                        return [2 /*return*/];
                    }
                    return [4 /*yield*/, fetch("/NewReply", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify({
                                ThreadId: modalId,
                                Content: replyInput.value
                            })
                        })];
                case 1:
                    response = _a.sent();
                    if (!response.ok) return [3 /*break*/, 3];
                    console.log("reply posted");
                    return [4 /*yield*/, getCommentsFromThread(Number(modalId))];
                case 2:
                    comments = _a.sent();
                    addCommentsOnThread(comments, modalId);
                    return [3 /*break*/, 4];
                case 3:
                    console.log("something went wrong");
                    _a.label = 4;
                case 4: return [2 /*return*/];
            }
        });
    });
}
document.addEventListener("click", function (e) {
    var _a, _b, _c, _d;
    var target = e.target;
    var modalId = target.getAttribute("id");
    if (target.classList.contains("i-upvoteBtn") || target.classList.contains("i-downvoteBtn")) {
        addVote(target);
        return;
    }
    if (target.classList.contains("replyBtn")) {
        addComment(target, modalId.split("-")[1]);
        return;
    }
    if (!target.classList.contains("modal") && !target.classList.contains("modalClose"))
        return;
    var modal = document.getElementById(modalId);
    if (target === modal && !target.classList.contains("modalClose")) {
        modal.classList.remove("show");
        modal.classList.remove("modal-show");
        modal.setAttribute("aria-hidden", "true");
        return;
    }
    if (target.classList.contains("modalClose")) {
        var modalId_1 = target.getAttribute("id");
        if (modalId_1 === "createNewContent") {
            (_a = document.getElementById(modalId_1)) === null || _a === void 0 ? void 0 : _a.classList.remove("show");
            (_b = document.getElementById(modalId_1)) === null || _b === void 0 ? void 0 : _b.classList.remove("modal-show");
            return;
        }
        (_c = document.getElementById("modal-".concat(modalId_1))) === null || _c === void 0 ? void 0 : _c.classList.remove("show");
        (_d = document.getElementById("modal-".concat(modalId_1))) === null || _d === void 0 ? void 0 : _d.classList.remove("modal-show");
    }
    else {
        return;
    }
});
function addVote(target) {
    return __awaiter(this, void 0, void 0, function () {
        var buttonVoteId, voteParts, contentType, voteType, voteId, payload, response;
        var _a;
        return __generator(this, function (_b) {
            switch (_b.label) {
                case 0:
                    buttonVoteId = (_a = target.parentElement) === null || _a === void 0 ? void 0 : _a.getAttribute("id");
                    voteParts = buttonVoteId === null || buttonVoteId === void 0 ? void 0 : buttonVoteId.split("-");
                    if (!voteParts)
                        return [2 /*return*/];
                    contentType = voteParts[1];
                    voteType = voteParts[2];
                    voteId = parseInt(voteParts[3]);
                    if (contentType === "thread") {
                        payload = {
                            VoteType: voteType,
                            ThreadId: voteId
                        };
                    }
                    else if (contentType === "comment") {
                        payload = {
                            VoteType: voteType,
                            CommentId: voteId
                        };
                    }
                    else if (contentType === "review") {
                        payload = {
                            VoteType: voteType,
                            ReviewId: voteId
                        };
                    }
                    else {
                        return [2 /*return*/];
                    }
                    return [4 /*yield*/, fetch("/NewVote", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify(payload)
                        })];
                case 1:
                    response = _b.sent();
                    if (response.ok) {
                        refreshVotes();
                    }
                    else {
                        console.log("some error ocurred");
                    }
                    return [2 /*return*/];
            }
        });
    });
}
var postNewBtn = document.querySelector(".postNewBtn");
var modalNewContent = document.getElementById("createNewContent");
var formsNewContent = document.getElementById("formsReviews") ||
    document.getElementById("formsThreads");
postNewBtn.addEventListener("click", function () {
    modalNewContent.classList.add("show");
    modalNewContent.setAttribute('aria-hidden', 'false');
});
formsNewContent.addEventListener("submit", function (e) {
    return __awaiter(this, void 0, void 0, function () {
        var inputGame, inputPlatform, inputContent, inputScore, response, inputTitle, inputContent, response;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    // send data to route
                    e.preventDefault();
                    console.log(this.id);
                    if (!(this.id === "formsReviews")) return [3 /*break*/, 2];
                    inputGame = document.getElementById("inputGame");
                    inputPlatform = document.getElementById("inputPlatform");
                    inputContent = document.getElementById("inputContent");
                    inputScore = document.getElementById("inputScore");
                    return [4 /*yield*/, fetch("/NewReview", {
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
                        })];
                case 1:
                    response = _a.sent();
                    if (response.ok) {
                        alert("Your review has been successfully posted!");
                        window.location.href = "/Community/Reviews";
                    }
                    else {
                        alert("Something went wrong, try again in a few seconds.");
                    }
                    return [3 /*break*/, 4];
                case 2:
                    if (!(this.id === "formsThreads")) return [3 /*break*/, 4];
                    inputTitle = document.getElementById("inputTitle");
                    inputContent = document.getElementById("inputContent");
                    return [4 /*yield*/, fetch("/NewThread", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify({
                                Title: inputTitle.value,
                                Content: inputContent.value
                            })
                        })];
                case 3:
                    response = _a.sent();
                    if (response.ok) {
                        alert("Your thread has been successfully posted!");
                        window.location.href = "/Community/Gaming";
                    }
                    else {
                        alert("Something went wrong, try again in a few seconds.");
                    }
                    _a.label = 4;
                case 4: return [2 /*return*/];
            }
        });
    });
});
//# sourceMappingURL=reviews.js.map