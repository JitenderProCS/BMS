var objCompany = [];
var uploadedFile = null;

$(document).ready(function () {

    fnGetCompanyList();
    fnBindCompanyType();
    fnBindCompanyGroup();

});

function fnGetCompanyList() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/Company/GetCompanyList";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({         
            //CompanyId:0
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            var result = "";
            var table = $('#tbl-company-setup').DataTable();
            table.destroy();

            $("#tbdCompanyList").html("");
            if (msg.StatusFl) {
                for (var i = 0; i < msg.CompanyList.length; i++) {
                    objCompany.push(msg.CompanyList[i]);
                    result += '<tr id="tr_' + msg.CompanyList[i].companyId + '">';
                    result += '<td id="tdEdit_' + msg.CompanyList[i].companyId + '"><a data-target="#exampleModalSizeLg" data-toggle="modal" id="a_' + msg.CompanyList[i].companyId + '" class="btn btn-outline dark" onclick=\"javascript:fnEditUser(' + i + ');\">Edit</a></td>';
                    result += '<td id="tdUser_Name_' + msg.CompanyList[i].companyId + '">' + msg.CompanyList[i].CompanyName + '</td>';
                    result += '<td id="tdUser_Name_' + msg.CompanyList[i].CompanyTypeId + '">' + msg.CompanyList[i].CompanyTypeName + '</td>';
                    result += '<td id="tdUser_Name_' + msg.CompanyList[i].CompanyGroupId + '">' + msg.CompanyList[i].CompanyGroupName + '</td>';
                    
                   // result += '<td id="tdUser_UserLogin_' + msg.CompanyList[i].companyId + '">' + msg.CompanyList[i].uploadAvatar + '</td>';
                  //  result += '<td id="tdUser_Status_' + msg.CompanyList[i].companyId + '">' + msg.CompanyList[i].status + '</td>';
                    if (msg.CompanyList[i].uploadAvatar == "") {
                        result += '<td id="tdUser_Avatar_' + msg.CompanyList[i].companyId + '"><image height="80px" width="80px" src=' + uri + '/BoardMeeting/images/user/Unknown.png/></td>';
                    }
                    else {
                        var pic = msg.CompanyList[i].uploadAvatar;
                        result += '<td id="tdUser_Avatar_' + msg.CompanyList[i].companyId + '"><image height="80px" width="80px" src=' + uri + "/BoardMeeting/images/CompanyLogo/" + pic + '/></td>';
                    }
                    result += '</tr>';
                }
                $("#tbdCompanyList").html(result);
                initializeDataTable();
            }
            else {
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                else {
                    $("#tbdCompanyList").html(result);
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


function fnAddUpdateUser() {
    debugger;
    var companyData = new FormData();
    var CompanyColl = [];
    CompanyColl[CompanyColl.length] = new Company($("input[id*='txtCompanyId']").val() == 0 ? 0 : $("input[id*='txtCompanyId']").val(),
        $("select[id*='ddlCompanyGroup']").val(),
        $("input[id*='txtCompanyName']").val(),
        $("select[id*='ddlCompanyType']").val(),
    
    );

    companyData.append("Object", JSON.stringify(CompanyColl));

    var comp = new Company();
 

    if ($("input[id*='fileUploadImage']").get(0).files.length > 0) {
        companyData.append("Files", $("input[id*='fileUploadImage']").get(0).files[0]);
    }

    $("#Loader").show();
    var webUrl = uri + "/api/Company/SaveCompany";

    setTimeout(function () {
        $.ajax({
            type: 'POST',
            url: webUrl,
            data: companyData,
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
    $("#lbl" + val + "").removeClass('requied');
}

function Company(ID, CompanyGroupId,CompanyName, CompanyTypeId) {
    debugger
    this.companyId = ID;
    this.CompanyGroupId = CompanyGroupId;
    this.CompanyName = CompanyName;
    this.CompanyTypeId = CompanyTypeId;
   
}


function initializeDataTable() {
    $('#tbl-company-setup').DataTable({
        dom: 'Bfrtip',
        pageLength: 10,
        buttons: [
            {
                extend: 'pdf',
                className: 'btn green btn-outline',
                exportOptions: {
                    columns: [1,2,3,4]
                }
            },
            {
                extend: 'excel',
                className: 'btn yellow btn-outline ',
                exportOptions: {
                    columns: [1,2,3,4]
                }
            },
            //    { extend: 'colvis', className: 'btn dark btn-outline', text: 'Columns' }
        ]
    });
}

function fnEditUser(index) {
    debugger;
    $("span[Id*='spnCompany']").html("Edit Company");
    $('#txtCompanyId').val(objCompany[index].companyId);
    $("select[id*='ddlCompanyGroup'] option[value='" + objCompany[index].CompanyGroupId + "']").prop("selected", true);
    $('#txtCompanyName').val(objCompany[index].CompanyName);
    $("select[id*='ddlCompanyType'] option[value='" + objCompany[index].CompanyTypeId + "']").prop("selected", true);

    if (objCompany[index].uploadAvatar !== undefined && objCompany[index].uploadAvatar !== null && objCompany[index].uploadAvatar.trim() !== '') {
        $("#aUserAvatarImageUploaded").show();
        uploadedFile = objCompany[index].uploadAvatar;
        $("#aUserAvatarImageUploaded").attr('href', 'BoardMeeting/images/CompanyLogo/' + objCompany[index].uploadAvatar);
        $("#companyImageUploaded").attr('src', 'BoardMeeting/images/CompanyLogo/' + objCompany[index].uploadAvatar);
    }
    else {
        $("#aUserAvatarImageUploaded").hide();
    }

}

function fnBindCompanyType() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/Company/GetCompanyTypeList";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: {},
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {

            var dt = msg.CompanyList[0];

            $("#Loader").hide();
            if (msg.StatusFl) {
                $("#ddlCompanyType").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.CompanyList.length != undefined && msg.CompanyList.length != null) {
                    if (msg.CompanyList.length > 0) {
                        for (var i = 0; i < msg.CompanyList.length; i++) {                         
                            $("#ddlCompanyType").append($("<option></option>").val(msg.CompanyList[i].CompanyTypeId).html(msg.CompanyList[i].CompanyTypeName));
                        }
                    }
                }
            }
            else {
                $("#ddlCompanyType").empty().append('<option selected="selected" value="0">Please Select</option>');
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


function fnBindCompanyGroup() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/Company/GetCompanyGroupList";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: {},
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {

           // var dt = msg.CompanyList[0];

            $("#Loader").hide();
            if (msg.StatusFl) {
                $("#ddlCompanyGroup").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.CompanyGroupList.length != undefined && msg.CompanyGroupList.length != null) {
                    if (msg.CompanyGroupList.length > 0) {
                        for (var i = 0; i < msg.CompanyGroupList.length; i++) {                           
                            $("#ddlCompanyGroup").append($("<option></option>").val(msg.CompanyGroupList[i].CompanyGroupId).html(msg.CompanyGroupList[i].CompanyGroupName));
                        }
                    }
                }
            }
            else {
                $("#ddlCompanyGroup").empty().append('<option selected="selected" value="0">Please Select</option>');
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

function fnOpenNew() {
    $("span[id*='spnCompany']").html("New Company");
}
