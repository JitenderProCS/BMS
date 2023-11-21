<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BMS_New.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BMS || Change Password</title>
    <link href="assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/custom/prismjs/prismjs.bundle.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.bundle.css" rel="stylesheet" type="text/css" />
       <style type="text/css">
    .change-password-container {
        max-width: 582px;
        margin: 90px auto;
        padding: 10px;
        border: 4px solid #ccc;
        background-color: #dfe0e1;
        text-align: left;
    }

    .form-group {
        margin: 10px 0;
    }

    label {
        font-weight: bold;
       /* color:#060606;*/
    }
    .requied {
            color: red;
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
  <%--  <style type="text/css">
        .requied {
            color: red;
        }
    </style>--%>

     
</head>
<body style="background:#9496a1;">
   <form id="form1" runat="server">
    <div class="change-password-container">
    <h2 style="color: #578ebe;text-align: center;">Change Password</h2>
    <div class="form-group">
         <label id="lblLoginId"   class="col-xl-3 col-lg-3 col-form-label">Login Id <sup class="text-danger">*</sup></label>
       <div class="col-xl-12 col-lg-12">
          <input id="txtLoginId" disabled="disabled" runat="server" type="text" class="form-control" placeholder="Enter your Login Id" onkeypress="javascript:fnRemoveClass(this,'LoginId');" autocomplete="off" />
            </div>
    </div>
    <div class="form-group">
         <label id="lblOldPassword" class="col-xl-3 col-lg-3 col-form-label">Old Password <sup class="text-danger">*</sup></label>
       <div class="col-xl-12 col-lg-12">
         <input id="txtOldPassword" runat="server"  type="password" class="form-control" placeholder="Enter your Old Password" onkeypress="javascript:fnRemoveClass(this,'OldPassword');" autocomplete="off" />
            </div>
    </div>
    <div class="form-group">
         <label id="lblNewPassword" class="col-xl-3 col-lg-3 col-form-label">New Password <sup class="text-danger">*</sup></label>
        <div class="col-xl-12 col-lg-12">
         <input id="txtNewPassword" runat="server"  type="password" class="form-control" placeholder="Enter your new password" onkeypress="javascript:fnRemoveClass(this,'NewPassword');" autocomplete="off" />
            </div>
    </div>
        <div class="form-group">
        <label id="lblConfirmNewPassword" class="col-xl-3 col-lg-3 col-form-label">Confirm Password <sup class="text-danger">*</sup></label>
            <div class="col-xl-12 col-lg-12">
        <input id="txtConfirmNewPassword" runat="server" type="password" class="form-control" placeholder="Confirm your new password" onkeypress="javascript:fnRemoveClass(this,'ConfirmNewPassword');" autocomplete="off" />
                </div>
    </div>
        <div class="form-group">
            <div class="col-xl-9 col-lg-9">
        <asp:Button runat="server" OnClick="GoToLogin" class="btn btn-primary" OnClientClick="return true;" Text="Back To Login" />
         <asp:Button runat="server" OnClick="SaveChangedPassword" class="btn btn-primary" OnClientClick="return fnValidateForm();" Text="Save Changes" />
                </div>
            </div>
         <br />
        <br />
        <%--<asp:Button ID="btnBck" runat="server" OnClientClick="return fnLogin();" class="btn btn-primary" Text="Login" />--%>
   <%-- <button class="btn btn-primary">Change Password</button>--%>
</div>
 </form>
    <script src="assets/plugins/global/plugins.bundle.js"></script>
    <script src="assets/plugins/custom/prismjs/prismjs.bundle.js"></script>
    <script src="assets/js/scripts.bundle.js"></script>
     <script src="js/Global.js?<%=DateTime.Now%>"></script>
    <script src="../assets/global/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <script src="js/ChangePassword.js"></script>
</body>
</html>
