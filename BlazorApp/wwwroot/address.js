export function initializeAddressAutocomplete(elementId, dotNetHelper) {
    const input = document.getElementById(elementId);
    input.addEventListener('input', async function () {
        const query = input.value;
        const results = ["a", "b", "c"];
        dotNetHelper.invokeMethodAsync('PopupAddresses', results);
    });
}