$(document).ajaxComplete(function (event, request, settings) {
    $("#category").val($('#categoryValue').val());
    $("#ingredient").val($('#ingregientValue').val());
    $("#cuisine").val($('#countryValue').val());
    $("#method").val($('#cookValue').val());
});