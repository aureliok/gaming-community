interface InboxMessage {
    userId: number
    messageText: string,
    createdAt: Date,
    otherId: number,
    otherUsername: string,
    messageAuthor: string
}

import { checkPassword, checkIfPasswordEqual, checkEmailInput, checkCurrentPassword } from "../Helpers/validators.js";

const username = <HTMLParagraphElement>document.getElementById("profileUsername");
const gender = <HTMLParagraphElement>document.getElementById("profileGender");
const age = <HTMLParagraphElement>document.getElementById("profileAge");
const bio = <HTMLParagraphElement>document.getElementById("profileBioText");
const platformLink = <HTMLParagraphElement>document.getElementById("profilePlatformLink");
const profileMenu = <HTMLDivElement>document.querySelector(".profileMenu");
const profileWindow = <HTMLDivElement>document.querySelector(".profileWindow");


function calculateAge(dateOfBirthStr: string): number {
    const today = new Date();
    const dob = new Date(dateOfBirthStr);

    let age = today.getFullYear() - dob.getFullYear();
    const monthDiff = today.getMonth() - dob.getMonth();

    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < dob.getDate())) {
        age--;
    }

    return age;
}


function loadUserData(): void {
    fetch("/GetUserData", {
        method: "GET",
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Something went wrong");
            }
            return response.json();
        })
        .then(data => {
            console.log(data.bio);
            username.innerHTML = `<strong>${data.username}</strong>`;
            gender.innerHTML = `<strong>${data.gender}</strong>`;
            age.innerHTML = `<strong>${calculateAge(data.birthDate) }</strong>`;
            platformLink.innerHTML = `<a href="${data.platformLink}" target="_blank">My Game Link</a>`;
            bio.innerHTML = `"${data.bio}"`;
        })
        .catch(error => {
            console.log(error);
        });
}



async function displayMyMessages(): Promise<void> {
    profileWindow.innerHTML = `
    <h5>My Inbox</h5>
    `;

    var inboxMessages: InboxMessage[] = [];

    const response = await fetch("/GetInboxMessages", {
        method: "GET",
    });

    if (response.ok) {
        const messages: InboxMessage[] = await response.json();
        messages.forEach(message => {
            message.createdAt = new Date(message.createdAt);
        });
        inboxMessages.push(...messages);
    }

    if (inboxMessages.length == 0) return;

    inboxMessages.sort((a, b) => b.createdAt.getTime() - a.createdAt.getTime());

    console.log(inboxMessages);

    inboxMessages.forEach(message => { 
        profileWindow.innerHTML += `
        <div class="inboxMessage modal-InboxMessage inboxMessage-${message.otherId}" 
            id="inboxMessage-${message.otherId}"
            data-toggle="modal" data-target="#modal-inboxMessage">
            <div class="row modal-InboxMessage inboxMessage-${message.otherId}">
                <div class="col modal-InboxMessage inboxMessage-${message.otherId}">
                    <p class="modal-InboxMessage inboxMessage-${message.otherId}">Chat with <strong>${message.otherUsername}</strong></p>
                </div>
                <div class="col-3 inboxDate modal-InboxMessage inboxMessage-${message.otherId}">
                    <p class="modal-InboxMessage inboxMessage-${message.otherId}">${message.createdAt.toLocaleString()}</p>
                </div>
            </div>
            <div class="modal-InboxMessage inboxMessage-${message.otherId}">
                <strong>${message.messageAuthor}</strong>: ${message.messageText}
            </div>
        </div>
        `;
    })
    
}

