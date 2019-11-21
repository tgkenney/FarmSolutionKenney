$(document).ready(function () {
    DisplayRoles();
    $("#usersTarget").on("change", function () {
        DisplayRoles();
    });
});

function DisplayRoles() {
    var inputUrl = "GetCurrentRoles";
    var checkBoxName = "currentRoles";
    var rolesTarget = "#currentRolesTarget";
    GetRolesForUser(inputUrl, checkBoxName, rolesTarget);

    inputUrl = "GetAvailableRoles";
    checkBoxName = "availableRoles";
    rolesTarget = "#availableRolesTarget";
    GetRolesForUser(inputUrl, checkBoxName, rolesTarget);
}

function GetRolesForUser(dataUrl, checkBoxName, rolesTarget) {
    var listRoles = $(rolesTarget);
    var usersTarget = $("#usersTarget").val();
    var appendString;
    $.ajax(
        {
            url: dataUrl,
            type: "GET",
            dataType: "json",
            data: { id: usersTarget },
            success: function (data) {
                listRoles.empty();
                $.each(data, function () {
                    appendString = '<input type="checkbox" ';
                    appendString += ' name = "';
                    appendString += checkBoxName;
                    appendString += '" ';
                    appendString += ' value = "';
                    appendString += this.Name;
                    appendString += '" >';
                    appendString += this.Name;
                    appendString += '<br/>';
                    //alert(appendString);
                    listRoles.append(appendString);
                });
            },
            error: function () {
                alert("Data not received");
            }
        });
}