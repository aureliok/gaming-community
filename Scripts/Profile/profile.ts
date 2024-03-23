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


function displayMyActivities(): void {
    profileWindow.innerHTML = `
    <h5>My Activities</h5>
    `;
}

function displayMyMessages(): void {
    profileWindow.innerHTML = `
    <h5>My Direct Messages</h5>
    `;
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


document.addEventListener("DOMContentLoaded", loadUserData);

profileMenu.addEventListener("click", function (e: Event): void {
    const target = <HTMLElement>e.target;

    if (target.nodeName != "BUTTON") return;

    switch (target.id) {
        case "myActivitiesBtn":
            displayMyActivities();
            return;
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