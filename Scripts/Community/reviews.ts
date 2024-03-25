document.addEventListener("DOMContentLoaded", function (): void {
    const tableRows = document.querySelectorAll(".table tbody tr");

    tableRows.forEach(row => {
        row.addEventListener("click", function (this: HTMLTableRowElement) {
            const targetModalId = this.getAttribute("data-target");

            if (targetModalId) {
                const targetModal = document.querySelector(targetModalId);

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
    const target = <HTMLElement>e.target;
    const modalId = <string>target.getAttribute("id");

    if (!target.classList.contains("modal") && !target.classList.contains("modalClose")) return;

    const modal = <HTMLDivElement>document.getElementById(modalId);

    if (target === modal && !target.classList.contains("modalClose")) {
        modal.classList.remove("show");
        return;
    }
    
    if (target.classList.contains("modalClose")) {
        const modalId = target.getAttribute("id");
        document.getElementById(`modal-${modalId}`)?.classList.remove("show");
    } else {
        return;
    }
})



