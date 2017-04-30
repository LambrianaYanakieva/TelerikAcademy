function solve() {

    return function(selector) {

        var leftArray = arguments[1] || [];
        var rightArray = arguments[2] || [];

        var mainContainer = document.querySelector(selector);
        var columContainer = document.createElement('div');
        columContainer.className = 'column-container';

        var column1 = createColumn();
        var column2 = createColumn();

        //select radio 1 
        var select1 = column1.children[0];
        var radio1 = select1.children[0];
        radio1.checked = true;

        var mainInput = document.createElement('input');
        var addButton = document.createElement('button');

        mainInput.size = 40;
        mainInput.autofocus = true;

        addButton.innerHTML = 'Add';

        columContainer.appendChild(column1);
        columContainer.appendChild(column2);

        mainContainer.appendChild(columContainer);
        mainContainer.appendChild(mainInput);
        mainContainer.appendChild(addButton);

        // fill first column
        fillColumn(leftArray, column1.children[1]);
        fillColumn(rightArray, column2.children[1]);

        mainContainer.addEventListener('click', function(event) {
            var target = event.target;

            // If delete img is clicked
            if (target.className == 'delete') {
                var parent = target.parentElement;
                parent.removeChild(target);
                mainInput.value = parent.innerHTML;
                var column = parent.parentElement;
                column.removeChild(parent);
            } else {
                // if add Button is clicked
                var textContent = mainInput.value.trim();

                if (textContent !== '') {
                    if (radio1.checked == true) {
                        addElement(textContent, column1.children[1]);
                    } else {
                        addElement(textContent, column2.children[1]);
                    }

                    // clear content of input 
                    mainInput.value = '';
                }
            }
        });
    };

    function createColumn() {
        var column = document.createElement('div');
        column.className = 'column';
        var select = document.createElement('div');
        select.className = 'select';
        var radio = document.createElement('input');
        var label = document.createElement('label');
        var list = document.createElement('ol');

        label.innerHTML = "Add Here";
        radio.type = 'radio';
        radio.name = 'column';

        select.appendChild(radio);
        select.appendChild(label);
        column.appendChild(select);
        column.appendChild(list);

        return column;
    }
    // SUBMIT THE CODE ABOVE THIS LINE
    function addElement(elementContent, outputElement) {
        var li = document.createElement('li');
        li.className = 'entry';
        var deleteImg = document.createElement('img');
        deleteImg.className = 'delete';
        deleteImg.src = './imgs/Remove-icon.png';

        li.appendChild(deleteImg);
        li.innerHTML += elementContent;

        outputElement.appendChild(li);
    }

    function fillColumn(inputArray, outputElement) {
        for (var i = 0; i < inputArray.length; i += 1) {
            addElement(inputArray[i], outputElement);
        }
    }
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
    module.exports = solve;
}