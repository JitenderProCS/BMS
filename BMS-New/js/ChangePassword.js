function fnValidateForm() {
    debugger
    var count = 0;
    if ($("#txtLoginId").val() == undefined || $("#txtLoginId").val() == null || $("#txtLoginId").val().trim() == "") {

        $("#lblLoginId").addClass('text-danger');
        count++;
    }
    else {
        $("#lblLoginId").removeClass('text-danger');
    }
    if ($("#txtOldPassword").val() == undefined || $("#txtOldPassword").val() == null || $("#txtOldPassword").val().trim() == "") {
        $('#lblOldPassword').addClass('text-danger');
        count++;
    }
    else {
        $("#lblOldPassword").removeClass('text-danger');
    }
    if ($("#txtNewPassword").val() == undefined || $("#txtNewPassword").val() == null || $("#txtNewPassword").val().trim() == "") {
        $("#lblNewPassword").addClass('text-danger');
        count++;
    }
    else if ($("#txtNewPassword").val().length < 6) {
        alert(" Password at least 6 Character");
        $("#lblNewPassword").addClass('text-danger');
    }
    else {
        $("#lblNewPassword").removeClass('text-danger');
    }
    if ($("#txtConfirmNewPassword").val() == undefined || $("#txtConfirmNewPassword").val() == null || $("#txtConfirmNewPassword").val().trim() == "") {
        $("#lblConfirmNewPassword").addClass('text-danger');
        count++;
    }
    else {
        $("#lblConfirmNewPassword").removeClass('text-danger');
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
    debugger
    $("#lbl" + val + "").removeClass('text-danger');
}