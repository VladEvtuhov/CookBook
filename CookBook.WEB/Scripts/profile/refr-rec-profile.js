function refresh() {
    $.ajax({
        url: '/Profile/UserRecipes/',
        data: { email: $('#userEmail').val() },
        type: 'GET',
        success: function (data) {
            $('#results').html(data);
        }
    });
};