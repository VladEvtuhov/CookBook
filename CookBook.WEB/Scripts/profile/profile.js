$(document).ready(function () {
    let url = $('#loader').data('request-url');
    $("#results").load(url);
});