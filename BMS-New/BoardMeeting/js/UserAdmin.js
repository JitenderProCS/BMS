var objAdminUser = [];
var arrACompMap = new Array();

$(document).ready(function () {
    fnGetAdminUserList();
    fnBindCompany();
    fnBindModule();
    fnAddRow();

    $("input[id*='txtEmail']").prop("disabled", false).val("");
    $("input[id*='txtUserid']").prop("disabled", false).val("");

    $('#stack1').on('hide.bs.modal', function () {
    });
});


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
                    columns: [1, 2, 3, 4]
                }
            },

            {
                extend: 'excel',
                className: 'btn yellow btn-outline ',
                exportOptions: {
                    //modifier: {
                    //    page: 'current'
                    //}
                    columns: [1, 2, 3, 4]
                }
            },
        ]
    });
}

function fnBindCompany() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/AdminUser/GetCompanyList";
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
                $("#ddlCompany").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.CompanyList != undefined && msg.CompanyList != null) {
                    if (msg.CompanyList.length > 0) {
                        for (var i = 0; i < msg.CompanyList.length; i++) {
                            $("#ddlCompany").append($("<option></option>").val(msg.CompanyList[i].companyId).html(msg.CompanyList[i].CompanyName));
                        }
                    }
                }
            }
            else {
                $("#ddlCompany").empty().append('<option selected="selected" value="0">Please Select</option>');
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

function fnBindModule() {
    $("#Loader").show();
    var webUrl = uri + "/api/AdminUser/GetModuleList";
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
                $("#ddlmodule").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.UserList != undefined && msg.UserList != null) {
                    if (msg.UserList.length > 0) {
                        for (var i = 0; i < msg.UserList.length; i++) {
                            $("#ddlmodule").append($("<option></option>").val(msg.UserList[i].moduleId).html(msg.UserList[i].moduleName));
                        }
                    }
                }
            }
            else {
                $("#ddlmodule").empty().append('<option selected="selected" value="0">Please Select</option>');
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

function fnGetAdminUserList() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/AdminUser/GetUserList";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({
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
            arrACompMap = new Array();
            arrACompMap = msg.UserList;
            if (msg.StatusFl) {
                for (var i = 0; i < msg.UserList.length; i++) {
                    //objAdminUser.push(msg.UserList[i]);
                    result += '<tr id="tr_' + msg.UserList[i].ID + '">';
                    /* result += '<td id="tdedit_' + msg.UserList[i].userLogin + '">';*/
                    result += '<td id="tdEdit_' + msg.UserList[i].ID + '"><a data-target="#exampleModalSizeLg" data-toggle="modal" id="a_' + msg.UserList[i].ID + '" title="Edit" class="btn btn-light-primary px-3 font-weight-bold" onclick=\"javascript:fnEditUser(\'' + msg.UserList[i].ID + '\',\'' + msg.UserList[i].userName + '\',\'' + msg.UserList[i].LoginId + '\',\'' + msg.UserList[i].emailId + '\',\'' + msg.UserList[i].phone + '\',\'' + msg.UserList[i].authentication + '\');\"><i class="fas fa-pencil-alt"></i></a>';
                   /* result += '<td id="tdEdit_' + msg.UserList[i].ID + '"><a data-target="#exampleModalSizeLg" data-toggle="modal" id="a_' + msg.UserList[i].ID + '" title="Edit" class="btn btn-light-primary px-3 font-weight-bold" onclick=\"javascript:fnEditUser(' + i + ');\"><i class="fas fa-pencil-alt"></i></a></td>';*/
                    result += '<td id="tdUser_Name_' + msg.UserList[i].ID + '">' + msg.UserList[i].userName + '</td>';
                    result += '<td id="tdUser_Email_' + msg.UserList[i].ID + '">' + msg.UserList[i].emailId + '</td>';
                    result += '<td id="tdUser_UserLogin_' + msg.UserList[i].ID + '">' + msg.UserList[i].LoginId + '</td>';
                    result += '<td id="tdUser_Authentication_' + msg.UserList[i].ID + '">' + msg.UserList[i].authentication + '</td>';

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

    var UserColl = [];
    var CompanyMapping = [];
    for (var i = 0; i < $("#tbdAccessList").children().length; i++) {
        var AE = new Object();

        AE.ID = $($($("#tbdAccessList").children()[i]).children()[0]).text();
        AE.companyId = $($($("#tbdAccessList").children()[i]).children()[1]).text();;
        AE.CompanyName = $($($("#tbdAccessList").children()[i]).children()[2]).text();;
        AE.moduleId = $($($("#tbdAccessList").children()[i]).children()[3]).text();;
        AE.moduleName = $($($("#tbdAccessList").children()[i]).children()[4]).text();;
        AE.Role_Admin = $($($("#tbdAccessList").children()[i]).children()[5]).text();;
     
        CompanyMapping.push(AE);
    }
    UserColl[UserColl.length] = new AdminUser($("input[id*='txtUserId']").val() == 0 ? 0 : $("input[id*='txtUserId']").val(),
        $("input[id*='txtName']").val(), $("input[id*='txtEmail']").val(),
        $("input[id*='txtUserid']").val(), $("input[id*='txtPhone']").val(), $("select[id*='ddlAuthentication']").val(),
        CompanyMapping,

    );

    userData.append("Object", JSON.stringify(UserColl));

    $("#Loader").show();
    var webUrl = uri + "/api/AdminUser/SaveUser";

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

function OpenNew() {
    $("span[Id*='spnTitle']").html("New User");
}


//function fnEditUser(index) {
//    debugger
//    $("span[Id*='spnTitle']").html("Edit User");
//    $('#txtUserId').val(objAdminUser[index].ID);
//    $('#txtName').val(objAdminUser[index].userName);
//    $('#txtEmail').prop('disabled', true).val(objAdminUser[index].emailId);
//    $('#txtUserid').prop('disabled', true).val(objAdminUser[index].userLogin);
//    $('#txtPhone').val(objAdminUser[index].phone);
//    $("select[id*='ddlAuthentication'] option[value='" + objAdminUser[index].authentication + "']").prop("selected", true);


//    /*$('#ddlAuthentication').val(objAdminUser[index].authentication);*/
//    /************Add By Jitender *****************/
//    var ACompMap = new Array();
//    for (var x = 0; x < arrACompMap.length; x++) {
//        //alert("arrUpsiType[" + x + "].TypeId=" + arrUpsiType[x].TypeId);
//        if (objAdminUser[index].userLogin == arrACompMap[x].userLogin) {
//            for (var i = 0; i < arrACompMap[x].CompanyMapping.length; i++) {
//                var obj = new Object();
//                obj.ID = arrACompMap[x].CompanyMapping[i].ID;
//                obj.CompanyName = arrACompMap[x].CompanyMapping[i].CompanyName;
//                obj.moduleName = arrACompMap[x].CompanyMapping[i].moduleName;
//                obj.Role_Admin = arrACompMap[x].CompanyMapping[i].Role_Admin;
//                ACompMap.push(obj);
//            }
//            break;
//        }
//    }

//    if (ACompMap.length >= 0) {
//        debugger
//        var str = '';
//        for (var x = 0; x < ACompMap.length; x++) {
//        var str = "";
//            str += '<tr>';
//            str += '<td style="display:none;">' + ACompMap[x].ID + '</td>';
//            str += '<td style="display:none;">' + ACompMap[x].companyId + '</td>';
//            str += '<td>' + ACompMap[x].CompanyName + '</td>';
//            str += '<td style="display:none;">' + ACompMap[x].moduleId + '</td>';
//            str += '<td>' + ACompMap[x].moduleName + '</td>';
//            str += '<td>' + ACompMap[x].Role_Admin + '</td>';
//        str += '<td><img onclick="javascript:fnDeleteAccessDetail(this);" src="../assets/image/Icon/delete.png" style="width:24px;height:24px;" /></td>';
//        str += '</tr>';
//    }
//        $("#tbdAccessList").html(str);
//    }
//    //===============================
//    else (arrACompMap.CompanyMapping == null)
//    {
//        var str = '<tr>';
//        str += ' <td>' +
//            /*'<input id="txtAlternateEmail" class="form-control form-control-inline" placeholder="Enter Alternate Email" type="email" autocomplete="off" />' +*/
//            '<select id="ddlCompany" class="form-control form-control-lg form-control-solid col";"/>' +
//            '</td>';

//        str += '<td>' +
//            '<img onclick="javascript:fnAddAlternateEmail();" src="images/icons/AddButton.png" height="24" width="24" />' +
//            '&nbsp;' +
//            '<img onclick="javascript:fnDeleteAlternateEmail(this);" src="images/icons/MinusButton.png" height="24" width="24" />' +
//            '</td>';
//        str += '</tr>';
//        $("#tbdEmailAdd").append(str);
//    }
//    /**************End**************************/

//}

function fnCloseModal() {
    fnClearForm();
}

function fnClearForm() {
    $('#txtUserId').val('');
    $('#txtName').val('');
    $('#txtEmail').val('');
    //$('#ddlSalutation').val(0);
    $('#txtUserid').val('');
    $('#txtPhone').val('');
    $('#ddlAuthentication').val(0);
    $('#txtUserid').prop('disabled', false);
    $('#txtEmail').prop('disabled', false);
    fnRemoveClass(null, 'Email');
    fnRemoveClass(null, 'Name');
    fnRemoveClass(null, 'Userid');
    fnRemoveClass(null, 'Phone');
    fnRemoveClass(null, 'Authentication');
    $('#tbdAccessList').html('');
}

function fnValidate() {
    debugger
    var isValid = true;
    var Email = $('#txtEmail').val().trim();
    //var Salutation = $("select[id*='ddlSalutation']").val().trim();
    var Name = $('#txtName').val().trim();
    var UserLoginId = $('#txtUserid').val().trim();
    var Phone = $('#txtPhone').val().trim();
    var authentication = $("select[id*='ddlAuthentication']").val().trim();


    //if (Salutation == '0') {
    //    isValid = false;
    //    alert("Please Select Salutation !");
    //    $('#lblSalutation').addClass('text-danger');
    //}

    //else {
    //    $('#lblSalutation').removeClass('text-danger');
    //}


    if (Name == "") {
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

    if (UserLoginId == "") {
        isValid = false;
        $('#lblUserid').addClass('text-danger');
    }
    else {
        $('#lblUserid').removeClass('text-danger');
    }

    //if (Phone == "") {
    //    isValid = false;
    //    $('#lblPhone').addClass('text-danger');
    //}
    //else {
    //    $('#lblPhone').removeClass('text-danger');
    //}
    /****Add By Jitender*******/
    if (Phone == "") {
        isValid = false;
        $('#lblPhone').addClass('text-danger');
    }
    else if (Phone.length > 10) {
        $('#lblPhone').removeClass('text-danger');
    }
    else {
        $('#lblPhone').removeClass('text-danger');

        var regex = /^[0-9]{10}/;
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
    /******End*****************/

    if (authentication == '0') {
        isValid = false;
        $("#lblAuthentication").addClass('text-danger');
    }
    else {
        $("#lblAuthentication").removeClass('text-danger');
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

function DeleteUser() {
    var UserColl = [];
    UserColl[UserColl.length] = new User($('input[id*=txtDelID]').val(), "");
    $("#Loader").show();
    var webUrl = uri + "/api/AdminUser/DeleteUser";
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

function fnGetUserEmailList() {
    var webUrl = uri + "/api/AdminUser/GetUserEmailList";
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

function fnFillUserDetails() {
    $("#Loader").show();
    var webUrl = uri + "/api/AdminUser/FillUserDetails";
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
                $("input[id*='txtUserid']").prop("disabled", true).val(msg.AdminUser.userLogin);
                $("select[id*='ddlSalutation']").find('option[value=' + msg.AdminUser.salutation + ']').prop("selected", true);
                $("select[id*='ddlAuthentication']").find('option[value=' + msg.AdminUser.authentication + ']').prop("selected", true);

            }
            else {
                $("input[id*='txtEmail']").prop("disabled", false);
                $("input[id*='txtName']").val("");
                $("input[id*='txtUserid']").prop("disabled", false).val("");
                $("select[id*='ddlSalutation']").find('option[value=0]').prop("selected", true);
                $("select[id*='ddlAuthentication']").find('option[value=0]').prop("selected", true);
            }
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}

function AdminUser(ID, userName, emailId, userLogin, phone, authentication, CompanyMapping) {
    debugger
    this.ID = ID;
    this.userName = userName;
    this.emailId = emailId;
    //this.salutation = salutation;
    this.userLogin = userLogin;
    this.phone = phone;
    this.authentication = authentication;
    this.CompanyMapping = CompanyMapping;
    /*this.CompanyMappingList = CompanyMapping;*/

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
/****Add By Jitender*********** */
function fnValidateMapping() {
    debugger
    var isValid = true;
   
    var company = $("select[id*='ddlCompany']").val().trim();
    var module = $("select[id*='ddlmodule']").val().trim();
    var role = $("select[id*='ddlPaymentMode']").val().trim();

    if (company == '0') {
        isValid = false;
        alert("Please Select Company!");
    }
    else {
       // alert("This is your alert message!");
    }

    if (module == '0') {
        isValid = false;
        alert("Please Select Module!");
    }
    else {
        //$("#lblAuthentication").removeClass('text-danger');
    }
    if (role == '0') {
        isValid = false;
        alert("Please Select Role!");
    }
    else {
        //$("#lblAuthentication").removeClass('text-danger');
    }

    if (!isValid) {
        return isValid;
    }

    return isValid;
}
function AccessDetail() {
    debugger
    this.ID = 0;
    this.companyId = $("#ddlCompany").val() == null ? 0 : ($("#ddlCompany").val().trim() == "" ? 0 : $("#ddlCompany").val());
    this.CompanyName = $("#ddlCompany option:selected").text() == null ? 0 : ($("#ddlCompany option:selected").text().trim() == "" ? 0 : $("#ddlCompany option:selected").text());
    this.moduleId = $("#ddlmodule").val() == null ? 0 : ($("#ddlmodule").val().trim() == "" ? 0 : $("#ddlmodule").val());
    this.moduleName = $("#ddlmodule option:selected").text() == null ? 0 : ($("#ddlmodule option:selected").text().trim() == "" ? 0 : $("#ddlmodule option:selected").text());
    this.Role_Admin = $("#ddlPaymentMode").val() == null ? 0 : ($("#ddlPaymentMode").val().trim() == "" ? 0 : $("#ddlPaymentMode").val());
}
function fnAddAccessDetail() {
    debugger
    if (fnValidateMapping()) {
        var obj = new AccessDetail();
        var str = "";
        str += '<tr>';
        str += '<td style="display:none;">' + obj.ID + '</td>';
        str += '<td style="display:none;">' + obj.companyId + '</td>';
        str += '<td>' + obj.CompanyName + '</td>';
        str += '<td style="display:none;">' + obj.moduleId + '</td>';
        str += '<td>' + obj.moduleName + '</td>';
        str += '<td>' + obj.Role_Admin + '</td>';
        str += '<td><img onclick="javascript:fnDeleteAccessDetail(this);" src="../assets/image/Icon/delete.png" style="width:24px;height:24px;" /></td>';
        str += '</tr>';
        $("#tbdAccessList").append(str);
        $('#ddlCompany').val(0);
        $('#ddlmodule').val(0);
        $('#ddlPaymentMode').val(0);
    }
    else {
        $('#btnadd').removeAttr("data-dismiss");
        return false;
    }
}
function fnDeleteAccessDetail(cntrl) {
    debugger
    //deleteDematDetailElement = $(event.currentTarget).closest('tr');
    $(cntrl).closest('tr').remove();
}
function fnEditUser(ID, userName, LoginId, emailId, phone, authentication) {
    debugger
    $('#txtUserId').val(ID);
    $('#txtName').val(userName);
    $('#txtEmail').val(emailId);
    $('#txtUserid').val(LoginId);
    $('#txtPhone').val(phone);
    $("select[id*='ddlAuthentication']").val(authentication);
    $('#txtEmail').prop('disabled', true);
    $('#txtUserid').prop('disabled', true);
    //$('#txtUserid').prop('disabled', true);

    /************Add By Jitender *****************/
    var ACompMap = new Array();
    for (var x = 0; x < arrACompMap.length; x++) {
        //alert("arrUpsiType[" + x + "].TypeId=" + arrUpsiType[x].TypeId);
        if (LoginId == arrACompMap[x].LoginId) {
            for (var i = 0; i < arrACompMap[x].CompanyMapping.length; i++) {
                var obj = new Object();
                obj.ID = arrACompMap[x].CompanyMapping[i].ID;
                obj.companyId = arrACompMap[x].CompanyMapping[i].companyId;
                obj.CompanyName = arrACompMap[x].CompanyMapping[i].CompanyName;
                obj.moduleId = arrACompMap[x].CompanyMapping[i].moduleId;
                obj.moduleName = arrACompMap[x].CompanyMapping[i].moduleName;
                obj.Role_Admin = arrACompMap[x].CompanyMapping[i].Role_Admin;
                ACompMap.push(obj);
            }
            break;
        }
    }
    if (ACompMap.length >= 0) {
        debugger
        var str = ''; // Initialize str here
        for (var x = 0; x < ACompMap.length; x++) {
            str += '<tr>';
            str += '<td style="display:none;">' + ACompMap[x].ID + '</td>';
            str += '<td style="display:none;">' + ACompMap[x].companyId + '</td>';
            str += '<td>' + ACompMap[x].CompanyName + '</td>';
            str += '<td style="display:none;">' + ACompMap[x].moduleId + '</td>';
            str += '<td>' + ACompMap[x].moduleName + '</td>';
            str += '<td>' + ACompMap[x].Role_Admin + '</td>';
            str += '<td><img onclick="javascript:fnDeleteAccessDetail(this);" src="../assets/image/Icon/delete.png" style="width:24px;height:24px;" /></td>';
            str += '</tr>';
        }
        $("#tbdAccessList").html(str);
    }
}

/**********End********** */

function fnAddRow() {
    debugger
    $("#tbdTrade").html("");
    //alert("In function fnAddRow");
    var str = "";
    str += "<tr>";
    str += "<td style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    str += "<select id='ddlForTD' class='form-control' onchange='javascript:fnForTD_onChange(this);'>";
    str += "<option value='-1'>Please Select</option>";
    //alert("arrDetails.length=" + arrDetails.length);
    for (var x = 0; x < arrDetails.length; x++) {
        //alert("arrDetails[" + x + "].RelativeId=" + arrDetails[x].RelativeId);
        //alert("arrDetails[" + x + "].RelativeNm=" + arrDetails[x].RelativeNm);
        str += "<option value='" + arrDetails[x].RelativeId + "'>" + arrDetails[x].RelativeNm + "</option>";
    }
    str += "</select>";
    str += "</td>";
    str += "<td id='tdPanTD' style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    str += "<input id='txtTDPan' disabled type='text' class='form-control' />";
    str += "</td>";
    str += "<td id='tdDematTD' style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    str += "<select id='ddlDematTD' class='form-control' onchange='javascript:fnDematTD_onChange(this);'>";
    str += "<option value='-1'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>";
    str += "</select>";
    str += "</td>";

    str += "<td id='tdHoldingTD' style='padding-left:5px;padding-right:5px;padding-top:10px;text-align:right;'>";
    str += "</td>";

    str += "<td id='tdPledgedTD' style='padding-left:5px;padding-right:5px;padding-top:10px;text-align:right;'>";
    str += "</td>";

    str += "<td style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    str += "<input id='txtTDDate' type='text' class='form-control' />";
    str += "</td>";
    str += "<td style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    str += "<select id='ddlTypeForTD' class='form-control'>";
    str += "<option value='-1'>Please Select</option>";
    for (var x = 0; x < arrTransType.length; x++) {
        str += "<option value='" + arrTransType[x].Id + "'>" + arrTransType[x].Name + "</option>";
    }
    str += "</select>";
    str += "</td>";
    str += "<td style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    str += "<input id='txtTDQty' type='number' class='form-control' />";
    str += "</td>";
    str += "<td style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    str += "<input id='txtTDValue' type='text' class='form-control' />";
    str += "</td>";

    str += "<td style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    str += "<select id='ddlProposedTransactionThrough' class='form-control'>";
    str += "<option value=''>--Select--</option>";
    str += "<option value='Stock Exchange'>Stock Exchange</option>";
    str += "<option value='Off-Market Deal'>Off-Market Deal</option>";
    str += "</select>";
    str += "</td>";

    str += "<td style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    str += "<select id='ddlExchangeTradedOn' class='form-control'>";
    str += "<option value=''>--Select--</option>";
    str += "<option value='BSE'>BSE</option>";
    str += "<option value='NSE'>NSE</option>";
    str += "</select>";
    str += "</td>";

    //str += "<td style='padding-left:5px;padding-right:5px;padding-top:10px;'>";
    //str += "<input id='txtTDAmount' type='text' class='form-control' />";
    //str += "</td>";
    str += "<td style='padding-left:5px;padding-right:5px;width:5%;padding-top:10px;'>";
    str += "<a onclick='javascript:fnAddNewRow();'>";
    str += "<i class='fa fa-plus'></i>";
    //str += "</a>&nbsp;&nbsp;";
    //str += "<a onclick='javascript:fnRemoveRow(this);'>";
    //str += "<i class='fa fa-minus'></i>";
    //str += "</a>";
    str += "</td>";
    str += "</tr>";
    $("#tbdTrade").append(str);

    //fnSetDate();
}