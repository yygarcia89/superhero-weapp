$(document).ready(function () {
    $('img.js-profile-photo').on('error', function () {
        $(this).attr('src', 'https://w7.pngwing.com/pngs/434/127/png-transparent-mystery-mysterious-man-s-woman-silhouette-thriller-thumbnail.png');
    });
});