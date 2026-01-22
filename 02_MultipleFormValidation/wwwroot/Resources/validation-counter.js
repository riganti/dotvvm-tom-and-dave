ko.bindingHandlers["validation-counter"] = {
    init: (element, valueAccessor) => {
        const pathPrefix = valueAccessor();

        dotvvm.validation.events.validationErrorsChanged.subscribe(_ => {
            element.innerHTML = "";
            const errors = dotvvm.validation.errors;

            const filteredErrors = errors.filter(error => {
                return error.propertyPath.startsWith(pathPrefix);
            });

            if (filteredErrors.length > 0) {
                element.innerHTML = `${filteredErrors.length} error${filteredErrors.length > 1 ? "s" : ""}`;
            }
            element.style.display = filteredErrors.length > 0 ? "" : "none";
        });
    }
}