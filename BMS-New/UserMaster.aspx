<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BMSMaster.Master" CodeBehind="UserMaster.aspx.cs" Inherits="BMS_New.UserMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/intl-tel-input@18.2.1/build/css/intlTelInput.css">
    
    <%--Bootstrap For UI --%>
    <%--<link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>

    <link rel="stylesheet" href="https://cdn.datatables.net/1.13.6/css/jquery.dataTables.css" />
    <link href="https://cdn.datatables.net/1.13.6/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.4.1/css/buttons.dataTables.min.css" rel="stylesheet" />
    
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

        .collapse1[aria-expanded='true'] .plus {
            display: none
        }

        .collapse1[aria-expanded='false'] .minus {
            display: none
        }

        .dataTable,
        .dataTables_scrollHeadInner,
        .dataTables_scrollBody {
            width: 100% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
    <!--begin::Subheader-->
    <div class="subheader py-2 py-lg-5 subheader-solid" id="kt_subheader">
        <div class="container-fluid ">
            <!--begin::Info-->
           <div class="col-12">
                <div class="d-flex align-items-center flex-wrap mr-1">
                <!--begin::Page Heading-->
                <div class="d-flex align-items-baseline flex-wrap mr-5">
                    <!--begin::Page Title-->
                    <h5 class="text-dark font-weight-bold my-1 mr-5">User's Profile Details</h5>
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
                            <div class="col-md-5 my-2 my-md-0">
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
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
            <!--end::Info-->
        </div>
    </div>
    <!--end::Subheader-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <!--begin::Card-->
     <!--begin::Modal-->
                <div class="modal fade" id="exampleModalSizeLg" tabindex="-1" role="dialog" aria-labelledby="exampleModalSizeLg" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered modal-lg" style="margin-left:23%;" role="document">
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


                                                        <!--begin::Group-->
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
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblName" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Name <sup class="text-danger">*</sup></label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                    <div class="input-group-prepend">
															         <input id="txtFirstName" class="form-control form-control-solid form-control-lg" type="text" value="" onkeypress="return blockSpecialChar(event)"  placeholder="First Name . ." autocomplete="off" /> <%--onkeypress="javascript:fnRemoveClass(this,'FirstName');"--%>
															        </div>
                                                                        </div>
                                                                    <div class="col-4">
																        <input id="txtMiddleName" class="form-control form-control-solid form-control-lg" type="text" value="" onkeypress="return blockSpecialChar(event)"   placeholder="Middle Name . ." autocomplete="off" /><%-- onkeypress="javascript:fnRemoveClass(this,'MiddleName');"--%>
														        </div>
                                                                    <div class="col-4">
                                                                    <div class="input-group-prepend">
															        <input id="txtLastName" class="form-control form-control-solid form-control-lg" type="text" value="" onkeypress="return blockSpecialChar(event)"  placeholder="Last Name . ." autocomplete="off" /> <%--onkeypress="javascript:fnRemoveClass(this,'LastName');"--%>

															        </div>
                                                                  </div>
                                                                    </div>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <%--<!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblName" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Name <sup class="text-danger">*</sup></label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtName" placeholder="Enter name" class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="javascript:fnRemoveClass(this,'Name');" autocomplete="off" maxlength="100" />
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->--%>

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblDateofbirth" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Date Of Birth </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtDateofbirth" data-required="1" class="form-control form-control-solid form-control-lg" size="16" type="date" onkeypress="return blockSpecialChar(event)" value="" autocomplete="off" />
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
                                                                    <input id="txtEmail" type="text" class="form-control form-control-solid form-control-lg" name="email" value="" placeholder="Email Address" onkeypress="javascript:fnRemoveClass(this,'Email');" autocomplete="on" maxlength="100" /> <%--onchange="javascript:fnFillUserDetails();"--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblPhone" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Phone(WhatsApp Preffered) <sup class="text-danger">*</sup>
                                                                <button class="btn btn-primary rounded-circle d-flex justify-content-center align-items-center p-0" style="width:16px;height:16px" type="button" data-container="body" data-offset="20px 20px" data-toggle="popover" data-placement="top" data-content="Type the initial letter of your number to get the Country code" >i</button> 
                                                            </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtPhone" class="form-control form-control-solid form-control-lg w-100" type="number" value="" onkeypress="return blockSpecialChar(event)"  oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" maxlength="10" placeholder="Enter Phone No" autocomplete="off" /> <%--onkeypress="javascript:fnRemoveClass(this,'Phone');"--%>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblAddress" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Address</label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <textarea id="txtAddress" placeholder="Address" class="form-control form-control-solid form-control-lg" rows="3" maxlength="200"> </textarea>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblNationality" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Nationality</label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlNationality" class="form-control form-control-lg form-control-solid" name="language">
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="Resident">Resident</option>
                                                                    <option value="ForegnierNational">Foregnier National</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblUserid" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label d-flex">User Login Id <sup class="text-danger">*</sup>
                                                                <button class="btn btn-primary rounded-circle d-flex justify-content-center align-items-center p-0" style="width:16px;height:16px" type="button" data-container="body" data-offset="20px 20px" data-toggle="popover" data-placement="top" data-content="Example content" >i</button>
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
                                                            <label id="lblPassword" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label d-flex">Password <sup class="text-danger">*</sup>
                                                                <button class="btn btn-primary rounded-circle d-flex justify-content-center align-items-center p-0" style="width:16px;height:16px" type="button" data-container="body" data-offset="20px 20px" data-toggle="popover" data-placement="top" data-content="Password should be Minimum length 8 characters, Minimum one alphabet Upper Case character(A-Z), Minimum one alphabet Lower Case character(a-z), Minimum one digit (0-9), Minimum one special character eg.[ !,@,#,$,%,^,&,*,(,),\,-,+,. ]" >i</button>
                                                            </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtPassword" class="form-control form-control-solid form-control-lg" type="password" value="" placeholder="Password" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'Password');" />
                                                                <span class="form-text text-danger">Password should be Minimum length 8 characters, Minimum one alphabet Upper Case character(A-Z), Minimum one alphabet Lower Case character(a-z), Minimum one digit (0-9), Minimum one special character eg.[ !,@,#,$,%,^,&,*,(,),\,-,+,. ] </span>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblConfirm" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Confirm Password <sup class="text-danger">*</sup></label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtConfirm" class="form-control form-control-solid form-control-lg" type="password" value="" placeholder="Confirm Password" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'Confirm');" />

                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblRole" style="text-align: left" class="col-form-label col-xl-3 col-lg-3 d-flex">Role <sup class="text-danger">*</sup> 
                                                              <button class="btn btn-primary rounded-circle d-flex justify-content-center align-items-center p-0" style="width:16px;height:16px" type="button" data-container="body" data-offset="20px 20px" data-toggle="popover" data-placement="top" data-content="Admin - Have full control of application including Publish right. Secretarial user - Limited Control of Application (No Publish right), Directors- Board of Directors, Promoters - Promoters & Promoter Group, Invitee - Invited in Board or Committee Meeting for any specific purpose (Have acess to only relevant items), HOD - Head of Departments" >i</button> 
                                                            </label>
                                                            
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlRole" class="form-control form-control-lg form-control-solid col" onchange="getdiv(this); fnRemoveClass(this,'Role');">
                                                               </select>
                                                              <%--  <select id="ddlRole" class="form-control form-control-lg form-control-solid" onchange="getdiv(this); fnRemoveClass(this,'Role');" name="language">
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="Admin">Admin</option>
                                                                    <option value="Director">Director</option>
                                                                    <option value="Invitee">Meeting Co-Ordinator</option>
                                                                </select>--%>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <br id="brDepartment" />
                                                        <div id="divDepartment" class="form-group row">
                                                            <label id="lblDepartment" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Department <sup class="text-danger">*</sup></label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlDepartment" class="form-control form-control-lg form-control-solid" <%--onchange="javascript:fnRemoveClass(this,'Department');"--%>>
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="Accounts">Accounts</option>
                                                                    <option value="Audit">Audit</option>
                                                                    <option value="Finance">Finance</option>
                                                                    <option value="Implementation">Implementation</option>
                                                                    <option value="Not Applicable">Not Applicable</option>
                                                                    <option value="Sales">Sales</option>
                                                                    <option value="Secretarial">Secretarial</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->
                                                        <!--begin::Group-->
                                                        <br id="brDesignation" />
                                                        <div id="divDesignation" class="form-group row">
                                                            <label id="lblDesignation" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Designation <sup class="text-danger">*</sup></label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlDesignation" class="form-control form-control-lg form-control-solid" <%--onchange="javascript:fnRemoveClass(this,'Designation');"--%>>
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="Additional Director">Additional Director</option>
                                                                    <option value="Admin">Admin</option>
                                                                    <option value="CEO">CEO</option>
                                                                    <option value="CFO">CFO</option>
                                                                    <option value="Chairman , Non-Executive - Independent Director">Chairman , Non-Executive - Independent Director</option>
                                                                    <option value="Chairperson">Chairperson</option>
                                                                    <option value="Chief Operating Officer">Chief Operating Officer</option>
                                                                    <option value="Company Secretary">Company Secretary</option>
                                                                    <option value="Director">Director</option>
                                                                    <option value="Director (Commercial)">Director (Commercial)</option>
                                                                    <option value="Director (Finance)">Director (Finance)</option>
                                                                    <option value="Govt. Nominee Director">Govt. Nominee Director</option>
                                                                    <option value="HOD">HOD</option>
                                                                    <option value="Independent Director">Independent Director</option>
                                                                    <option value="Independent Non-Executive Chairman">Independent Non-Executive Chairman</option>
                                                                    <option value="Independent Non-Executive Director">Independent Non-Executive Director</option>
                                                                    <option value="Investor Nominee Director">Investor Nominee Director</option>
                                                                    <option value="Invitee">Invitee</option>
                                                                    <option value="Joint. Managing Director">Joint. Managing Director</option>
                                                                    <option value="Managing Director">Managing Director</option>
                                                                    <option value="Managing Director and CEO">Managing Director and CEO</option>
                                                                    <option value="MD and CEO">MD and CEO</option>
                                                                    <option value="Member">Member</option>
                                                                    <option value="Nominee Director">Nominee Director</option>
                                                                    <option value="Non Independent - Non Executive Director">Non Independent - Non Executive Director</option>
                                                                    <option value="Non-Executive & Non-Independent Director">Non-Executive & Non-Independent Director</option>
                                                                    <option value="Secretarial">Secretarial</option>
                                                                    <option value="Secretarial User">Secretarial User</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <br id="brCategory" />
                                                        <div id="divCategory" class="form-group row">
                                                            <label id="lblCategory" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Category <sup class="text-danger">*</sup></label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlCategory" class="form-control form-control-lg form-control-solid" <%--onchange="javascript:fnRemoveClass(this,'Category');"--%>>
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="Chairman">Chairman</option>
                                                                    <option value="Executive Director">Executive Director</option>
                                                                    <option value="Independent Director">Independent Director</option>
                                                                    <option value="Managing Director">Managing Director</option>
                                                                    <option value="Non-Executive Independent Director">Non-Executive Independent Director</option>
                                                                    <option value="Non-Executive Non- Independent Director">Non-Executive Non- Independent Director</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <%--DirectorProfile Case--%>
                                                        <!--begin::Group-->
                                                        <div id="directorprofile" style="display: none">
                                                            <div class="form-group row">
                                                                <label id="lblPAN" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Pan No<sup class="text-danger">*</sup></label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <div class="input-group">
                                                                        <input id="txtPAN" class="form-control text-uppercase" placeholder="Enter Pan No" maxlength="10" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'PAN');" />
                                                                        <span class="input-group-addon" style="background-color: #343a41; color: white;">
                                                                            <input class="coupon_question" type="checkbox" name="coupon_question" value="Not Provide" onchange="valueChanged()" />
                                                                            <labelstyle="color: white;">Click here If PAN is Not available </labelstyle>
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="remark" class="form-group row" style="display: none">
                                                                <label id="lblPANRemark" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Remark(For Not Providing DIN)<sup class="text-danger">*</sup></label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <textarea id="txtPANRemark" class="form-control form-control-solid form-control-lg" placeholder="Enter Your Remark" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'PANRemark');"></textarea>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label id="lblDIN" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">DIN<sup class="text-danger">*</sup></label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <div class="input-group">
                                                                        <input id="txtDIN" type="number" class="form-control text-uppercase" maxlength="8" placeholder="Enter DIN" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'DIN');" />
                                                                        <span class="input-group-addon" style="background-color: #343a41; color: white;">
                                                                            <input class="coupon_questiondin" type="checkbox" name="coupon_question" value="Not Provide" onchange="valueChangeddin()" />
                                                                            <label style="color: white;">Click here If DIN is Not available </label>
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="dinremark" class="form-group row" style="display: none">
                                                                <label id="lblDINRemark" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Remark(For Not Providing DIN)<sup class="text-danger">*</sup></label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <textarea id="txtDINRemark" class="form-control form-control-solid form-control-lg" placeholder="Enter Your Remark" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'DINRemark');"></textarea>
                                                                </div>
                                                            </div>
                                                            
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div id="RoleAdmin" style="display: none">
                                                        <div class="form-group row">
                                                            <label id="lblMembershipnumber" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Membership number of Secretarial User </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtMembershipnumber" placeholder="Enter Membership number" class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="javascript:fnRemoveClass(this,'Membershipnumber');" autocomplete="off" maxlength="100" />
                                                            </div>
                                                        </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblTenurestartdate" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Tenure Start Date <sup class="text-danger">*</sup></label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtTenurestartdate" class="form-control form-control-solid form-control-lg" size="16" type="date" onkeypress="return blockSpecialChar(event)" value="" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblTenureenddate" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Tenure End Date </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtTenureenddate" class="form-control form-control-solid form-control-lg" size="16" type="date" onkeypress="return blockSpecialChar(event)" value="" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblProfile" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Profile </label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <textarea id="txtProfile" placeholder="Profile" class="form-control form-control-solid form-control-lg" rows="3" maxlength="4000"> </textarea>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->




                                                        <!--begin::Group-->
                                                        <div id="uploadfile" class="form-group row">
                                                            <%--<div class="fileinput fileinput-new" data-provides="fileinput">--%>
                                                            <label id="lblUpload1" style="text-align: left" class="col-form-label col-xl-3 col-lg-3 ">Upload Picture</label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <input id="fileUploadImage" class="form-control form-control-solid form-control-lg" type="file" name="..." onchange="javascript:fnRemoveClass(this,'Upload');" />
                                                                <a style="display: none" id="aUserAvatarImageUploaded" href="#" target="_blank">
                                                                    <img id="imgavatar" src="#" style="width: 70px; height: 70px;" />
                                                                </a>
                                                                <span class="form-text text-muted">Please Select Only (Png, Jpg, Jpeg, Gif) Files </span>
                                                            </div>
                                                            <%--</div>--%>
                                                        </div>
                                                        <%--<div id="uploadfile" class="form-group row">
                                                            <label id="lblUpload1" class="col-xl-3 col-lg-3 col-form-label text-left" data-provides="fileinput">Upload File <sup class="text-danger">*</sup></label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <div class="image-input image-input-outline" id="kt_user_add_avatar">
                                                                    <div class="image-input-wrapper" style="background-image: url(assets/media/users/100_6.jpg)"></div>
                                                                    <label class="btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow" data-action="change" data-toggle="tooltip" title="" data-original-title="Change avatar">
                                                                        <i class="fa fa-pen icon-sm text-muted"></i>
                                                                        <input type="file" name="profile_avatar" accept=".png, .jpg, .jpeg" />
                                                                        <input type="hidden" name="profile_avatar_remove" />
                                                                    </label>
                                                                    <span class="btn btn-xs btn-icon btn-circle btn-white btn-hover-text-primary btn-shadow" data-action="cancel" data-toggle="tooltip" title="Cancel avatar">
                                                                        <i class="ki ki-bold-close icon-xs text-muted"></i>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblStatus" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Status <sup class="text-danger">*</sup></label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlStatus" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'Status');">
                                                                    <option selected="selected" value="0">Please Select . . .</option>
                                                                    <option value="Active">Active</option>
                                                                    <option value="InActive">InActive</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->
                                                        <!--end::Wizard Step 1-->
                                                        <%--Collapse Start From Here--%>
                                                        <button id="collapseDetail" class="btn text-dark pl-0 collapse1 d-flex" style="text-align: left" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
                                                        <span class="plus">
                                                            <span class="btn mr-2 btn-success rounded-circle d-flex justify-content-center align-items-center p-0" style="width:20px;height:20px" type="button">+</span>
                                                        </span>
                                                         <span class="minus">
                                                            <span class="btn mr-2 btn-danger rounded-circle d-flex justify-content-center align-items-center p-0" style="width:20px;height:20px" type="button" >-</span>
                                                         </span> 
                                                         <b>Additional Details</b>
                                                        </button>
                                                        <div class="collapse" id="collapseExample">
                                                            <!--begin::Group-->
                                                            <br style="display: none;" />
                                                            <div style="display: none;" class="form-group row">
                                                                <label id="dpcat1" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Category 1 of Director</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <select id="ddlcat1" class="form-control form-control-lg form-control-solid" runat="server" data-control="select2">
                                                                        <option value="0">Please Select . . .</option>
                                                                        <option value="Executive Director">Executive Director</option>
                                                                        <option value="Non-Executive Non-Independent Director">Non-Executive Non-Independent Director</option>
                                                                        <option value="Non-Executive -Independent Director">Non-Executive -Independent Director</option>
                                                                        <option value="Non-Executive -Nominee Director">Non-Executive -Nominee Director</option>
                                                                        <option value="Executive -Nominee Director">Executive -Nominee Director</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <br style="display: none;" />
                                                            <div style="display: none;" class="form-group row">
                                                                <label id="dpcat2" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Category 2 of Director</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <select id="ddlcat2" class="form-control form-control-lg form-control-solid" runat="server">
                                                                        <option value="0">Please Select . . .</option>
                                                                        <option value="ChairPerson">ChairPerson</option>
                                                                        <option value="Not Applicable">Not Applicable</option>
                                                                        <option value="ChairPerson Related To Promotor">ChairPerson Related To Promotor</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <br style="display: none;" />
                                                            <div style="display: none;" class="form-group row">
                                                                <label id="dpcat3" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Category 3 of Director</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <select id="ddlcat3" class="form-control form-control-lg form-control-solid" runat="server">
                                                                        <option value="0">Please Select . . .</option>
                                                                        <option value="CEO">CEO</option>
                                                                        <option value="MD">MD</option>
                                                                        <option value="CEO-MD">CEO-MD</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label id="lbl17A" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Whether Special Resolution 17(1A) Of LODR Required ?</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <select id="ddl17A" class="form-control form-control-lg form-control-solid" onchange="get2nddiv()" runat="server">
                                                                        <option value="0">Please Select . . .</option>
                                                                        <option value="NO">NO</option>
                                                                        <option value="YES">YES</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div id="dateandfileupload">  <%--style="display: none"--%>
                                                                <div class="form-group row">
                                                                    <label id="lbldate" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Date Of Passing Special Resoultion</label>
                                                                    <div class="col-lg-9 col-xl-9">
                                                                        <input id="txtdate" class="form-control form-control-solid form-control-lg" size="16" type="date" onkeypress="return blockSpecialChar(event)" value="" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label id="lbldate1" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Number of Directorship in listed entities including this listed entity (Refer Regulation 17A of Listing Regulations)</label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <select id="no1" class="form-control form-control-lg form-control-solid" >
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5">5</option>
                                                                    <option value="6">6</option>
                                                                    <option value="7">7</option>
                                                                    <option value="8">8</option>
                                                                    <option value="9">9</option>
                                                                    <option value="10">10</option>
                                                                </select>
                                                                    <%--<textarea id="no1" class="form-control form-control-solid form-control-lg" rows="3" maxlength="100"> </textarea>--%>
                                                                    
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label id="lbldate2" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Number of Independent Directorship in listed entities including this listed entity (Refer Regulation 17A(1) of Listing Regulations</label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <select id="no2" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'no2');">
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5">5</option>
                                                                    <option value="6">6</option>
                                                                    <option value="7">7</option>
                                                                    <option value="8">8</option>
                                                                    <option value="9">9</option>
                                                                    <option value="10">10</option>
                                                                </select>
                                                                    <%--<textarea id="no2" class="form-control form-control-solid form-control-lg" rows="3" maxlength="100"> </textarea>--%>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label id="lbldate3" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Number of memberships in Audit/ Stakeholder Committee(s) including this listed entity (Refer Regulation 26(1) of Listing Regulations)</label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <select id="no3" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'no3');">
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5">5</option>
                                                                    <option value="6">6</option>
                                                                    <option value="7">7</option>
                                                                    <option value="8">8</option>
                                                                    <option value="9">9</option>
                                                                    <option value="10">10</option>
                                                                </select>
                                                                    <%--<textarea id="no3" class="form-control form-control-solid form-control-lg" rows="3" maxlength="100"> </textarea>--%>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label id="lbldate4" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Number of post of Chairperson in Audit/ Stakeholder Committee held in listed entities including this listed entity (Refer Regulation 26(1) of Listing  Regulations)</label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <select id="no4" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'no4');">
                                                                    <option value="0">Please Select . . .</option>
                                                                    <option value="1">1</option>
                                                                    <option value="2">2</option>
                                                                    <option value="3">3</option>
                                                                    <option value="4">4</option>
                                                                    <option value="5">5</option>
                                                                    <option value="6">6</option>
                                                                    <option value="7">7</option>
                                                                    <option value="8">8</option>
                                                                    <option value="9">9</option>
                                                                    <option value="10">10</option>
                                                                </select>
                                                                    <%--<textarea id="no4" class="form-control form-control-solid form-control-lg" rows="3" maxlength="100"> </textarea>--%>
                                                                </div>
                                                            </div>
                                                        <!--end::Group-->
                                                            <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblOccupationArea" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Occupation & its area </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <textarea id="txtOccupationArea" placeholder="Enter Occupation" class="form-control form-control-solid form-control-lg" rows="3" maxlength="300" onkeypress="javascript:fnRemoveClass(this,'OccupationArea');"> </textarea>
                                                                <%--<input id="txtOccupationArea" placeholder="Enter Occupation" class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="javascript:fnRemoveClass(this,'OccupationArea');" autocomplete="off" />--%>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->
                                                            <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblEducationalqualification" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Educational qualification  </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <textarea id="txtEducationalqualification" placeholder="Enter Educational qualification " class="form-control form-control-solid form-control-lg" rows="3" maxlength="300" onkeypress="javascript:fnRemoveClass(this,'Educationalqualification');"> </textarea>
                                                                <%--<input id="txtEducationalqualification" placeholder="Enter Educational qualification " class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="javascript:fnRemoveClass(this,'Educationalqualification');" autocomplete="off" maxlength="100" />--%>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->
                                                            <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblExperience" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Experience </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <textarea id="txtExperience" placeholder="Enter Experience" class="form-control form-control-solid form-control-lg" rows="3" maxlength="300" onkeypress="javascript:fnRemoveClass(this,'Experience');"> </textarea>
                                                                <%--<input id="txtExperience" placeholder="Enter Experience" class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="javascript:fnRemoveClass(this,'Experience');" autocomplete="off" maxlength="100" />--%>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->
                                                            <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblGender" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Gender </label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlGender" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'Gender');">
                                                                    <option selected="selected" value="0">Please Select . . .</option>
                                                                    <option value="Male">Male</option>
                                                                    <option value="Female">Female</option>
                                                                    <option value="PreferNotToSay">Prefer Not To Say</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->
                                                            <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblAadharNo" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Aadhar Number </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtAadharNo" class="form-control form-control-solid form-control-lg" type="number" onkeypress="return blockSpecialChar(event)" oninput="javascript: if (this.value.length > this.max) this.value = this.value.slice(0, this.max);" max="12" value="" placeholder="Enter Aadhar Number" autocomplete="off"  />

                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                            <!--begin::Group-->
                                                            <div class="form-group row">
                                                            <label id="lblShareholding" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Shareholding & Percentages </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                 <div class="row">
                                                                     <div class="col-8">
                                                                        <input id="txtShareholding" class="form-control form-control-solid form-control-lg" type="number" value="" placeholder="Share Holding" autocomplete="off" onkeypress="return blockSpecialChar(event)"  /> <%--onkeypress="javascript:fnRemoveClass(this,'Shareholding');"--%>
                                                                    </div>
                                                                     <div class="col-4">
                                                                        <div class="input-group  input-group-lg">
															                <input id="txtshareholdingpercentage" type="number" class="form-control form-control-solid " onkeypress="return blockSpecialChar(event)" placeholder="Persentages" aria-describedby="basic-addon2">
															                <div class="input-group-append">
																                <span class="input-group-text">%</span>
															                </div>
														                </div>
                                                                    </div>
                                                                 </div>
                                                            </div>
                                                        </div>
                                                            <!--end::Group-->

                                                            <%--<!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblSittingFee" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Sitting Fee </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                    <div class="input-group-prepend">
															         <select id="ddlCurrencySymbol" class="form-control form-control-lg form-control-solid col">
                                                                        <option selected="selected" value="0">¤ currencySign</option>
                                                                         <option value="rupee">₹ rupee</option>
                                                                          <option value="austral">₳ austral</option>
                                                                          <option value="australCentavo">¢ australCentavo</option>
                                                                          <option value="baht">฿ baht</option>
                                                                          <option value="cedi">₵ cedi</option>
                                                                          <option value="cent">¢ cent</option>
                                                                          <option value="colon">₡ colon</option>
                                                                          <option value="cruzeiro">₢ cruzeiro</option>
                                                                          <option value="dollar">$ dollar</option>
                                                                          <option value="dong">₫ dong</option>
                                                                          <option value="drachma">₯ drachma</option>
                                                                          <option value="dram">​֏ dram</option>
                                                                          <option value="european">₠ european</option>
                                                                          <option value="euro">€ euro</option>
                                                                          <option value="florin">ƒ florin</option>
                                                                          <option value="franc">₣ franc</option>
                                                                          <option value="guarani">₲ guarani</option>
                                                                          <option value="hryvnia">₴ hryvnia</option>
                                                                          <option value="kip">₭ kip</option>
                                                                          <option value="att ">ອັດ att</option>
                                                                          <option value="lepton">Λ. lepton</option>
                                                                          <option value="lira">₺ lira</option>
                                                                          <option value="liraOld">₤ liraOld</option>
                                                                          <option value="lari">₾ lari</option>
                                                                          <option value="mark">ℳ mark</option>
                                                                          <option value="mill">₥ mill</option>
                                                                          <option value="naira">₦ naira</option>
                                                                          <option value="peseta">₧ peseta</option>
                                                                          <option value="peso">₱ peso</option>
                                                                          <option value="pfennig">₰ pfennig</option>
                                                                          <option value="pound">£ pound</option>
                                                                          <option value="real">R$  real</option>
                                                                          <option value="riel">៛ riel</option>
                                                                          <option value="ruble">₽ ruble</option>
                                                                          <option value="rupeeOld">₨ rupeeOld</option>
                                                                          <option value="shekel">₪ shekel</option>
                                                                          <option value="shekelAlt">ש״ח shekelAlt</option>
                                                                          <option value="taka">৳ taka</option>
                                                                          <option value="tenge">₸ tenge</option>
                                                                          <option value="togrog">₮ togrog </option>
                                                                          <option value="won">₩ won </option>
                                                                          <option value="yen">¥ yen  </option>
                                                                    </select> 
															        </div>
                                                                        </div>
                                                                    <div class="col-5">
																        <input id="txtSittingFee" class="form-control form-control-solid form-control-lg" type="number" value="" onkeypress="javascript:fnRemoveClass(this,'SittingType');" oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" maxlength="10" placeholder="Enter Amount" autocomplete="off" />
														        </div>
                                                                    <div class="col-3">
                                                                    <div class="input-group-prepend">
															         <select id="ddlPaymentMode" class="form-control form-control-lg form-control-solid col">
                                                                        <option selected="selected" value="0">Select . . .</option>
                                                                          <option value="Monthly">Monthly</option>
                                                                          <option value="Quarterly">Quarterly</option>
                                                                          <option value="BioAnnual">Bi Annual</option>
                                                                          <option value="Yearly">Yearly</option>

                                                                    </select> 
															        </div>
                                                                  </div>
                                                                    </div>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->


                                                            <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblRemuneration" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Remuneration </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <div class="row">
                                                                    <div class="col-4">
                                                                    <div class="input-group-prepend">
															         <select id="ddlCurrencySymbolRem" class="form-control form-control-lg form-control-solid col">
                                                                        <option selected="selected" value="0">¤ currencySign</option>
                                                                         <option value="rupee">₹ rupee</option>
                                                                          <option value="austral">₳ austral</option>
                                                                          <option value="australCentavo">¢ australCentavo</option>
                                                                          <option value="baht">฿ baht</option>
                                                                          <option value="cedi">₵ cedi</option>
                                                                          <option value="cent">¢ cent</option>
                                                                          <option value="colon">₡ colon</option>
                                                                          <option value="cruzeiro">₢ cruzeiro</option>
                                                                          <option value="dollar">$ dollar</option>
                                                                          <option value="dong">₫ dong</option>
                                                                          <option value="drachma">₯ drachma</option>
                                                                          <option value="dram">​֏ dram</option>
                                                                          <option value="european">₠ european</option>
                                                                          <option value="euro">€ euro</option>
                                                                          <option value="florin">ƒ florin</option>
                                                                          <option value="franc">₣ franc</option>
                                                                          <option value="guarani">₲ guarani</option>
                                                                          <option value="hryvnia">₴ hryvnia</option>
                                                                          <option value="kip">₭ kip</option>
                                                                          <option value="att ">ອັດ att</option>
                                                                          <option value="lepton">Λ. lepton</option>
                                                                          <option value="lira">₺ lira</option>
                                                                          <option value="liraOld">₤ liraOld</option>
                                                                          <option value="lari">₾ lari</option>
                                                                          <option value="mark">ℳ mark</option>
                                                                          <option value="mill">₥ mill</option>
                                                                          <option value="naira">₦ naira</option>
                                                                          <option value="peseta">₧ peseta</option>
                                                                          <option value="peso">₱ peso</option>
                                                                          <option value="pfennig">₰ pfennig</option>
                                                                          <option value="pound">£ pound</option>
                                                                          <option value="real">R$  real</option>
                                                                          <option value="riel">៛ riel</option>
                                                                          <option value="ruble">₽ ruble</option>
                                                                          <option value="rupeeOld">₨ rupeeOld</option>
                                                                          <option value="shekel">₪ shekel</option>
                                                                          <option value="shekelAlt">ש״ח shekelAlt</option>
                                                                          <option value="taka">৳ taka</option>
                                                                          <option value="tenge">₸ tenge</option>
                                                                          <option value="togrog">₮ togrog </option>
                                                                          <option value="won">₩ won </option>
                                                                          <option value="yen">¥ yen  </option>
                                                                    </select> 
															        </div>
                                                                        </div>
                                                                    <div class="col-5">
																        <input id="txtRemuneration" class="form-control form-control-solid form-control-lg" type="number" value="" onkeypress="javascript:fnRemoveClass(this,'Remuneration');" placeholder="Enter Amount" autocomplete="off" />
														            </div>
                                                                  <div class="col-3">
                                                                    <div class="input-group-prepend">
															         <select id="ddlddlPaymentModeRemuneration" class="form-control form-control-lg form-control-solid col">
                                                                        <option selected="selected" value="0">Select . . .</option>
                                                                          <option value="Monthly">Monthly</option>
                                                                          <option value="Quarterly">Quarterly</option>
                                                                          <option value="BioAnnual">Bi Annual</option>
                                                                          <option value="Yearly">Yearly</option>

                                                                    </select> 
															        </div>
                                                                  </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->--%>

                                                            <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblAppointedSection" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Section under which appointed </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtAppointedSection" placeholder="Enter Section" class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="return blockSpecialChar(event)"  autocomplete="off" maxlength="100" /> <%--onkeypress="javascript:fnRemoveClass(this,'AppointedSection');"--%>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblOtherCompanies" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Other companies in which directorships are held </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <%--<input id="txtOtherCompanies" placeholder="Enter Other Companies" class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="javascript:fnRemoveClass(this,'OtherCompanies');" autocomplete="off" maxlength="100" />--%>
                                                            
                                                                <table id="tblmultiCompanies">
                                                                    <tbody id="tbdCompany">
                                                                        <tr>
                                                                            <td>
                                                                                 <input id="txtOtherCompanies" type="text" class="form-control d-flex form-control-solid form-control-lg" placeholder="Enter Company" onkeypress="javascript:fnRemoveClass(this,'OtherCompanies');" autocomplete="off" />
                                                                            </td>
                                                                            <td>
                                                                                <img onclick="javascript:fnAddmultiCompanies();" src="../assets/Image/Icon/AddButton.png" height="24" width="24" />
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                
                                                                <%--<div id="kt_repeater_3">
	                                                            <div class="form-group row">
		                                                            <div data-repeater-list="" class="col-xl-9">
			
		                                                            <div data-repeater-item="" class="form-group row" style="">
				                                                            <div class="col-lg-8 companies">
					                                                            <div class="input-group">
						                                                            
						                                                            <input type="text" name="companyName" id="txtOtherCompanies" placeholder="Enter Other Companies" class="form-control form-control-solid form-control-lg" value="" onkeypress="return blockSpecialChar(event)" autocomplete="off" maxlength="100" />    onkeypress="javascript:fnRemoveClass(this,'OtherCompanies');"
					                                                            </div>
				                                                            </div>
				                                                            <div class="col-lg-2">
					                                                            <a href="javascript:;" data-repeater-delete="" class="btn font-weight-bold btn-danger btn-icon">
						                                                            <i class="la la-remove"></i>
					                                                            </a>
				                                                            </div>
                                                                        <div class="col-lg-3"></div>
		                                                            
			                                                            </div></div>
                                                                    <div class="col-lg-3"></div>
		                                                            <div class="col">
			                                                            <div data-repeater-create="" class="btn font-weight-bold btn-primary">
			                                                            <i id="autoAddTextbox" class="la la-plus"></i>Add</div>
		                                                            </div>
	                                                            </div>
	                                                            
                                                            </div>--%>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblCommitteesAlreadyDirector" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Committees on which already a director </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtCommitteesAlreadyDirector" placeholder="Enter Committees on which already a Director" class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="return blockSpecialChar(event)"  autocomplete="off" maxlength="100" /> <%--onkeypress="javascript:fnRemoveClass(this,'CommitteesAlreadyDirector');"--%>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->
                                                        
                                                        </div>
                                                        <div class="d-flex justify-content-between border-top pt-10 mt-15">
                                                            <%--<div class="mr-2">
                                                        <button type="button" id="prev-step" class="btn btn-light-primary font-weight-bolder px-9 py-4" data-wizard-type="action-prev">Previous</button>
                                                    </div>--%>
                                                            <div class="mr-2" style="float: right;">
                                                                <button id="btnSave" type="button" data-dismiss="modal" class="btn btn-success font-weight-bolder px-9 py-4" data-wizard-type="action-submit" onclick="javascript:fnSaveUser();">Submit</button>
                                                                <button id="btnCancel" type="button" class="btn btn-success font-weight-bolder px-9 py-4" data-dismiss="modal" data-wizard-type="action-close" onclick="javascript:fnCloseModal();">Close</button>
                                                                <%--<button type="button" id="next-step" class="btn btn-primary font-weight-bolder px-9 py-4" data-wizard-type="action-next">Next</button>--%>
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
        <div>
            <!--begin: Search Form-->
            <!--begin::Search Form-->
            <%--<div class="mb-7">
                <div class="row align-items-center">
                    <div class="col-lg-9 col-xl-8">
                        <div class="row align-items-center">
                            <div class="col-md-4 my-2 my-md-0">
                                <div class="input-icon">
                                    <input type="text" class="form-control" placeholder="Search..." />
                                    <span>
                                        <i class="flaticon2-search-1 text-muted"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-4 my-2 my-md-0">
                                <div class="d-flex align-items-center">
                                    <label class="mr-3 mb-0 d-none d-md-block">Status:</label>
                                    <select style="width: 250px;" id="ddlUserStatus" class="form-control" >
                                        <option selected="selected" value="0">Please Select Status</option>
                                        <option value="Active">Active</option>
                                        <option value="InActive">InActive</option>
                                        
                                    </select>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-3 col-xl-4 mt-5 mt-lg-0">
                        <button id="btnSearch" runat="server" class="btn btn-light-primary px-6 font-weight-bold" onclick="javascript:fnGetUserList();">
                            Search
                        </button>
                    </div>
                </div>

            </div>--%>
        </div>
        <!--end::Search Form-->
    </div>
    </div>
    <!--end::Card-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--List Bind--%>
    <div class="portlet light bordered">
        <div class="portlet-body">
            <div class="form-body">
                <table class="table table-striped table-hover table-bordered" id="tbl-User-setup">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Name </th>
                            <th>Role  </th>
                            <%-- <th>Tenure Start</th>
                            <th>Tenure End</th>--%>
                            <th>Email</th>
                            <th>User Login</th>
                            <th>Status</th>
                            <th></th>
                            <%--<th></th>--%>
                        </tr>
                    </thead>
                    <tbody id="tbdUserList">
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <%--<div class="datatable datatable-bordered datatable-head-custom" id="kt_datatable"></div>--%>
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    
    <%--    <script src="js/CreateDoc.js?<%=DateTime.Now %>"></script>--%>
    <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js" type="text/javascript"></script>
    <link href="../assets/global/css/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../assets/global/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/intl-tel-input@18.2.1/build/js/intlTelInput.min.js"></script>

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
    <script src="js/Global.js?<%=DateTime.Now%>"></script>
    <%--<script src="assets/js/pages/crud/ktdatatable/base/data-local.js"></script>--%>
    <script src="js/User.js?<%=DateTime.Now%>"></script>
    <%--<script>
        $(document).ready(function () {
            $('#tbl-User-setup').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });
        });
    </script>--%>
    <script>
        var KTFormRepeater = function () {
            var demo3 = function () {
                $('#kt_repeater_3').repeater({
                    initEmpty: false,

                    defaultValues: {
                        'text-input': 'foo'
                    },

                    show: function () {
                        $(this).slideDown();
                    },

                    hide: function (deleteElement) {
                        if (confirm('Are you sure you want to delete this element?')) {
                            $(this).slideUp(deleteElement);
                        }
                    }
                });
            }
            return {
                // public functions
                init: function () {
                    demo3();
                }
            };
        }();

        jQuery(document).ready(function () {
            KTFormRepeater.init();
        });
    </script>
    <script type="text/javascript">
        function blockSpecialChar(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>
</asp:Content>
