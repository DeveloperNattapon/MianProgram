<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditPassword.aspx.vb" Inherits="MainProgram.EditPassword" MasterPageFile="~/Site1.Master" EnableEventValidation="false" EnableViewState="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>User 
       
                <small>Edit Password</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="UserProject.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a href="#"><i class="active"></i>Password</a></li>
                <li><a href="#">Edit Password</a></li>
            </ol>
        </section>

        <!-- Main content -->
        <section class="centered">
            <div class="row">
                <div class=" col-xs-12">
                    <!-- general form elements -->
                    <div class="box box-primary">
                        <!-- /.box-header -->

                        <div class="box-header">

                            <form class="form-horizontal">
                                <div class="col-lg-8 col-md-12 col-md-offset-3">
                                    <div class="box-body">

                                        <div class="form-group">
                                            <div class="col-xs-8">
                                                <label class="control-label " for="txtPassword">รหัสผ่านเดิม</label>
                                                <div class="controls ">

                                                    <input class="form-control" runat="server" id="txtPass" type="password"/>
                                                </div>

                                            </div>



                                            <div class="col-xs-8">
                                              <label class="control-label " for="txtPassword">รหัสผ่านใหม่</label>
                                                <div class="controls ">
                                                    <input class="form-control" id="txtPasswordeName" required="required" runat="server" type="password" />
                                                </div>
                                            </div>
                                       </div>
                                        <div class="form-group span9">
                                            <div class="text-center">
                                                 <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Edit" OnClick="btnEdit_Click" EnableTheming="True" />
                                            </div>
                                        </div>
                         
                                    </div>
                                </div>
                            </form>


                            <!--/.row-->
                        </div>


                        <!-- /.box -->

                    </div>

                    <!--/.row-->
                </div>
                <!-- /.box -->
            </div>

        </section>


    </form>
</asp:Content>
