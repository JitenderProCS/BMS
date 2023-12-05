var objUser = [];
var uploadedFile = null;
var arrmultiCompanies = new Array();
var multicompanies = [];

$(document).ready(function () {
    debugger
    window.history.forward();
    function preventBack() { window.history.forward(1); }

    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (('' + day).length < 2 ? '0' : '') + day + '/' +
        (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();
    $("input[id*='txtTenurestartdate']").val(output);
    $("input[id*='txtTenureenddate']").val(output);
    $("input[id*='txtDateofbirth']").val(output);

    getAllUsersRole();
    fnGetUserList();
    fnBindDepartment();
    fnBindDesignation();
    //fnBindCategory();

    $("input[id*='txtEmail']").prop("disabled", false).val("");
    $("input[id*='txtUserid']").prop("disabled", false).val("");

    $('#stack1').on('hide.bs.modal', function () {
    });
    //$("span[Id*='spnTitle']").html("New User");
});

function fnBindDepartment() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/Department/GetDepartmentsForUser";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({
            Id: 0
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            if (msg.StatusFl) {
                $("#ddlDepartment").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.DepartmentList != undefined && msg.DepartmentList != null) {
                    if (msg.DepartmentList.length > 0) {
                        for (var i = 0; i < msg.DepartmentList.length; i++) {
                            $("#ddlDepartment").append($("<option></option>").val(msg.DepartmentList[i].departmentId).html(msg.DepartmentList[i].departmentName));
                        }
                    }
                }
            }
            else {
                //alert(msg.Msg);
                $("#ddlDepartment").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                return false;
            }
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}

function fnBindDesignation() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/User/GetDesignation";
    $.ajax({
        type: "GET",
        url: webUrl,
        data: {},
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            if (msg.StatusFl) {
                $("#ddlDesignation").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.DesignationList != undefined && msg.DesignationList != null) {
                    if (msg.DesignationList.length > 0) {
                        for (var i = 0; i < msg.DesignationList.length; i++) {
                            $("#ddlDesignation").append($("<option></option>").val(msg.DesignationList[i].ID).html(msg.DesignationList[i].designationName));
                        }
                    }
                }
            }
            else {
                $("#ddlDesignation").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                return false;
            }
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}

function fnBindCategory() {
    $("#Loader").show();
    var webUrl = uri + "/api/User/GetCategory";
    $.ajax({
        type: "GET",
        url: webUrl,
        data: {},
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            if (msg.StatusFl) {
                $("#ddlCategory").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.CategoryList != undefined && msg.CategoryList != null) {
                    if (msg.CategoryList.length > 0) {
                        for (var i = 0; i < msg.CategoryList.length; i++) {
                            $("#ddlCategory").append($("<option></option>").val(msg.CategoryList[i].ID).html(msg.CategoryList[i].categoryName));
                        }
                    }
                }
            }
            else {
                $("#ddlCategory").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                return false;
            }
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}

function valueChanged() {
    if ($('.coupon_question').is(":checked")) {
        $("#remark").show();
        $("#txtPAN").prop('disabled', true);
    }
    else {
        $("#remark").hide();
        $("#txtPAN").prop('disabled', false);
        $("textarea[id*='txtPANRemark']").val("");
    }
}

function valueChangeddin() {
    if ($('.coupon_questiondin').is(":checked")) {
        $("#dinremark").show();
        $("#txtDIN").prop('disabled', true);
    }
    else {
        $("#dinremark").hide();
        $("#txtDIN").prop('disabled', false);
        $("textarea[id*='txtDINRemark']").val("");
    }
}

//function getdiv() {
//    var roleid = $("select[id*='ddlRole']").val().trim();
//    if (roleid == 3) {
//        $("#directorprofile").show();
//        $("#remark").hide();
//        $("#dinremark").hide();
//        $("#divDepartment,#divDesignation,#brDepartment,#brDesignation").hide();
//        $("#divCategory,#brCategory").show();
//        $("input[name='coupon_question']").prop('checked', false);
//    }
//    else {
//        $("#directorprofile").hide();
//        $("#divDepartment,#divDesignation,#brDepartment,#brDesignation").show();
//        $("#divCategory,#brCategory").hide();
//    }
//}

function getdiv() {
    debugger
    var roleid = $("select[id*='ddlRole']").val().trim();
    if (roleid == '3') {
        $("#directorprofile").show();
        $("#remark").hide();
        $("#dinremark").hide();
        $("#divDepartment,#divDesignation,#brDepartment,#brDesignation").hide();
        $("#divCategory,#brCategory").show();
        $("input[name='coupon_question']").prop('checked', false);
    }
    else if (roleid == '1') {
        $("#RoleAdmin").show();
        $("#divDepartment,#divDesignation,#brDepartment,#brDesignation").show();
        $("#directorprofile").hide();
        $("#divCategory,#brCategory").hide();
    }
    else {
        $("#directorprofile").hide();
        $("#divDepartment,#divDesignation,#brDepartment,#brDesignation").show();
        $("#divCategory,#brCategory").hide();
        $("#RoleAdmin").hide();
    }
}

//function get2nddiv() {
//    var ddl17A_id = $("select[id*='ContentPlaceHolder1_ddl17A']").val().trim();
//    if (ddl17A_id == "YES") {
//        $("#dateandfileupload").show();
//    }
//    else {
//        $("#dateandfileupload").hide();
//    }
//}

function initializeDataTable() {
    var table = $('#tbl-User-setup').DataTable({
        "scrollX": true,
        scrollY: 350,
        dom: 'Bfrtip',
        pageLength: 10,
        buttons: [
            {
                extend: 'pdf',
                className: 'btn green btn-outline',
                exportOptions: {
                    //modifier: {
                    //    page: 'current'
                    //}
                    columns: [1, 2, 3, 4, 5, 6]
                }
            },

            {
                extend: 'excel',
                className: 'btn yellow btn-outline ',
                exportOptions: {
                    //modifier: {
                    //    page: 'current'
                    //}
                    columns: [1, 2, 3, 4, 5, 6]
                }
            },
        ]
    });
}

function fnGetUserList() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/User/GetUserList";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({
            status: $("select[id*='ddlUserStatus']").val()
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            var result = "";
            var table = $('#tbl-User-setup').DataTable();
            table.destroy();
            $("#tbdUserList").html("");
            if (msg.StatusFl) {
                arrmultiCompanies = new Array();
                arrmultiCompanies = msg.UserList;

                for (var i = 0; i < msg.UserList.length; i++) {
                    objUser.push(msg.UserList[i]);
                    result += '<tr id="tr_' + msg.UserList[i].ID + '">';
                    result += '<td id="tdEdit_' + msg.UserList[i].ID + '"><a data-target="#exampleModalSizeLg" data-toggle="modal" id="a_' + msg.UserList[i].ID + '" title="Edit" class="btn btn-light-primary px-3 font-weight-bold" onclick=\"javascript:fnEditUser(' + i + ',\'' + msg.UserList[i].userLogin + '\');\"><i class="fas fa-pencil-alt"></i></a></td>';
                    result += '<td id="tdUser_Name_' + msg.UserList[i].ID + '">' + msg.UserList[i].userFirstName + '</td>';
                    result += '<td id="tdUser_Role_' + msg.UserList[i].ID + '">' + msg.UserList[i].role.role + '</td>';
                    result += '<td id="tdUser_Email_' + msg.UserList[i].ID + '">' + msg.UserList[i].emailId + '</td>';
                    //result += '<td  id="tdUser_TenureStart_' + msg.UserList[i].ID + '">' + msg.UserList[i].tenureStartDate.split(" ")[0] + '</td>';
                    //result += '<td id="tdUser_TenureEnd_' + msg.UserList[i].ID + '">' + msg.UserList[i].tenureEndDate.split(" ")[0] + '</td>';
                    result += '<td id="tdUser_UserLogin_' + msg.UserList[i].ID + '">' + msg.UserList[i].userLogin + '</td>';
                    result += '<td id="tdUser_Status_' + msg.UserList[i].ID + '">' + msg.UserList[i].status + '</td>';
                    if (msg.UserList[i].uploadAvatar == "") {
                        result += '<td id="tdUser_Avatar_' + msg.UserList[i].ID + '"><image height="80px" width="80px" src=' + uri + '/BoardMeeting/images/user/Unknown.png/></td>';
                    }
                    else {
                        var pic = msg.UserList[i].uploadAvatar;
                        result += '<td id="tdUser_Avatar_' + msg.UserList[i].ID + '"><image height="80px" width="80px" src=' + uri + "/BoardMeeting/images/user/" + pic + '/></td>';
                    }
                    result += '</tr>';
                }
                $("#tbdUserList").html(result);
                initializeDataTable();
            }
            else {
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                else {
                    $("#tbdUserList").html(result);
                    initializeDataTable();
                }
                return false;
            }
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}

