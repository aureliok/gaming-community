"use strict";
document.addEventListener("DOMContentLoaded", function () {
    var tableRows = document.querySelectorAll(".table tbody tr");
    tableRows.forEach(function (row) {
        row.addEventListener("click", function () {
            var targetModalId = this.getAttribute("data-target");
            if (targetModalId) {
                var targetModal = document.querySelector(targetModalId);
                console.log(targetModalId);
                if (targetModal) {
                    targetModal.classList.add('show');
                    targetModal.setAttribute('aria-hidden', 'false');
                }
            }
            return;
        });
    });
});
//# sourceMappingURL=reviews.js.map