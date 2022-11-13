const baseUrl = "https://localhost:7079/api";

$(document).ready(function () {

});


function save() {

    const newUser = {
        fullName: $("#fullName").val(),
        userName: $("#userName").val()
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(newUser),
        url: `${baseUrl}/User`,
        contentType: "application/json",
        dataType: "json",
        success: function (result) {

            alert("User creation successful");
        },
        error: function (error) {
            console.log(error)
            alert(error.responseText);
        }
    });
}
