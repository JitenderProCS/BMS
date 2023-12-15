var userlistforcommittee = [];
var CommitteeRoleList = [];
var arrCommitteeUserList = new Array();
function fnOpenNew() {
    $("#Coordinator").hide();
    $("#Select_Coordinator").hide();
   /* $("#committee_add").modal('show');*/
    $("span[id*='spnCommitte']").html("New Committe");
    $('#lblCommitteeName').removeClass('text-danger');
    $('#lblCommitteeABRR').removeClass('text-danger');
    $('#lblMembers').removeClass('text-danger');
    $('#lblIndependentDir').removeClass('text-danger');
    $('#lblWomenDir').removeClass('text-danger');
    $('#lblChairman').removeClass('text-danger');
    $('#lblSelectCoordinator').removeClass('text-danger');
    GetUserListForCommittee();
    
}
function fnRemoveClass(obj, val) {
    $("#lbl" + val + "").removeClass('text-danger');
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
                    columns: [0, 1, 2, 3, 4, 5]
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
    window.history.forward();
    function preventBack() { window.history.forward(1); }

    fnListCommittee();
   /* setuserDesignation();*/
  
   
    getuserforSuperAdmin();
    $("#txteditID").val("0");
   /* GetUserListForCommittee();*/
    GetCommitteeRole();
    GetCommitteeCoordinatorList();

});

function GetCommitteeRole() {
    $("#Loader").show();
    
    var webUrl = uri + "/api/Committee/GetCommitteeRole"; 
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
                $("#ddlSelectRole").empty().append('<option selected="selected" value="0">ROLE</option>');
                if (msg.CommitteeList != undefined && msg.CommitteeList != null) {
                    if (msg.CommitteeList.length > 0) {
                        for (var i = 0; i < msg.CommitteeList[0].committeerole.length; i++) {
                            CommitteeRoleList.push(msg.CommitteeList[0].committeerole[i]);
                            /* for (var i = 0; i < msg.UserList.length; i++) {*/
                            /* $("#ddlCoordinator").append($("<option></option>").val(msg.UserList[i].ID).html(msg.UserList[i].userFirstName));*/
                            /*$("#ddlCoordinator").append($("<option></option>").val(msg.CommitteeList[0].committeeAdmins[i].ID).html(msg.CommitteeList[0].committeeAdmins[i].userName).html(msg.CommitteeList[0].committeeAdmins[i].emailId));*/
                            $("#ddlSelectRole").append(
                                $("<option></option>")
                                    .val(msg.CommitteeList[0].committeerole[i].Id)
                                    .text(msg.CommitteeList[0].committeerole[i].committeerole)
                                    //.text(msg.CommitteeList[0].roles[i].role + " - " + msg.CommitteeList[0].committeeAdmins[i].emailId)
                            );
                        }
                    }
                }
            }
            else {
                $("#ddlSelectRole").empty().append('<option selected="selected" value="0">Please Select</option>');
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                return false;
            }
           /* $("#committee_add").modal('show');*/
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}
//function setuserDesignation() {
//    var webUrl = uri + "/api/Designation/GetDesignationList"; //"api/DesignationHandler.ashx?caller=GetDesignationList";
//    $.ajax({
//        type: "POST",
//        url: webUrl,
//        data: JSON.stringify({
//            companyId: 0
//        }),
//        contentType: "application/json; charset=utf-8",
//        datatype: "json",
//        async: false,
//        success: function (data) {
//            if (data.StatusFl) {
//                for (var x = 0; x < data.DesignationList.length; x++) {
//                    if (data.DesignationList[x].designationName != 'Chairperson') {
//                        userdesignation.push({
//                            ItemId: data.DesignationList[x].ID,
//                            ItemNm: data.DesignationList[x].designationName
//                        });
//                    }
//                }
//            }
//            else {
//                if (data.Msg == "SessionExpired") {
//                    alert("Your session is expired. Please login again to continue");
//                    window.location.href = "../Login.aspx";
//                }
//                return false;
//            }
//        },
//        error: function (response) {
//            $("#Loader").hide();
//            alert(response.status + ' ' + response.statusText);
//        }
//    });
//}
function getuserforSuperAdmin() {
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
                               // val: item.ID
                                val: item.userLogin
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
            debugger
            $("input[id*='emailAddSuperAdmin']").val(i.item.val);
        },
        minLength: 3
    });
    $('.ui-autocomplete').css({ 'z-index': '2147483647' });
}
function GetUserListForCommittee() {
    debugger
    $("#Loader").show();
    $("input[id*='txteditID']").val(0);
    $("input[id*='txtCommitteeName']").val("");
    $("input[id*='txtCommitteeAbbr']").val("");
    $("input[id*='txtAddSuperAdmin']").val("");
    $("input[id*='emailAddSuperAdmin']").val("");
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
                $("#ddlCoordinator").empty().append('<option selected="selected" value="0">Please Select Committee Member</option>');
                if (msg.CommitteeList != undefined && msg.CommitteeList != null) {
                    if (msg.CommitteeList.length > 0) {
                        for (var i = 0; i < msg.CommitteeList[0].committeeAdmins.length; i++) {
                            userlistforcommittee.push(msg.CommitteeList[0].committeeAdmins[i]);
                            $("#ddlCoordinator").append(
                                $("<option></option>")
                                    //.val(msg.CommitteeList[0].committeeAdmins[i].ID)
                                    .val(msg.CommitteeList[0].committeeAdmins[i].userLogin)
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
            $("#committee_add").modal('show');
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}

function GetCommitteeCoordinatorList() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/Committee/GetCommitteeCoordinatorList";
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
                $("#ddlSelectCoordinator").empty().append('<option selected="selected" value="0">Please Select Committee Coordinator(s)</option>');
                if (msg.CommitteeList != undefined && msg.CommitteeList != null) {
                    if (msg.CommitteeList.length > 0) {
                        for (var i = 0; i < msg.CommitteeList[0].committeeAdmins.length; i++) {
                            userlistforcommittee.push(msg.CommitteeList[0].committeeAdmins[i]);
                            /* for (var i = 0; i < msg.UserList.length; i++) {*/
                            /* $("#ddlCoordinator").append($("<option></option>").val(msg.UserList[i].ID).html(msg.UserList[i].userFirstName));*/
                            /*$("#ddlCoordinator").append($("<option></option>").val(msg.CommitteeList[0].committeeAdmins[i].ID).html(msg.CommitteeList[0].committeeAdmins[i].userName).html(msg.CommitteeList[0].committeeAdmins[i].emailId));*/
                            $("#ddlSelectCoordinator").append(
                                $("<option></option>")
                                    //.val(msg.CommitteeList[0].committeeAdmins[i].ID)
                                    .val(msg.CommitteeList[0].committeeAdmins[i].userLogin)
                                    .text(msg.CommitteeList[0].committeeAdmins[i].userName + " - " + msg.CommitteeList[0].committeeAdmins[i].emailId)
                            );
                        }
                    }
                }
            }
            else {
                $("#ddlSelectCoordinator").empty().append('<option selected="selected" value="0">Please Select Coordinator</option>');
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                }
                return false;
            }
            /*$("#committee_add").modal('show');*/
        },
        error: function (response) {
            $("#Loader").hide();
            alert(response.status + ' ' + response.statusText);
        }
    });
}


