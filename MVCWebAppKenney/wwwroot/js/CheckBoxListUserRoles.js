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
                    $listCurrentRoles.append('<input type="checkbox" name="rolesTarget" value=" ' + this.Name + ' "> ' + this.Name + ' <br>');
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
                    $listAvailableRoles.append('<input type="checkbox" name="availableRolesTarget" value=" ' + this.Name + ' "> ' + this.Name + ' <br>');
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
                    listRoles.append('<input type="checkbox" name="' + checkboxName + '" value=" ' + this.Name + ' "> ' + this.Name + ' <br>');
                });
            },
            error: function () {
                alert("Data not received");
            }
        });
}