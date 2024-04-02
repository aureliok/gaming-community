const logoutBtn = <HTMLButtonElement>document.getElementById("logoutBtn");
const dropdownToggle = <HTMLButtonElement>document.getElementById("userDropdown");
const dropdownMenu = <HTMLUListElement>document.querySelector(".dropdown-userMenu");


function logoutUser(): void {
    fetch("/Logout")
        .then(response => {
            if (response.ok) {
                alert("You've successfully logged out!");
                window.location.href = "/Home/Index";
            }
            else {
                throw new Error("Something went wrong, please try again.");
            }
        })
        .catch(error => {
            alert("Error logging out: " + error.message);
        });
};

function toggleMenu(): void {
    if (dropdownMenu.classList.contains("show")) {
        dropdownMenu.classList.remove("show");
    } else {
    dropdownMenu.classList.add("show");
    }
};


function closeMenu(e): void {
    if (!dropdownToggle.contains(e.target as Node) && !dropdownMenu.contains(e.target as Node)) {
        dropdownMenu.classList.remove("show");
    }
};


function linkToUserProfile(userId: string): void {
    window.location.href = `/Community/UserProfile?userId=${userId}`;
}

 
logoutBtn?.addEventListener("click", logoutUser);
dropdownToggle?.addEventListener("click", toggleMenu);
document.addEventListener("click", (e) => {
    if (dropdownMenu) closeMenu(e);

    const target = <HTMLElement>e.target;
    if (target.classList.contains("userlink")) {
        const userId: string = target.classList[1].split("-")[1];
        console.log(userId);
        linkToUserProfile(userId);
    }
});