function fnAddMembers() {
    debugger;
    if (fnValidateCoordinator()) {
        // Get the selected values from the dropdowns
        var selectedCoordinator = $("#ddlCoordinator").val();
        var selectedSequence = $("#txtSequence").val();

        // Check if the selected coordinator is already in the table
        if ($("#sample_Users tbody td:first-child").filter(function () {
            return $(this).text() === selectedCoordinator;
        }).length > 0) {
            // Value is already in the table, handle the validation accordingly
            alert("This Committee Member is already selected.");
            // You may choose to return false or take other actions based on your requirements
            return false;
        }

        // Get the corresponding admin object from userlistforcommittee based on selectedCoordinator
        var selectedAdmin = userlistforcommittee.find(function (admin) {
            return admin.userLogin == selectedCoordinator;
        });


        // Display the selected admin in the table
        var tableRow = $("<tr></tr>")
            .append($("<td id='UserId' style='display: none;'></td>").text(selectedAdmin.userLogin))
            .append($("<td></td>").text(selectedAdmin.userName))
            .append($("<td></td>").text(selectedAdmin.emailId))
            .append($("<td id='Sequence'></td>").text(selectedSequence))
            .append($("<td><img onclick='javascript: fnDeleteCoordinator(this);' src='../assets/image/Icon/delete.png' style='width: 24px; height: 24px;' /></td>"));

        // Append the row to the table
        $("#sample_Users tbody").append(tableRow);

        // Reset the dropdown values
        $('#ddlCoordinator').val(0);
        $("input[id*='txtSequence']").val("");
    } 
    else {
        // Handle validation failure
        $('#btnadd').removeAttr("data-dismiss");
        return false;
    }

    $("#Coordinator").show();
}
function fnDeleteCoordinator(cntrl) {
    debugger
    $(cntrl).closest('tr').remove();
    // $("#Coordinator").hide();
}
function fnValidateCoordinator() {
    debugger
    var isValid = true;

    var Coordinator = $("select[id*='ddlCoordinator']").val().trim();
    var Sequence = $("input[id*='txtSequence']").val();


    if (Coordinator == '0') {
        isValid = false;
        alert("Please Select Meeting Coordinator!");
    }
    else {
        // alert("This is your alert message!");
    }

    if (Sequence == "" || Sequence == null || Sequence == '0') {
        isValid = false;
        alert("Please Enter Sequence!");

    }
    else {

    }

    if (!isValid) {
        return isValid;
    }

    return isValid;
}



