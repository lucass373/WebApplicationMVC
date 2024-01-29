
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready( function () {
    $('#myTable').DataTable();
} );


$('.close-alert').on("click", function () {
    $('.alert').hide('hide');
});