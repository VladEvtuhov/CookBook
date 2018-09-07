$(document).ready(function () {
    $('#creatorEmail').val($('#userEmail').val());
    $('#Modal').modal('show');
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Profile/GetCategories',
        success: function (response) {
            $.each(response, function (key, value) {
                $('#category').append($("<option/>", {
                    value: value,
                    text: value
                }));
            });
        }
    });
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Profile/GetIngredientTypes',
        success: function (response) {
            $.each(response, function (key, value) {
                $('#ingredient').append($("<option/>", {
                    value: value,
                    text: value
                }));
            });
        }
    });
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Profile/GetCuisineCountries',
        success: function (response) {
            $.each(response, function (key, value) {
                $('#cuisine').append($("<option/>", {
                    value: value,
                    text: value
                }));
            });
        }
    });
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Profile/GetCookingMethods',
        success: function (response) {
            $.each(response, function (key, value) {
                $('#method').append($("<option/>", {
                    value: value,
                    text: value
                }));
            });
        }
    });
});
$(function () {
    $('#createRecipe').click(function () {
        $('#Modal').modal('hide');
    });
});