/*************************************** */
function fnValidateSelectCoordinator() {
    debugger
    var isValid = true;

    var SelectCoordinator = $("select[id*='ddlSelectCoordinator']").val().trim();
    var CommitteeRole = $("select[id*='ddlSelectRole']").val().trim();
    

       if (SelectCoordinator == '0') {
        isValid = false;
        alert("Please Select Coordinators!");
    }
    else {
        // alert("This is your alert message!");
    }


    if (CommitteeRole == '0') {
        isValid = false;
        alert("Please Select Committee Role !");
    }
    else {
        // alert("This is your alert message!");
    }

    if (!isValid) {
        return isValid;
    }

    return isValid;
}
function CoordinatorDetail() {
    debugger
    this.ID = 0;
    this.userLogin = $("#ddlSelectCoordinator").val() == null ? 0 : ($("#ddlSelectCoordinator").val().trim() == "" ? 0 : $("#ddlSelectCoordinator").val());
    this.userName = $("#ddlSelectCoordinator option:selected").text() == null ? 0 : ($("#ddlSelectCoordinator option:selected").text().trim() == "" ? 0 : $("#ddlSelectCoordinator option:selected").text());
    this.CommitteeRoleId = $("#ddlSelectRole").val() == null ? 0 : ($("#ddlSelectRole").val().trim() == "" ? 0 : $("#ddlSelectRole").val());
    this.committeerole = $("#ddlSelectRole option:selected").text() == null ? 0 : ($("#ddlSelectRole option:selected").text().trim() == "" ? 0 : $("#ddlSelectRole option:selected").text());
    
}
function fnSelectCoordinator() {
    debugger
    $("#Select_Coordinator").show();
    if (fnValidateSelectCoordinator()) {
        var obj = new CoordinatorDetail();
        var str = "";
        str += '<tr>';
        str += '<td style="display:none;">' + obj.ID + '</td>';
        str += '<td style="display:none;">' + obj.userLogin + '</td>';
        str += '<td>' + obj.userName + '</td>';
        str += '<td style="display:none;">' + obj.CommitteeRoleId + '</td>';
        str += '<td>' + obj.committeerole + '</td>';
        str += '<td><img onclick="javascript:fnDeleteCoordinators(this);" src="../assets/image/Icon/delete.png" style="width:24px;height:24px;" /></td>';
        str += '</tr>';
        $("#tbdSelectCoordinatorList").append(str);
        $('#ddlSelectCoordinator').val(0);
        $('#ddlSelectRole').val(0);
        
    }
    else {
        $('#btnadd').removeAttr("data-dismiss");
        return false;
    }
}
function fnDeleteCoordinators(cntrl) {
    debugger
    //deleteDematDetailElement = $(event.currentTarget).closest('tr');
    $(cntrl).closest('tr').remove();
}
/************************************* */

function fnCloseModal() {
    fnClearForm();
}


function fnClearForm() {
    $('#txtCommitteeid').val('');
    //$('#txtName').val('');
    $('#txtCommitteeName').val('');
    $('#txtCommitteeAbbr').val('');
    $('#txtMembers').val('');
    $('#txtIndependentDir').val('');
    $('#txtWomenDir').val('');
    $('#txtAddSuperAdmin').val('');
    $('#emailAddSuperAdmin').val('');
    $('#ddlCoordinator').val(0);
    $('#ddlSelectCoordinator').val(0);
    $('#ddlSequence').val(0);
   
    fnRemoveClass(null, 'CommitteeName');
    fnRemoveClass(null, 'CommitteeABRR');
    fnRemoveClass(null, 'Members');
    fnRemoveClass(null, 'IndependentDirector');
    fnRemoveClass(null, 'WomenDirector');
    fnRemoveClass(null, 'CommitteeSuperAdmin');
    fnRemoveClass(null, 'Coordinator');
    fnRemoveClass(null, 'SelectCoordinator');
    fnRemoveClass(null, 'Sequence');
    $('#tbdCoordinatorList').html('');
    $('#tbdSelectCoordinatorList').html('');
}
function fnSaveCommittee() {
    debugger
    var st = fnValidate();
    if (!st) {
        return false;
    }

    $("#Loader").show();
    $("#EditCommittee").modal('hide');

    var CommitteeMemberlist = [];
    for (var i = 0; i < $("#tbdCoordinatorList").children().length; i++) {
        var O = new Object();
        var txtuserid = $("input[id*='emailAddSuperAdmin']").val();

        O.userLogin = $($($("#tbdCoordinatorList").children()[i]).children()[0]).text();
        O.userName = $($($("#tbdCoordinatorList").children()[i]).children()[1]).text();
        O.Sequence = $($($("#tbdCoordinatorList").children()[i]).children()[3]).text();;
        if (O.userLogin == txtuserid) {
            alert("This is already Committee Chairman, you cannot select this user '" + O.userName + "' in Select Committee Member(s)");
            return false;
            // checkmsg = "A";
        }
        else {
            CommitteeMemberlist.push(O);
            //UseridList.push($(UserID).text());
        }
    }

    var membersColl = [];
    for (var i = 0; i < CommitteeMemberlist.length; i++) {
        var selectedValue = CommitteeMemberlist[i];

        //membersColl.push(new CommitteeMember(selectedValue, "Members"));
        //adminColl[adminColl.length] = new CommitteeMember(UseridList[i], "Members");
       // membersColl[membersColl.length] = new CommitteeMember(CommitteeMemberlist[i], "Members");
        //membersColl.push(new CommitteeMember(CommitteeMember[i].UserID, CommitteeMember[i].Sequence, "Members"));
        var committeeMember = new CommitteeMember(selectedValue.userLogin, selectedValue.Sequence, "Member","0");

        membersColl.push(committeeMember);
    }

    membersColl.push(new CommitteeMember($("input[id*='emailAddSuperAdmin']").val(),"0", "Chairman","0"));

    if (CommitteeMemberlist.length == 0) {
        alert("Please select atleast one Meeting Member");
        return false;
    }

    var CoordinatoridList = [];
    for (var i = 0; i < $("#tbdSelectCoordinatorList").children().length; i++) {
        var AE = new Object();

        // AE.ID = $($($("#tbdSelectCoordinatorList").children()[i]).children()[0]).text();
        AE.userLogin = $($($("#tbdSelectCoordinatorList").children()[i]).children()[1]).text();;
        //AE.userName = $($($("#tbdSelectCoordinatorList").children()[i]).children()[2]).text();;
        AE.CommitteeRoleId = $($($("#tbdSelectCoordinatorList").children()[i]).children()[3]).text();;
        // AE.committeerole = $($($("#tbdSelectCoordinatorList").children()[i]).children()[4]).text();;
        CoordinatoridList.push(AE);
    }

    for (var i = 0; i < CoordinatoridList.length; i++) {
        var selectedValue1 = CoordinatoridList[i];
        var committeeMember = new CommitteeMember(selectedValue1.userLogin, "0", "", selectedValue1.CommitteeRoleId);

        membersColl.push(committeeMember);
        //adminColl[adminColl.length] = new CommitteeMember(UseridList[i], "Members");
        //membersColl.push(new CommitteeMember(CoordinatoridList[0].UserLogin, CoordinatoridList[0].Id));
    }

    if (CoordinatoridList.length == 0) {
        alert("Please select atleast one Meeting Coordinator");
        return false;
    }

    var commiteeColl = [
        new Committee(
            $("input[id*='txteditID']").val(),
            $("input[id*='txtCommitteeName']").val(),
            $("input[id*='txtCommitteeAbbr']").val(),
            $("input[id*='txtMembers']").val(),
            $("input[id*='txtIndependentDir']").val(),
            $("input[id*='txtWomenDir']").val(),
            membersColl
            //CoordinatoridList
        )
    ];


    var webUrl = uri + "/api/Committee/SaveCommittee";

    $.ajax({
        type: 'POST',
        url: webUrl,
        data: JSON.stringify(commiteeColl),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    })
        .done(function (msg) {
            $("#Loader").hide();
            if (!msg.StatusFl) {
                if (msg.Msg == "SessionExpired") {
                    alert("Your session is expired. Please login again to continue");
                    window.location.href = "../Login.aspx";
                } else {
                    alert(msg.Msg);
                }
            }
            else {
                $("#committee_add").modal('hide');
                alert(msg.Msg);
                fnListCommittee();
            }
        })
        .fail(function (error) {
            $("#Loader").hide();
            alert(error.status + ' ' + error.statusText);
        });
}


