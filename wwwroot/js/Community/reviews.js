"use strict";
document.addEventListener("DOMContentLoaded", function () {
    var tableRows = document.querySelectorAll(".table tbody tr");
    tableRows.forEach(function (row) {
        row.addEventListener("click", function () {
            var targetModalId = this.getAttribute("data-target");
            if (targetModalId) {
                var targetModal = document.querySelector(targetModalId);
                if (targetModal) {
                    targetModal.classList.add('show');
                    targetModal.setAttribute('aria-hidden', 'false');
                }
            }
            return;
        });
    });
});
document.addEventListener("click", function (e) {
    var _a;
    var target = e.target;
    var modalId = target.getAttribute("id");
    if (!target.classList.contains("modal") && !target.classList.contains("modalClose"))
        return;
    var modal = document.getElementById(modalId);
    if (target === modal && !target.classList.contains("modalClose")) {
        modal.classList.remove("show");
        return;
    }
    if (target.classList.contains("modalClose")) {
        var modalId_1 = target.getAttribute("id");
        (_a = document.getElementById("modal-".concat(modalId_1))) === null || _a === void 0 ? void 0 : _a.classList.remove("show");
    }
    else {
        return;
    }
});
//# sourceMappingURL=reviews.js.map