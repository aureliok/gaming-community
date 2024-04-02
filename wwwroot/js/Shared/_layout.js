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
function linkToUserProfile(userId) {
    window.location.href = "/Community/UserProfile?userId=".concat(userId);
}
logoutBtn === null || logoutBtn === void 0 ? void 0 : logoutBtn.addEventListener("click", logoutUser);
dropdownToggle === null || dropdownToggle === void 0 ? void 0 : dropdownToggle.addEventListener("click", toggleMenu);
document.addEventListener("click", function (e) {
    if (dropdownMenu)
        closeMenu(e);
    var target = e.target;
    if (target.classList.contains("userlink")) {
        var userId = target.classList[1].split("-")[1];
        console.log(userId);
        linkToUserProfile(userId);
    }
});
//# sourceMappingURL=_layout.js.map