$(document).ready(function () {
    $("#usersTarget").on("change", function () {
        DisplayCheckBoxList();
    });
});

function DisplayCheckBoxList() {
    $listCurrentRoles = $("#rolesTarget");
    $.ajax(
        {
            url: "GetCurrentRoles",
            type: "GET",
            dataType: "json",
            data: { id: $("#usersTarget").val() },
            success: function (data) {
                $listCurrentRoles.empty();
                $.each(data, function () {
                    $listCurrentRoles.append('<input type="checkbox" name="userRoles" value=" ' + this.Name + ' "> ' + this.Name + ' <br>');
                });
            },
            error: function () {
                alert("Data not received");
            }
        });

    $listAvailableRoles = $("#availableRolesTarget");
    $.ajax(
        {
            url: "GetAvailableRoles",
            type: "GET",
            dataType: "json",
            data: { id: $("#usersTarget").val() },
            success: function (data) {
                $listAvailableRoles.empty();
                $.each(data, function () {
                    $listAvailableRoles.append('<input type="checkbox" name="availableRoles" value=" ' + this.Name + ' "> ' + this.Name + ' <br>');
                });
            },
            error: function () {
                alert("Data not received");
            }
        });
}

function GetListBoxData(targetType, inputURL, checkboxName) {
    var listRoles = $(targetType);
    $.ajax(
        {
            url: inputURL,
            type: "GET",
            dataType: "json",
            data: { id: $("#usersTarget").val() },
            success: function (data) {
                listRoles.empty();
                $.each(data, function () {
                    var appendString = '<input type="checkbox" name=" ';
                    appendString.append(checkboxName);
                    appendString.append('" value=" ');
                    appendString.append(this.Name);
                    appendString.append(' "> ');
                    appendString.append(this.Name)
                    appendString.append(' <br>');
                    listRoles.append(appendString);
                });
            },
            error: function () {
                alert("Data not received");
            }
        });
}