function fnValidateForm() {
    debugger
    var count = 0;
    if ($("#txtLoginId").val() == undefined || $("#txtLoginId").val() == null || $("#txtLoginId").val().trim() == "") {
        $("#lblLoginId").addClass('required');
        count++;
    }
    else {
        $("#lblLoginId").removeClass('required');
    }
    if ($("#txtOldPassword").val() == undefined || $("#txtOldPassword").val() == null || $("#txtOldPassword").val().trim() == "") {
        $("#lblOldPassword").addClass('required');
        count++;
    }
    else {
        $("#lblOldPassword").removeClass('required');
    }
    if ($("#txtNewPassword").val() == undefined || $("#txtNewPassword").val() == null || $("#txtNewPassword").val().trim() == "") {
        $("#lblNewPassword").addClass('required');
        count++;
    }
    else if ($("#txtNewPassword").val().length < 6) {
        alert(" Password at least 6 Character");
        $("#lblNewPassword").addClass('required');
    }
    else {
        $("#lblNewPassword").removeClass('required');
    }
    if ($("#txtConfirmNewPassword").val() == undefined || $("#txtConfirmNewPassword").val() == null || $("#txtConfirmNewPassword").val().trim() == "") {
        $("#lblConfirmNewPassword").addClass('required');
        count++;
    }
    else {
        $("#lblConfirmNewPassword").removeClass('required');
    }
    if ($("#txtConfirmNewPassword").val() !== $("#txtNewPassword").val()) {
        alert("New Password and Confirm New Password does not match");
        return false;
    }
    if (count > 0) {
        return false;
    }
    else {
        return true;
    }

}

function fnRemoveClass(obj, val) {
    $("#lbl" + val + "").removeClass('required');
}