function fnSaveUser() {
    if (fnValidate()) {
        fnAddUpdateUser();
    }
    else {
        $('#btnSave').removeAttr("data-dismiss");
        return false;
    }
}

function fnAddUpdateUser() {
    debugger
    var userData = new FormData();
    var multicompanies = [];

    for (var i = 0; i < $("#tbdCompany").children().length; i++) {
        var AE = new String();
        AE = $($($($("#tbdCompany").children()[i]).children()[0]).children()[0]).val();
        multicompanies.push(AE);
    }
   

    var UserColl = [];
    UserColl[UserColl.length] = new User($("input[id*='txtUserId']").val() == 0 ? 0 : $("input[id*='txtUserId']").val(),
        $("input[id*='txtEmail']").val(), $("input[id*='txtFirstName']").val(), $("input[id*='txtMiddleName']").val(), $("input[id*='txtLastName']").val(), $("select[id*='ddlSalutation']").val(),
        $("input[id*='txtPhone']").val(), $("textarea[id*='txtAddress']").val(), $("input[id*='txtTenurestartdate']").val(),
        $("input[id*='txtTenureenddate']").val(), $("input[id*='txtDateofbirth']").val(), $("select[id*='ddlNationality']").val(),
        $("input[id*='txtUserid']").val(),
        //$("input[id*='txtPassword']").val(),
        //$("#txtPassword").val(fff),
        $("select[id*='ddlRole']").val(),
        $("select[id*='ddlCategory']").val(),
        $("select[id*='ddlStatus']").val(),
        $("textarea[id*='txtProfile']").val(),
        $("input[id*='txtPAN']").val(),
        $("textarea[id*='txtPANRemark']").val(),
        $("input[id*='txtDIN']").val(),
        $("textarea[id*='txtDINRemark']").val(),
        $("input[id*='txtdate']").val(),
        $("textarea[id*='txtOccupationArea']").val(),
        $("textarea[id*='txtEducationalqualification']").val(),
        $("textarea[id*='txtExperience']").val(),
        $("select[id*='ddlGender']").val(),
        $("input[id*='txtAadharNo']").val(),
        $("input[id*='txtShareholding']").val(),
        $("input[id*='txtshareholdingpercentage']").val(),
        $("input[id*='txtAppointedSection']").val(),
        $("input[id*='txtCommitteesAlreadyDirector']").val(),
        $("select[id*='no1']").val(),
        $("select[id*='no2']").val(),
        $("select[id*='no3']").val(),
        $("select[id*='no4']").val(),
        multicompanies,
        $("input[id*='txtMembershipnumber']").val()
        
        //$("select[id*='ddlDepartment']").val(), $("select[id*='ddlDesignation']").val(), $("select[id*='ddlCategory']").val(),
        
       
      
       
      
       
        
      
       
    );

    userData.append("Object", JSON.stringify(UserColl));

    if ($("input[id*='fileUploadImage']").get(0).files.length > 0) {
        userData.append("Files", $("input[id*='fileUploadImage']").get(0).files[0]);
    }

    $("#Loader").show();
    var webUrl = uri + "/api/User/SaveUser";

    setTimeout(function () {
        $.ajax({
            type: 'POST',
            url: webUrl,
            data: userData,
            //cache: false,
            contentType: false,
            //async: false,
            processData: false,
            success: function (msg) {
                $("#Loader").hide();
                if (!msg.StatusFl) {
                    if (msg.Msg == "SessionExpired") {
                        alert("Your session is expired. Please login again to continue");
                        window.location.href = "../Login.aspx";
                    }
                    else {
                        alert(msg.Msg);
                        $('#btnSave').removeAttr("data-dismiss");
                    }
                    return false;
                }
                else {
                    alert(msg.Msg);
                    window.location.reload(true);
                }
                $("#stack1").modal('hide');
            },
            error: function (error) {
                $("#Loader").hide();
                $('#btnSave').removeAttr("data-dismiss");
                alert(error.status + ' ' + error.statusText);
            }
        })
    }, 10);
}