function CommitteeMember(UserLogin, Sequence, CommitteeDesignationName, CommitteeRoleId )
{
    //this.ID = ID;
    this.UserLogin = UserLogin;
    this.Sequence = Sequence;
    this.CommitteeDesignationName = CommitteeDesignationName;
    this.CommitteeRoleId = CommitteeRoleId;
 

}

function Committee(ID, name, abrr, NoOfMembers, NoOfIndependentDirector, NoOfWomenDirector, usercoll) {
    if (ID == "") {
        this.ID = 0;
    }
    else {
        this.ID = ID;
    }
    this.ID = ID;
    this.committeeName = name;
    this.committeeABRR = abrr;
    this.NoOfMembers = NoOfMembers;
    this.NoOfIndependentDirector = NoOfIndependentDirector;
    this.NoOfWomenDirector = NoOfWomenDirector;
    this.committeeMembers = usercoll;
}
function fnValidate() {
    var obj = "";

    var CommitteeName = $("input[id*='txtCommitteeName']").val();
    var CommitteeAbbr = $("input[id*='txtCommitteeAbbr']").val();
    var txtMembers = $("input[id*='txtMembers']").val();
    var txtIndependentDir = $("input[id*='txtIndependentDir']").val();
    var txtWomenDir = $("input[id*='txtWomenDir']").val();
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

    if (txtMembers == "" || txtMembers == null || txtMembers == '0') {
        $('#lblMembers').addClass('text-danger');
        obj = "false";
    }
    else {
        $('#lblMembers').removeClass('text-danger');
        obj = "";
    }
    if (txtIndependentDir == "" || txtIndependentDir == null || txtIndependentDir == '0') {
        $('#lblIndependentDir').addClass('text-danger');
        obj = "false";
    }
    else {
        $('#lblIndependentDir').removeClass('text-danger');
        obj = "";
    }
    if (txtWomenDir == "" || txtWomenDir == null || txtWomenDir == '0') {
        $('#lblWomenDir').addClass('text-danger');
        obj = "false";
    }
    else {
        $('#lblWomenDir').removeClass('text-danger');
        obj = "";
    }


    if (txtAddSuperAdmin == "" || txtAddSuperAdmin == null || txtAddSuperAdmin == '0') {
        $('#lblChairman').addClass('text-danger');
        obj = "false";
    }
    else {
        $('#lblChairman').removeClass('text-danger');
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
            arrCommitteeUserList = new Array();
            arrCommitteeUserList = msg.CommitteeList;
            if (msg.StatusFl) {
                for (var i = 0; i < msg.CommitteeList.length; i++) {
                    var seq = i + 1;
                    result += '<tr id="tr_' + msg.CommitteeList[i].ID + '">';
                    result += '<td style="text-align:center;">' + seq + '</td>';
                    result += '<td>' + msg.CommitteeList[i].committeeName + '</td>';
                    result += '<td>' + msg.CommitteeList[i].committeeABRR + '</td>';
                    result += '<td style="text-align:center;">' + msg.CommitteeList[i].NoOfMembers + ', (<span style="color: red;">' + msg.CommitteeList[i].NoOfcommitteeMembers + '</span>)' + '</td>';
                    result += '<td style="text-align:center;">' + msg.CommitteeList[i].NoOfIndependentDirector + ', (<span style="color: red;">' + msg.CommitteeList[i].CntIndependentDirector + '</span>)' + '</td>';
                    result += '<td style="text-align:center;">' + msg.CommitteeList[i].NoOfWomenDirector + ', (<span style="color: red;">' + msg.CommitteeList[i].CntWomenDirector + '</span>)' + '</td>';
                    result += '<td id="tdEdit_' + msg.CommitteeList[i].ID + '"><a data-target="#committee_add" data-toggle="modal" id="a_' + msg.CommitteeList[i].ID + '" title="Edit" class="btn btn-light-primary px-3 font-weight-bold" onclick=\"javascript:EditCommittee(\'' + msg.CommitteeList[i].ID + '\',\'' + msg.CommitteeList[i].committeeName + '\',\'' + msg.CommitteeList[i].committeeABRR + '\',\'' + msg.CommitteeList[i].NoOfMembers + '\',\'' + msg.CommitteeList[i].NoOfIndependentDirector + '\',\'' + msg.CommitteeList[i].NoOfWomenDirector + '\');\"><i class="fas fa-pencil-alt"></i></a>' + '<a data-target="#deleteCommittee" data-toggle="modal" id="a_' + msg.CommitteeList[i].ID + '" title="Delete" class="btn btn-light-danger px-3 font-weight-bold" onclick=\"javascript:Conferm_Delete(' + msg.CommitteeList[i].ID + ');\"><i class="fas fa-trash-alt"></i></a>' + '<a data-target="#committee_history" data-toggle="modal" id="a_' + msg.CommitteeList[i].ID + '" title="History" class="btn btn-info px-3 ml-2" onclick="javascript:HistoryCommittee(\''+ msg.CommitteeList[i].ID + '\');">'+ '<i class="fas fa-history"></i></a>';
                   
                    //result += '<td id="tdEdit_' + msg.CommitteeList[i].ID + '">';
                    //if (msg.CommitteeList[i].isDelete == 0) {
                    //    result += '<a  id="a_' + msg.CommitteeList[i].ID + '" class="btn btn-light-primary px-3 font-weight-bold" onclick=\"javascript:EditCommittee(' + msg.CommitteeList[i].ID + ');\">Edit</a>';
                    //    result += '&nbsp;&nbsp;';
                    //    result += '<a  id="a_' + msg.CommitteeList[i].ID + '" class="btn btn-light-primary px-3 font-weight-bold" onclick=\"javascript:Conferm_Delete(' + msg.CommitteeList[i].ID + ');\">Delete</a>';
                    //}
                    //else {
                    //    result += '<a  id="a_' + msg.CommitteeList[i].ID + '" class="btn btn-light-primary px-3 font-weight-bold" onclick=\"javascript:EditCommittee(' + msg.CommitteeList[i].ID + ');\">Edit</a>';
                    //}
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

function EditCommittee(ID, committeeName, committeeABRR, NoOfMembers, NoOfIndependentDirector, NoOfWomenDirector) {
    debugger
    $('#tbdCoordinatorList').html('');
    $('#tbdSelectCoordinatorList').html('');
    GetUserListForCommittee();
    $("#Coordinator").show();
    $("#Select_Coordinator").show();
    $('#txteditID').val(ID);
    $('#txtCommitteeName').val(committeeName);
    $('#txtCommitteeAbbr').val(committeeABRR);
    $('#txtMembers').val(NoOfMembers);
    $('#txtIndependentDir').val(NoOfIndependentDirector);
    $('#txtWomenDir').val(NoOfWomenDirector);
    $('#txtCommitteeid').prop('disabled', true);
    //$('#txtUserid').prop('disabled', true);
  /*  $("#committee_add").modal('show');*/

    /************Add By Jitender *****************/
    var AMembertbl = new Array();
    for (var x = 0; x < arrCommitteeUserList.length; x++) {
        //alert("arrUpsiType[" + x + "].TypeId=" + arrUpsiType[x].TypeId);
        if (ID == arrCommitteeUserList[x].ID) {
            for (var i = 0; i < arrCommitteeUserList[x].committeeMembers.length; i++) {
                var obj = new Object();
                obj.UserLogin = arrCommitteeUserList[x].committeeMembers[i].UserLogin;
                obj.UserNm = arrCommitteeUserList[x].committeeMembers[i].UserNm;
                obj.UserEmail = arrCommitteeUserList[x].committeeMembers[i].UserEmail;
                obj.Sequence = arrCommitteeUserList[x].committeeMembers[i].Sequence;
                obj.CommitteeRoleId = arrCommitteeUserList[x].committeeMembers[i].CommitteeRoleId;
                obj.CommitteeDesignationName = arrCommitteeUserList[x].committeeMembers[i].CommitteeDesignationName;
                AMembertbl.push(obj);
            }
            break;
        }
    }
    if (AMembertbl.length > 0) {
        for (var x = 0; x < AMembertbl.length; x++) {
            if (AMembertbl[x].CommitteeDesignationName == 'Chairman') {
                $("input[id*='emailAddSuperAdmin']").val(AMembertbl[x].UserLogin);
                $('#txtAddSuperAdmin').val(AMembertbl[x].UserNm);
            }
            else if (AMembertbl[x].CommitteeDesignationName == 'Member') {
                var str = ''; // Initialize str here
                    str += '<tr>';
                    str += '<td style="display:none;">' + AMembertbl[x].UserLogin + '</td>';
                    str += '<td>' + AMembertbl[x].UserNm + '</td>';
                    str += '<td>' + AMembertbl[x].UserEmail + '</td>';
                    str += '<td>' + AMembertbl[x].Sequence + '</td>';
                    str += '<td style="display:none;">' + AMembertbl[x].CommitteeRoleId + '</td>';
                    str += '<td style="display:none;">' + AMembertbl[x].CommitteeDesignationName + '</td>';
                str += '<td><img onclick="javascript:fnDeleteCoordinator(this);" src="../assets/image/Icon/delete.png" style="width:24px;height:24px;" /></td>';
                    str += '</tr>';
                $("#tbdCoordinatorList").append(str);
            }
            else if (AMembertbl[x].CommitteeDesignationName == 'Maker') {
                var str1 = ''; // Initialize str here
                str1 += '<tr>';
                str1 += '<td style="display:none;">' + AMembertbl[x].ID + '</td>';
                str1 += '<td style="display:none;">' + AMembertbl[x].UserLogin + '</td>';
                str1 += '<td>' + AMembertbl[x].UserNm + '</td>';
                str1 += '<td style="display:none;">' + AMembertbl[x].CommitteeRoleId + '</td>';
                str1 += '<td>' + AMembertbl[x].CommitteeDesignationName + '</td>';
                str1 += '<td style="display:none;">' + AMembertbl[x].UserEmail + '</td>';
                str1 += '<td style="display:none;">' + AMembertbl[x].Sequence + '</td>';
                str1 += '<td><img onclick="javascript:fnDeleteCoordinators(this);" src="../assets/image/Icon/delete.png" style="width:24px;height:24px;" /></td>';
                str1 += '</tr>';
                $("#tbdSelectCoordinatorList").append(str1);
            }
            else if (AMembertbl[x].CommitteeDesignationName == 'Checker') {
                var str1 = ''; // Initialize str here
                str1 += '<tr>';
                str1 += '<td style="display:none;">' + AMembertbl[x].ID + '</td>';
                str1 += '<td style="display:none;">' + AMembertbl[x].UserLogin + '</td>';
                str1 += '<td>' + AMembertbl[x].UserNm + '</td>';
                str1 += '<td style="display:none;">' + AMembertbl[x].CommitteeRoleId + '</td>';
                str1 += '<td>' + AMembertbl[x].CommitteeDesignationName + '</td>';
                str1 += '<td style="display:none;">' + AMembertbl[x].UserEmail + '</td>';
                str1 += '<td style="display:none;">' + AMembertbl[x].Sequence + '</td>';
                str1 += '<td><img onclick="javascript:fnDeleteCoordinators(this);" src="../assets/image/Icon/delete.png" style="width:24px;height:24px;" /></td>';
                str1 += '</tr>';
                $("#tbdSelectCoordinatorList").append(str1);
            }
        }
    }
    else (arrCommitteeUserList.committeeMembers == null)
    {
        //$("#tbdCoordinatorList").html('');
        //$("#tbdSelectCoordinatorList").html('');
        //$("#Coordinator").hide();
        //$("#SelectCoordinator").hide();
    }
}



function Conferm_Delete(id) {
    delete
    $("#txtDelID").val(id);
    $("#deleteCommittee").show();
}
function Conferm_Delete_Close(id) {

    $("#txtDelID").val('');
    $("#deleteCommittee").hide();
}
function Conferm_Edit_Close(id) {
    $("#txteditID").val('');
    $("#EditCommittee").hide();
}

function DeleteCommittee() {
    debugger
    $("#Loader").show();
    $("#deleteCommittee").hide();
    var webUrl = uri + "/api/Committee/DeleteCommittee"; //"api/CompositionHandler.ashx?caller=DeleteCommitteeComposition";
    setTimeout(function () {
        $.ajax({
            type: "POST",
            url: webUrl,
            data: JSON.stringify({
                ID: $("input[id*='txtDelID']").val()
            }),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: false,
            success: function (msg) {
                $("#Loader").hide();
                if (msg.StatusFl) {
                    alert(msg.Msg);
                    fnListCommittee();
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

function CancleCommittee() {
    $('#tbody').html("");
    //var strTable = setCommitteeComposition();
    $('#tbody').append(strTable);
}

function setCommittee() {
    debugger
    rows = $('#adduser_for_comp tbody tr').length;
    var strTable = '<tr id="row_' + rows + '">';
    strTable += '<td>';
    strTable += '<input id="txtName' + rows + '" type="text" class = "form-control ui-autocomplete-input txtAddOthers" autocomplete="off"/>';
    strTable += '<input id="txtID' + rows + '" type="text" class = "form-control txtEmail" style="display:none;">';
    strTable += '</td>';
    strTable += '<td>';
    strTable += '<select id="ddlUser' + rows + '" class="form-control">';
    strTable += '<option value=""></option>';
    for (var i = 0; i < committeeMembers.length; i++) {
        strTable += '<option value="' + CommitteeRoleId + '">' + CommitteeDesignationName + '</option>';
    }
    strTable += '</select>';
    strTable += '<input id="txtText' + rows + '" type="text" style="display:none;" class="form-control" />';
    strTable += '</td>';
    strTable += '<td><button type="button" class="btn blue btn-outline adddesignation">Add</button>';
    strTable += '<input type="text" class="form-control txtId" style="display:none;" value="" /></td>';
    if (rows != '0') {
        strTable += '<td><button type="button" class="btn red btn-outline removeadddesignation">Remove</button></td>';
    }
    strTable += '</tr>';
    $('#trIngredientsId').val('0')
    return strTable;
}

function HistoryCommittee(id) {
    debugger
    $("#EditCommittee").hide();
    $('#tbody').html("");
    $('#tbody_prev').html("");
    $("#Loader").show();
    var webUrl = uri + "/api/Committee/HistoryCommittee"; //"api/CompositionHandler.ashx?caller=HistoryCommitteeComposition";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({
            ID: id
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            if (msg.StatusFl) {
                var sr = "";
                $('#tbody_prev').html('');
                sr += '<option value="' + msg.Committee.ID + '" selected>' + msg.Committee.committeeName + '</option>';
                $("#ddlCommittee_his").html(sr);
               // var prev_version = msg.Committee.committeeMembers[0].Operation;
           
                //for (var i = 0; i < msg.Committee.committeeMembers.length; i++) {
                //    if (msg.Committee.committeeMembers[i].Operation == 'Insert') {
                //        var strTable = "";
                //        rows = $('#adduser_for_comp tbody tr').length;
                //       /* if (prev_version == msg.Committee.committeeMembers[i].Operation) {*/
                //            strTable += '<tr scope="row" id="row_' + rows + '">';
                //            strTable += '<th><b>Action: </b>' + msg.Committee.committeeMembers[i].Operation + '</th>';
                //            strTable += '<th><b>Modified By: </b>' + msg.Committee.committeeMembers[i].modifiedBy + '</th>';
                //            strTable += '<th><b>Created On: </b>' + msg.Committee.committeeMembers[i].createdon + '</th>';
                //            strTable += '<th><b>Modified Date: </b>'+ '</th>';
                //           // strTable += '<th><b>Modified Date: </b>' + msg.Committee.committeeMembers[i].committeeModifiedDate + '</th>';
                //            //strTable += '<th><b>Remarks: </b>' + msg.Committee.committeeMembers[i].remarks + '</th>';
                //            strTable += "</tr>";
                //           /* strTable += '<tr><th colspan="3"><b>Committee Modified Date: </b>' + msg.Committee.committeeMembers[i].committeeModifiedDate + '</th></tr>';*/
                //            // strTable += '<tr><th colspan="3"><b>Remarks: </b>' + msg.Committee.committeeMembers[i].remarks + '</th></tr>';
                //           // prev_version = prev_version - 1;
                //       /* }*/
                //        strTable += '<tr id="row_' + rows + '">';
                //        strTable += '<td>' + msg.Committee.committeeMembers[i].Sequence + '</td>';
                //        strTable += '<td>' + msg.Committee.committeeMembers[i].UserNm + ' (' + msg.Committee.committeeMembers[i].UserEmail + ')' + ' </td>';
                //        strTable += "<td>" + msg.Committee.committeeMembers[i].CommitteeDesignationName + "";
                //        strTable += "<td>" + msg.Committee.committeeMembers[i].committeeModifiedDate + "";
                //        //strTable += "<td colspan='2'><input type='text' class='form-control txtId' style='display:none;' value='' /></td>";
                //        strTable += "<input type='text' class='form-control txtId' style='display:none;' value='' /></td>";
                //        strTable += "</tr>";
                //        $('#tbody_prev').append(strTable);
                //    }
                //    else if (msg.Committee.committeeMembers[i].Operation == 'Delete') {
                //        var strTable = "";
                //        rows = $('#adduser_for_comp tbody tr').length;
                //        //if (prev_version == msg.Committee.committeeMembers[i].Operation) {
                //            strTable += '<tr scope="row" id="row_' + rows + '">';
                //            strTable += '<th><b>Action: </b>' + msg.Committee.committeeMembers[i].Operation + '</th>';
                //            strTable += '<th><b>Modified By: </b>' + msg.Committee.committeeMembers[i].modifiedBy + '</th>';
                //        strTable += '<th><b>Created On: </b>' + msg.Committee.committeeMembers[i].createdon + '</th>';
                //        strTable += '<th><b>Modified Date: </b>' + '</th>';
                //            //strTable += '<th><b>Modified Date: </b>' + msg.Committee.committeeMembers[i].committeeModifiedDate + '</th>';
                //            //strTable += '<th><b>Remarks: </b>' + msg.Committee.committeeMembers[i].remarks + '</th>';
                //            strTable += "</tr>";
                //            /*strTable += '<tr><th colspan="3"><b>Committee Modified Date: </b>' + msg.Committee.committeeMembers[i].committeeModifiedDate + '</th></tr>';*/
                //            // strTable += '<tr><th colspan="3"><b>Remarks: </b>' + msg.Committee.committeeMembers[i].remarks + '</th></tr>';
                //            //prev_version = prev_version - 1;
                //       /* }*/
                //        strTable += '<tr id="row_' + rows + '">';
                //        strTable += '<td>' + msg.Committee.committeeMembers[i].Sequence + '</td>';
                //        strTable += '<td>' + msg.Committee.committeeMembers[i].UserNm + ' (' + msg.Committee.committeeMembers[i].UserEmail + ')' + ' </td>';
                //        strTable += "<td>" + msg.Committee.committeeMembers[i].CommitteeDesignationName + "";
                //        strTable += "<td>" + msg.Committee.committeeMembers[i].committeeModifiedDate + "";
                //        //strTable += "<td colspan='2'><input type='text' class='form-control txtId' style='display:none;' value='' /></td>";
                //        strTable += "<input type='text' class='form-control txtId' style='display:none;' value='' /></td>";
                //        strTable += "</tr>";
                //        $('#tbody_prev').append(strTable);
                //    }
                //    }

                for (var i = 0; i < msg.Committee.committeeMembers.length; i++) {
                    var strTable = "";
                    var operation = msg.Committee.committeeMembers[i].Operation;

                    rows = $('#adduser_for_comp tbody tr').length;

                    strTable += '<tr scope="row" id="row_' + rows + '">';
                    strTable += '<th><b>Action: </b>' + operation + '</th>';
                    strTable += '<th><b>Modified By: </b>' + msg.Committee.committeeMembers[i].modifiedBy + '</th>';
                    strTable += '<th><b>Created On: </b>' + msg.Committee.committeeMembers[i].createdon + '</th>';
                    strTable += '<th><b>Modified Date: </b></th>';
                    strTable += "</tr>";

                    strTable += '<tr id="row_' + rows + '">';
                    strTable += '<td>' + msg.Committee.committeeMembers[i].Sequence + '</td>';
                    strTable += '<td>' + msg.Committee.committeeMembers[i].UserNm + ' (' + msg.Committee.committeeMembers[i].UserEmail + ')' + ' </td>';
                    strTable += "<td>" + msg.Committee.committeeMembers[i].CommitteeDesignationName + "</td>";
                    strTable += "<td>" + msg.Committee.committeeMembers[i].committeeModifiedDate + "</td>";
                    strTable += "<input type='text' class='form-control txtId' style='display:none;' value='' />";
                    strTable += "</tr>";

                    if (operation === 'Insert' || operation === 'Delete') {
                        $('#tbody_prev').append(strTable);
                    }
                }

                       

              
                rows = $('#adduser_for_comp tbody tr').length;
                if (rows == 0) {
                    var st = setCommittee();
                   // $('#tbody').append(st);
                    //fnGetUserforComposition();
                    GetCommitteeCoordinatorList();
                }
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
    $("#committee_history").modal('show');
}

//function HistoryCommittee(id) {
//    debugger
//    $("#EditCommittee").hide();
//    $('#tbody').html("");
//    $('#tbody_prev').html("");
//    $("#Loader").show();
//    var webUrl = uri + "/api/Committee/HistoryCommittee"; //"api/CompositionHandler.ashx?caller=HistoryCommitteeComposition";
//    $.ajax({
//        type: "POST",
//        url: webUrl,
//        data: JSON.stringify({
//            ID: id
//        }),
//        contentType: "application/json; charset=utf-8",
//        datatype: "json",
//        async: false,
//        success: function (msg) {
//            $("#Loader").hide();
//            if (msg.StatusFl) {
//                var sr = "";
//                $('#tbody_prev').html('');
//                sr += '<option value="' + msg.Committee.ID + '" selected>' + msg.Committee.committeeName + '</option>';
//                $("#ddlCommittee_his").html(sr);
//                var prev_version = msg.Committee.committeeMembers[0].Operation;
//                for (var i = 0; i < msg.Committee.committeeMembers.length; i++) {
//                    var strTable = "";
//                    rows = $('#adduser_for_comp tbody tr').length;
//                    if (prev_version == msg.Committee.committeeMembers[i].Operation) {
//                        strTable += '<tr scope="row" id="row_' + rows + '">';
//                        strTable += '<th><b>Action: </b>' + msg.Committee.committeeMembers[i].Operation + '</th>';
//                        strTable += '<th><b>Modified By: </b>' + msg.Committee.committeeMembers[i].modifiedBy + '</th>';
//                        strTable += '<th><b>Created On: </b>' + msg.Committee.committeeMembers[i].createdon + '</th>';
//                        //strTable += '<th><b>Modified Date: </b>' + msg.Committee.committeeMembers[i].committeeModifiedDate + '</th>';
//                        //strTable += '<th><b>Remarks: </b>' + msg.Committee.committeeMembers[i].remarks + '</th>';
//                        strTable += "</tr>";
//                        strTable += '<tr><th colspan="3"><b>Committee Modified Date: </b>' + msg.Committee.committeeMembers[i].committeeModifiedDate + '</th></tr>';
//                       // strTable += '<tr><th colspan="3"><b>Remarks: </b>' + msg.Committee.committeeMembers[i].remarks + '</th></tr>';
//                        prev_version = prev_version - 1;
//                    }
//                    strTable += '<tr id="row_' + rows + '">';
//                    strTable += '<td>' + msg.Committee.committeeMembers[i].Sequence + '</td>';
//                    strTable += '<td>' + msg.Committee.committeeMembers[i].UserNm + ' (' + msg.Committee.committeeMembers[i].UserEmail + ')' + ' </td>';
//                    strTable += "<td>" + msg.Committee.committeeMembers[i].CommitteeDesignationName + "";
//                    //strTable += "<td colspan='2'><input type='text' class='form-control txtId' style='display:none;' value='' /></td>";
//                    strTable += "<input type='text' class='form-control txtId' style='display:none;' value='' /></td>";
//                    strTable += "</tr>";
//                    $('#tbody_prev').append(strTable);
//                }
//                rows = $('#adduser_for_comp tbody tr').length;
//                if (rows == 0) {
//                    var st = setCommittee();
//                    $('#tbody').append(st);
//                    //fnGetUserforComposition();
//                    GetCommitteeCoordinatorList();
//                }
//            }
//            else {
//                if (msg.Msg == "SessionExpired") {
//                    alert("Your session is expired. Please login again to continue");
//                    window.location.href = "../Login.aspx";
//                }
//                else {
//                    alert(msg.Msg);
//                }
//                return false;
//            }
//        },
//        error: function (response) {
//            $("#Loader").hide();
//            alert(response.status + ' ' + response.statusText);
//        }
//    });
//    $("#committee_history").modal('show');
//}