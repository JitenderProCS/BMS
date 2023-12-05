var objDesignation = [];

$(document).ready(function () {

    window.history.forward();
    function preventBack() { window.history.forward(1); }

    fnGetDesignationList();
    $('#exampleModalSizeLg').on('hide.bs.modal', function () {
        $('#txtDesignationName').val('');
    });
});

function initializeDataTable() {
    debugger;
    $('#tbl-Designation-setup').DataTable({
        //  "dom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>',
        dom: 'Bfrtip',
        pageLength: 10,
        buttons: [
                {
                    extend: 'pdf',
                    className: 'btn green btn-outline',
                    exportOptions: {
                        columns: [0,1,2]
                    }
                },
                {
                    extend: 'excel',
                    className: 'btn yellow btn-outline ',
                    exportOptions: {
                        columns: [0,1,2]
                    }
                },
            //    { extend: 'colvis', className: 'btn dark btn-outline', text: 'Columns' }
        ]
    });
}

function fnGetDesignationList() {
    debugger
    $("#Loader").show();
    var webUrl = uri + "/api/Designation/GetDesignationList"; //"api/DesignationHandler.ashx?caller=GetDesignationList";
    $.ajax({
        type: "POST",
        url: webUrl,
        data: JSON.stringify({
            COMPANY_ID: 0
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (msg) {
            $("#Loader").hide();
            if (msg.StatusFl) {
                var result = "";
                for (var i = 0; i < msg.DesignationList.length; i++) {
                    objDesignation.push(msg.DesignationList[i]);
                    result += '<tr id="tr_' + msg.DesignationList[i].ID + '">';
                    result += '<td id="tdDesignation_Name_' + msg.DesignationList[i].ID + '">' + msg.DesignationList[i].designationName + '</td>';
                    result += '<td id="tdEdit_' + msg.DesignationList[i].ID + '"><a data-target="#exampleModalSizeLg" data-toggle="modal" id="a_' + msg.DesignationList[i].ID + '" class="btn btn-outline dark" onclick=\"javascript:fnEditDesignation(' + i + ');\">Edit</a></td>';
                    result += '<td id="tdDelete_' + msg.DesignationList[i].ID + '"><a style="margin-left:20px" data-target="#delete" data-toggle="modal" id="d_' + msg.DesignationList[i].ID + '" class="btn btn-outline dark" onclick=\"javascript:DeleteDesignation1(' + msg.DesignationList[i].ID + ');\">Delete</a></td>';
                    result += '</tr>';
                }
                var table = $('#tbl-Designation-setup').DataTable();
                table.destroy();
                $("#tbdDesignationList").html(result);
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
}

function fnSaveDesignation() {
    if (fnValidate()) {
        fnAddUpdateDesignation();
    }
    else {
        $('#btnSave').removeAttr("data-dismiss");
        return false;
    }
}

function fnAddUpdateDesignation() {
    debugger
    $("#Loader").show();

    var DesignationColl = [];
    DesignationColl[DesignationColl.length] = new Designation($("input[id*='txtDesignationId']").val() == 0 ? 0 : $("input[id*='txtDesignationId']").val(), $("input[id*='txtDesignationName']").val());

    var webUrl = uri + "/api/Designation/SaveDesignation"; //"api/DesignationHandler.ashx?caller=SaveDesignation";
    setTimeout(function () {
        $.ajax({
            type: 'POST',
            url: webUrl,
            data: JSON.stringify(DesignationColl),
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
                    else {
                        alert(msg.Msg);
                        $("#btnSave").removeAttr("data-dismiss");
                    }
                    return false;
                }
                else {
                    alert(msg.Msg);
                    objDesignation.push(msg.Designation);
                    if (msg.Designation.ID == $("input[id*='txtDesignationId']").val()) {
                        $("#tdDesignation_Name_" + msg.Designation.ID).html(msg.Designation.designationName);
                        $("#a_" + msg.Designation.ID).attr("onclick", "javascript:fnEditDesignation('" + (parseInt(objDesignation.length) - 1) + "');");
                        $("#a_" + msg.Designation.ID).attr("data-target", "#exampleModalSizeLg");
                        $("#a_" + msg.Designation.ID).attr("data-toggle", "modal");
                        $("#d_" + msg.Designation.ID).attr("onclick", "javascript:DeleteDesignation1('" + msg.Designation.ID + "');");
                        $("#d_" + msg.Designation.ID).css({ 'margin-left': '20px' });
                        $("#d_" + msg.Designation.ID).attr("data-target", "#delete");
                        $("#d_" + msg.Designation.ID).attr("data-target", "#modal");
                        var table = $('#tbl-Designation-setup').DataTable();
                        table.destroy();
                        initializeDataTable();
                    }
                    else {
                        var result = "";
                        result += '<tr id="tr_' + msg.Designation.ID + '">';
                        result += '<td id="tdDesignation_Name_' + msg.Designation.ID + '">' + msg.Designation.designationName + '</td>';
                        result += '<td id="tdEdit_' + msg.Designation.ID + '"><a data-target="#exampleModalSizeLg" data-toggle="modal" id="a_' + msg.Designation.ID + '" class="btn btn-outline dark" onclick=\"javascript:fnEditDesignation(' + (parseInt(objDesignation.length) - 1) + ');\">Edit</a></td>';
                        result += '<td id="tdDelete_' + msg.Designation.ID + '"><a style="margin-left:20px" data-target="#delete" data-toggle="modal" id="d_' + msg.Designation.ID + '" class="btn btn-outline dark" onclick=\"javascript:DeleteDesignation1(' + msg.Designation.ID + ');\">Delete</a></td>';
                        result += '</tr>';
                        var table = $('#tbl-Designation-setup').DataTable();
                        table.destroy();
                        $("#tbdDesignationList").append(result);
                        initializeDataTable();
                    }
                    fnClearForm();
                    return true;
                }
            },
            error: function (error) {
                $("#Loader").hide();
                alert(error.status + ' ' + error.statusText);
            }
        })
    }, 10);
}

function fnEditDesignation(index) {
    $("span[id*='spnDesignation']").html("Edit Designation");
    $('#txtDesignationName').val(objDesignation[index].designationName);
    $('#txtDesignationId').val(objDesignation[index].ID);
}

function fnCloseModal() {
    fnClearForm();
}

function fnClearForm() {
    $('#txtDesignationName').val('');
    $('#txtDesignationId').val(0);
}

function fnValidate() {
    var Designation = $('#txtDesignationName').val();
    if (Designation == '' || Designation == null || Designation == '0') {
        $('#lblDesignation').addClass('requied');
        return false;
    }
    else {
        $('#lblDesignation').removeClass('requied');
    }
    return true;
}

function fnOpenNew() {
    $("span[id*='spnDesignation']").html("New Designation");
}

function DeleteDesignation1(ID) {
    $('input[id*=txtDelID]').val(ID);
    $("#deleteProduct").modal(); {
    }
}

function DeleteDesignation() {
    $("#Loader").show();

    var DesignationColl = [];
    DesignationColl[DesignationColl.length] = new Designation($('input[id*=txtDelID]').val(), "");

    var webUrl = uri + "/api/Designation/DeleteDesignation"; //"api/DesignationHandler.ashx?caller=DeleteDesignation";
    setTimeout(function () {
        $.ajax({
            type: 'POST',
            url: webUrl,
            data: JSON.stringify(DesignationColl),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: false,
            success: function (msg) {
                $("#Loader").hide();
                if (msg.StatusFl) {
                    alert(msg.Msg);
                    var table = $('#tbl-Designation-setup').DataTable();
                    table.destroy();
                    $("#tr_" + msg.Designation.ID).remove();
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

function Designation(ID, designationName) {
    this.ID = ID;
    this.designationName = designationName;
}

function fnRemoveClass(obj, val) {
    $("#lbl" + val + "").removeClass('requied');
}
