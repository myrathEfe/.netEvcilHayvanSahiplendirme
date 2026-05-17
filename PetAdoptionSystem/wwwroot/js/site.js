// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const sterilizationSpecies = new Set(["Cat", "Dog", "Rabbit", "Hamster", "GuineaPig"]);

function updatePetFormVisibility() {
    const speciesSelect = document.querySelector("[data-species-select]");
    const sterilizationField = document.querySelector("[data-sterilization-field]");
    const sterilizationSelect = document.querySelector("[data-sterilization-select]");
    const disabilitySelect = document.querySelector("[data-disability-select]");
    const disabilityDescriptionField = document.querySelector("[data-disability-description-field]");
    const disabilityDescription = disabilityDescriptionField?.querySelector("[data-disability-description]");

    if (speciesSelect && sterilizationField && sterilizationSelect) {
        const supportsSterilization = sterilizationSpecies.has(speciesSelect.value);
        sterilizationField.classList.toggle("d-none", !supportsSterilization);
        sterilizationSelect.disabled = !supportsSterilization;

        if (!supportsSterilization) {
            sterilizationSelect.value = "";
        }
    }

    if (disabilitySelect && disabilityDescriptionField && disabilityDescription) {
        const hasDisability = disabilitySelect.value === "Yes";
        disabilityDescriptionField.classList.toggle("d-none", !hasDisability);
        disabilityDescription.disabled = !hasDisability;
        disabilityDescription.required = hasDisability;

        if (!hasDisability) {
            disabilityDescription.value = "";
        }
    }
}

function bindClickablePetCards() {
    document.querySelectorAll("[data-card-link]").forEach((card) => {
        const openDetails = () => {
            const target = card.getAttribute("data-card-link");
            if (target) {
                window.location.href = target;
            }
        };

        card.addEventListener("click", (event) => {
            if (event.target.closest("a, button, input, select, textarea, label, form")) {
                return;
            }

            openDetails();
        });

        card.addEventListener("keydown", (event) => {
            if (event.key !== "Enter" && event.key !== " ") {
                return;
            }

            if (event.target.closest("a, button, input, select, textarea, label, form")) {
                return;
            }

            event.preventDefault();
            openDetails();
        });
    });
}

document.addEventListener("DOMContentLoaded", () => {
    updatePetFormVisibility();
    bindClickablePetCards();

    document.querySelector("[data-species-select]")?.addEventListener("change", updatePetFormVisibility);
    document.querySelector("[data-disability-select]")?.addEventListener("change", updatePetFormVisibility);
});
