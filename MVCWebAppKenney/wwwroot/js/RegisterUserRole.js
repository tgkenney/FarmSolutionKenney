$(document).ready(function () {
    $('#FarmGroup').hide();
    $('#RoleGroup').change(function () {
        if ($(this).val() == 'Farmer') {
            $('#FarmGroup').show();
        }
        else {
            $('#FarmGroup').hide();
        }
    });
});