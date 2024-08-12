// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#TripType').change(function () {
        if ($(this).val() === 'OneWay') {
            $('#ResReturnDate').closest('.form-group').hide();
            $('#ResReturnTime').closest('.form-group').hide();
        } else {
            $('#ResReturnDate').closest('.form-group').show();
            $('#ResReturnTime').closest('.form-group').show();
        }
    }).change(); // Trigger change on page load
});