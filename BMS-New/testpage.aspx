<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BMSMaster.Master" CodeBehind="testpage.aspx.cs" Inherits="BMS_New.testpage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
    <!--begin::Subheader-->
    <div class="subheader py-2 py-lg-6 subheader-solid" id="kt_subheader">
        <div class="container-fluid d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap">
            <!--begin::Info-->
            <div class="d-flex align-items-center flex-wrap mr-1">
                <!--begin::Page Heading-->
                <div class="d-flex align-items-baseline flex-wrap mr-5">
                    <!--begin::Page Title-->
                    <h5 class="text-dark font-weight-bold my-1 mr-5">Local Data</h5>
                    <!--end::Page Title-->
                    <!--begin::Breadcrumb-->
                    <ul class="breadcrumb breadcrumb-transparent breadcrumb-dot font-weight-bold p-0 my-2 font-size-sm">
                        <li class="breadcrumb-item text-muted">
                            <a href="#" class="text-muted">Crud</a>
                        </li>
                        <li class="breadcrumb-item text-muted">
                            <a href="#" class="text-muted">KTDatatable</a>
                        </li>
                        <li class="breadcrumb-item text-muted">
                            <a href="#" class="text-muted">Base</a>
                        </li>
                        <li class="breadcrumb-item text-muted">
                            <a href="#" class="text-muted">Local Data</a>
                        </li>
                    </ul>
                    <!--end::Breadcrumb-->
                </div>
                <!--end::Page Heading-->
            </div>
            <!--end::Info-->
            <!--begin::Toolbar-->
            <div class="d-flex align-items-center">
                <!--begin::Actions-->
                <a href="#" class="btn btn-light-primary font-weight-bolder btn-sm">Actions</a>
                <!--end::Actions-->
                <!--begin::Dropdown-->
                <div class="dropdown dropdown-inline" data-toggle="tooltip" title="Quick actions" data-placement="left">
                    <a href="#" class="btn btn-icon" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="svg-icon svg-icon-success svg-icon-2x">
                            <!--begin::Svg Icon | path:assets/media/svg/icons/Files/File-plus.svg-->
                            <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                                <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                    <polygon points="0 0 24 0 24 24 0 24" />
                                    <path d="M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z" fill="#000000" fill-rule="nonzero" opacity="0.3" />
                                    <path d="M11,14 L9,14 C8.44771525,14 8,13.5522847 8,13 C8,12.4477153 8.44771525,12 9,12 L11,12 L11,10 C11,9.44771525 11.4477153,9 12,9 C12.5522847,9 13,9.44771525 13,10 L13,12 L15,12 C15.5522847,12 16,12.4477153 16,13 C16,13.5522847 15.5522847,14 15,14 L13,14 L13,16 C13,16.5522847 12.5522847,17 12,17 C11.4477153,17 11,16.5522847 11,16 L11,14 Z" fill="#000000" />
                                </g>
                            </svg>
                            <!--end::Svg Icon-->
                        </span>
                    </a>
                    <div class="dropdown-menu dropdown-menu-md dropdown-menu-right p-0 m-0">
                        <!--begin::Navigation-->
                        <ul class="navi navi-hover">
                            <li class="navi-header font-weight-bold py-4">
                                <span class="font-size-lg">Choose Label:</span>
                                <i class="flaticon2-information icon-md text-muted" data-toggle="tooltip" data-placement="right" title="Click to learn more..."></i>
                            </li>
                            <li class="navi-separator mb-3 opacity-70"></li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-text">
                                        <span class="label label-xl label-inline label-light-success">Customer</span>
                                    </span>
                                </a>
                            </li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-text">
                                        <span class="label label-xl label-inline label-light-danger">Partner</span>
                                    </span>
                                </a>
                            </li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-text">
                                        <span class="label label-xl label-inline label-light-warning">Suplier</span>
                                    </span>
                                </a>
                            </li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-text">
                                        <span class="label label-xl label-inline label-light-primary">Member</span>
                                    </span>
                                </a>
                            </li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-text">
                                        <span class="label label-xl label-inline label-light-dark">Staff</span>
                                    </span>
                                </a>
                            </li>
                            <li class="navi-separator mt-3 opacity-70"></li>
                            <li class="navi-footer py-4">
                                <a class="btn btn-clean font-weight-bold btn-sm" data-toggle="modal" data-target="#exampleModalSizeXl" href="#">
                                    <i class="ki ki-plus icon-sm"></i>Add new</a>
                            </li>
                        </ul>
                        <!--end::Navigation-->
                    </div>
                </div>
                <!--end::Dropdown-->
            </div>
            <!--end::Toolbar-->
        </div>
    </div>
    <!--end::Subheader-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <!--begin::Notice-->
    <div class="alert alert-custom alert-white alert-shadow gutter-b" role="alert">
        <div class="alert-icon">
            <span class="svg-icon svg-icon-primary svg-icon-xl">
                <!--begin::Svg Icon | path:assets/media/svg/icons/Tools/Compass.svg-->
                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                    <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                        <rect x="0" y="0" width="24" height="24" />
                        <path d="M7.07744993,12.3040451 C7.72444571,13.0716094 8.54044565,13.6920474 9.46808594,14.1079953 L5,23 L4.5,18 L7.07744993,12.3040451 Z M14.5865511,14.2597864 C15.5319561,13.9019016 16.375416,13.3366121 17.0614026,12.6194459 L19.5,18 L19,23 L14.5865511,14.2597864 Z M12,3.55271368e-14 C12.8284271,3.53749572e-14 13.5,0.671572875 13.5,1.5 L13.5,4 L10.5,4 L10.5,1.5 C10.5,0.671572875 11.1715729,3.56793164e-14 12,3.55271368e-14 Z" fill="#000000" opacity="0.3" />
                        <path d="M12,10 C13.1045695,10 14,9.1045695 14,8 C14,6.8954305 13.1045695,6 12,6 C10.8954305,6 10,6.8954305 10,8 C10,9.1045695 10.8954305,10 12,10 Z M12,13 C9.23857625,13 7,10.7614237 7,8 C7,5.23857625 9.23857625,3 12,3 C14.7614237,3 17,5.23857625 17,8 C17,10.7614237 14.7614237,13 12,13 Z" fill="#000000" fill-rule="nonzero" />
                    </g>
                </svg>
                <!--end::Svg Icon-->
            </span>
        </div>
        <div class="alert-text">
            BMS USER
        </div>
    </div>
    <!--end::Notice-->
    <!--begin::Card-->
    <div class="card card-custom">
        <div class="card-header flex-wrap border-0 pt-6 pb-0">
            <div class="card-title">
                <h3 class="card-label">Local Datasource
											<span class="text-muted pt-2 font-size-sm d-block">Javascript array as data source</span></h3>
            </div>
            <div class="card-toolbar">
                <!--begin::Dropdown-->
                <div class="dropdown dropdown-inline mr-2">
                    <button type="button" class="btn btn-light-primary font-weight-bolder dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="svg-icon svg-icon-md">
                            <!--begin::Svg Icon | path:assets/media/svg/icons/Design/PenAndRuller.svg-->
                            <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                                <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                    <rect x="0" y="0" width="24" height="24" />
                                    <path d="M3,16 L5,16 C5.55228475,16 6,15.5522847 6,15 C6,14.4477153 5.55228475,14 5,14 L3,14 L3,12 L5,12 C5.55228475,12 6,11.5522847 6,11 C6,10.4477153 5.55228475,10 5,10 L3,10 L3,8 L5,8 C5.55228475,8 6,7.55228475 6,7 C6,6.44771525 5.55228475,6 5,6 L3,6 L3,4 C3,3.44771525 3.44771525,3 4,3 L10,3 C10.5522847,3 11,3.44771525 11,4 L11,19 C11,19.5522847 10.5522847,20 10,20 L4,20 C3.44771525,20 3,19.5522847 3,19 L3,16 Z" fill="#000000" opacity="0.3" />
                                    <path d="M16,3 L19,3 C20.1045695,3 21,3.8954305 21,5 L21,15.2485298 C21,15.7329761 20.8241635,16.200956 20.5051534,16.565539 L17.8762883,19.5699562 C17.6944473,19.7777745 17.378566,19.7988332 17.1707477,19.6169922 C17.1540423,19.602375 17.1383289,19.5866616 17.1237117,19.5699562 L14.4948466,16.565539 C14.1758365,16.200956 14,15.7329761 14,15.2485298 L14,5 C14,3.8954305 14.8954305,3 16,3 Z" fill="#000000" />
                                </g>
                            </svg>
                            <!--end::Svg Icon-->
                        </span>Export</button>
                    <!--begin::Dropdown Menu-->
                    <div class="dropdown-menu dropdown-menu-sm dropdown-menu-right">
                        <!--begin::Navigation-->
                        <ul class="navi flex-column navi-hover py-2">
                            <li class="navi-header font-weight-bolder text-uppercase font-size-sm text-primary pb-2">Choose an option:</li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-icon">
                                        <i class="la la-print"></i>
                                    </span>
                                    <span class="navi-text">Print</span>
                                </a>
                            </li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-icon">
                                        <i class="la la-copy"></i>
                                    </span>
                                    <span class="navi-text">Copy</span>
                                </a>
                            </li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-icon">
                                        <i class="la la-file-excel-o"></i>
                                    </span>
                                    <span class="navi-text">Excel</span>
                                </a>
                            </li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-icon">
                                        <i class="la la-file-text-o"></i>
                                    </span>
                                    <span class="navi-text">CSV</span>
                                </a>
                            </li>
                            <li class="navi-item">
                                <a href="#" class="navi-link">
                                    <span class="navi-icon">
                                        <i class="la la-file-pdf-o"></i>
                                    </span>
                                    <span class="navi-text">PDF</span>
                                </a>
                            </li>
                        </ul>
                        <!--end::Navigation-->
                    </div>
                    <!--end::Dropdown Menu-->
                </div>
                <!--end::Dropdown-->
                <!--begin::Button-->
                <button type="button" data-toggle="modal" data-target="#exampleModalSizeXl" class="btn btn-primary font-weight-bolder">
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
                <!--begin::Modal-->
                <div class="modal fade" id="exampleModalSizeXl" tabindex="-1" role="dialog" aria-labelledby="exampleModalSizeXl" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Add New User</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <i aria-hidden="true" class="ki ki-close"></i>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="row justify-content-center py-8 px-8 py-lg-15 px-lg-10">
                                    <div class="col-xl-12 col-xxl-12">
                                        <!--begin::Wizard Form-->
                                        <form class="form" id="kt_form">
                                            <div class="row justify-content-center">
                                                <div class="col-xl-12">
                                                    <!--begin::Wizard Step 1-->
                                                    <div class="my-5 step" data-wizard-type="step-content" data-wizard-state="current">
                                                        <%--<h5 class="text-dark font-weight-bold mb-10">User's Profile Details:</h5>--%>

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
                                                                    <input id="txtEmail" type="email" class="form-control form-control-solid form-control-lg" placeholder="Email Address" onkeypress="javascript:fnRemoveClass(this,'Email');" onchange="javascript:fnFillUserDetails();" autocomplete="on" maxlength="100" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->


                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblRole" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Role <sup class="text-danger">*</sup></label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlRole" class="form-control form-control-lg form-control-solid" onchange="getdiv(this); fnRemoveClass(this,'Role');" name="language">
                                                                    <option value="">Please Select . . .</option>
                                                                    <option value="Admin">Admin</option>
                                                                    <option value="Secretarial User">Secretarial User</option>
                                                                    <option value="Director">Director</option>
                                                                    <option value="Invitee">Invitee</option>
                                                                    <option value="Committee Admin">Committee Admin</option>
                                                                    <option value="Managing Director">Managing Director</option>
                                                                    <option value="CEO">CEO</option>
                                                                    <option value="General Manager">General Manager</option>
                                                                    <option value="Chairperson">Chairperson</option>
                                                                    <option value="Meeting Coordinator">Meeting Coordinator</option>
                                                                    <option value="HOD">HOD</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

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
                                                            <label id="lblPhone" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Phone <sup class="text-danger">*</sup></label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtPhone" class="form-control form-control-solid form-control-lg" type="number" value="" onkeypress="javascript:fnRemoveClass(this,'Phone');" oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);" maxlength="10" placeholder="Enter Phone No" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblUserid" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">User Login Id <sup class="text-danger">*</sup></label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtUserid" placeholder="Enter log ID" class="form-control form-control-solid form-control-lg" type="text" value="" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'Userid');" />
                                                                <input id="txtUserId" class="form-control form-control-solid form-control-lg" type="text" data-tabindex="1" style="display: none" value="0" />
                                                                <input class="form-control form-control-solid form-control-lg" id="txtUserID" type="text" style="display: none;" />
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblPassword" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Password <sup class="text-danger">*</sup></label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtPassword" class="form-control form-control-solid form-control-lg" type="password" value="" placeholder="Password" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'Password');" />

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
                                                        <div id="divDepartment" class="form-group row">
                                                            <label id="lblDepartment" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Department <sup class="text-danger">*</sup></label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlDepartment" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'Department');">
                                                                    <option value="">Please Select . . .</option>
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
                                                        <div id="divDesignation" class="form-group row">
                                                            <label id="lblDesignation" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Designation <sup class="text-danger">*</sup></label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlDesignation" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'Designation');">
                                                                    <option value="">Please Select . . .</option>
                                                                    <option value="Additional Director">Additional Director</option>
                                                                    <option value="Admin">Admin</option>
                                                                    <option value="CEO">CEO</option>
                                                                    <option value="CFO">CFO</option>
                                                                    <option value="id">Chairman , Non-Executive - Independent Director</option>
                                                                    <option value="id">Chairperson</option>
                                                                    <option value="id">Chief Operating Officer</option>
                                                                    <option value="id">Company Secretary</option>
                                                                    <option value="id">Director</option>
                                                                    <option value="id">Director (Commercial)</option>
                                                                    <option value="id">Director (Finance)</option>
                                                                    <option value="id">Govt. Nominee Director</option>
                                                                    <option value="id">HOD</option>
                                                                    <option value="id">Independent Director</option>
                                                                    <option value="id">Independent Non-Executive Chairman</option>
                                                                    <option value="id">Independent Non-Executive Director</option>
                                                                    <option value="id">Investor Nominee Director</option>
                                                                    <option value="id">Invitee</option>
                                                                    <option value="id">Joint. Managing Director</option>
                                                                    <option value="id">Managing Director</option>
                                                                    <option value="id">Managing Director and CEO</option>
                                                                    <option value="id">MD and CEO</option>
                                                                    <option value="id">Member</option>
                                                                    <option value="id">Nominee Director</option>
                                                                    <option value="id">Non Independent - Non Executive Director</option>
                                                                    <option value="id">Non-Executive & Non-Independent Director</option>
                                                                    <option value="id">Secretarial</option>
                                                                    <option value="id">Secretarial User</option>
                                                                    <option value="id">Secreterial</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div id="divCategory" class="form-group row">
                                                            <label id="lblCategory" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Category <sup class="text-danger">*</sup></label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlCategory" class="form-control form-control-lg form-control-solid" onchange="javascript:fnRemoveClass(this,'Category');">
                                                                    <option value="">Please Select . . .</option>
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
                                                                            <label>Not Provided</label>
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div id="remark" class="form-group row" style="display: none">
                                                                <label id="lblPANRemark" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Remark<sup class="text-danger">*</sup></label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <textarea id="txtPANRemark" class="form-control form-control-solid form-control-lg" placeholder="Enter Your Remark" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'PANRemark');"></textarea>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="form-group">
                                                                <label id="lblDIN" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">DIN<sup class="text-danger">*</sup></label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <div class="input-group">
                                                                        <input id="txtDIN" type="number" class="form-control text-uppercase" maxlength="8" placeholder="Enter DIN" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'DIN');" />
                                                                        <span class="input-group-addon" style="background-color: #343a41; color: white;">
                                                                            <input class="coupon_questiondin" type="checkbox" name="coupon_question" value="Not Provide" onchange="valueChangeddin()" />
                                                                            <label>Not Provided</label>
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div id="dinremark" class="form-group row" style="display: none">
                                                                <label id="lblDINRemark" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">DIN Remark<sup class="text-danger">*</sup></label>
                                                                <div class="col-md-8">
                                                                    <textarea id="txtDINRemark" class="form-control form-control-solid form-control-lg" placeholder="Enter Your Remark" autocomplete="off" onkeypress="javascript:fnRemoveClass(this,'DINRemark');"></textarea>
                                                                </div>
                                                            </div>
                                                            <br style="display: none;" />
                                                            <div style="display: none;" class="form-group row">
                                                                <label id="dpcat1" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Category 1 of Director</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <select id="ddlcat1" class="form-control form-control-lg form-control-solid" runat="server" data-control="select2">
                                                                        <option value="">Please Select . . .</option>
                                                                        <option>Executive Director</option>
                                                                        <option>Non-Executive Non-Independent Director</option>
                                                                        <option>Non-Executive -Independent Director</option>
                                                                        <option>Non-Executive -Nominee Director</option>
                                                                        <option>Executive -Nominee Director</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <br style="display: none;" />
                                                            <div style="display: none;" class="form-group row">
                                                                <label id="dpcat2" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Category 2 of Director</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <select id="ddlcat2" class="form-control form-control-lg form-control-solid" runat="server">
                                                                        <option value="">Please Select . . .</option>
                                                                        <option>ChairPerson</option>
                                                                        <option>Not Applicable</option>
                                                                        <option>ChairPerson Related To Promotor</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <br style="display: none;" />
                                                            <div style="display: none;" class="form-group row">
                                                                <label id="dpcat3" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Category 3 of Director</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <select id="ddlcat3" class="form-control form-control-lg form-control-solid" runat="server">
                                                                        <option value="">Please Select . . .</option>
                                                                        <option>CEO</option>
                                                                        <option>MD</option>
                                                                        <option>CEO-MD</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="form-group row">
                                                                <label id="lbl17A" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Weather Special Resulation 17(1A) Of LODR Required ?</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <select id="ddl17A" class="form-control form-control-lg form-control-solid" onchange="get2nddiv()" runat="server">
                                                                        <option value="">Please Select . . .</option>
                                                                        <option>NO</option>
                                                                        <option>YES</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div id="dateandfileupload" style="display: none">
                                                                <div class="form-group row">
                                                                    <label id="lbldate" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Date Of Passing Special Resoultion</label>
                                                                    <div class="col-lg-9 col-xl-9">
                                                                        <input id="txtdate" class="form-control form-control-solid form-control-lg" size="16" type="date" value="" autocomplete="off" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="form-group row">
                                                                <label id="lbldate1" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">No of Directorship in listed entities including this listed entity (Refer Regulation 17A of Listing Regulations)</label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <input id="no1" class="form-control form-control-solid form-control-lg" size="16" type="number" value="" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="form-group row">
                                                                <label id="lbldate2" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">No of Independent Directorship in listed entities including this listed entity (Refer Regulation 17A(1) of Listing Regulations</label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <input id="no2" class="form-control form-control-solid form-control-lg" size="16" type="number" value="" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="form-group row">
                                                                <label id="lbldate3" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Number of memberships in Audit/ Stakeholder Committee(s) including this listed entity (Refer Regulation 26(1) of Listing Regulations)</label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <input id="no3" class="form-control form-control-solid form-control-lg" size="16" type="number" value="" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="form-group row">
                                                                <label id="lbldate4" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">No of post of Chairperson in Audit/ Stakeholder Committee held in listed entities including this listed entity (Refer Regulation 26(1) of Listing  Regulations)</label>
                                                                <div class="col-lg-9 col-xl-9">
                                                                    <input id="no4" class="form-control form-control-solid form-control-lg" size="16" type="number" value="" autocomplete="off" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblTenurestartdate" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Tenure Start Date <sup class="text-danger">*</sup></label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtTenurestartdate" class="form-control form-control-solid form-control-lg" size="16" type="date" value="" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblTenureenddate" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Tenure End Date </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtTenureenddate" class="form-control form-control-solid form-control-lg" size="16" type="date" value="" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblDateofbirth" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Date Of Birth </label>
                                                            <div class="col-lg-9 col-xl-9">
                                                                <input id="txtDateofbirth" data-required="1" class="form-control form-control-solid form-control-lg" size="16" type="date" value="" autocomplete="off" />
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblNationality" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Nationality</label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <select id="ddlNationality" class="form-control form-control-lg form-control-solid" name="language">
                                                                    <option value="Indian">Indian</option>
                                                                    <option value="ForegnierNational">Foregnier National</option>
                                                                </select>
                                                            </div>
                                                        </div>
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


                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblAddress" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Address</label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <textarea id="txtAddress" class="form-control form-control-solid form-control-lg" rows="3" maxlength="200"> </textarea>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->

                                                        <!--begin::Group-->
                                                        <div class="form-group row">
                                                            <label id="lblProfile" style="text-align: left" class="col-form-label col-xl-3 col-lg-3">Profile </label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <textarea id="txtProfile" class="form-control form-control-solid form-control-lg" rows="3" maxlength="4000"> </textarea>
                                                            </div>
                                                        </div>
                                                        <!--end::Group-->




                                                        <!--begin::Group-->
                                                        <div id="uploadfile" class="form-group row">
                                                             <%--<div class="fileinput fileinput-new" data-provides="fileinput">--%>
                                                                    <label id="lblUpload1" style="text-align: left" class="col-form-label col-xl-3 col-lg-3 ">Upload File<sup class="text-danger">*</sup></label>                                                       
                                                                      <div class="col-xl-9 col-lg-9">
                                                                        <input id="fileUploadImage" class="form-control form-control-solid form-control-lg" type="file" name="..." onchange="javascript:fnRemoveClass(this,'Upload');" />
                                                                         <a style="display: none" id="aUserAvatarImageUploaded" href="#" target="_blank">
                                                                         <img src="../assets/images/arrow-download-icon.png" style="width: 30px; height: 30px;" />
                                                                        </a>
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
                                                        <!--end::Wizard Step 1-->
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
            </div>
        </div>
        <div class="card-body">
            <!--begin: Search Form-->
            <!--begin::Search Form-->
            <div class="mb-7">
                <div class="row align-items-center">
                    <div class="col-lg-9 col-xl-8">
                        <div class="row align-items-center">
                            <div class="col-md-4 my-2 my-md-0">
                                <div class="input-icon">
                                    <input type="text" class="form-control" placeholder="Search..." id="kt_datatable_search_query" />
                                    <span>
                                        <i class="flaticon2-search-1 text-muted"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-4 my-2 my-md-0">
                                <div class="d-flex align-items-center">
                                    <label class="mr-3 mb-0 d-none d-md-block">Status:</label>
                                    <select class="form-control" id="kt_datatable_search_status">
                                        <option value="">All</option>
                                        <option value="1">Pending</option>
                                        <option value="2">Delivered</option>
                                        <option value="3">Canceled</option>
                                        <option value="4">Success</option>
                                        <option value="5">Info</option>
                                        <option value="6">Danger</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-4 my-2 my-md-0">
                                <div class="d-flex align-items-center">
                                    <label class="mr-3 mb-0 d-none d-md-block">Type:</label>
                                    <select class="form-control" id="kt_datatable_search_type">
                                        <option value="">All</option>
                                        <option value="1">Online</option>
                                        <option value="2">Retail</option>
                                        <option value="3">Direct</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-xl-4 mt-5 mt-lg-0">
                        <a href="#" class="btn btn-light-primary px-6 font-weight-bold">Search</a>
                    </div>
                </div>
            </div>
            <!--end::Search Form-->
            <!--end: Search Form-->
            <!--begin: Datatable-->

            <!--end: Datatable-->
        </div>
    </div>
    <!--end::Card-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="datatable datatable-bordered datatable-head-custom" id="kt_datatable"></div>
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <%--    <script src="js/CreateDoc.js?<%=DateTime.Now %>"></script>--%>
    <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js" type="text/javascript"></script>
    <link href="../assets/global/css/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../assets/global/plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
    <script src="../assets/pages/scripts/components-date-time-pickers.min.js" type="text/javascript"></script>
    <script src="js/Global.js?<%=DateTime.Now%>"></script>
    <script src="assets/js/pages/crud/ktdatatable/base/data-local.js"></script>
    <script src="js/User.js?<%=DateTime.Now%>"></script>
</asp:Content>
