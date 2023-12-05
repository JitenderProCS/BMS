<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BoardMeeting/BMSMaster.Master" CodeBehind="DesignationMaster.aspx.cs" Inherits="BMS_New.BoardMeeting.DesignationMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <link href="assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" />--%>
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
                    <h5 class="text-dark font-weight-bold my-1 mr-5">
                          <span class="svg-icon svg-icon-primary svg-icon-2x">
                            <!--begin::Svg Icon | path:C:\wamp64\www\keenthemes\legacy\metronic\theme\html\demo1\dist/../src/media/svg/icons\General\Settings-2.svg-->
                            <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
                                <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                    <rect x="0" y="0" width="24" height="24" />
                                    <path d="M5,8.6862915 L5,5 L8.6862915,5 L11.5857864,2.10050506 L14.4852814,5 L19,5 L19,9.51471863 L21.4852814,12 L19,14.4852814 L19,19 L14.4852814,19 L11.5857864,21.8994949 L8.6862915,19 L5,19 L5,15.3137085 L1.6862915,12 L5,8.6862915 Z M12,15 C13.6568542,15 15,13.6568542 15,12 C15,10.3431458 13.6568542,9 12,9 C10.3431458,9 9,10.3431458 9,12 C9,13.6568542 10.3431458,15 12,15 Z" fill="#000000" />
                                </g>
                            </svg><!--end::Svg Icon--></span>
                        Designation
                    </h5>
                    <!--end::Page Title-->
                    
                </div>
                <!--end::Page Heading-->
            </div>
            <!--end::Info-->
        <!--begin::Button-->
        <a href="#" data-toggle="modal" data-target="#exampleModalSizeLg" class="btn btn-primary font-weight-bolder" onclick="javascript:fnOpenNew();">
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
            </span>New Record</a>
        <!--end::Button-->
        </div>
    </div>
    <!--end::Subheader-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <%--  <div class="datatable datatable-bordered datatable-head-custom" id="kt_datatable"></div>--%>



    <table class="table table-striped table-hover table-bordered" id="tbl-Designation-setup">
        <thead>
            <tr>
                <th>Designation</th>
                <th></th>
                <th></th>

            </tr>
        </thead>
        <tbody id="tbdDesignationList">
        </tbody>
    </table>

    <!--begin::Modal-->
    <div class="modal fade" id="exampleModalSizeLg" tabindex="-1" role="dialog" aria-labelledby="exampleModalSizeLg" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel"><span id="spnDesignation"></span></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <i aria-hidden="true" class="ki ki-close"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <!--begin::Group-->
                    <div class="form-group row">
                        <label id="lblName" style="text-align: left" class="col-xl-3 col-lg-3 col-form-label">Designation <sup class="text-danger">*</sup></label>
                        <div class="col-lg-9 col-xl-9">
                            <input id="txtDesignationName" placeholder="Enter name" class="form-control form-control-solid form-control-lg" name="name" type="text" value="" onkeypress="javascript:fnRemoveClass(this,'Name');" autocomplete="off" maxlength="100" />
                            <input id="txtDesignationId" type="hidden" value="0" />
                        </div>
                    </div>
                    <!--end::Group-->

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-light-primary font-weight-bold" data-dismiss="modal" onclick="javascript:fnCloseModal();">Close</button>
                    <button type="button" class="btn btn-primary font-weight-bold" onclick="javascript:fnSaveDesignation();">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <!--end::Modal-->
    <!--begin::Modal-->
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
                    <input value="YES" id="btnDeleteConfirm" data-dismiss="modal" class="btn red" onclick="DeleteDesignation()" type="submit" />
                </div>
            </div>
        </div>
    </div>
    <!--end::Modal-->
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <%--    <script src="js/CreateDoc.js?<%=DateTime.Now %>"></script>--%>
    <%--  <script src="assets/global/scripts/datatable.js"></script>
        <script src="assets/global/scripts/datatable.min.js"></script>--%>


    <script src="js/Designation.js"></script>
</asp:Content>
