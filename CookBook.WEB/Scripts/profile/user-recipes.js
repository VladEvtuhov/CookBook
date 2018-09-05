$(document).ready(function () {
    $(".card").click(function () {
        window.location.href = $('#getRecipe').data('request-url') + '/' + this.id;
    });
    $(".card a").click(function (e) {
        e.stopPropagation();
    });
})