function fnRemoveClass(obj, val) {
    $("#lbl" + val + "").removeClass('text-danger');
}

function UploadFiles(filename) {
    var fileUpload = $("#file").get(0);
    var files = fileUpload.files;
    var test = new FormData();
    for (var i = 0; i < files.length; i++) {
        files[i].name = filename;
        test.append(filename, files[i]);
    }
    var webUrl = uri + "/api/User/SaveImageFile"; //"api/UserHandler.ashx?caller=SaveImageFile";
    setTimeout(function () {
        $.ajax({
            url: webUrl,
            type: "POST",
            contentType: false,
            processData: false,
            data: test,
            async: false,
            success: function (result) {
            },
            error: function (error) {
                if (error.responseText == "Session Expired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                    return false;
                }
                else {
                    if (error.status !== 200) {
                        alert(error.status + ' ' + error.statusText);
                    }
                }
            }
        })
    }, 10);
}

function OpenNew() {
    $("span[Id*='spnTitle']").html("New User");
}

function fnEditUser(index, UserLogin) {
    debugger
    $("span[Id*='spnTitle']").html("Edit User");
    $('#txtUserId').val(objUser[index].ID);
    $('#txtFirstName').val(objUser[index].userFirstName);
    $('#txtMiddleName').val(objUser[index].userMiddleName);
    $('#txtLastName').val(objUser[index].userLastName);
    $('#txtEmail').prop('disabled', true).val(objUser[index].emailId);
   // $("select[id*='ddlRole'] option[value='" + objUser[index].role + "']").prop("selected", true);
    $("select[id*='ddlSalutation'] option[value='" + objUser[index].salutation + "']").prop("selected", true);
    //$("select[id*='ddlDepartment'] option[value='" + objUser[index].department + "']").prop("selected", true);
    //$("select[id*='ddlDesignation'] option[value='" + objUser[index].designation + "']").prop("selected", true);
    $("select[id*='ddlCategory'] option[value='" + objUser[index].category + "']").prop("selected", true);
    $("select[id*='ddlRole'] option[value='" + objUser[index].role.Id + "']").prop("selected", true);
    $("select[id*='ddlDepartment'] option[value='" + objUser[index].department.departmentId + "']").prop("selected", true);
    $("select[id*='ddlDesignation'] option[value='" + objUser[index].designation.ID + "']").prop("selected", true);
    //$("select[id*='ddlCategory'] option[value='" + objUser[index].category.ID + "']").prop("selected", true);
    getdiv();
    $('#txtPhone').val(objUser[index].phone);
    $('#txtAddress').val(objUser[index].address);
    var dateformat = objUser[index].tenureStartDate.split(' ')[0];
    var dateformat1 = objUser[index].tenureEndDate.split(' ')[0];
    var dateformat2 = objUser[index].dateOfBirth.split(' ')[0];
    var TenDate = dateformat.split('-').reverse().join('-');
    var TenDate1 = dateformat1.split('').reverse().join('-');
    var TenDate2 = dateformat2.split('-').reverse().join('-');
    $('#txtTenurestartdate').val(TenDate);
    $('#txtTenureenddate').val(TenDate1);
    $('#txtDateofbirth').val(TenDate2);

    //$('#txtTenurestartdate').val(objUser[index].tenureStartDate.split(" ")[0]);
    //$('#txtTenureenddate').val(objUser[index].tenureEndDate.split(" ")[0]);
    //$('#txtDateofbirth').val(objUser[index].dateOfBirth.split(" ")[0]);


 



    $('#ddlNationality').val(objUser[index].nationality);
    $('#txtUserid').prop('disabled', true).val(objUser[index].userLogin);
    $('#txtPassword').val(objUser[index].password);
    $('#txtConfirm').val(objUser[index].password);
    $('#ddlStatus').val(objUser[index].status);
    $("textarea[id*='txtProfile']").val(objUser[index].profile);
    if (objUser[index].uploadAvatar !== undefined && objUser[index].uploadAvatar !== null && objUser[index].uploadAvatar.trim() !== '') {
        $("#aUserAvatarImageUploaded").show();
        uploadedFile = objUser[index].uploadAvatar;
        $("#aUserAvatarImageUploaded").attr('href', 'boardmeeting/images/user/' + objUser[index].uploadAvatar);
        $("#imgavatar").attr('src', 'boardmeeting/images/user/' + objUser[index].uploadAvatar);
    }
    else {
        $("#aUserAvatarImageUploaded").hide();
    }

    //if (objUser[index].txtdp_pan == "") {
    //    $('.coupon_question').prop("checked", true);
    //    $("#txtPAN").prop('disabled', true);
    //    $("#remark").show();
    //}
    //else {
    //    $('.coupon_question').prop("checked", false);
    //    $("#remark").hide();
    //}

    //if (objUser[index].txtdin_pan == '') {
    //    $('.coupon_questiondin').prop("checked", true);
    //    $("#txtDIN").prop('disabled', true);
    //    $("#dinremark").show();
    //}
    //else {
    //    $('.coupon_questiondin').prop("checked", false);
    //    $("#dinremark").hide();
    //}

    if (objUser[index].ddl17A == "YES") {
        $("#dateandfileupload").show();
    }
    else {
        $("#dateandfileupload").hide();
    }

    $('#txtPAN').val(objUser[index].txtdp_pan);

    $('.coupon_question').prop("checked", false);
    $("#remark").hide();
    if (objUser[index].panremark != "") {
        $('#txtPANRemark').val(objUser[index].panremark);
        $('.coupon_question').prop("checked", true);
        $("#remark").show();
    }

    $('#txtDIN').val(objUser[index].txtdin_pan);

    $('.coupon_questiondin').prop("checked", false);
    $("#dinremark").hide();
    if (objUser[index].din_remark != "") {
        $('#txtDINRemark').val(objUser[index].din_remark);
        $('.coupon_questiondin').prop("checked", true);
        $("#dinremark").show();
    }

    //$("select[id*='ddlcat1'] option[value='" + objUser[index].ddlcat1 + "']").prop("selected", true);
    //$("select[id*='ddlcat2'] option[value='" + objUser[index].ddlcat2 + "']").prop("selected", true);
    //$("select[id*='ddlcat3'] option[value='" + objUser[index].ddlcat3 + "']").prop("selected", true);
    //$("select[id*='ddl17A'] option[value='" + objUser[index].ddl17A + "']").prop("selected", true);
    $('#txtdate').val(objUser[index].txtdate);
    $("select[id*='no1'] option[value='" + objUser[index].no_of_directorship + "']").prop("selected", true);
    $("select[id*='no2'] option[value='" + objUser[index].no_of_independent + "']").prop("selected", true);
    $("select[id*='no3'] option[value='" + objUser[index].no_of_membership + "']").prop("selected", true);
    $("select[id*='no4'] option[value='" + objUser[index].no_of_post_of_chairperson + "']").prop("selected", true);
    //$('#no1').val(objUser[index].no_of_directorship);
    //$('#no2').val(objUser[index].no_of_independent);
    //$('#no3').val(objUser[index].no_of_membership);
    //$('#no4').val(objUser[index].no_of_post_of_chairperson);
    $('#txtOccupationArea').val(objUser[index].occupation_Area);
    $('#txtEducationalqualification').val(objUser[index].educational_Qualification);
    $('#txtExperience').val(objUser[index].experience);
    $("select[id*='ddlGender'] option[value='" + objUser[index].gender + "']").prop("selected", true);
    $('#txtAadharNo').val(objUser[index].aadhar_Number);
    $('#txtShareholding').val(objUser[index].shareHolding);
    $('#txtshareholdingpercentage').val(objUser[index].shareHolding_percentage);
    //$("select[id*='ddlCurrencySymbol'] option[value='" + objUser[index].currency_Symbol + "']").prop("selected", true);
    //$('#txtSittingFee').val(objUser[index].sitting_Amount);
    //$("select[id*='ddlPaymentMode'] option[value='" + objUser[index].payment_mode + "']").prop("selected", true);
    //$("select[id*='ddlCurrencySymbolRem'] option[value='" + objUser[index].currency_Symbol + "']").prop("selected", true);
    //$('#txtRemuneration').val(objUser[index].remuneration_Amount);
    $("select[id*='ddlddlPaymentModeRemuneration'] option[value='" + objUser[index].payment_mode + "']").prop("selected", true);
    $('#txtAppointedSection').val(objUser[index].appointed_Section);
    //$('#txtOtherCompanies').val(objUser[index].multi_Companies);

    //for (i = 0; i <= objUser[index].multi_Companies.length; i++) {
    //    $('#txtOtherCompanies').val(objUser[index].multi_Companies.Companies);
    //        document.getElementById("autoAddTextbox").addEventListener('click', function () {
    //        });
    //}

    /*****Himanshu 7-0ct *****/

    var ACompanies = new Array();
    debugger
    for (var x = 0; x < arrmultiCompanies.length; x++) {
        if (UserLogin == arrmultiCompanies[x].userLogin) {
            for (var i = 0; i < arrmultiCompanies[x].multi_Companies.length; i++) {
                var obj = new Object();
                obj.multi_Companies = arrmultiCompanies[x].multi_Companies[i];
                if (obj.multi_Companies != "") {
                    ACompanies.push(obj);
                }
            }
            break; // Exit the loop since we found a match
        }
    }

    if (ACompanies.length >= 0) {
        debugger
        var str = '';
        for (var x = 0; x < ACompanies.length; x++) {
            str += '<tr>';
            str += '<td>' +
                '<input id="txtOtherCompanies" class="form-control form-control-solid form-control-lg" placeholder="Enter Company" type="text" autocomplete="off" value="' + ACompanies[x].multi_Companies + '" />' +
                '</td>';
            str += '<td>' +
                '<img onclick="javascript:fnAddmultiCompanies();" src="../assets/Image/Icon/AddButton.png" height="24" width="24" />' +
                '&nbsp;' +
                '<img onclick="javascript:fnDeletemultiCompanies(this);" src="../assets/Image/Icon/MinusButton.png" height="24" width="24" />' +
                '</td>';
            str += '</tr>';
        }
        $("#tbdCompany").html(str);
    }
    //===============================
    else (arrmultiCompanies.multi_Companies == null)
    {
        debugger
        var str = '<tr>';
        str += ' <td>' +
            '<input id="txtOtherCompanies" class="form-control form-control-solid form-control-lg" placeholder="Enter Company" type="text" autocomplete="off" />' +
            '</td>';
        str += '<td>' +
            '<img onclick="javascript:fnAddmultiCompanies();" src="../assets/Image/Icon/AddButton.png" height="24" width="24" />' +
            '</td>';
        str += '</tr>';
        $("#tbdCompany").append(str);
    }
    //=====================
//==========END==============================



    $('#txtCommitteesAlreadyDirector').val(objUser[index].committees_Already_director);
    $('#txtMembershipnumber').val(objUser[index].membership_Num_Secretarial_User);
}

