document.addEventListener("DOMContentLoaded", function () {
    const tableRows = document.querySelectorAll(".table tbody tr");

    tableRows.forEach(row => {
        row.addEventListener("click", function (this: HTMLTableRowElement) {
            const targetModalId = this.getAttribute("data-target");

            if (targetModalId) {
                const targetModal = document.querySelector(targetModalId);

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
