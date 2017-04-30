function solve() {
    return function(selector) {
        if (typeof selector == 'string') {
            selector = document.getElementById(selector);
            if (selector == undefined) {
                throw Error('no element with provided id');
            }
        } else if (!(selector instanceof HTMLElement)) {
            throw Error('invalid element');
        }
        var buttons,
            targetButton,
            currentContent,
            len,
            i;

        buttons = selector.getElementByClassName('button');
        len = buttons.length;
        for (i = 0; i < len; i += 1) {
            buttons[i].innerHTML = 'hide';
        }
        for (i = 0; i < len; i += 1) {
            buttons[i].setEventListener('click', function(event) {
                targetButton = event.target;
                currentContent = targetButton.nextElementSibling;
                if (currentContent.className == 'content') {
                    if (currentContent.style.display == '') {
                        currentContent.style.display = 'none';
                        targetButton.innerHTML = 'show';
                    } else {
                        currentContent.style.display = '';
                        targetButton.innerHTML = 'hide';
                    }
                }
            });
        }


    }
}
module.exports = solve;