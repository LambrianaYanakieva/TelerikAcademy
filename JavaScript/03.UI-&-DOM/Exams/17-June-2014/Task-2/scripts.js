/* globals $ */
$.fn.gallery = function() {

    let cols = arguments[0];

    if (arguments.length > 1 || arguments.length < 1 || (typeof arguments[0] != 'number')) {
        throw Error('invalid input');
    }

    if (cols == undefined) {
        cols = 4;
    }

    let $gallery = $(this);

    let $galleryList = $('.gallery-list');
    let $imageContainer = $('.image-container');
    let imageList = $('img[data-info]');

    let $selected = $('.selected');
    let $currentImage = $('#current-image');
    let $previousImage = $('#previous-image');
    let $nextImage = $('#next-image');

    let imageContainerWidth = $imageContainer.width() + 10;
    let galleryWidth = imageContainerWidth * cols;

    $gallery.css('width', galleryWidth);

    $selected.hide();

    //Show selected images:
    $galleryList.on('click', 'img', function() {

        let $target = $(this);

        $galleryList.addClass('blurred');

        //Get index of elements in 'imageList' array:
        let indexOfTargetImage = Number($target.attr('data-info')) - 1;
        let indexOfPreviousImage = indexOfTargetImage - 1;
        let indexOfNextImage = indexOfTargetImage + 1;
        let lastImageIndex = Number($(imageList[imageList.length - 1]).attr('data-info')) - 1;

        $currentImage.attr('src', $(imageList[indexOfTargetImage]).attr('src'));
        $currentImage.attr('data-info', $(imageList[indexOfTargetImage]).attr('data-info'));

        //Check if image is first,last or in - between:
        if (indexOfTargetImage == 0) {
            //if $currentImage is the first image, set $previousImage to be the last image
            $previousImage.attr('src', $(imageList[lastImageIndex]).attr('src'));
            $previousImage.attr('data-info', $(imageList[lastImageIndex]).attr('data-info'));

            $nextImage.attr('src', $(imageList[indexOfNextImage]).attr('src'));
            $nextImage.attr('data-info', $(imageList[indexOfNextImage]).attr('data-info'));

        } else if (indexOfTargetImage == lastImageIndex) {
            //if $currentImage is the last image, set $nextImage to be the first image
            $previousImage.attr('src', $(imageList[indexOfPreviousImage]).attr('src'));
            $previousImage.attr('data-info', $(imageList[indexOfPreviousImage]).attr('data-info'));

            $nextImage.attr('src', $(imageList[0]).attr('src'));
            $nextImage.attr('data-info', $(imageList[0]).attr('data-info'));

        } else {
            $previousImage.attr('src', $(imageList[indexOfPreviousImage]).attr('src'));
            $previousImage.attr('data-info', $(imageList[indexOfPreviousImage]).attr('data-info'));

            $nextImage.attr('src', $(imageList[indexOfNextImage]).attr('src'));
            $nextImage.attr('data-info', $(imageList[indexOfNextImage]).attr('data-info'));
        }

        $selected.show();
        $selected.addClass('clearfix');
    });

    //hide selected images, and show default view of the gallery
    $currentImage.on('click', function() {
        $selected.hide();
        $galleryList.removeClass('blurred');
    });

    //slideshow to the left    
    $previousImage.on('click', function() {
        let lastImageIndex = Number($(imageList[imageList.length - 1]).attr('data-info')) - 1;
        let targetIndex = Number($previousImage.attr('data-info')) - 1;
        let mainImageIndex = targetIndex + 1;

        if (targetIndex == 0) {
            //if $currentImage is the first image, set $previousImage to be the last image
            $(this).attr('src', $(imageList[lastImageIndex]).attr('src'));
            $(this).attr('data-info', $(imageList[lastImageIndex]).attr('data-info'));

            $currentImage.attr('src', $(imageList[targetIndex]).attr('src'));
            $currentImage.attr('data-info', $(imageList[targetIndex]).attr('data-info'));

            $nextImage.attr('src', $(imageList[mainImageIndex]).attr('src'));
            $nextImage.attr('data-info', $(imageList[mainImageIndex]).attr('data-info'));

        } else if (targetIndex == lastImageIndex) {
            //if $currentImage is the last image, set $nextImage to be the first image
            $previousImage.attr('src', $(imageList[lastImageIndex - 1]).attr('src'));
            $previousImage.attr('data-info', $(imageList[lastImageIndex - 1]).attr('data-info'));

            $currentImage.attr('src', $(imageList[lastImageIndex]).attr('src'));
            $currentImage.attr('data-info', $(imageList[lastImageIndex]).attr('data-info'));

            $nextImage.attr('src', $(imageList[0]).attr('src'));
            $nextImage.attr('data-info', $(imageList[0]).attr('data-info'));

        } else {
            $(this).attr('src', $(imageList[(targetIndex - 1)]).attr('src'));
            $(this).attr('data-info', $(imageList[(targetIndex - 1)]).attr('data-info'));

            $currentImage.attr('src', $(imageList[targetIndex]).attr('src'));
            $currentImage.attr('data-info', $(imageList[targetIndex - 1]).attr('data-info'));

            $nextImage.attr('src', $(imageList[mainImageIndex]).attr('src'));
            $nextImage.attr('data-info', $(imageList[mainImageIndex]).attr('data-info'));
        }

    });

    //slideshow to the right
    $nextImage.on('click', function() {
        let lastImageIndex = Number($(imageList[imageList.length - 1]).attr('data-info')) - 1;
        let targetIndex = Number($nextImage.attr('data-info')) - 1;
        let mainImageIndex = targetIndex - 1;

        if (targetIndex == 0) {
            //if $currentImage is the first image, set $previousImage to be the last image
            $previousImage.attr('src', $(imageList[lastImageIndex]).attr('src'));
            $previousImage.attr('data-info', $(imageList[lastImageIndex]).attr('data-info'));

            $currentImage.attr('src', $(imageList[targetIndex]).attr('src'));
            $currentImage.attr('data-info', $(imageList[targetIndex]).attr('data-info'));

            $(this).attr('src', $(imageList[targetIndex + 1]).attr('src'));
            $(this).attr('data-info', $(imageList[targetIndex + 1]).attr('data-info'));

        } else if (targetIndex == lastImageIndex) {
            //if $currentImage is the last image, set $nextImage to be the first image
            $previousImage.attr('src', $(imageList[lastImageIndex - 1]).attr('src'));
            $previousImage.attr('data-info', $(imageList[lastImageIndex - 1]).attr('data-info'));

            $currentImage.attr('src', $(imageList[lastImageIndex]).attr('src'));
            $currentImage.attr('data-info', $(imageList[lastImageIndex]).attr('data-info'));

            $(this).attr('src', $(imageList[0]).attr('src'));
            $(this).attr('data-info', $(imageList[0]).attr('data-info'));

        } else {
            $previousImage.attr('src', $(imageList[mainImageIndex]).attr('src'));
            $previousImage.attr('data-info', $(imageList[mainImageIndex]).attr('data-info'));

            $currentImage.attr('src', $(imageList[targetIndex]).attr('src'));
            $currentImage.attr('data-info', $(imageList[targetIndex]).attr('data-info'));

            $(this).attr('src', $(imageList[targetIndex + 1]).attr('src'));
            $(this).attr('data-info', $(imageList[targetIndex + 1]).attr('data-info'));
        }

    });

}