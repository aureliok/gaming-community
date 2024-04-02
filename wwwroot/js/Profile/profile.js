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
import { checkPassword, checkIfPasswordEqual, checkEmailInput, checkCurrentPassword } from "../Helpers/validators.js";
var username = document.getElementById("profileUsername");
var gender = document.getElementById("profileGender");
var age = document.getElementById("profileAge");
var bio = document.getElementById("profileBioText");
var platformLink = document.getElementById("profilePlatformLink");
var profileMenu = document.querySelector(".profileMenu");
var profileWindow = document.querySelector(".profileWindow");
document.addEventListener("DOMContentLoaded", function () {
    loadUserData();
    displayMyMessages();
});
function calculateAge(dateOfBirthStr) {
    var today = new Date();
    var dob = new Date(dateOfBirthStr);
    var age = today.getFullYear() - dob.getFullYear();
    var monthDiff = today.getMonth() - dob.getMonth();
    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < dob.getDate())) {
        age--;
    }
    return age;
}
function loadUserData() {
    fetch("/GetUserData", {
        method: "GET",
    })
        .then(function (response) {
        if (!response.ok) {
            throw new Error("Something went wrong");
        }
        return response.json();
    })
        .then(function (data) {
        console.log(data.bio);
        username.innerHTML = "<strong>".concat(data.username, "</strong>");
        gender.innerHTML = "<strong>".concat(data.gender, "</strong>");
        age.innerHTML = "<strong>".concat(calculateAge(data.birthDate), "</strong>");
        platformLink.innerHTML = "<a href=\"".concat(data.platformLink, "\" target=\"_blank\">My Game Link</a>");
        bio.innerHTML = "\"".concat(data.bio, "\"");
    })
        .catch(function (error) {
        console.log(error);
    });
}
function displayMyMessages() {
    return __awaiter(this, void 0, void 0, function () {
        var inboxMessages, response, messages;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    profileWindow.innerHTML = "\n    <h5>My Inbox</h5>\n    ";
                    inboxMessages = [];
                    return [4 /*yield*/, fetch("/GetLastInboxMessages", {
                            method: "GET",
                        })];
                case 1:
                    response = _a.sent();
                    if (!response.ok) return [3 /*break*/, 3];
                    return [4 /*yield*/, response.json()];
                case 2:
                    messages = _a.sent();
                    messages.forEach(function (message) {
                        message.createdAt = new Date(message.createdAt);
                    });
                    inboxMessages.push.apply(inboxMessages, messages);
                    _a.label = 3;
                case 3:
                    if (inboxMessages.length == 0)
                        return [2 /*return*/];
                    inboxMessages.sort(function (a, b) { return b.createdAt.getTime() - a.createdAt.getTime(); });
                    inboxMessages.forEach(function (message) {
                        profileWindow.innerHTML += "\n        <div class=\"inboxMessage modal-InboxMessage inboxMessage-".concat(message.otherId, "\" \n            id=\"inboxMessage-").concat(message.otherId, "\"\n            data-toggle=\"modal\" data-target=\"#modal-inboxMessage\">\n            <div class=\"row modal-InboxMessage inboxMessage-").concat(message.otherId, "\">\n                <div class=\"col modal-InboxMessage inboxMessage-").concat(message.otherId, "\">\n                    <p class=\"modal-InboxMessage inboxMessage-").concat(message.otherId, "\">\n                    Chat with <strong><span class=\"modal-InboxMessage userlink user-").concat(message.otherId, " inboxMessage-").concat(message.otherId, "\">\n                    ").concat(message.otherUsername, "</span></strong>\n                    </p>\n                </div>\n                <div class=\"col-3 inboxDate modal-InboxMessage inboxMessage-").concat(message.otherId, "\">\n                    <p class=\"modal-InboxMessage inboxMessage-").concat(message.otherId, "\">").concat(message.createdAt.toLocaleString(), "</p>\n                </div>\n            </div>\n            <div class=\"modal-InboxMessage inboxMessage-").concat(message.otherId, "\">\n                <strong>").concat(message.messageAuthor, "</strong>: ").concat(message.messageText, "\n            </div>\n        </div>\n        ");
                    });
                    return [2 /*return*/];
            }
        });
    });
}
function displayChangePassword() {
    var _this = this;
    console.log("changethis");
    profileWindow.innerHTML = "\n    <h5>Change Password</h5>\n    <form id=\"passwordForm\" class=\"forms\">\n        <div>\n            <label for=\"password\">Current Password</label>\n            <input type=\"password\" class=\"form-control\" id=\"password\" name=\"password\" required />\n            <span id=\"correctPassword\"></span>\n        </div>\n        <div>\n            <label for=\"newPassword\">New Password</label>\n            <input type=\"password\" class=\"form-control\" id=\"newPassword\" name=\"newPassword\" required />\n            <span id=\"validNewPassword\"></span>\n        </div>\n        <div>\n            <label for=\"confirmPassword\">Confirm your new password</label>\n            <input type=\"password\" class=\"form-control\" id=\"confirmPassword\" name=\"confirmPassword\" required />\n            <span id=\"confirmPasswordEqual\"></span>\n        </div>\n        <button type=\"submit\" class=\"submitBtn\" id=\"changePasswordBtn\">Change Password</button>\n    </form>\n    ";
    var curPasswordInput = document.getElementById("password");
    var newPasswordInput = document.getElementById("newPassword");
    var confirmPasswordInput = document.getElementById("confirmPassword");
    var correctPassword = document.getElementById("correctPassword");
    var strongPassword = document.getElementById("validNewPassword");
    var passwordEquality = document.getElementById("confirmPasswordEqual");
    var passwordForm = document.getElementById("passwordForm");
    var curValidPassword = false;
    var validPassword = false;
    var equalPassword = false;
    curPasswordInput.addEventListener("input", function () { return __awaiter(_this, void 0, void 0, function () {
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, checkCurrentPassword(curPasswordInput, correctPassword)];
                case 1:
                    curValidPassword = _a.sent();
                    return [2 /*return*/];
            }
        });
    }); });
    newPasswordInput.addEventListener("input", function () { return __awaiter(_this, void 0, void 0, function () {
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, checkPassword(newPasswordInput, strongPassword)];
                case 1:
                    validPassword = _a.sent();
                    return [2 /*return*/];
            }
        });
    }); });
    confirmPasswordInput.addEventListener("input", function () { return __awaiter(_this, void 0, void 0, function () {
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, checkIfPasswordEqual(newPasswordInput, confirmPasswordInput, passwordEquality)];
                case 1:
                    equalPassword = _a.sent();
                    return [2 /*return*/];
            }
        });
    }); });
    passwordForm.addEventListener("submit", function (e) { return __awaiter(_this, void 0, void 0, function () {
        var response;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    e.preventDefault();
                    if (!curValidPassword || !validPassword || !equalPassword) {
                        alert("filll everything correctly");
                        console.log(curValidPassword, validPassword, equalPassword);
                        return [2 /*return*/];
                    }
                    return [4 /*yield*/, fetch("/ChangePassword", {
                            method: "PATCH",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify(newPasswordInput.value)
                        })];
                case 1:
                    response = _a.sent();
                    if (response.ok) {
                        alert("Password updated successfully");
                    }
                    else {
                        alert("Couldn't update password, try again.");
                    }
                    return [2 /*return*/];
            }
        });
    }); });
}
function displayChangeEmail() {
    var _this = this;
    profileWindow.innerHTML = "\n    <h5>Change Email</h5>\n    <form id=\"emailForm\" class=\"forms\">\n        <div>\n            <label for=\"password\">Current Password</label>\n            <input type=\"password\" class=\"form-control\" id=\"password\" name=\"password\" required />\n            <span id=\"correctPassword\"></span>\n        </div>\n        <div>\n            <label for=\"newEmail\">New Email</label>\n            <input type=\"email\" class=\"form-control\" id=\"newEmail\" name=\"newEmail\" required />\n            <span id=\"newEmailAvailability\"></span>\n        </div>\n        <button type=\"submit\" class=\"submitBtn\">Change Email</button>\n    </form>\n    ";
    var passwordInput = document.getElementById("password");
    var newEmailInput = document.getElementById("newEmail");
    var correctPassword = document.getElementById("correctPassword");
    var newEmailAvailability = document.getElementById("newEmailAvailability");
    var emailForm = document.getElementById("emailForm");
    var validPassword = false;
    var validNewEmail = false;
    passwordInput.addEventListener("input", function () { return __awaiter(_this, void 0, void 0, function () {
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, checkCurrentPassword(passwordInput, correctPassword)];
                case 1:
                    validPassword = _a.sent();
                    return [2 /*return*/];
            }
        });
    }); });
    newEmailInput.addEventListener("input", function () { return __awaiter(_this, void 0, void 0, function () {
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, checkEmailInput(newEmailInput, newEmailAvailability)];
                case 1:
                    validNewEmail = _a.sent();
                    return [2 /*return*/];
            }
        });
    }); });
    emailForm.addEventListener("submit", function (e) { return __awaiter(_this, void 0, void 0, function () {
        var response;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    e.preventDefault();
                    if (!validPassword || !validNewEmail) {
                        alert("filll everything correctly");
                        return [2 /*return*/];
                    }
                    return [4 /*yield*/, fetch("/ChangeEmail", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify(newEmailInput.value)
                        })];
                case 1:
                    response = _a.sent();
                    if (response.ok) {
                        alert("Email updated successfully");
                    }
                    else {
                        alert("Couldn't update email, try again.");
                    }
                    return [2 /*return*/];
            }
        });
    }); });
}
function loadConversationChat(otherUserId) {
    return __awaiter(this, void 0, void 0, function () {
        var response, chatTitle, chatBody, inboxMessages, i;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, fetch("/GetInboxMessages?otherUserId=".concat(otherUserId), {
                        method: "GET"
                    })];
                case 1:
                    response = _a.sent();
                    chatTitle = document.querySelector(".modal-title");
                    chatBody = document.querySelector(".modal-body");
                    chatBody.innerHTML = "";
                    if (!response.ok) return [3 /*break*/, 3];
                    return [4 /*yield*/, response.json()];
                case 2:
                    inboxMessages = _a.sent();
                    chatTitle.innerHTML = "<span class=\"modalDisplay userlink user-".concat(inboxMessages[0].otherId, "\">\n                                Chat with ").concat(inboxMessages[0].otherUsername, "</span>");
                    for (i = 0; i < inboxMessages.length; i++) {
                        chatBody.innerHTML += "\n            <div class=\"chatMessage modalDisplay\">\n                <div class=\"row modalDisplay\">\n                    <div class=\"messageAuthor modalDisplay col\">\n                        <strong class=\"modalDisplay\">".concat(inboxMessages[i].messageAuthor, "</strong>:\n                    </div>\n                    <div class=\"messageDate modalDisplay col-3\">\n                        ").concat(new Date(inboxMessages[i].createdAt).toLocaleString(), "\n                    </div>\n                    <div class=\"messageContent modalDisplay\">\n                        ").concat(inboxMessages[i].messageText, "\n                    </div>\n                </div>\n            </div>\n            ");
                    }
                    chatBody.innerHTML += "\n                <div class=\"messageReply modalDisplay\">\n                    <textarea class=\"messageAreaInput modalDisplay\" placeholder=\"Write your message\"></textarea>\n                    <div class=\"buttonChatContainer modalDisplay\">\n                        <button type=\"click\" class=\"chatSendBtn modalDisplay\" id=\"sendTo-".concat(inboxMessages[0].otherId, "\">Send</button>\n                    </div>\n                </div>\n                ");
                    return [3 /*break*/, 4];
                case 3:
                    alert("Something went wrong when fetching chat history");
                    _a.label = 4;
                case 4: return [2 /*return*/];
            }
        });
    });
}
function SendPrivateMessage(target) {
    return __awaiter(this, void 0, void 0, function () {
        var messageInput, otherId, sendMessage, response;
        var _a;
        return __generator(this, function (_b) {
            switch (_b.label) {
                case 0:
                    messageInput = document.querySelector(".messageAreaInput");
                    otherId = (_a = target.getAttribute("id")) === null || _a === void 0 ? void 0 : _a.split("-")[1];
                    if (messageInput.value.length < 5) {
                        alert("Your message can't have less than 5 characters");
                        return [2 /*return*/];
                    }
                    sendMessage = {
                        OtherId: otherId,
                        Content: messageInput.value
                    };
                    return [4 /*yield*/, fetch("/SendPrivateMessage", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify(sendMessage)
                        })];
                case 1:
                    response = _b.sent();
                    if (response.ok) {
                        loadConversationChat(otherId);
                    }
                    else {
                        alert("Something went wrong");
                    }
                    return [2 /*return*/];
            }
        });
    });
}
document.addEventListener("click", function (e) {
    var _a;
    var target = e.target;
    var modalDiv = document.getElementById("modal-inboxMessage");
    var regexModalId = /inboxMessage-(\d+)/;
    if (!modalDiv.classList.contains("show") && target.classList.contains("modal-InboxMessage")) {
        var otherUserId = (_a = target.classList.value.match(regexModalId)) === null || _a === void 0 ? void 0 : _a[1];
        if (otherUserId) {
            console.log(otherUserId);
            loadConversationChat(otherUserId);
            modalDiv.classList.add("show");
            modalDiv.classList.add("modal-show");
            modalDiv.setAttribute("aria-hidden", "false");
            return;
        }
        else {
            alert("Couldn't load chat");
            return;
        }
    }
    if (target.classList.contains("chatSendBtn")) {
        SendPrivateMessage(target);
    }
    if (target.classList.contains("modalClose") || !target.classList.contains("modalDisplay")) {
        if (modalDiv.classList.contains("show")) {
            modalDiv.classList.remove("show");
            modalDiv.classList.remove("modal-show");
            modalDiv.setAttribute("aria-hidden", "true");
            displayMyMessages();
        }
        return;
    }
});
profileMenu.addEventListener("click", function (e) {
    var target = e.target;
    if (target.nodeName != "BUTTON")
        return;
    switch (target.id) {
        case "seeDMBtn":
            console.log("here");
            displayMyMessages();
            return;
        case "changePasswordBtn":
            console.log("password");
            displayChangePassword();
            return;
        case "changeEmailBtn":
            displayChangeEmail();
            return;
        default:
            break;
    }
});
//# sourceMappingURL=profile.js.map