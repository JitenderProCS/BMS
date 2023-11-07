<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BMS_New.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BMS || Change Password</title>
    <link href="../assets/global/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
       <style>
    .change-password-container {
        max-width: 400px;
        margin: 90px auto;
        padding: 20px;
        border: 4px solid #ccc;
        background-color: white;
        text-align: center;
    }

    .form-group {
        margin: 10px 0;
    }

    label {
        font-weight: bold;
        color:#060606;
    }

    .form-control {
        width: 100%;
        padding: 5px;
        border: 1px solid #ccc;
    }

    .btn {
        background-color: #007bff;
        color: #fff;
        padding: 10px 20px;
        border: none;
        cursor: pointer;
    }

    .btn:hover {
        background-color: #0056b3;
    }
</style>
    <style type="text/css">
        .requied {
            color: red;
        }
    </style>
     
</head>
<body style="background:#BDBDBD;">
   <form id="form1" runat="server">
    <div class="change-password-container">
    <h2 style="color: #578ebe;">Change Password</h2>
    <div class="form-group">
         <label id="lblLoginId" class="col-xl-3 col-lg-3 col-form-label">Login Id <sup class="text-danger">*</sup></label>
          <input id="txtLoginId" style="height: 22px; width: 272px;" runat="server" type="text" class="form-control" placeholder="Enter your Login Id" onkeypress="javascript:fnRemoveClass(this,'LoginId');" autocomplete="off" />
    </div>
    <div class="form-group">
         <label id="lblOldPassword" class="col-xl-3 col-lg-3 col-form-label">Password <sup class="text-danger">*</sup></label>
         <input id="txtOldPassword" runat="server" style="height: 22px; width: 272px;" type="password" class="form-control" placeholder="Enter your current password" onkeypress="javascript:fnRemoveClass(this,'OldPassword');" autocomplete="off" />
    </div>
        <br />
    <div class="form-group">
         <label id="lblNewPassword" class="col-xl-3 col-lg-3 col-form-label">New Password <sup class="text-danger">*</sup></label>
         <input id="txtNewPassword" runat="server" style="height: 22px; width: 275px;" type="password" class="form-control" placeholder="Enter your new password" onkeypress="javascript:fnRemoveClass(this,'NewPassword');" autocomplete="off" />
    </div>
        <div class="form-group">
        <label id="lblConfirmNewPassword" class="col-xl-3 col-lg-3 col-form-label">Confirm New Password <sup class="text-danger">*</sup></label>
        <input id="txtConfirmNewPassword" runat="server" style="height: 22px; width: 272px;" type="password" class="form-control" placeholder="Confirm your new password" onkeypress="javascript:fnRemoveClass(this,'ConfirmNewPassword');" autocomplete="off" />
    </div>
        
        <asp:Button runat="server" OnClick="GoToLogin" class="btn btn-primary" OnClientClick="return true;" Text="Back To Login" />
         <asp:Button runat="server" OnClick="SaveChangedPassword" class="btn btn-primary" OnClientClick="return fnValidateForm();" Text="Save Changes" />
         <br />
        <br />
         <br />
        <br />
         <br />
        <%--<asp:Button ID="btnBck" runat="server" OnClientClick="return fnLogin();" class="btn btn-primary" Text="Login" />--%>
   <%-- <button class="btn btn-primary">Change Password</button>--%>
</div>
 </form>
     <script src="js/Global.js?<%=DateTime.Now%>"></script>
    <script src="../assets/global/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/intl-tel-input@18.2.1/build/js/intlTelInput.min.js"></script>
    <script src="js/ChangePassword.js"></script>
</body>
</html>
