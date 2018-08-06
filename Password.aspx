<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Password.aspx.vb" Inherits="MainProgram.Password" MasterPageFile="~/Site1.Master"  EnableEventValidation="false" EnableViewState="true"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>User 
       
                <small>Profile</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="UserProject.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a href="#">Password</a></li>
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
                            <div class="col-lg-6 col-md-12 col-md-offset-2">
                                 <div class="box-body">   

                              <div class="form-group">
                                <div class="col-xs-3">
                                    <div class="controls ">
                                    <input class="form-control" placeholder="Searchfrom" runat="server" id="Text1"/>
                                          </div>

                                </div>

                                <div class="col-xs-6">
                                    <div class="controls">
                                          <asp:DropDownList ID="ddlSearchU" runat="server" class="form-control select2" DataTextField = "Name" DataValueField = "UserId" AutoPostBack="true"></asp:DropDownList>
                
<%--                                        <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" placeholder="InputData"></asp:TextBox>--%>
                                    </div>
                                </div>

                                <div class="col-xs-3">
                                    <div class="controls">
                                        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click" EnableTheming="True"/>
                                    </div>
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
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class=" col-xs-12">
                    <div class="box">

                        <!-- /.box-header -->
                        <div class="box-body">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="example1" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>รหัสพนักงาน</th>
                                                <th>ชื่อ - นามสกุล</th>
                                                <th>รหัสผ่าน</th>
                                                <th>Edit</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>

                                <ItemTemplate>

                                    <tr>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserId")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Name")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblPassword" runat="server"></asp:Label></td>
                                 
                                        <td class="text-center">

                                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="editPass" CommandArgument='<%# Eval("UserId")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                        </td>

                                    </tr>


                                </ItemTemplate>

                                <FooterTemplate>
                                    <tfoot>
                                        <tr>
                                                <th>รหัสพนักงาน</th>
                                                <th>ชื่อ - นามสกุล</th>
                                                <th>รหัสผ่าน</th>
                                                <th>Edit</th>
                                        </tr>
                                    </tfoot>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <!-- /.box-body -->

                        <!-- /.box -->
                    </div>
                </div>
            </div>
        </section>


        <!-- Main content -->


    </form>
    
</asp:Content>
