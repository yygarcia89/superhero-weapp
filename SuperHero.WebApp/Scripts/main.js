$(document).ready(function () {
    $('img.js-profile-photo').on('error', function () {
        $(this).attr('src', '/Content/Images/profile-image-404.png');
    });
});