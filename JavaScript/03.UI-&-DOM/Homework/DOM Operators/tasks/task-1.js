function solve() {

    return function(element, contents) {

        var divFragment,
            divElement,
            len,
            i;

        if (element === undefined || contents === undefined) {
            throw Error('parameter is not defined');
        }

        if (contents.length < 0) {
            throw Error('contents should be array');
        }

        divFragment = document.createDocumentFragment();

        if (typeof element === 'string') {
            element = document.getElementById(element);

            if (element === undefined) {
                throw Error('cannot find element with provided id');
            }
        }

        if (!(element instanceof HTMLElement)) {
            throw Error('invalid instance');
        }

        len = contents.length;
        for (i = 0; i < len; i += 1) {

            if (typeof content !== 'string' && typeof content !== 'number') {
                throw Error('type of content should be string or number');
            }

            divElement = document.createElement('div');
            divElement.innerHTML = content;
            divFragment.appendChild(divElement);
        }

        element.innerHTML = '';
        element.appendChild(divFragment);

    };
}

module.exports = solve;