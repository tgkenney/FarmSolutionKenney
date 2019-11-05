$(document).ready(function () {
    $("#usersTarget").on("change", function () {
        $listCurrentRoles = $("#rolesTarget")
        $.ajax(
            {
                url: "GetCurrentRoles",
                type: "GET",
                dataType: "json",
                data: { id: $("#usersTarget").val() },
                success: function (data) {
                    $listCurrentRoles.empty();
                    $.each(data, function () {
                        $listCurrentRoles.append('<input type="checkbox" name="userRoles" value=" ' + this.Name + ' "> ' + this.Name + '<br>')
                    })
                },
                error: function () {
                    alert("Data not received")
                }
            }
        )
    });
});