function fnCloseModal() {
    fnClearForm();
}

function fnClearForm() {
    $('#txtUserId').val('');
    //$('#txtName').val('');
    $('#txtFirstName').val('');
    $('#txtMiddleName').val('');
    $('#txtLastName').val('');
    $('#txtEmail').val('');
    $('#ddlRole').val(0);
    $('#ddlSalutation').val(0);
    $('#txtPhone').val('');
    $('#txtProfile').val('');
    $('#txtAddress').val('');
    $('#txtTenurestartdate').val('');
    $('#txtTenureenddate').val('');
    $('#txtDateofbirth').val('');
    $('#ddlNationality').val(0)
    $('#txtUserid').val('');
    $('#txtPassword').val('');
    $('#txtConfirm').val('');
    $('#ddlStatus').val(0);
    $('#txtUserid').prop('disabled', false);
    $('#txtEmail').prop('disabled', false);
    $('#txtPAN').prop('disabled', false);
    $('#txtDIN').prop('disabled', false);
    $("input[name='coupon_question']").prop('checked', false);
    $("input[name='coupon_questiondin']").prop('checked', false);
    $("textarea[id*='txtPANRemark']").val("");
    $("textarea[id*='txtDINRemark']").val("");
    uploadedFile = null;
    $("#file").val('');
    fnRemoveClass(null, 'Email');
    fnRemoveClass(null, 'Salutation');
    fnRemoveClass(null, 'Department');
    fnRemoveClass(null, 'Designation');
    fnRemoveClass(null, 'Name');
    fnRemoveClass(null, 'Phone');
    fnRemoveClass(null, 'Userid');
    fnRemoveClass(null, 'Password');
    fnRemoveClass(null, 'Confirm');
    fnRemoveClass(null, 'Role');
    fnRemoveClass(null, 'Status');
    fnRemoveClass(null, 'Upload');
    $("#aUserAvatarImageUploaded").hide();
    $('#ddlDepartment').val(0);
    $('#ddlDesignation').val(0);
    $('#ddlCategory').val(0);

    $("textarea[id*='txtOccupationArea']").val("");
    $("textarea[id*='txtEducationalqualification']").val("");
    $("textarea[id*='txtExperience']").val("");
    //$('#txtOccupationArea').val('');
    //$('#txtEducationalqualification').val('');
    //$('#txtExperience').val('');
    $('#ddlGender').val(0);
    $('#txtAadharNo').val('');
    $('#txtShareholding').val('');
    $('#txtshareholdingpercentage').val('');
    //$('#ddlCurrencySymbol').val(0);
    //$('#txtSittingFee').val('');
    //$('#ddlPaymentMode').val(0);
    //$('#ddlCurrencySymbolRem').val(0);
    //$('#txtRemuneration').val('');
    $('#ddlddlPaymentModeRemuneration').val(0);
    $('#txtAppointedSection').val('');
    $('#txtOtherCompanies').val('');
    $('#txtCommitteesAlreadyDirector').val('');
    $('#txtMembershipnumber').val('');
    $('#ddl17A').val(0);
    $('#no1').val(0);
    $('#no2').val(0);
    $('#no3').val(0);
    $('#no4').val(0);
    //fnBindDepartment();
    //fnBindDesignation();

    /***Add by Himanshu 7-oct****/
    $("#tbdCompany").html('');
    var str = '<tr>';
    str += ' <td>' +
        '<input id="txtOtherCompanies" class="form-control form-control-solid form-control-lg" placeholder="Enter Company" type="text" autocomplete="off" />' +
        '</td>';
    str += '<td>' +
        '<img onclick="javascript:fnAddmultiCompanies();" src="../assets/Image/Icon/AddButton.png" height="24" width="24" />' +
        //'&nbsp;' +
        //'<img onclick="javascript:fnDeletemultiCompanies(this);" src="../assets/Image/Icon/MinusButton.png" height="24" width="24" />' +
        '</td>';

    str += '</tr>';
    $("#tbdCompany").append(str);
    /*******End*********/
}
function fnAddmultiCompanies() {
    var str = '<tr>';
    str += ' <td>' +
        '<input id="txtOtherCompanies" class="form-control form-control-solid form-control-lg" placeholder="Enter Company" type="text" autocomplete="off" />' +
        '</td>';

    str += '<td>' +
        '<img onclick="javascript:fnAddmultiCompanies();" src="../assets/Image/Icon/AddButton.png" height="24" width="24" />' +
        '&nbsp;' +
        '<img onclick="javascript:fnDeletemultiCompanies(this);" src="../assets/Image/Icon/MinusButton.png" height="24" width="24" />' +
        '</td>';
    str += '</tr>';
    $("#tbdCompany").append(str);
}
function fnDeletemultiCompanies(cntrl) {
    //deleteDematDetailElement = $(event.currentTarget).closest('tr');
    $(cntrl).closest('tr').remove();
}

