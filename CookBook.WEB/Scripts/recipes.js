$(document).ready(function () {
    var page = 0;
    var recipesCount = $('#recipesCount').val();
    next();
    $(window).scroll(function () {
        if ($(window).scrollTop() + $(window).height() === $(document).height()) {
            if (recipesCount > 6 * page) {
                next();
            }
        }
    });
    function next() {
        $.ajax({
            type: "GET",
            url: "/Recipes/GetRecipes/",
            dataType: 'json',
            data: {
                page: page
            },
            success: function (response) {
                page++;
                $.each(response, function (key, value) {
                    var imageTag = null;
                    if (value["ImageUrl"] !== null) {
                        imageTag = "<img class=\"card-img-top\" src=" + value["ImageUrl"] + ">";
                    }
                    else
                    {
                        imageTag = "<img class=\"card-img-top\" src=\"https://www.socabelec.co.ke/wp-content/uploads/no-photo-6.jpg\">";
                    }
                    var txt = "<div id=\""+value["Id"]+"\" class=\"card card-recipe\">" +
                                "<div class=\"card-image\">" +
                                        imageTag +
                                "</div>" +
                                "<div class=\"card-body\">" +
                                    "<h5 class=\"card-title\">" + value["Title"]+"</h5>" +
                                    "<p class=\"card-text\">" + value["ShortDescription"]+"</p>" +
                                "</div>" +
                                "<div class=\"bottom-line row\">"+
                                    "<div class=\"col-md-6\">"+
                                        "<p class=\"comment\">"+7+"<img src=\"/Content/Images/comment.png\" height=\"20\" width=\"20\" /></p>"+
                                    "</div>"+
                                    "<div class=\"col-md-6\">" +
                                        "<p class=\"rating\"><img src=\"/Content/Images/icons8-star-filled-50.png\" height=\"25\" width=\"25\" />" + value["AverageRating"] + "</p>" +
                                    "</div>"+
                                "</div>" +
                            "</div>";
                    $('#cards').append(txt);
                });
            }
        });
    };
});