export async function checkPassword(passwordInput: HTMLInputElement,
                       strongPassword: HTMLSpanElement): Promise<boolean> {
    const passwordRegex: RegExp = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    const password = passwordInput.value;

    if (passwordRegex.test(password)) {
        strongPassword.innerText = "Password is valid.";
        return true;
    } else {
        strongPassword.innerText = "Your Password must have 8 digits and contain at least one digit and at least one of lowercase, uppercase and special characters.";
        return true;
    }
}

export async function checkIfPasswordEqual(passwordInput: HTMLInputElement,
                              confirmPasswordInput: HTMLInputElement,
                              passwordEquality: HTMLSpanElement): Promise<boolean> {
    //const passwordInput = <HTMLInputElement>document.getElementById("password");

    if (passwordInput.value != confirmPasswordInput.value) {
        passwordEquality.innerText = "Passwords does not match";
        return false;
    } else {
        passwordEquality.innerText = "Password OK";
        return true;
    }
}

export async function checkCurrentPassword(passwordInput: HTMLInputElement,
    correctPassword: HTMLSpanElement): Promise<boolean> {

    const response = await fetch("/CheckCurrentPassword", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(passwordInput.value)
    });


    if (response.ok) {
        correctPassword.innerText = "Ok";
        return true;
    } else {
        correctPassword.innerText = "Password is not correct";
        return false;
    }
}


export function isEmail(input: string): boolean {
    const emailRegex: RegExp = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(input);
}


export async function checkEmailInput(emailInput: HTMLInputElement,
                               emailAvailability: HTMLSpanElement): Promise<boolean> {
    const email = emailInput.value;

    if (!isEmail(email)) {
        emailAvailability.innerText = "Not a valid email";
        return false;
    }

    const response = await fetch("/CheckIfEmailExists", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(email)
    });

    if (response.ok) {
        console.log("email does exist");
        emailAvailability.innerText = "Email is already registered to another user account."
        return false;
    } else if (response.status == 404) {
        console.log("email does not exist");
        emailAvailability.innerText = "Email is available."
        return true;
    } else {
        console.log("failed to check");
        return false;
    }
}