﻿//var objDesignation = [];
var userlistforcommittee = [];
//var result12 = "";
function fnOpenNew() {
    $("#Coordinator").hide();
    $("span[id*='spnCommitte']").html("New Committe");
    $('#lblCommitteeName').removeClass('text-danger');
    $('#lblCommitteeABRR').removeClass('text-danger');
    $('#lblCommitteeSuperAdmin').removeClass('text-danger');
    //fnAddCommittee();
}
function fnRemoveClass(obj, val) {
    $("#lbl" + val + "").removeClass('requied');
}
function initializeDataTable() {
    $('#tbl-committee-setup').DataTable({
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

$(document).ready(function () {
    debugger
    //window.history.forward();
    //function preventBack() { window.history.forward(1); }

    //fnListCommittee();
    //fnBindDesignation();
    //fnBindCompanyGroup();

    getuserforSuperAdmin();
    GetUserListForCommittee();

});
function getuserforSuperAdmin() {
    debugger
    var webUrl = uri + "/api/Committee/GetUsersForCommitteeSuperAdmin";
    $("input[id*='txtAddSuperAdmin']").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: webUrl,
                type: "POST",
                data: JSON.stringify({
                    userName: request.term
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    $("#Loader").hide();
                    if (!data.StatusFl) {
                        alert(data.Msg);
                        return false;
                    }
                    else {
                        //$.each(data.UserList, function (index, item) {
                        //    objUser.push(item);                                                 
                        //})                        
                        response($.map(data.UserList, function (item) {
                            return {
                                label: item.userName + " (" + item.emailId + ")",
                                val: item.ID
                            }
                        }))
                    }
                },
                error: function (response) {
                    $("#Loader").hide();
                    alert(response.status + ' ' + response.statusText);
                }
            });
        },
        select: function (e, i) {
            $("input[id*='emailAddSuperAdmin']").val(i.item.val);

        },
        minLength: 3
    });
    $('.ui-autocomplete').css({ 'z-index': '2147483647' });
}
function GetUserListForCommittee() {
    debugger
    $("#Loader").show();
    //var webUrl = uri + "/api/User/GetUserList";
    var webUrl = uri + "/api/Committee/GetUserListForCommittee"; //"api/CommitteeHandler.ashx?caller=GetUserListForCommittee";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({
            /*status: $("select[id*='ddlUserStatus']").val()*/
            COMPANY_ID: 0
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            if (msg.StatusFl) {
                $("#ddlCoordinator").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.CommitteeList != undefined && msg.CommitteeList != null) {
                    if (msg.CommitteeList.length > 0) {
                        for (var i = 0; i < msg.CommitteeList[0].committeeAdmins.length; i++) {
                            userlistforcommittee.push(msg.CommitteeList[0].committeeAdmins[i]);
                       /* for (var i = 0; i < msg.UserList.length; i++) {*/
                            /* $("#ddlCoordinator").append($("<option></option>").val(msg.UserList[i].ID).html(msg.UserList[i].userFirstName));*/
                            /*$("#ddlCoordinator").append($("<option></option>").val(msg.CommitteeList[0].committeeAdmins[i].ID).html(msg.CommitteeList[0].committeeAdmins[i].userName).html(msg.CommitteeList[0].committeeAdmins[i].emailId));*/
                            $("#ddlCoordinator").append(
                                $("<option></option>")
                                    .val(msg.CommitteeList[0].committeeAdmins[i].ID)
                                    .text(msg.CommitteeList[0].committeeAdmins[i].userName + " - " + msg.CommitteeList[0].committeeAdmins[i].emailId)
                            );
                        }
                    }
                }
            }
            else {
                $("#ddlCoordinator").empty().append('<option selected="selected" value="0">Please Select</option>');
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

function fnAddCoordinator() {
    debugger
    if (fnValidateCoordinator()) {
        // Get the selected value from the dropdown
        var selectedValue = $("#ddlCoordinator").val();

        // Check if the selected value is already in the table
        if ($("#sample_Users tbody td:first-child").filter(function () {
            return $(this).text() === selectedValue;
        }).length > 0) {
            // Value is already in the table, handle the validation accordingly
            alert("This coordinator is already selected.");
            // You may choose to return false or take other actions based on your requirements
            return false;
        }

        // Get the corresponding admin object from msg.CommitteeList[0].committeeAdmins
        var selectedAdmin = userlistforcommittee.find(function (admin) {
            return admin.ID == selectedValue;
        });

        // Display the selected admin in the table
        var tableRow = $("<tr></tr>")
            .append($("<td style='display: none;'></td>").text(selectedAdmin.ID))
            .append($("<td></td>").text(selectedAdmin.userName))
            .append($("<td></td>").text(selectedAdmin.emailId))
            .append($("<td><img onclick='javascript: fnDeleteCoordinator(this); ' src='../assets/image/Icon/delete.png' style='width: 24px; height: 24px;' /></td>"));

        // Append the row to the table
        $("#sample_Users tbody").append(tableRow);

        // Reset the dropdown value
        $('#ddlCoordinator').val(0);
    }
    else {
        // Handle validation failure
        $('#btnadd').removeAttr("data-dismiss");
        return false;
    }

    $("#Coordinator").show();

}
function fnValidateCoordinator() {
    debugger
    var isValid = true;

    var Coordinator = $("select[id*='ddlCoordinator']").val().trim();
   

    if (Coordinator == '0') {
        isValid = false;
        alert("Please Select Meeting Coordinator!");
    }
    else {
        // alert("This is your alert message!");
    }

    if (!isValid) {
        return isValid;
    }

    return isValid;
}
function fnDeleteCoordinator(cntrl) {
    debugger
    $(cntrl).closest('tr').remove();
   // $("#Coordinator").hide();
}
function fnCheckAll(source, tbl) {
    if ($(source)[0].checked) {
        $("#" + tbl + "").children().find("td input:checkbox").prop("checked", true);
    }
    else {
        $("#" + tbl + "").children().find("td input:checkbox").prop("checked", false);
    }
}
function fnCloseModal() {
    fnClearForm();
}

function fnClearForm() {
    $('#txtCommitteeid').val('');
    //$('#txtName').val('');
    $('#txtCommitteeName').val('');
    $('#txtCommitteeAbbr').val('');
    $('#txtAddSuperAdmin').val('');
    $('#emailAddSuperAdmin').val('');
    $('#ddlCoordinator').val(0);
   
    fnRemoveClass(null, 'CommitteeName');
    fnRemoveClass(null, 'CommitteeABRR');
    fnRemoveClass(null, 'CommitteeSuperAdmin');
    fnRemoveClass(null, 'Coordinator');
}
function fnSaveCommittee() {
    debugger
    var st = fnValidate();
    if (!st) {
        return false;
    }
    $("#Loader").show();

    $("#EditCommittee").modal('hide');

    var CommitteeAdmin = [];
    for (var i = 0; i < $("#tbdCoordinatorList").children().length; i++) {
        var AE = new Object();

        AE.ID = $($($("#tbdCoordinatorList").children()[i]).children()[0]).text();
        AE.userName = $($($("#tbdCoordinatorList").children()[i]).children()[1]).text();;
        AE.emailId = $($($("#tbdCoordinatorList").children()[i]).children()[2]).text();;
        CommitteeAdmin.push(AE);
    }
    //var adminColl = [];
    //for (var i = 0; i < CommitteeAdmin.length; i++) {
    //    adminColl[adminColl.length] = new User(CommitteeAdmin[i], "Both");
    //}

    //adminColl[adminColl.length] = new User($("input[id*='emailAddSuperAdmin']").val(), "Committee Admin");

    var commiteeColl = [];
    commiteeColl[commiteeColl.length] = new Committee($("input[id*='txteditID']").val(),$("input[id*='txtCommitteeName']").val(), $("input[id*='txtCommitteeAbbr']").val(),CommitteeAdmin);

    var webUrl = uri + "/api/Committee/SaveCommittee"; //"api/CommitteeHandler.ashx?caller=SaveCommittee";
    setTimeout(function () {
        $.ajax({
            type: 'POST',
            url: webUrl,
            data: JSON.stringify(commiteeColl),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: false,
            success: function (msg) {
                $("#Loader").hide();
                if (!msg.StatusFl) {
                    if (msg.Msg == "SessionExpired") {
                        alert("Your session is expired. Please login again to continue");
                        window.location.href = "../Login.aspx";
                        return false;
                    }
                    else {
                        alert(msg.Msg);
                        return false;
                    }
                }
                else {
                    $("#committee_add").modal('hide');
                    alert(msg.Msg);
                    fnListCommittee();
                }
            },
            error: function (error) {
                $("#Loader").hide();
                $('#btnSave').removeAttr("data-dismiss");
                alert(error.status + ' ' + error.statusText);
            }
        })
    }, 10);
}
//function User(id, designationName) {
//    this.ID = id;
//    this.designation = new Designation(designationName)
//}
//function Designation(designationName) {
//    this.designationName = designationName;
//}
function Committee(ID, name, abrr, usercoll) {
    debugger
    if (ID == "") {
        this.ID = 0;
    }
    else {
        this.ID = ID;
    }
    this.ID = ID;
    this.committeeName = name;
    this.committeeABRR = abrr;
    this.committeeAdmins = usercoll;
}
function fnValidate() {
    var obj = "";

    var CommitteeName = $("input[id*='txtCommitteeName']").val();
    var CommitteeAbbr = $("input[id*='txtCommitteeAbbr']").val();
    var txtAddSuperAdmin = $("input[id*='txtAddSuperAdmin']").val();

    if (CommitteeName == "" || CommitteeName == null || CommitteeName == '0') {
        $('#lblCommitteeName').addClass('text-danger');
        obj = "false";
    }
    else {
        $('#lblCommitteeName').removeClass('text-danger');
        obj = "";
    }

    if (CommitteeAbbr == "" || CommitteeAbbr == null || CommitteeAbbr == '0') {
        $('#lblCommitteeABRR').addClass('text-danger');
        obj = "false";
    }
    else {
        $('#lblCommitteeABRR').removeClass('text-danger');
        obj = "";
    }

    if (txtAddSuperAdmin == "" || txtAddSuperAdmin == null || txtAddSuperAdmin == '0') {
        $('#lblCommitteeSuperAdmin').addClass('text-danger');
        obj = "false";
    }
    else {
        $('#lblCommitteeSuperAdmin').removeClass('text-danger');
        obj = "";
    }

    if (obj == "false") {
        return false;
    }

    return true;
}



function fnListCommittee() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/Committee/ListCommittee";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({
            COMPANY_ID: 0
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (msg) {
            $("#Loader").hide();
            var result = "";
            var table = $('#tbl-committee-setup').DataTable();
            table.destroy();
            $("#tbdCommitteList").html(result);
            if (msg.StatusFl) {
                for (var i = 0; i < msg.CommitteeList.length; i++) {
                    var seq = i + 1;
                    result += '<tr id="tr_' + msg.CommitteeList[i].ID + '">';
                    result += '<td style="text-align:center;">' + seq + '</td>';
                    result += '<td>' + msg.CommitteeList[i].committeeName + '</td>';
                    result += '<td>' + msg.CommitteeList[i].committeeABRR + '</td>';
                    result += '<td style="text-align:center;">' + msg.CommitteeList[i].NoOfcommitteeMembers + '</td>';
                    result += '<td id="tdEdit_' + msg.CommitteeList[i].ID + '">';
                    if (msg.CommitteeList[i].isDelete == 0) {
                        result += '<a  id="a_' + msg.CommitteeList[i].ID + '" class="btn btn-outline dark" onclick=\"javascript:EditCommittee(' + msg.CommitteeList[i].ID + ');\">Edit</a>';
                        result += '&nbsp;&nbsp;';
                        result += '<a  id="a_' + msg.CommitteeList[i].ID + '" class="btn btn-outline dark" onclick=\"javascript:Conferm_Delete(' + msg.CommitteeList[i].ID + ');\">Delete</a>';
                    }
                    else {
                        result += '<a  id="a_' + msg.CommitteeList[i].ID + '" class="btn btn-outline dark" onclick=\"javascript:EditCommittee(' + msg.CommitteeList[i].ID + ');\">Edit</a>';
                    }
                    result += '</td>';
                    result += '</tr>';
                }
                $("#tbdCommitteList").html(result);
                initializeDataTable();
            }
            else {
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                else {
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

//function EditCommittee(ide) {
//    $("#Loader").show();
//    $('#lblCommitteeName').removeClass('requied');
//    $('#lblCommitteeABRR').removeClass('requied');
//    $('#lblCommitteeSuperAdmin').removeClass('requied');
//    $("span[id*='spnCommittee']").html("Edit Committee");
//    $("#txteditID").val(ide);
//    $("#EditCommittee").hide();

//    var webUrl = uri + "/api/Committee/EditCommittee"; //"api/CommitteeHandler.ashx?caller=EditCommittee";
//    setTimeout(function () {
//        $.ajax({
//            type: "POST",
//            url: webUrl,
//            data: JSON.stringify({
//                ID: ide
//            }),
//            contentType: "application/json; charset=utf-8",
//            datatype: "json",
//            async: true,
//            success: function (msg) {
//                $("#Loader").hide();
//                if (msg.StatusFl) {
//                    var result = "";
//                    $("input[id*='txtCommitteeName']").val(msg.CommitteeList[0].committeeName);
//                    $("input[id*='txtCommitteeAbbr']").val(msg.CommitteeList[0].committeeABRR);
//                    if (msg.CommitteeList[0].superAdmin != null) {
//                        if (msg.CommitteeList[0].superAdmin != undefined) {
//                            $("input[id*='emailAddSuperAdmin']").val(msg.CommitteeList[0].superAdmin.ID);
//                            $("input[id*='txtAddSuperAdmin']").val(msg.CommitteeList[0].superAdmin.userName);
//                        }
//                    }

//                    var result = "";
//                    result += '<table id="sample_Users" class="TFtable">';
//                    result += '<thead>';
//                    result += '<th>';
//                    result += '<input id="chkAll" type="checkbox" onclick="fnCheckAll(this,\'sample_Users\');" />';
//                    result += '</th>';
//                    result += '<th>Name</th>';
//                    result += '<th>Email</th>';
//                    result += '<th>Role</th>';
//                    result += '</tr>';
//                    result += '</thead>';
//                    result += '<tbody id="tbodySeq">';

//                    for (var i = 0; i < msg.CommitteeList[0].committeeAdmins.length; i++) {
//                        userlistforcommittee.push(msg.CommitteeList[0].committeeAdmins[i]);
//                        result += '<tr id="tr_' + msg.CommitteeList[0].committeeAdmins[i].ID + '">';
//                        result += '<td>';
//                        if (msg.CommitteeList[0].committeeAdmins[i].CHECKED == 1) {
//                            result += '<input type="checkbox" class="checkboxes" checked="true" value="' + msg.CommitteeList[0].committeeAdmins[i].ID + '" onclick="fnUncheckAll(this,\'sample_Users\',\'chkAll\');" />';
//                        }
//                        else {
//                            result += '<input type="checkbox" class="checkboxes" value="' + msg.CommitteeList[0].committeeAdmins[i].ID + '" onclick="fnUncheckAll(this,\'sample_Users\',\'chkAll\');" />';
//                        }
//                        result += '</td>';
//                        result += '<td>' + msg.CommitteeList[0].committeeAdmins[i].userName + '</td>';
//                        result += '<td>' + msg.CommitteeList[0].committeeAdmins[i].emailId + '</td>';
//                        result += '<td>' + msg.CommitteeList[0].committeeAdmins[i].role.role + '</td>';
//                        result += '</tr>';
//                    }
//                    result += '</tbody>';
//                    result += '</table>';

//                    $("#divUsers").html(result);

//                    //for (var i = 0; i < msg.CommitteeList[0].committeeAdmins.length; i++) {
//                    //    userlistforcommittee.push(msg.CommitteeList[0].committeeAdmins[i]);
//                    //    result += '<tr id="tr_' + msg.CommitteeList[0].committeeAdmins[i].ID + '">';
//                    //    var CH = msg.CommitteeList[0].committeeAdmins[i].CHECKED;
//                    //    if (CH == 1) {
//                    //        result += '<td><label class="mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox" checked class="checkboxes" value="' + msg.CommitteeList[0].committeeAdmins[i].ID + '" /><span></span></label></td>';
//                    //    }
//                    //    else {
//                    //        result += '<td><label class="mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox"  class="checkboxes" value="' + msg.CommitteeList[0].committeeAdmins[i].ID + '" /><span></span></label></td>';
//                    //    }
//                    //    result += '<td>' + msg.CommitteeList[0].committeeAdmins[i].userName + '</td>';
//                    //    result += '<td>' + msg.CommitteeList[0].committeeAdmins[i].emailId + '</td>';
//                    //    result += '<td>' + msg.CommitteeList[0].committeeAdmins[i].role.role + '</td>';
//                    //    result += '</tr>';
//                    //}

//                    //var table = $('#sample_1_2').DataTable();
//                    //table.destroy();
//                    //$("#user_detail").html(result);
//                    //initializeDataTable();
//                    $("#committee_add").modal('show');
//                }
//                else {
//                    if (msg.Msg == "SessionExpired") {
//                        alert("Your session is expired. Please login again to continue");
//                        window.location.href = "../Login.aspx";
//                        return false;
//                    }
//                    else {
//                        alert(msg.Msg);
//                        return false;
//                    }
//                }
//            },
//            error: function (response) {
//                $("#Loader").hide();
//                alert(response.status + ' ' + response.statusText);
//            }
//        });
//    }, 10);
//}


//function Conferm_save() {
//    var st = fnValidate();
//    if (!st) {
//        return false;
//    }
//    else {
//        var comid = $("input[id*='txteditID']").val()
//        var name = $("input[id*='txtCommitteeName']").val();
//        var status = true;
//        var webUrl = uri + "/api/Committee/ListCommittee"; //"api/CommitteeHandler.ashx?caller=ListCommittee";
//        setTimeout(function () {
//            $.ajax({
//                type: "POST",
//                url: webUrl,
//                data: JSON.stringify({
//                    companyId: 0
//                }),
//                contentType: "application/json; charset=utf-8",
//                datatype: "json",
//                async: false,
//                success: function (msg) {
//                    $("#Loader").hide();
//                    if (msg.StatusFl) {
//                        var result = "";
//                        for (var j = 0; j < msg.CommitteeList.length; j++) {
//                            if (msg.CommitteeList[j].committeeName == name) {
//                                status = false;
//                                if (comid == 0) {
//                                    alert("committee Name Already Exist. Please Choose Another. ");
//                                    return false;
//                                }
//                            }
//                        }
//                    }
//                    else {
//                        alert(msg.Msg);
//                        return false;
//                    }
//                },
//                error: function (response) {
//                    $("#Loader").hide();
//                    if (response.responseText == "Session Expired") {
//                        alert("Your session is expired. Please login again to continue");
//                        window.location.href = "../Login.aspx";
//                        return false;
//                    }
//                    else {
//                        alert(response.status + ' ' + response.statusText);
//                    }
//                }
//            });
//        }, 10);

//        if (status) {
//        }
//        else {
//            if (comid == 0) {
//                return false;
//            }
//        }
//        $("#committee_add").modal('hide');
//        $("#EditCommittee").modal('show');
//    }
//}


//function toggle(source) {
//    var checkboxes = document.querySelectorAll('input[type="checkbox"]');
//    for (var i = 0; i < checkboxes.length; i++) {
//        if (checkboxes[i] != source)
//            checkboxes[i].checked = source.checked;
//    }
//}

//function Conferm_Delete(id) {
//    $("#txtDelID").val(id);
//    $("#deleteCommittee").show();
//}

//function Conferm_Edit(id) {
//    $("#txteditID").val(id);
//    $("#EditCommittee").show();
//}

//function DeleteCommittee() {
//    $("#Loader").show();
//    $("#deleteCommittee").hide();
//    var webUrl1 = uri + "/api/Committee/DeleteCommittee_CheckMeeting"; //"api/CommitteeHandler.ashx?caller=DeleteCommittee_CheckMeeting";
//    $.ajax({
//        type: "POST",
//        url: webUrl1,
//        data: JSON.stringify({
//            ID: $("input[id*='txtDelID']").val()
//        }),
//        contentType: "application/json; charset=utf-8",
//        datatype: "json",
//        async: false,
//        success: function (msg) {
//            if (msg.StatusFl) {
//                result12 = 'true';
//                alert(msg.Msg);
//                return false;
//            }
//            else {
//                if (msg.Msg == "SessionExpired") {
//                    alert("Your session is expired. Please login again to continue");
//                    window.location.href = "../Login.aspx";
//                    return false;
//                }
//                else {
//                    result12 = 'false';
//                }
//            }
//        },
//        error: function (response) {
//            $("#Loader").hide();
//            alert(response.status + ' ' + response.statusText);
//        }
//    });

//    var aa;
//    if (result12 == 'false') {
//        aa = "";
//        var webUrl = uri + "/api/Committee/DeleteCommittee"; //"api/CommitteeHandler.ashx?caller=DeleteCommittee";
//        $.ajax({
//            type: "POST",
//            url: webUrl,
//            data: JSON.stringify({
//                ID: $("input[id*='txtDelID']").val()
//            }),
//            contentType: "application/json; charset=utf-8",
//            datatype: "json",
//            async: true,
//            success: function (msg) {
//                $("#Loader").hide();
//                if (msg.StatusFl) {
//                    var result = "";
//                    alert(msg.Msg);
//                    fnListCommittee();
//                }
//                else {
//                    if (msg.Msg == "SessionExpired") {
//                        alert("Your session is expired. Please login again to continue");
//                        window.location.href = "../Login.aspx";
//                        return false;
//                    }
//                    else {
//                        alert(msg.Msg);
//                        return false;
//                    }
//                }
//            },
//            error: function (response) {
//                $("#Loader").hide();
//                alert(response.status + ' ' + response.statusText);
//            }
//        });
//    }
//    else {
//        $("#Loader").hide();
//        fnListCommittee();
//    }
//}

//function initializeDataTable() {
//    $('#tbl-committee-setup').DataTable({
//        //  "dom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>',
//        dom: 'Bfrtip',
//        pageLength: 10,
//        buttons: [
//            //    {
//            //        extend: 'pdf',
//            //        className: 'btn green btn-outline',
//            //        exportOptions: {
//            //            columns: [0]
//            //        }
//            //    },
//            //    {
//            //        extend: 'excel',
//            //        className: 'btn yellow btn-outline ',
//            //        exportOptions: {
//            //            columns: [0]
//            //        }
//            //    },
//            ////    { extend: 'colvis', className: 'btn dark btn-outline', text: 'Columns' }
//        ]
//    });
//}

//function fnCheckAll(source, tbl) {
//    if ($(source)[0].checked) {
//        $("#" + tbl + "").children().find("td input:checkbox").prop("checked", true);
//    }
//    else {
//        $("#" + tbl + "").children().find("td input:checkbox").prop("checked", false);
//    }
//}

//function fnUncheckAll(source, tbl, chk) {
//    if (!$(source)[0].checked) {
//        $("#" + tbl + " > thead").find("th input[id*='" + chk + "']").prop("checked", false);
//    }
//}

//function fnCloseModal() {
//    fnClearForm();
//}

//function fnClearForm() {
//    $('#txtDesignationName').val('');
//    $('#txtDesignationId').val(0);
//}

//function Conferm_Delete_Close(id) {

//    $("#txtDelID").val('');
//    $("#deleteCommittee").hide();
//}

//function Conferm_Edit_Close(id) {
//    $("#txteditID").val('');
//    $("#EditCommittee").hide();
//}

//function fnOpenNew() {
//    debugger
//    /* $("span[id*='spnCommitte']").html("New Committee");*/
//    $("span[Id*='spnTitle']").html("New Committee");
//    $('#lblCommitteeName').removeClass('requied');
//    $('#lblCommitteeABRR').removeClass('requied');
//    $('#lblCommitteeSuperAdmin').removeClass('requied');
//    fnAddCommittee();
//}

//function Committee(ID, name, abrr, usercoll) {
//    if (ID == "") {
//        this.ID = 0;
//    }
//    else {
//        this.ID = ID;
//    }
//    this.ID = ID;
//    this.committeeName = name;
//    this.committeeABRR = abrr;
//    this.committeeAdmins = usercoll;
//}

//function User(id, designationName) {
//    this.ID = id;
//    this.designation = new Designation(designationName)
//}

//function Designation(designationName) {
//    this.designationName = designationName;
//}

//function fnRemoveClass(obj, val) {
//    $("#lbl" + val + "").removeClass('requied');
//}