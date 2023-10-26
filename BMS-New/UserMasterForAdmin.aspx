<%@ Page Title="" Language="C#" MasterPageFile="~/BMSMaster.Master" AutoEventWireup="true" CodeBehind="UserMasterForAdmin.aspx.cs" Inherits="BMS_New.UserMasterForAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/intl-tel-input@18.2.1/build/css/intlTelInput.css">

    <%--<link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>
    <style type="text/css">
        .requied {
            color: red;
        }

        .iti {
            width: 100%;
        }

        @media (min-width: 992px) {
            .header-fixed.subheader-fixed .subheader {
                height: 76px;
            }
        }

        .dataTable,
        .dataTables_scrollHeadInner,
        .dataTables_scrollBody {
            width: 99% !important;
        }

        .dataTables_filter {
            margin-right: 9px !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <!--begin::Subheader-->
    <div class="subheader py-2 py-lg-5 subheader-solid" id="kt_subheader">
        <div class="container-fluid ">
            <!--begin::Info-->
            <div class="col-12">
                <div class="d-flex align-items-center flex-wrap mr-1">
                    <!--begin::Page Heading-->
                    <div class="d-flex align-items-baseline flex-wrap mr-5">
                        <!--begin::Page Title-->
                        <h5 class="text-dark font-weight-bold my-1 mr-5">Admin User's Profile Details</h5>
                        <!--end::Page Title-->
                    </div>
                    <!--end::Page Heading-->
                </div>
            </div>
            <div class="col-12">
                <div class="row align-items-center">
                    <div class="col-lg-9 col-xl-8">
                        <div class="row align-items-center">
                            <div class="col-auto my-2 my-md-0">
                                <!--begin::Button-->
                                <button type="button" data-toggle="modal" data-target="#exampleModalSizeLg" class="btn btn-primary font-weight-bolder" onclick="javascript:fnClearForm();">
                                    <span class="svg-icon svg-icon-md">
                                        <!--begin::Svg Icon | path:assets/media/svg/icons/Design/Flatten.svg-->
                                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                <rect x="0" y="0" width="24" height="24" />
                                                <circle fill="#000000" cx="9" cy="15" r="6" />
                                                <path d="M8.8012943,7.00241953 C9.83837775,5.20768121 11.7781543,4 14,4 C17.3137085,4 20,6.6862915 20,10 C20,12.2218457 18.7923188,14.1616223 16.9975805,15.1987057 C16.9991904,15.1326658 17,15.0664274 17,15 C17,10.581722 13.418278,7 9,7 C8.93357256,7 8.86733422,7.00080962 8.8012943,7.00241953 Z" fill="#000000" opacity="0.3" />
                                            </g>
                                        </svg>
                                        <!--end::Svg Icon-->
                                    </span>Add New User</button>
                            </div>
                            <%--<div class="col-md-5 my-2 my-md-0">
                                <div class="d-flex align-items-center">
                                    <label class="mr-3 mb-0 d-none d-md-block">Status:</label>
                                    <select id="ddlUserStatus" class="form-control" >
                                        <option selected="selected" value="0">Select Status</option>
                                        <option value="Active">Active</option>
                                        <option value="InActive">InActive</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-auto">
                                <button id="Button1" runat="server" class="btn btn-light-primary px-6 font-weight-bold" onclick="javascript:fnGetUserList();">
                            Search
                        </button>
                            </div>--%>
                        </div>
                    </div>

                </div>
            </div>
            <!--end::Info-->
        </div>
    </div>
    <!--end::Subheader-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <!--begin::Card-->
    <!--begin::Modal-->
    <div class="modal fade" id="exampleModalSizeLg" tabindex="-1" role="dialog" aria-labelledby="exampleModalSizeLg" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg" style="margin-left: 23%;" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Add New User</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <i aria-hidden="true" class="ki ki-close"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row justify-content-center py-8 px-8 py-lg-6 px-lg-50">
                        <div class="col-xl-12 col-xxl-12">
                            <!--begin::Wizard Form-->
                            <form class="form" id="kt_form">
                                <div class="row justify-content-center">
                                    <div class="col-xl-12">
                                        <!--begin::Wizard Step 1-->
                                        <div class="my-5 step" data-wizard-type="step-content" data-wizard-state="current">
                                            <%--<h5 class="text-dark font-weight-bold mb-10">User's Profile Details:</h5>--%>


                                            <%--<!--begin::Group-->
                                                        <div id="divSalutation" class="form-group row">
                                                            <label id="lblSalutation" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Salutation <sup class="text-danger">*</sup></label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlSalutation" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'Salutation');">
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="Mr.">Mr.</option>
                                                                    <option value="Ms.">Ms.</option>
                                                                    <option value="Mrs.">Mrs.</option>
                                                                    <option value="Dr.">Dr.</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->--%>

                                            <!--begin::Group-->
                                            <div class="form-group row">
                                                <label id="lblName" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Name <sup class="text-danger">*</sup></label>
                                                <div class="col-lg-9 col-xl-9">
                                                    <input id="txtName" placeholder="Enter name" class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="javascript:fnRemoveClass(this,'Name');" autocomplete="off" maxlength="100" />
                                                </div>
                                            </div>
                                            <!--end::Group-->

                                            <!--begin::Group-->
                                            <div class="form-group row">
                                                <label id="lblEmail" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Email <sup class="text-danger">*</sup></label>
                                                <div class="col-lg-9 col-xl-9">
                                                    <div class="input-group input-group-solid input-group-lg">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="la la-at"></i>
                                                            </span>
                                                        </div>
                                                        <input id="txtEmail" type="text" class="form-control form-control-solid form-control-lg" name="email" value="" placeholder="Email Address" onkeypress="javascript:fnRemoveClass(this,'Email');" autocomplete="on" maxlength="100" />
                                                        <%--onchange="javascript:fnFillUserDetails();"--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--end::Group-->

                                            <!--begin::Group-->
                                            <div class="form-group row">
                                                <label id="lblUserid" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label d-flex">
                                                    User Login Id <sup class="text-danger">*</sup>
                                                    <%--<button class="btn btn-primary rounded-circle d-flex justify-content-center align-items-center p-0" style="width:16px;height:16px" type="button" data-container="body" data-offset="20px 20px" data-toggle="popover" data-placement="top" data-content="Example content" >i</button>--%>
                                                </label>
                                                <div class="col-lg-9 col-xl-9">
                                                    <input id="txtUserid" placeholder="Enter log ID" class="form-control form-control-solid form-control-lg" type="text" value="" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'Userid');" />
                                                    <input id="txtUserId" class="form-control form-control-solid form-control-lg" type="text" data-tabindex="1" style="display: none" value="0" />
                                                    <input class="form-control form-control-solid form-control-lg" id="txtUserID" type="text" style="display: none;" />
                                                </div>
                                            </div>
                                            <!--end::Group-->

                                            <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblPhone" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label d-flex">Mobile No. <sup class="text-danger">*</sup>
                                                                <button class="btn btn-primary rounded-circle d-flex justify-content-center align-items-center p-0" style="width:16px;height:16px" type="button" data-container="body" data-offset="20px 20px" data-toggle="popover" data-placement="top" data-content="Type the initial letter of your number to get the Country code" >i</button> 
                                                            </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtPhone" class="form-control form-control-solid form-control-lg w-100" type="number" value="" onkeypress="javascript:fnRemoveClass(this,'Phone');" oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" maxlength="10" placeholder="Enter Phone No" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                            <!--begin::Group-->
                                            <div class="form-group row">
                                                <label id="lblAuthentication" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Authentication <sup class="text-danger">*</sup></label>
                                                <div class="col-xl-9 col-lg-9">
                                                    <select id="ddlAuthentication" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'Authentication');">
                                                        <option selected="selected" value="0">Please Select . . .</option>
                                                        <option value="Application">Application</option>
                                                        <option value="ActiveDirectory">Active Directory</option>
                                                        <option value="CloudSSO">Cloud SSO</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <!--end::Group-->
                                            <!--end::Wizard Step 1-->

                                        </div>

                                        <table class="table" id="authtable">
                                            <thead>
                                                <tr>
                                                    <th scope="col">COMPANY</th>
                                                    <th scope="col">MODULE</th>
                                                    <th scope="col">ROLE ADMIN</th>
                                                </tr>
                                            </thead>
                                            <tbody id="Auth">
                                                <tr>
                                                    <td>
                                                        <select id="ddlCompany" class="form-control form-control-lg form-control-solid col" onchange="javascript:fnRemoveClass(this,'Company');">
                                                        </select>
                                                    </td>
                                                    <td>
                                                        <select id="ddlmodule" class="form-control form-control-lg form-control-solid col" onchange="javascript:fnRemoveClass(this,'Module');">
                                                        </select>
                                                    </td>
                                                    <td>
                                                        <select id="ddlPaymentMode" class="form-control form-control-lg form-control-solid col" onchange="javascript:fnRemoveClass(this,'Mode');">
                                                            <option selected="selected" value="0">Select </option>
                                                            <option value="Yes">Yes </option>
                                                            <option value="No">No </option>

                                                        </select>
                                                    </td>

                                                    <td>
                                                         <button id="btnadd" class="btn btn-primary " onclick=" javascript:fnAddAccessDetail();" type="button">Add</button></td>
                                                       <%-- <button class="btn btn-primary " onclick="addNewRow()" type="button">Add</button></td>--%>
                                                </tr>
                                            </tbody>
                                        </table>
                                         <div class="form-group row">
                                             <%--   <a class="btn btn-default" data-toggle="modal" data-target="#modalAddDematDetail">
                                                    <i class="fa fa-plus"></i>Add
                                                </a>
                                                <br />
                                                <br />--%>
                                                <table class="table" style="width: 700px;">
                                                    <thead class="text-uppercase">
                                                        <tr>
                                                            <th style="display: none;"> ID</th>
                                                            <th>COMPANY</th>
                                                            <th>MODULE</th>
                                                            <th>ROLE ADMIN</th>
                                                            <th>ACTION</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="tbdAccessList">
                                                    </tbody>
                                                </table>
                                            </div>
                                        <div class="d-flex justify-content-between border-top pt-10 mt-15">

                                            <div class="mr-2" style="float: right;">
                                                <button id="btnSave" type="button" data-dismiss="modal" class="btn btn-success font-weight-bolder px-9 py-4" data-wizard-type="action-submit" onclick="javascript:fnSaveUser();">Submit</button>
                                                <button id="btnCancel" type="button" class="btn btn-success font-weight-bolder px-9 py-4" data-dismiss="modal" data-wizard-type="action-close" onclick="javascript:fnCloseModal();">Close</button>
                                            </div>
                                        </div>

                                        <!--end::Wizard Actions-->
                                    </div>
                                </div>
                            </form>
                            <!--end::Wizard Form-->
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!--end::Modal-->
    <div class="card card-custom">
        <div class="modal fade in" id="deleteProduct" tabindex="-1" role="dialog" aria-hidden="True">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="True"></button>
                        <h4 class="modal-title"><b>Are you sure, you want to delete ?</b></h4>
                    </div>
                    <div class="modal-footer">
                        <input id="txtDelID" type="hidden" value="0" />
                        <button type="button" class="btn dark btn-outline" data-dismiss="modal">NO</button>
                        <input value="YES" id="btnDeleteConfirm" data-dismiss="modal" class="btn red" onclick="DeleteUser()" type="submit" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--<script>
        const gettableid = document.getElementById("authtable").getElementsByTagName('tbody')[0];
        function addNewRow() {
            gettableid.innerHTML += `<tr><td><select id="ddlCompany" class="form-control form-control-lg form-control-solid col" onchange="javascript:fnRemoveClass(this,'Company');"> +
                                                                        
                                              </select> 
      </td>
      <td>
          <select id="ddlmodule" class="form-control form-control-lg form-control-solid col" onchange="javascript:fnRemoveClass(this,'Module');">
                                                                        
           </select> 
      </td>
      <td><select id="ddlPaymentMode" class="form-control form-control-lg form-control-solid col">
                                                                        <option selected="selected" value="0">Select </option>
                                                                          <option value="Yes">Yes </option>
                                                                          <option value="No">No </option>

                                                                    </select> </td>
    <td><button class="btn btn-primary" onclick="addNewRow()" type="button">Add</button></td><td><button class="btn btn-danger" onclick="removeRow(event)" type="button">Remove</button></td>
            </tr>`
        }

        function removeRow(event) {
            const getparentid = event.target.parentNode.parentNode.rowIndex
            gettableid.deleteRow(Number(getparentid) - 1);
        }

    </script>--%>
    <!--end::Card-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="portlet light bordered">
        <div class="portlet-body">
            <div class="form-body">
                <table class="table table-striped table-hover table-bordered" id="tbl-User-setup">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Name </th>
                            <th>Email</th>
                            <th>User Login</th>
                            <th>Authentication</th>
                        </tr>
                    </thead>
                    <tbody id="tbdUserList">
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js" type="text/javascript"></script>
    <link href="../assets/global/css/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../assets/global/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/intl-tel-input@18.2.1/build/js/intlTelInput.min.js"></script>

    <script src="js/Global.js"></script>
    <script src="js/UserAdmin.js"></script>

    <script>
            const input = document.querySelector("#txtPhone");
            window.intlTelInput(input, {
                initialCountry: "auto",
                geoIpLookup: callback => {
                    fetch("https://ipapi.co/json")
                        .then(res => res.json())
                        .then(data => callback(data.country_code))
                        .catch(() => callback("us"));
                },
                utilsScript: "/intl-tel-input/js/utils.js?1690975972744" // just for formatting/placeholders etc
            });
    </script>
</asp:Content>
