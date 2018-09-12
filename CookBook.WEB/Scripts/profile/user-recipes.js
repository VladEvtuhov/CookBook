$(document).ready(function () {
    /*$(".card").click(function () {
    window.location.href = $('#getRecipe').data('request-url') + '/' + this.id;
});
$(".card a").click(function (e) {
    e.stopPropagation();
});*/
    $('div .remove').click(function () {
        $.ajax({
            type: "Post",
            url: "/Profile/RemoveRecipe/",
            data: {
                id: $('div .remove input').val(),
                email: $('#userEmail').val()
            },
            async: false
        }).done(refresh());
    });
});