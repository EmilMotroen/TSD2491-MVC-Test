// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.animal-button').click(function () {
        var animal = $(this).data('animal');
        var description = $(this).data('description');

        $.ajax({
            url: '/Home/ButtonClick',
            type: 'POST',
            data: {
                animal: animal,
                uniqueDescription: description
            },
            success: function (response) {
                // Update the view with the new data
                $('#matches-found').text(response.matchesFound);
                $('#time-display').text(response.timeDisplay);
            }
        });
    });
});