function fnValidate() {
    debugger
    var isValid = true;
    var Email = $('#txtEmail').val().trim();
    var Role = $("select[id*='ddlRole']").val().trim();
    var Salutation = $("select[id*='ddlSalutation']").val().trim();
    var FirstName = $('#txtFirstName').val().trim();
    var MiddleName = $('#txtMiddleName').val().trim();
    var LastName = $('#txtLastName').val().trim();
    var Phone = $('#txtPhone').val().trim();
    var UserLoginId = $('#txtUserid').val().trim();
    var Password = $('#txtPassword').val().trim();
    var ConfirmPassword = $('#txtConfirm').val().trim();

    var Department = $("select[id*='ddlDepartment']").val().trim();
    var Designation = $("select[id*='ddlDesignation']").val().trim();
    var Category = $("select[id*='ddlCategory']").val().trim();

    var panno = $("#txtPAN").val().trim();
    var dinno = $("#txtDIN").val().trim();
    var txtPANRemark = $("textarea[id*='txtPANRemark']").val();
    var txtDINRemark = $("textarea[id*='txtDINRemark']").val();

    var startDate = $("#txtTenurestartdate").val().trim();
    var endDate = $("#txtTenureenddate").val().trim();
    var status = $("select[id*='ddlStatus']").val().trim();
    var UploadAvatar = $('input[type=file]').val().split('.').pop().toLowerCase();


    if (Salutation == '0') {
        isValid = false;
        //alert("Please Select Salutation !");
        $('#lblSalutation').addClass('text-danger');
    }

    else {
        $('#lblSalutation').removeClass('text-danger');
    }

    if (FirstName == "") {
        isValid = false;
        $('#lblName').addClass('text-danger');
    }
    else {
        $('#lblName').removeClass('text-danger');
    }

    if (Email == "") {
        $('#lblEmail').addClass('text-danger');
        isValid = false;
    }
    else if (!validateEmail(Email)) {
        isValid = false;
        alert("Please Enter Valid Email !");
        $('#lblEmail').addClass('text-danger');
    }
    else {
        $('#lblEmail').removeClass('text-danger');
    }


    if (Phone == "") {
        isValid = false;
        $('#lblPhone').addClass('text-danger');
    }
    else if (Phone.length > 10) {
        $('#lblPhone').removeClass('text-danger');
    }
    else {
        $('#lblPhone').removeClass('text-danger');

        var regex =  /^[0-9]{10}$/;
        //var regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()\-+.]).{8,20}$/;        /*(^.* (?=.{ 8,}) (?=.*\d) (?=.* [a - z])(?=.* [A - Z])(?=.* [!*@#$%^&+=]).* $)*/
        if (Phone != "") {
            if (Phone.match(regex)) {
                $('#lblPhone').removeClass('text-danger');
            }
            else {
                isValid = false;
                alert("Please enter correct Phone Number format !");
                $('#lblPhone').addClass('text-danger');
            }
        }
    }


    if (UserLoginId == "") {
        isValid = false;
        $('#lblUserid').addClass('text-danger');
    }
    else {
        $('#lblUserid').removeClass('text-danger');
    }


    //if (Password == "") {
    //    isValid = false;
    //    $('#lblPassword').addClass('text-danger');
    //}
    //else if (Password.length < 8) {
    //    isValid = false;
    //    alert("Password should have atleast 8 Character !");
    //    $('#lblPassword').addClass('text-danger');
    //}
    //else {
    //    $('#lblPassword').removeClass('text-danger');

    //   //var regex =  /^[0-9]{10}$/;
    //    var regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()\-+.]).{8,20}$/;        /*(^.* (?=.{ 8,}) (?=.*\d) (?=.* [a - z])(?=.* [A - Z])(?=.* [!*@#$%^&+=]).* $)*/
    //    if (Password != "") {
    //        if (Password.match(regex)) {
    //            $('#lblPassword').removeClass('text-danger');
    //        }
    //        else {
    //            isValid = false;
    //            alert("Please enter correct Password format !");
    //            $('#lblPassword').addClass('text-danger');
    //        }
    //    }
    //}

    //if (ConfirmPassword == "") {
    //    isValid = false;
    //    $('#lblConfirm').addClass('text-danger');
    //}
    //else if (Password !== ConfirmPassword) {
    //    isValid = false;
    //    alert("Password and Confirm Password Not Match !");
    //    $('#lblConfirm').addClass('text-danger');
    //}
    //else {
    //    $('#lblPassword').removeClass('text-danger');
    //    $('#lblConfirm').removeClass('text-danger');
    //}
    /******Add By Jitender**********/
    //var _salt = $("#txtSalt").val();
    //var _msalt = $("#txtMSalt").val();

    //var Password = $("#txtPassword").val();
    //var hash = (hex_sha512(Password) + _salt);
    //var fff = hex_sha512(hash );
    //$("#txtPassword").val(fff);
    //return true;
    /*************End***********/

    if (Role == 3) {
        if (Category == '0') {
            isValid = false;
            $('#lblCategory').addClass('text-danger');
        }
        else {
            $('#lblCategory').removeClass('text-danger');
        }

        if (panno == "" && $('.coupon_question').is(":checked") == false) {
            isValid = false;
            $('#lblPAN').addClass('text-danger');
        }
        else {
            $('#lblPAN').removeClass('text-danger');

            var regex = /([A-Z]){5}([0-9]){4}([A-Z]){1}$/;
            if (panno != "") {
                if (panno.match(regex)) {
                    $('#lblPAN').removeClass('text-danger');
                }
                else {
                    isValid = false;
                    alert("Invalid PAN number");
                    $('#lblPAN').addClass('text-danger');
                }
            }

            $('#lblPANRemark').removeClass('text-danger');
            if ($('.coupon_question').is(":checked")) {
                if (txtPANRemark == "") {
                    isValid = false;
                    alert("Please Enter PAN Remarks in case of Not Provided !");
                    $('#lblPANRemark').addClass('text-danger');
                }
                else {
                    $('#lblPANRemark').removeClass('text-danger');
                }
            }
        }

        if (dinno == "" && $('.coupon_questiondin').is(":checked") == false) {
            isValid = false;
            $('#lblDIN').addClass('text-danger');
        }
        else {
            $('#lblDIN').removeClass('text-danger');
            $('#lblDINRemark').removeClass('text-danger');
            if ($('.coupon_questiondin').is(":checked")) {
                if (txtDINRemark == "") {
                    isValid = false;
                    alert("Please Enter DIN Remarks in case of Not Provided");
                    $('#lblDINRemark').addClass('text-danger');
                }
                else {
                    $('#lblDINRemark').removeClass('text-danger');
                }
            }
        }
    }
    else {
        if (Department == '0') {
            isValid = false;
            $('#lblDepartment').addClass('text-danger');
        }
        else {
            $('#lblDepartment').removeClass('text-danger');
        }

        if (Designation == '0') {
            isValid = false;
            $('#lblDesignation').addClass('text-danger');
        }
        else {
            $('#lblDesignation').removeClass('text-danger');
        }
    }

    if (startDate == "") {
        isValid = false;
        $('#lblTenurestartdate').addClass('text-danger');
    }
    else {
        $('#lblTenurestartdate').removeClass('text-danger');
    }

    if (Category == "2" || Category == "4") {
        if (endDate == "") {
            isValid = false;
            $('#lblTenureenddate').addClass('text-danger');
        }
        else {
            $('#lblTenureenddate').removeClass('text-danger');
        }
    }

    if (startDate != "" && endDate != "") {
        if (!compareTenureDate(startDate, endDate)) {
            isValid = false;
            alert("Tenure End Date should be greater than Tenure Start Date");
            $('#lblTenureenddate').addClass('text-danger');
        }
        else {
            $('#lblTenureenddate').removeClass('text-danger');
        }
    }

    if (status == '0') {
        isValid = false;
        $("#lblStatus").addClass('text-danger');
    }
    else if (status == 'InActive') {
        alert("Tenure End Date should not blank when status is InActive !");
        $('#lblTenureenddate').addClass('text-danger');
    }
    else {
        $("#lblStatus").removeClass('text-danger');
    }

    if ($.inArray(UploadAvatar, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
        if (UploadAvatar.trim() == undefined || UploadAvatar.trim() == null || UploadAvatar.trim() == '') {
            $('#lblUpload').removeClass('text-danger');
        }
        else {
            isValid = false;
            alert("Please Select Only Png,Jpg,Jpeg,Gif !");
            $('#lblUpload').addClass('text-danger');
        }
    }
    else {
        $('#lblUpload').removeClass('text-danger');
    }

    if (!isValid) {
        return isValid;
    }

    return isValid;
}

function DeleteUser1(ID) {
    $('input[id*=txtDelID]').val(ID);
    $("#deleteProduct").modal(); {
    }
}

function validateEmail(value) {
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (reg.test(value) == false) {
        return false;
    }
    return true;
}

//function validateDate(value) {
//    debugger
//    var checkdate = value.split('/').join('-');
//    if (checkdate.test(value) == false) {
//        return false;
//    }
//    return true;
//}

function DeleteUser() {
    var UserColl = [];
    UserColl[UserColl.length] = new User($('input[id*=txtDelID]').val(), "");
    $("#Loader").show();
    var webUrl = uri + "/api/User/DeleteUser"; //"api/UserHandler.ashx?caller=DeleteUser";
    setTimeout(function () {
        $.ajax({
            type: 'POST',
            url: webUrl,
            data: JSON.stringify(UserColl),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: false,
            success: function (msg) {
                $("#Loader").hide();
                if (msg.StatusFl) {
                    var table = $('#tbl-User-setup').DataTable();
                    table.destroy();
                    $("#tr_" + msg.User.ID).remove();
                    initializeDataTable();
                }
                else {
                    if (msg.Msg == "SessionExpired") {
                        alert("Your session is expired. Please login again to continue");
                        window.location.href = "../Login.aspx";
                    }
                    else {
                        alert(msg.Msg);
                    }
                    return false;
                }
            },
            error: function (response) {
                $("#Loader").hide();
                alert(response.status + ' ' + response.statusText);
            }
        });
    }, 10);
}

function getAllUsersRole() {
    debugger
    var webUrl = uri + "/api/User/GetAllUsersRole";
    $.ajax({
        type: "GET",
        url: webUrl,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            if (msg.StatusFl) {
                var result = "";
                for (var i = 0; i < msg.UserList.length; i++) {
                    result += '<option value="' + msg.UserList[i].role.Id + '">' + msg.UserList[i].role.role + '</option>'
                }
                $("#ddlRole").append(result);
            }
            else {
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                else {
                    alert(msg.Msg);
                }
                return false;
            }
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}

function fnGetUserEmailList() {
    debugger
    var webUrl = uri + "/api/User/GetUserEmailList";
    $("#txtEmail").autocomplete({
        source: function (request, response) {
            setTimeout(function () {
                $.ajax({
                    url: webUrl,
                    method: "post",
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify({ emailId: request.term }),
                    dataType: 'json',
                    success: function (data) {
                        var tempArr = [];
                        $.each(data.UserList, function (index, item) {
                            tempArr.push(item.emailId);
                        })
                        response(tempArr);
                    },
                    error: function (err) {
                        if (err.responseText == "Session Expired") {
                            alert("Your session is expired. Please login again to continue");
                            window.location.href = "../Login.aspx";
                            return false;
                        }
                        else {
                            alert(err.status + ' ' + err.statusText);
                        }
                    }
                });
            }, 10)
        }
    });
    $('.ui-autocomplete').css({ 'z-index': '2147483647' });
}

//Companies of directorship 4-october

$('#btnSave').on('click', function (e) {
    e.preventDefault();
    multicompanies.push($(this).data('#txtOtherCompanies'));
});

function fnFillUserDetails() {
    $("#Loader").show();
    var webUrl = uri + "/api/User/FillUserDetails";
    $.ajax({
        type: 'POST',
        url: webUrl,
        data: JSON.stringify({ emailId: $("input[id*='txtEmail']").val() }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            if (!msg.StatusFl) {
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
            }
            if (msg.User != null) {
                $("input[id*='txtEmail']").prop("disabled", true);
                $("input[id*='txtName']").val(msg.User.userName);
                $("input[id*='txtPhone']").val(msg.User.phone);
                $("input[id*='txtUserid']").prop("disabled", true).val(msg.User.userLogin);
                $("input[id*='txtPassword']").val(msg.User.password);
                $("input[id*='txtConfirm']").val(msg.User.password);
                $("select[id*='ddlRole']").find('option[value=' + msg.User.role.Id + ']').prop("selected", true);
                $("input[id*='txtTenurestartdate']").val(msg.User.tenureStartDate);
                $("input[id*='txtTenureenddate']").val(msg.User.tenureEndDate);
                $("input[id*='txtDateofbirth']").val(msg.User.dateOfBirth);
                $("select[id*='ddlNationality']").find('option[value=' + msg.User.nationality + ']').prop("selected", true);
                $("select[id*='ddlStatus']").find('option[value=' + msg.User.status + ']').prop("selected", true);
                $("textarea[id*='txtAddress']").val(msg.User.address);
                $("textarea[id*='txtProfile']").val(msg.User.profile);

                //$('#txtName').val(msg.UserList[0].userName);
                //fnRemoveClass(null, 'Name');
                //$('#txtPhone').val(msg.UserList[0].phone);
                //fnRemoveClass(null, 'Phone');
                //$('#txtUserid').prop('disabled', true).val(msg.UserList[0].userLogin);
                //fnRemoveClass(null, 'Userid');
            }
            else {
                $("input[id*='txtEmail']").prop("disabled", false);
                $("input[id*='txtName']").val("");
                $("input[id*='txtPhone']").val("");
                $("input[id*='txtUserid']").prop("disabled", false).val("");
                $("input[id*='txtPassword']").val("");
                $("input[id*='txtConfirm']").val("");
                $("select[id*='ddlRole']").find('option[value=0]').prop("selected", true);
                $("input[id*='txtTenurestartdate']").val("");
                $("input[id*='txtTenureenddate']").val("");
                $("input[id*='txtDateofbirth']").val("");
                $("select[id*='ddlNationality']").find('option[value=0]').prop("selected", true);
                $("select[id*='ddlStatus']").find('option[value=0]').prop("selected", true);
                $("textarea[id*='txtAddress']").val("");
                $("textarea[id*='txtProfile']").val("");
            }
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}

function User(ID, emailId, userFirstName, userMiddleName, userLastName, salutation, phone, address, tenureStartDate, tenureEndDate, dateOfBirth,
    nationality, userLogin, roleId, CategoryName, status, profile, txtdp_pan, panremark, txtdin_pan, din_remark, txtdate,
    occupation_Area, educational_Qualification, experience, gender, aadhar_Number, shareHolding, shareHolding_percentage, appointed_Section, committees_Already_director,no_of_directorship, no_of_independent, no_of_membership, no_of_post_of_chairperson,    //currency_Symbol, sitting_Amount, payment_mode, remuneration_Amount,
       multicompanies, membership_Num_Secretarial_User) {
    debugger
    this.ID = ID;
    //this.userName = userName;
    this.emailId = emailId;
    this.userFirstName = userFirstName;
    this.userMiddleName = userMiddleName;
    this.userLastName = userLastName;
    //this.role = role;
    this.salutation = salutation;
    this.phone = phone;
    this.address = address;
    this.tenureStartDate = tenureStartDate;
    this.tenureEndDate = tenureEndDate;
    this.dateOfBirth = dateOfBirth;
    this.nationality = nationality;
    this.userLogin = userLogin;
   // this.password = password;
    this.role = new Role(roleId);
    this.category = CategoryName;
    this.status = status;
    this.profile = profile;
    this.txtdp_pan = txtdp_pan;
    this.panremark = panremark;
    this.txtdin_pan = txtdin_pan;
    this.din_remark = din_remark;
    this.txtdate = txtdate;
    //this.ddl17A = ddl17A;
    this.occupation_Area = occupation_Area;
    this.educational_Qualification = educational_Qualification;
    this.experience = experience;
    this.gender = gender;
    this.aadhar_Number = aadhar_Number;
    this.shareHolding = shareHolding;
    this.shareHolding_percentage = shareHolding_percentage;
    this.appointed_Section = appointed_Section;
    //this.other_Companies = other_Companies;
    this.committees_Already_director = committees_Already_director;
    this.no_of_directorship = no_of_directorship;
    this.no_of_independent = no_of_independent;
    this.no_of_membership = no_of_membership;
    this.no_of_post_of_chairperson = no_of_post_of_chairperson;
    this.multi_Companies = multicompanies;
    this.membership_Num_Secretarial_User = membership_Num_Secretarial_User;
    //this.department = DepartmentName;
    //this.designation = DesignationName;
    
    //this.role = role;
    
    
  
    //this.ddlcat1 = ddlcat1;
    //this.ddlcat2 = ddlcat2;
    //this.ddlcat3 = ddlcat3;
    
   
  
  
  
    //this.currency_Symbol = currency_Symbol;
    //this.sitting_Amount = sitting_Amount;
    //this.payment_mode = payment_mode;
    //this.remuneration_Amount = remuneration_Amount;
    //this.other_Companies = other_Companies;
    
    this.department = new Department();
    this.designation = new Designation();
    //this.category = new Category();
    
    //this.keyCompany = KeyCompany;
}

function Role(roleId) {
    this.Id = roleId;
}


function Department() {
    this.departmentId = $("select[id*='ddlDepartment']").val();
}

function Designation() {
    this.ID = $("select[id*='ddlDesignation']").val();
}

//function Category() {
//    this.ID = $("select[id*='ddlCategory']").val();
//}

function compareTenureDate(startDate1, endDate1) {
    var msg = "";
    var startDate2 = startDate1;
    var date = startDate2.split("/")[0];
    var month = startDate2.split("/")[1];
    var year = startDate2.split("/")[2];

    var endDate2 = endDate1;
    var date1 = endDate2.split("/")[0];
    var month1 = endDate2.split("/")[1];
    var year1 = endDate2.split("/")[2];

    var startDate3 = new Date(year, month - 1, date);
    var endDate3 = new Date(year1, month1 - 1, date1);

    if (startDate3.getFullYear() === endDate3.getFullYear() && startDate3.getMonth() === endDate3.getMonth() && startDate3.getDate() === endDate3.getDate()) {
        return false;
    }
    else if (endDate3.getTime() < startDate3.getTime()) {
        return false
    }
    else {
        return true;
    }
}

function fnDownloadUserReport(reportType) {
    var isValid = true;
    var object = "";
    $("#Loader").show();
    var webUrl = uri + "/api/Report/DownloadUserReport";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({
            committeeId: $("select[id*='ddlCommittee']").val(), fromDate: $("input[id*='txtFromDate']").val(), toDate: $("input[id*='txtToDate']").val(), reportType: reportType
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (msg) {
            $("#Loader").hide();
            if (msg.StatusFl) {
                downloadURL1(msg.UserList[0].downloadReportUrl);
            }
            else {
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                else {
                    alert("No Data Found!");
                }
                return false;
            }
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}