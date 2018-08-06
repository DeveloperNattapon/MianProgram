<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AddUser.aspx.vb" Inherits="MainProgram.AddUser" EnableEventValidation="false" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="form-horizontal">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <section class="content-header">
            <h1>Add User
            </h1>
            <ol class="breadcrumb">
                <li><a href="UserProject.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active"><i class="fa fa-file"></i>Pro File</a></li>
                <li><a href="AddUser.aspx">Add User</a></li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->
                <div class="col-lg-12 col-md-12 ">

                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add User Profile</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="row">

                            <form class="form-horizontal">
                                <div class="col-lg-6 col-md-6 col-md-offset-3">
                                    <div class="box-body">

                                        <div class="form-group">
                                            <div class="col-xs-12">
                                                <label class="control-label " for="txtUserId">UserId</label>
                                                <div class="controls ">

                                                    <input class="form-control" id="txtUser" runat="server" required="required" type="text" />
                                                </div>

                                            </div>



                                            <div class="col-xs-3">
                                                <label class="control-label" for="txtPrefix_thai">คำนำหน้า</label>
                                                <div class="controls ">

                                                    <asp:DropDownList ID="ddlPrefix" CssClass="form-control" runat="server">
                                                        <asp:ListItem> </asp:ListItem>
                                                        <asp:ListItem>นาย</asp:ListItem>
                                                        <asp:ListItem>นาง</asp:ListItem>
                                                        <asp:ListItem>นางสาว</asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>

                                                <label class="control-label" for="ddlPrefix_Eng">Name Title</label>
                                                <div class="controls ">
                                                    <asp:DropDownList ID="ddlPrefix_Eng" runat="server" CssClass="form-control">
                                                        <asp:ListItem> </asp:ListItem>
                                                        <asp:ListItem>Mr</asp:ListItem>
                                                        <asp:ListItem>Mrs</asp:ListItem>
                                                        <asp:ListItem>Miss</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>



                                            <div class="col-xs-5">

                                                <label class="control-label" for="txtName_thai">ชื่อ-ไทย</label>
                                                <div class="controls ">
                                                    <input class="form-control" id="txtNameThai" required="required" runat="server" type="text" />
                                                </div>

                                                <label class="control-label" for="txtName_eng">First name</label>
                                                <div class="controls ">
                                                    <input class="form-control" id="txtNameEng" runat="server" type="text" />
                                                </div>

                                            </div>
                                            <div class="col-xs-4">

                                                <label class="control-label" for="txtSurname_thai">นามสกุล</label>
                                                <div class="controls ">

                                                    <input class="form-control" id="txtSurnameThai" required="required" runat="server" type="text" />
                                                </div>


                                                <label class="control-label" for="txtSurname_eng">Surname</label>
                                                <div class="controls ">

                                                    <input class="form-control" id="txtSurnameEng" runat="server" type="text" />
                                                </div>

                                            </div>
                                            <div class="col-xs-12">
                                                <label class="control-label" for="txtEmail">อีเมล</label>
                                                <div class="controls ">
                                                    <input class="form-control" id="txtEmaile" runat="server" type="text" />
                                                </div>

                                                <label class="control-label" for="ddlBranch">สาขา</label>
                                                <div class="controls dropdown ">
                                                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control select2" DataTextField="BranchName" DataValueField="BranchName"></asp:DropDownList>
                                                </div>
                                                <label class="control-label" for="txtDept">ฝ่าย</label>
                                                <div class="controls ">
                                                    <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control select2" DataTextField="SideName" DataValueField="SideName"></asp:DropDownList>
                                                </div>

                                                <label class="control-label" for="txtDept">แผนก</label>
                                                <div class="controls ">
                                                    <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control select2" DataTextField="DepartmentName" DataValueField="DepartmentName" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>

                                                <label class="control-label" for="txtPosition">ตำแหน่ง</label>
                                                <div class="controls ">
                                                    <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control select2" DataTextField="PositionName" DataValueField="PositionName"></asp:DropDownList>
                                                </div>

                                                <label class="control-label" for="txtStatus">สถานะ</label>
                                                <div class="controls ">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2" DataTextField="StatusName" DataValueField="StatusID"></asp:DropDownList>
                                                </div>

                                                <label class="control-label " for="txtPassword">รหัสผ่าน</label>
                                                <div class="controls ">
                                                    <input class="form-control" id="txtPassworde" required="required" runat="server" type="password" />
                                                </div>

                                            </div>
                                        </div>

                                        <div class="form-group span9">
                                            <div class="text-center">
                                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                                                <input id="Reset1" class="btn" type="reset" value="Reset" />&nbsp;&nbsp;
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </form>

                            <!--/.row-->
                        </div>


                        <!--/.row-->
                    </div>

                    <!--/.box box-primary-->
                </div>
                <!--/.col-lg-12 -->
            </div>

            <!--/.col (right) -->

            <!-- /.row -->
        </section>
        <!-- /.content -->
    </form>
</asp:Content>
