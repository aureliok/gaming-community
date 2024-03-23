export function checkPassword(passwordInput: HTMLInputElement,
                       strongPassword: HTMLSpanElement,
                       validPassword: boolean): void {
    const passwordRegex: RegExp = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    const password = passwordInput.value;

    if (passwordRegex.test(password)) {
        validPassword = true;
        strongPassword.innerText = "Password is valid.";
    } else {
        validPassword = true;
        strongPassword.innerText = "Your Password must have 8 digits and contain at least one digit and at least one of lowercase, uppercase and special characters.";
    }
}

export function checkIfPasswordEqual(passwordInput: HTMLInputElement,
                              confirmPasswordInput: HTMLInputElement,
                              passwordEquality: HTMLSpanElement,
                              equalPassword: boolean): void {
    //const passwordInput = <HTMLInputElement>document.getElementById("password");

    if (passwordInput.value != confirmPasswordInput.value) {
        passwordEquality.innerText = "Passwords does not match";
        equalPassword = false;
    } else {
        passwordEquality.innerText = "Password OK";
        equalPassword = true;
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
                               emailAvailability: HTMLSpanElement,
                               validEmail: boolean): Promise<void> {
    const email = emailInput.value;

    if (!isEmail(email)) {
        validEmail = false;
        emailAvailability.innerText = "Not a valid email";
        return;
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
        validEmail = false;
    } else if (response.status == 404) {
        console.log("email does not exist");
        emailAvailability.innerText = "Email is available."
        validEmail = true;
    } else {
        console.log("failed to check");
    }
}