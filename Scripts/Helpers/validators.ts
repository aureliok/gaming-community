function checkPassword(): void {
    const password = passwordInput.value;

    if (passwordRegex.test(password)) {
        validPassword = true;
        strongPassword.innerText = "Password is valid.";
    } else {
        validPassword = true;
        strongPassword.innerText = "Your Password must have 8 digits and contain at least one digit and at least one of lowercase, uppercase and special characters.";
    }
}


function checkIfPasswordEqual(): void {
    const passwordInput = <HTMLInputElement>document.getElementById("password");

    if (passwordInput.value != confirmPasswordInput.value) {
        passwordEquality.innerText = "Passwords does not match";
        equalPassword = false;
    } else {
        passwordEquality.innerText = "Password OK";
        equalPassword = true;
    }
}


function isEmail(input: string): boolean {
    return emailRegex.test(input);
}


async function checkEmailInput(): Promise<void> {
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