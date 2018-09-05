$.fn.editable.defaults.mode = 'inline';
$(document).ready(function () {
    let email = $('#userEmail').val();
    $('#username').editable({
        type: "text",
        url: "/Profile/UpdateUserName",
        params: { email: email },
        pk: "1"
    });
    $('#information').editable({
        type: "textarea",
        url: "/Profile/UpdateInformation",
        params: { email: email },
        pk: "1",
        inputclass: 'input-information'
    });
});