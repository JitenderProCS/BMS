var objDepartment = [];

$(document).ready(function () {
    window.history.forward();
    function preventBack() { window.history.forward(1); }

    fnGetDepartmentList();
    //$('#stack1').on('hide.bs.modal', function () {
    //    $('#txtDepartmentName').val("");
    //});
});

function initializeDataTable() {
    $('#tbl-Department-setup').DataTable({
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

function fnGetDepartmentList() {
    $("#Loader").show();
    var webUrl = uri + "/api/Department/GetDepartmentList";
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
                for (var i = 0; i < msg.DepartmentList.length; i++) {
                    objDepartment.push(msg.DepartmentList[i]);
                    result += '<tr id="tr_' + msg.DepartmentList[i].departmentId + '">';
                    result += '<td id="tdDepartmentHead_' + msg.DepartmentList[i].departmentId + '">' + msg.DepartmentList[i].departmentHead + '</td>';
                    result += '<td id="tdDepartmentName_' + msg.DepartmentList[i].departmentId + '">' + msg.DepartmentList[i].departmentName + '</td>';
                    result += '<td id="tdEdit_' + msg.DepartmentList[i].departmentId + '"><a data-target="#exampleModalSizeLg" data-toggle="modal" id="a_' + msg.DepartmentList[i].departmentId + '" class="btn btn-outline dark" onclick=\"javascript:fnEditDepartment(' + i + ');\">Edit</a></td>';
                    result += '<td id="tdDelete_' + msg.DepartmentList[i].departmentId + '"><a style="margin-left:20px" data-target="#delete" data-toggle="modal" id="d_' + msg.DepartmentList[i].departmentId + '" class="btn btn-outline dark" onclick=\"javascript:fnShowDeleteAlert(' + msg.DepartmentList[i].departmentId + ');\">Delete</a></td>';
                    result += '</tr>';
                }
                var table = $('#tbl-Department-setup').DataTable();
                table.destroy();
                $("#tbdDepartmentList").html(result);
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

function fnValidateDepartment() {
    var isValid = true;

    var DepartmentHead = $("input[id*='txtDepartmentHead']").val();
    if (DepartmentHead == '' || DepartmentHead == null || DepartmentHead == '0') {
        $('#lblDepartmentHead').addClass('requied');
        isValid = false;
    }
    else {
        $('#lblDepartmentHead').removeClass('requied');
        isValid = true;
    }

    var Department = $("input[id*='txtDepartmentName']").val();
    if (Department == '' || Department == null || Department == '0') {
        $('#lblDepartment').addClass('requied');
        isValid = false;
    }
    else {
        $('#lblDepartment').removeClass('requied');
        isValid = true;
    }

    return isValid;
}

function fnValidateAndSaveDepartment() {
    if (fnValidateDepartment()) {
        $("#modalConfirmationAddAlert").modal('show');
        $("#stack1").modal('show');
        //return false;
    }
    else {
        $('#btnValidateDepartment').removeAttr("data-dismiss");
        return false;
    }
}

function fnAddUpdateDepartment() {
    debugger
    $("#Loader").show();
    var Department = new Object();
    Department.departmentId = $("input[id*='txtDepartmentId']").val() == 0 ? 0 : $("input[id*='txtDepartmentId']").val();
    Department.departmentName = $("input[id*='txtDepartmentName']").val();
    Department.departmentHead = $("input[id*='txtDepartmentHead']").val();

    var webUrl = uri + "/api/Department/SaveDepartment";
    setTimeout(function () {
        $.ajax({
            type: 'POST',
            url: webUrl,
            data: JSON.stringify(Department),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: false,
            success: function (msg) {
                $("#Loader").hide();
                if (msg.StatusFl) {
                    alert(msg.Msg);
                    fnClearForm();
                    window.location.reload();
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
            error: function (error) {
                $("#Loader").hide();
                alert(error.status + ' ' + error.statusText);
            }
        })
    }, 10);
}

function fnEditDepartment(index) {
    debugger
    $("span[id*='spnDepartment']").html("Edit Department");
    $('#txtDepartmentName').val(objDepartment[index].departmentName);
    $('#txtDepartmentHead').val(objDepartment[index].departmentHead);
    $('#txtDepartmentId').val(objDepartment[index].departmentId);
}

function fnCloseModal() {
    fnClearForm();
}

function fnClearForm() {
    $('#txtDepartmentName').val('');
    $('#txtDepartmentHead').val('');
    $('#txtDepartmentId').val(0);
}

function fnOpenNew() {
    $("span[id*='spnDepartment']").html("New Department");
}

function fnShowDeleteAlert(ID) {
    $('input[id*=txtDepartmentId]').val(ID);
    $("#modalConfirmationDeleteAlert").modal('show');
}

function fnDeleteDepartment() {
    $("#Loader").show();
    var Department = new Object();
    Department.departmentId = $('input[id*=txtDepartmentId]').val();

    var webUrl = uri + "/api/Department/DeleteDepartment";
    setTimeout(function () {
        $.ajax({
            type: 'POST',
            url: webUrl,
            data: JSON.stringify(Department),
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: false,
            success: function (msg) {
                $("#Loader").hide();
                if (msg.StatusFl) {
                    alert(msg.Msg);
                    window.location.reload();
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