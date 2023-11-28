function preventBack() { window.history.forward(); }
setTimeout("preventBack()", 0);
window.onunload = function () { null };
function fnLogin() {
    debugger
    //alert("In function fnLogin");
    var _salt = $("#txtSalt").val();
    var _msalt = $("#txtMSalt").val();

    //alert("_salt=" + _salt);
    //alert("_msalt=" + _msalt);

    var _loginid = $("#txtLoginId").val();
    var _pwd = $("#txtPwd").val();

    //alert("_loginid=" + _loginid);
    //alert("_pwd=" + _pwd);

    if (_loginid == null || _loginid == "") {
        alert("Please enter LoginId");
        return false;
    }
    if (_pwd == null || _pwd == "") {
        alert("Please enter Password");
        return false;
    }

    var hash = hex_sha512(hex_sha512(hex_sha512(_pwd) + _salt) + _salt);
    var fff = hex_sha512(hash + _msalt);
    /*$("#txtPwd").val(fff);*/

    $("#txtPwd").val();
    return true;
}

function openModal() {
    $('#stack1').modal({ show: true });
}

function unValidCredential(Msg) {
    //alert(Email);
   // alert(Msg);
    //alert($('#UserName').val());
    //alert($('#Password').val());
    // alert(Password);
    alert("User name or Password is incorrect. Please try again!");
}

function GoToDashBoard(companyId, CompanyNm, CompanyLogo, ModuleId, ModuleNm, ModuleFolder, ModuleDataBase, EmployeeId, Mobile) {
    var webUrl = uri + "/api/UserCompanyModuleSelection/SetSession";
    $.ajax({
        type: "POST",
        url: webUrl,
        //data: JSON.stringify({
        //    CompanyId: companyId, CompanyNm: CompanyNm, ModuleId: ModuleId, ModuleNm: ModuleNm, ModuleFolder: ModuleFolder, ModuleDataBase: ModuleDataBase, EmployeeId: EmployeeId, Mobile: Mobile
        //}),
        data: JSON.stringify({
            CompanyId: companyId, CompanyNm: CompanyNm, CompanyLogo: CompanyLogo, ModuleId: ModuleId, ModuleNm: ModuleNm, ModuleFolder: ModuleFolder,EmployeeId: EmployeeId, Mobile: Mobile
        }),
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: true,
        success: function (res) {
            //    window.location.href = window.location.protocol + "//" + window.location.host + "/" + res + "/" + "DesignationMaster.aspx";
            window.location.href = res + "/" + "Dashboard.aspx";
            //window.location.href = "../Dashboard.aspx";
        },
        error: function (error) {
            alert(error);
        }
    })
}

/********Switch Company Dashboard***********/
function SwitchDashBoard(selectedValue) {
    debugger;
    const selectedValues = selectedValue.split(',');
    const data = [];
    var rowData = {
        companyId: selectedValues[0],
        CompanyName: selectedValues[1],
        logo: selectedValues[2],
        moduleId: selectedValues[3],
        moduleName: selectedValues[4],
        modulefolder: selectedValues[5],
        //ModuleDataBase: selectedValues[6],
        LOGIN_ID: selectedValues[7],
        Mobile: selectedValues[8]
    };

    data.push(rowData);
    //const data = {
    //    selectedValue: selectedValue
    //};
    var webUrl = uri + "/api/UserCompanyModuleSelection/SetSessionDashBoard";
    $.ajax({
        type: "POST",
        url: webUrl,
       // data: [],
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // Corrected "datatype" to "dataType"
        //async: true,
        async: false,
        success: function (res) {
            debugger;
            // Handle the response or redirect to another page
            //window.location.href = res + "/" + "Dashboard.aspx";
            window.location.href = "Dashboard.aspx"; // Modify the URL as needed
        },
        error: function (error) {
            alert(error);
        }
    });
}

/*************End***************************/