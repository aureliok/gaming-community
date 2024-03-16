﻿const loginForm = document.getElementById("loginForm");

async function handleLogin() {
    const usernameOrEmail = (<HTMLInputElement>document.getElementById("usernameOrEmail")).value;
    const password = (<HTMLInputElement>document.getElementById("password")).value;

    console.log(usernameOrEmail, password);

    const response = await fetch("/api/login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ UsernameOrEmail: usernameOrEmail, Password: password })
    });

    if (response.ok) {
        alert("login ok!");
    } else {
        alert("login fail");
    }
}


loginForm?.addEventListener("submit", async function (e) {
    e.preventDefault();
    await handleLogin();
});