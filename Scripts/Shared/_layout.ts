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
    if (!dropdownMenu) {
        return;
    }
    if (!dropdownToggle.contains(e.target as Node) && !dropdownMenu.contains(e.target as Node)) {
        dropdownMenu.classList.remove("show");
    }
};

 
logoutBtn?.addEventListener("click", logoutUser);
dropdownToggle?.addEventListener("click", toggleMenu);
document.addEventListener("click", (e) => closeMenu(e));
