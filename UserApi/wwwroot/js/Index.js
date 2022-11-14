

var baseUrl = "https://localhost:52135/api";
var userList;

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

            populateTable(result);

            //console.log(result);
            //userList = result;
            //let bodyTable = "";
            //$.each(result, function (index, item) {
            //    bodyTable += `<tr>
            //                    <td align="center">${item.fullName}</td>
            //                    <td align="center">${item.userName}</td>
            //                    <td align="center"><a href="#" onclick=view(${item.userId})>View</a></td>
            //                </tr>`
            //});

            //$("#users tbody").html(bodyTable);
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
function search(event) {

    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '17' || keycode == '32') {
        return false;
    }
    const searching = $("#search").val();
    if (searching == "") {
        GetAll();
    }
    else {
        $.ajax({
            type: "Get",
            url: `${baseUrl}api/User/Search?search=${searching}`,
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                populateTable(result);
                //console.log(result);
                //let bodyTable = "";
                //$.each(result, function (index, item) {
                //    bodyTable += `<tr>
                //                <td align="center">${item.fullName}</td>
                //                <td align="center">${item.userName}</td>
                //                <td align="center"><a href="#" onclick=view(${item.userId})>View</a></td>
                //            </tr>`
                //});

                //$("#users tbody").html(bodyTable);
            },
            error: function (error) {
                console.log(error)
            }
        });
    }

}
function view(id) {
    const userView = userList.find(x => x.userId == id);
    $("#fullNameView").text(userView.fullName);
    $("#userNameView").text(userView.userName);
}

function populateTable(data) {
    console.log(data)
    let bodyTable = "";
    if (data != undefined && data.length) {
        userList = data;

        $.each(data, function (index, item) {
            bodyTable += `<tr>
                                <td align="center">${item.fullName}</td>
                                <td align="center">${item.userName}</td>
                                <td align="center"><a href="#" onclick=view(${item.userId})>View</a></td>
                            </tr>`
        });
    }
    else {
        bodyTable +="<tr><td colspan=3> No results found</td></tr>"
    }
    

    $("#users tbody").html(bodyTable);
}