function displayChangePassword(): void {
    profileWindow.innerHTML = `
    <h5>Change Password</h5>
    <form id="passwordForm" class="forms">
        <div>
            <label for="password">Current Password</label>
            <input type="password" class="form-control" id="password" name="password" required />
            <span id="correctPassword"></span>
        </div>
        <div>
            <label for="newPassword">New Password</label>
            <input type="password" class="form-control" id="newPassword" name="newPassword" required />
            <span id="validNewPassword"></span>
        </div>
        <div>
            <label for="confirmPassword">Confirm your new password</label>
            <input type="password" class="form-control" id="confirmPassword" name="confirmPassword" required />
            <span id="confirmPasswordEqual"></span>
        </div>
        <button type="submit" class="submitBtn" id="changePasswordBtn">Change Password</button>
    </form>
    `;

    const curPasswordInput = <HTMLInputElement>document.getElementById("password");
    const newPasswordInput = <HTMLInputElement>document.getElementById("newPassword");
    const confirmPasswordInput = <HTMLInputElement>document.getElementById("confirmPassword"); 
    const correctPassword = <HTMLSpanElement>document.getElementById("correctPassword");
    const strongPassword = <HTMLSpanElement>document.getElementById("validNewPassword");
    const passwordEquality = <HTMLSpanElement>document.getElementById("confirmPasswordEqual");
    const passwordForm = <HTMLFormElement>document.getElementById("passwordForm");

    let curValidPassword = <boolean>false;
    let validPassword = <boolean>false;
    let equalPassword = <boolean>false;

    curPasswordInput.addEventListener("input", async () => {
        curValidPassword = await checkCurrentPassword(curPasswordInput, correctPassword);
    })

    newPasswordInput.addEventListener("input", async () => {
        validPassword = await checkPassword(newPasswordInput, strongPassword);
    });
    confirmPasswordInput.addEventListener("input", async () => {
        equalPassword = await checkIfPasswordEqual(newPasswordInput, confirmPasswordInput, passwordEquality);
    });
    passwordForm.addEventListener("submit", async (e) => {
        e.preventDefault();
        if (!curValidPassword || !validPassword || !equalPassword) {
            alert("filll everything correctly");
            console.log(curValidPassword, validPassword, equalPassword);
            return;
        }

          
        const response = await fetch("/ChangePassword", {
            method: "PATCH",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(newPasswordInput.value)
        });

        if (response.ok) {
            alert("Password updated successfully");
        } else {
            alert("Couldn't update password, try again.");
        }
    })
}

function displayChangeEmail(): void {
    profileWindow.innerHTML = `
    <h5>Change Email</h5>
    <form id="emailForm" class="forms">
        <div>
            <label for="password">Current Password</label>
            <input type="password" class="form-control" id="password" name="password" required />
            <span id="correctPassword"></span>
        </div>
        <div>
            <label for="newEmail">New Email</label>
            <input type="email" class="form-control" id="newEmail" name="newEmail" required />
            <span id="newEmailAvailability"></span>
        </div>
        <button type="submit" class="submitBtn">Change Email</button>
    </form>
    `;

    const passwordInput = <HTMLInputElement>document.getElementById("password");
    const newEmailInput = <HTMLInputElement>document.getElementById("newEmail");
    const correctPassword = <HTMLSpanElement>document.getElementById("correctPassword");
    const newEmailAvailability = <HTMLSpanElement>document.getElementById("newEmailAvailability");
    const emailForm = <HTMLFormElement>document.getElementById("emailForm");

    let validPassword = <boolean>false;
    let validNewEmail = <boolean>false;

    passwordInput.addEventListener("input", async () => {
        validPassword = await checkCurrentPassword(passwordInput, correctPassword);
    })

    newEmailInput.addEventListener("input", async () => {
        validNewEmail = await checkEmailInput(newEmailInput, newEmailAvailability);
    });

    emailForm.addEventListener("submit", async (e) => {
        e.preventDefault();

        if (!validPassword || !validNewEmail) {
            alert("filll everything correctly");
            return;
        }

        const response = await fetch("/ChangeEmail", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(newEmailInput.value)
        });

        if (response.ok) {
            alert("Email updated successfully");
        } else {
            alert("Couldn't update email, try again.");
        }
    })
}


document.addEventListener("DOMContentLoaded", () => {
    loadUserData();
    //displayMyMessages();
});

document.addEventListener("click", (e) => {
    const target = e.target as HTMLElement;

    if (!target.classList.contains("modal-InboxMessage")) {
        return;
    }
    console.log(target);

    const modalDiv = <HTMLDivElement>document.getElementById("modal-inboxMessage");
    console.log(modalDiv);

    modalDiv.classList.add("show");
    modalDiv.classList.add("modal-show");
    modalDiv.setAttribute("aria-hidden", "false");

})

profileMenu.addEventListener("click", function (e: Event): void {
    const target = <HTMLElement>e.target;

    if (target.nodeName != "BUTTON") return;

    switch (target.id) {
        case "seeDMBtn":
            displayMyMessages();
            return;
        case "changePasswordBtn":
            displayChangePassword();
            return;
        case "changeEmailBtn":
            displayChangeEmail();
            return;
        default:
            break;
    }
});