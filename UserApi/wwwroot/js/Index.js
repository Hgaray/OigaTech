

var baseUrl = "https://localhost:52135/api";

$(document).ready(function () {

    if (localStorage.getItem('baseUrl') == undefined) {       
        localStorage.setItem('baseUrl', window.location.href);
    }
    baseUrl = localStorage.getItem('baseUrl');
    GetAll();
});

function GetAll() {


    $.ajax({
        type: "Get",
        url: `${baseUrl}api/User/GetAll`,
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            console.log(result);
            let bodyTable = "";
            $.each(result, function (index, item) {
                bodyTable += `<tr>
                                <td align="center">${item.fullName}</td>
                                <td align="center">${item.userName}</td>
                                <td align="center"><a href="#">View</a></td>
                            </tr>`
            });

            $("#users tbody").append(bodyTable);
        },
        error: function (error) {
            console.log(error)
        }
    });

}
function save() {

    const newUser = {
        fullName: $("#fullName").val(),
        userName: $("#userName").val()
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(newUser),
        url: `${baseUrl}api/User`,
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            alert("User created successful");            
            GetAll();
        },
        error: function (error) {
            console.log(error)
        }
    });
}
function search() {

}