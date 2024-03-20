const loginForm = <HTMLFormElement>document.getElementById("loginForm");
const signUpBtn = <HTMLButtonElement>document.getElementById("signUpBtn");

async function handleLogin() {
    const usernameOrEmail = (<HTMLInputElement>document.getElementById("usernameOrEmail")).value;
    const password = (<HTMLInputElement>document.getElementById("password")).value;


    const response = await fetch("/Login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({ UsernameOrEmail: usernameOrEmail, Password: password })
    });
    
    if (response.ok) {
        alert("login ok!");
        window.location.href = "/Home/Index";
    } else {
        alert("login fail");
    }
}


loginForm?.addEventListener("submit", async function (e) {
    e.preventDefault();
    await handleLogin();
});
signUpBtn?.addEventListener("click", () => {
    window.location.href = "/Register";
})