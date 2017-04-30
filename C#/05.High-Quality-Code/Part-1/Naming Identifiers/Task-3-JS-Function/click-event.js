const execute = (function Event(boolean) {
    if (boolean) {
        alert("Yes");
    } else {
        alert("No");
    }
})();

function IsValidBrowser(event, browser) {
    var currentBrowser,
        isValid;

    currentBrowser = window.navigator.appCodeName;

    isValid = (currentBrowser == `${browser}`);

    execute.Event(isValid);
}