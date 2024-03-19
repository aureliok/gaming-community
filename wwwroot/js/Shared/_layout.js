"use strict";
var logoutBtn = document.getElementById("logoutBtn");
var dropdownToggle = document.getElementById("userDropdown");
var dropdownMenu = document.querySelector(".dropdown-userMenu");
function logoutUser() {
    fetch("/Logout")
        .then(function (response) {
        if (response.ok) {
            alert("You've successfully logged out!");
            window.location.href = "/Home/Index";
        }
        else {
            throw new Error("Something went wrong, please try again.");
        }
    })
        .catch(function (error) {
        alert("Error logging out: " + error.message);
    });
}
;
function toggleMenu() {
    if (dropdownMenu.classList.contains("show")) {
        dropdownMenu.classList.remove("show");
    }
    else {
        dropdownMenu.classList.add("show");
    }
}
;
function closeMenu(e) {
    if (!dropdownToggle.contains(e.target) && !dropdownMenu.contains(e.target)) {
        dropdownMenu.classList.remove("show");
    }
}
;
logoutBtn.addEventListener("click", logoutUser);
dropdownToggle.addEventListener("click", toggleMenu);
document.addEventListener("click", function (e) { return closeMenu(e); });
//# sourceMappingURL=_layout.js.map