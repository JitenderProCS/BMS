var objGroupCompany = [];
var uploadedFile = null;

$(document).ready(function () {

    //window.history.forward();
    //function preventBack() { window.history.forward(1); }

    //fnGetCompanyList();
    //fnBindDesignation();
    //fnBindCompanyGroup();

    fnGetCompanyGroupList();

});

function fnGetCompanyGroupList() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/Company/GetCompanyGroupList";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({
            //status: $("select[id*='ddlUserStatus']").val()
            //CompanyId:0
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            var result = "";
            var table = $('#tbl-companygroup-setup').DataTable();
            table.destroy();

            $("#tbdGroupCompanyList").html("");
            if (msg.StatusFl) {
                for (var i = 0; i < msg.CompanyGroupList.length; i++) {
                    objGroupCompany.push(msg.CompanyGroupList[i]);
                    result += '<tr id="tr_' + msg.CompanyGroupList[i].companyId + '">';
                    result += '<td id="tdEdit_' + msg.CompanyGroupList[i].CompanyGroupId + '"><a data-target="#exampleModalSizeLg" data-toggle="modal" id="a_' + msg.CompanyGroupList[i].CompanyGroupId + '" class="btn btn-outline dark" onclick=\"javascript:fnEditUser(' + i + ');\">Edit</a></td>';
                    result += '<td id="tdUser_Name_' + msg.CompanyGroupList[i].CompanyGroupId + '">' + msg.CompanyGroupList[i].CompanyGroupName + '</td>';
 
                    if (msg.CompanyGroupList[i].uploadAvatar == "") {
                        result += '<td id="tdUser_Avatar_' + msg.CompanyGroupList[i].CompanyGroupId + '"><image height="80px" width="80px" src=' + uri + '/BoardMeeting/images/user/Unknown.png/></td>';
                    }
                    else {
                        var pic = msg.CompanyGroupList[i].uploadAvatar;
                        result += '<td id="tdUser_Avatar_' + msg.CompanyGroupList[i].CompanyGroupId + '"><image height="80px" width="80px" src=' + uri + "/BoardMeeting/images/CompanyGroupLogo/" + pic + '/></td>';
                    }
                    result += '</tr>';
                }
                $("#tbdGroupCompanyList").html(result);
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


function fnAddUpdateCompanyGroup() {
    debugger;
    var companyData = new FormData();
    var CompanyColl = [];
    CompanyColl[CompanyColl.length] = new CompanyGroup($("input[id*='txtCompanyGroupId']").val() == 0 ? 0 : $("input[id*='txtCompanyGroupId']").val(),
        $("input[id*='txtCompanyGroupName']").val()


    );

    companyData.append("Object", JSON.stringify(CompanyColl));

    //var comp = new CompanyGroup();


    if ($("input[id*='fileUploadImage']").get(0).files.length > 0) {
        companyData.append("Files", $("input[id*='fileUploadImage']").get(0).files[0]);
    }

    $("#Loader").show();
    var webUrl = uri + "/api/Company/SaveCompanyGroup";

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

function CompanyGroup(CompanyGroupId, CompanyGroupName) {
    debugger
    this.CompanyGroupId = CompanyGroupId;
    this.CompanyGroupName = CompanyGroupName;


}



function initializeDataTable() {
    $('#tbl-companygroup-setup').DataTable({
        dom: 'Bfrtip',
        pageLength: 10,
        buttons: [
            {
                extend: 'pdf',
                className: 'btn green btn-outline',
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'excel',
                className: 'btn yellow btn-outline ',
                exportOptions: {
                    columns: [0, 1]
                }
            },
            //    { extend: 'colvis', className: 'btn dark btn-outline', text: 'Columns' }
        ]
    });
}

function fnEditUser(index) {
    debugger;
    $("span[Id*='spnCompanyGroup']").html("Edit Company Group");
    $('#txtCompanyGroupId').val(objGroupCompany[index].CompanyGroupId);

    $('#txtCompanyGroupName').val(objGroupCompany[index].CompanyGroupName);


    if (objGroupCompany[index].uploadAvatar !== undefined && objGroupCompany[index].uploadAvatar !== null && objGroupCompany[index].uploadAvatar.trim() !== '') {
        $("#aUserAvatarImageUploaded").show();
        uploadedFile = objGroupCompany[index].uploadAvatar;
        $("#aUserAvatarImageUploaded").attr('href', 'BoardMeeting/images/CompanyLogo/' + objGroupCompany[index].uploadAvatar);
        $("#companyImageUploaded").attr('src', 'BoardMeeting/images/CompanyLogo/' + objGroupCompany[index].uploadAvatar);
    }
    else {
        $("#aUserAvatarImageUploaded").hide();
    }

}

function fnOpenNew() {
    $("span[id*='spnCompanyGroup']").html("New Company Group");
}
