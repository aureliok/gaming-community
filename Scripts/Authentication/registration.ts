import { checkPassword, checkIfPasswordEqual, checkEmailInput } from "../Helpers/validators.js";

const registrationForm = <HTMLFormElement>document.getElementById("registrationForm");
const usernameInput = <HTMLInputElement>document.getElementById("username");
const emailInput = <HTMLInputElement>document.getElementById("email");
const passwordInput = <HTMLInputElement>document.getElementById("password");
const confirmPasswordInput = <HTMLInputElement>document.getElementById("confirmPassword");
const birthDateInput = <HTMLInputElement>document.getElementById("birthDate");
const usernameAvailability = <HTMLSpanElement>document.getElementById("usernameAvailability");
const emailAvailability = <HTMLSpanElement>document.getElementById("emailAvailability");
const strongPassword = <HTMLSpanElement>document.getElementById("validPassword");
const passwordEquality = <HTMLSpanElement>document.getElementById("confirmPasswordEqual");
const birthDateWarning = <HTMLSpanElement>document.getElementById("birthDateWarning");

let validUser: boolean = false;
let validEmail: boolean = false;
let validPassword: boolean = false;
let equalPassword: boolean = false;
let validBDate: boolean = false;

async function checkUsernameAvailability(): Promise<void> {
    const username = usernameInput.value;
    console.log(username);
    const response = await fetch("/CheckIfUsernameExists", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(username)
    });

    if (response.ok) {
        console.log("username does exist");
        usernameAvailability.innerText = "Username is already taken.";
        validUser = false;
    } else if (response.status == 404) {
        console.log("username does not exist");
        usernameAvailability.innerText = "Username is available.";
        validUser = true;
    } else {
        console.log("failed to check");
    }
}



function checkBirthDateValid(): void {
    const birthDate = new Date(birthDateInput.value);

    const currentDate = new Date();
    const minDate = new Date("1900-01-01");
    const maxDate = new Date(currentDate.getFullYear() - 10, currentDate.getMonth(), currentDate.getDate());

    if (birthDate >= minDate && birthDate <= maxDate) {
        birthDateWarning.innerText = "";
        validBDate = true;
    } else {
        birthDateWarning.innerText = `Birth date must be within ${minDate} and ${maxDate}`;
        validBDate = false;
    }
}


async function loginUser(username: string, password: string): Promise<void> {
    try {
        const response = await fetch("/Login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ UsernameOrEmail: username, Password: password })
        });

        if (!response.ok) {
            console.log("Login failed");
        }
    } catch (error) {
        console.error("Error during login: ", error);
    }
}

async function registerNewUser(): Promise<void> {
    const username = (<HTMLInputElement>document.getElementById("username")).value;
    const email = (<HTMLInputElement>document.getElementById("email")).value;
    const password = (<HTMLInputElement>document.getElementById("password")).value;
    const birthDate = (<HTMLInputElement>document.getElementById("birthDate")).value;

    if (!username || !email || !password || !birthDate) {
        alert("All fields are required");
        return;
    }

    if (!validUser || !validEmail || !validPassword || !validBDate || !equalPassword) {
        alert("A field might be incorrect, please review and fill again");
        return;
    }


    const response = await fetch("/RegisterUser", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            Username: username,
            Email: email,
            BirthDate: birthDate,
            Password: password
        })
    });

    if (response.ok) {
        alert("User has been registered!");
        await loginUser(username, password);
        window.location.href = "/Home/Index";
    } else {
        alert("Something went wrong");
    }
}


usernameInput.addEventListener("input", checkUsernameAvailability);
emailInput.addEventListener("input", async () => {
    validEmail = await checkEmailInput(emailInput, emailAvailability);
});
passwordInput.addEventListener("input", async () => {
    validPassword = await checkPassword(passwordInput, strongPassword);
});
confirmPasswordInput.addEventListener("input", async () => {
    equalPassword = await checkIfPasswordEqual(passwordInput,
                         confirmPasswordInput,
                         passwordEquality);
});
birthDateInput.addEventListener("input", checkBirthDateValid);

registrationForm.addEventListener("submit", function (e) {
    e.preventDefault();
    registerNewUser();
});