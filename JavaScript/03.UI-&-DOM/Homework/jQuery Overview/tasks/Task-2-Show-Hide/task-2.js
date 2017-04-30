/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/
function solve() {
    return function(selector) {
        var $element;
        if (selector == undefined) {
            throw Error('hhhghghg');
        }
        if (typeof selector == 'string') {
            $element = $(selector);
            if ($element[0] == undefined) {
                throw Error('');
            }
        } else {
            $element = selector;
        }
        $element.find('.button').text('hide');


        $element.on('click', '.button', function() {

            var $buttons = $element.find('.button, .content');

            var saveIndex;
            for (var h = 0; h < $buttons.length; h += 1) {
                if ($buttons[h] == this) {
                    saveIndex = h;
                    break;
                }
            }

            var $clickedButton = $(this);

            for (var i = saveIndex + 1; i < $buttons.length; i += 1) {


                var $currentElement = $($buttons[i]);

                if ($currentElement.hasClass('content')) {
                    if ($currentElement.css('display') != 'none') {
                        $currentElement.css('display', 'none');
                        $clickedButton.text('show');
                    } else {
                        $currentElement.css('display', '');
                        $clickedButton.text('hide');
                    }
                } else {
                    break;
                }

            }
        });
    }
}
module.exports = solve;