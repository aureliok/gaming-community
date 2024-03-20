"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var registrationForm = document.getElementById("registrationForm");
var usernameInput = document.getElementById("username");
var emailInput = document.getElementById("email");
var passwordInput = document.getElementById("password");
var confirmPasswordInput = document.getElementById("confirmPassword");
var birthDateInput = document.getElementById("birthDate");
var usernameAvailability = document.getElementById("usernameAvailability");
var emailAvailability = document.getElementById("emailAvailability");
var strongPassword = document.getElementById("validPassword");
var passwordEquality = document.getElementById("confirmPasswordEqual");
var birthDateWarning = document.getElementById("birthDateWarning");
var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
var passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
var validUser = false;
var validEmail = false;
var validPassword = false;
var equalPassword = false;
var validBDate = false;
function checkUsernameAvailability() {
    return __awaiter(this, void 0, void 0, function () {
        var username, response;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    username = usernameInput.value;
                    console.log(username);
                    return [4 /*yield*/, fetch("/CheckIfUsernameExists", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify(username)
                        })];
                case 1:
                    response = _a.sent();
                    if (response.ok) {
                        console.log("username does exist");
                        usernameAvailability.innerText = "Username is already taken.";
                        validUser = false;
                    }
                    else if (response.status == 404) {
                        console.log("username does not exist");
                        usernameAvailability.innerText = "Username is available.";
                        validUser = true;
                    }
                    else {
                        console.log("failed to check");
                    }
                    return [2 /*return*/];
            }
        });
    });
}
function isEmail(input) {
    return emailRegex.test(input);
}
function checkEmailInput() {
    return __awaiter(this, void 0, void 0, function () {
        var email, response;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    email = emailInput.value;
                    if (!isEmail(email)) {
                        validEmail = false;
                        emailAvailability.innerText = "Not a valid email";
                        return [2 /*return*/];
                    }
                    return [4 /*yield*/, fetch("/CheckIfEmailExists", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify(email)
                        })];
                case 1:
                    response = _a.sent();
                    if (response.ok) {
                        console.log("email does exist");
                        emailAvailability.innerText = "Email is already registered to another user account.";
                        validEmail = false;
                    }
                    else if (response.status == 404) {
                        console.log("email does not exist");
                        emailAvailability.innerText = "Email is available.";
                        validEmail = true;
                    }
                    else {
                        console.log("failed to check");
                    }
                    return [2 /*return*/];
            }
        });
    });
}
function checkPassword() {
    var password = passwordInput.value;
    if (passwordRegex.test(password)) {
        validPassword = true;
        strongPassword.innerText = "Password is valid.";
    }
    else {
        validPassword = true;
        strongPassword.innerText = "Your Password must have 8 digits and contain at least one digit and at least one of lowercase, uppercase and special characters.";
    }
}
function checkIfPasswordEqual() {
    var passwordInput = document.getElementById("password");
    if (passwordInput.value != confirmPasswordInput.value) {
        passwordEquality.innerText = "Passwords does not match";
        equalPassword = false;
    }
    else {
        passwordEquality.innerText = "Password OK";
        equalPassword = true;
    }
}
function checkBirthDateValid() {
    var birthDate = new Date(birthDateInput.value);
    var currentDate = new Date();
    var minDate = new Date("1900-01-01");
    var maxDate = new Date(currentDate.getFullYear() - 10, currentDate.getMonth(), currentDate.getDate());
    if (birthDate >= minDate && birthDate <= maxDate) {
        birthDateWarning.innerText = "";
        validBDate = true;
    }
    else {
        birthDateWarning.innerText = "Birth date must be within ".concat(minDate, " and ").concat(maxDate);
        validBDate = false;
    }
}
function loginUser(username, password) {
    return __awaiter(this, void 0, void 0, function () {
        var response, error_1;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 2, , 3]);
                    return [4 /*yield*/, fetch("/Login", {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json"
                            },
                            body: JSON.stringify({ UsernameOrEmail: username, Password: password })
                        })];
                case 1:
                    response = _a.sent();
                    if (!response.ok) {
                        console.log("Login failed");
                    }
                    return [3 /*break*/, 3];
                case 2:
                    error_1 = _a.sent();
                    console.error("Error during login: ", error_1);
                    return [3 /*break*/, 3];
                case 3: return [2 /*return*/];
            }
        });
    });
}
function registerNewUser() {
    return __awaiter(this, void 0, void 0, function () {
        var username, email, password, birthDate, response;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    username = document.getElementById("username").value;
                    email = document.getElementById("email").value;
                    password = document.getElementById("password").value;
                    birthDate = document.getElementById("birthDate").value;
                    if (!username || !email || !password || !birthDate) {
                        alert("All fields are required");
                        return [2 /*return*/];
                    }
                    if (!validUser || !validEmail || !validPassword || !validBDate || !equalPassword) {
                        alert("A field might be incorrect, please review and fill again");
                        return [2 /*return*/];
                    }
                    return [4 /*yield*/, fetch("/RegisterUser", {
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
                        })];
                case 1:
                    response = _a.sent();
                    if (!response.ok) return [3 /*break*/, 3];
                    alert("User has been registered!");
                    return [4 /*yield*/, loginUser(username, password)];
                case 2:
                    _a.sent();
                    window.location.href = "/Home/Index";
                    return [3 /*break*/, 4];
                case 3:
                    alert("Something went wrong");
                    _a.label = 4;
                case 4: return [2 /*return*/];
            }
        });
    });
}
usernameInput.addEventListener("input", checkUsernameAvailability);
emailInput.addEventListener("input", checkEmailInput);
passwordInput.addEventListener("input", checkPassword);
confirmPasswordInput.addEventListener("input", checkIfPasswordEqual);
birthDateInput.addEventListener("input", checkBirthDateValid);
registrationForm.addEventListener("submit", function (e) {
    e.preventDefault();
    registerNewUser();
});
//# sourceMappingURL=registration.js.map