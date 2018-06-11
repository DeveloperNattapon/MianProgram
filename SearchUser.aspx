<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="SearchUser.aspx.vb" Inherits="MainProgram.SearchUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

         <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>User 
       
                <small>FroFile</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
                <li><a href="#">ProFile</a></li>
            </ol>
        </section>
           <div class="col-lg-12 col-md-12">
                   
                </div>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-header">        
                       <div class="form-group">
                       <div class="col-xs-3 col-sm-1">
                            <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Add User" />

                        </div> 
                        </div>
                          
                    </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <HeaderTemplate>
                                    <table id="example1" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>รหัสพนักงาน</th>
                                                <th>ชื่อ</th>
                                                <th>นามสกุล</th>
                                                <th>อีเมล์</th>
                                                <th>ตำแหน่ง</th>
                                                <th>แผนก</th>
                                                <th>ฝ่าย</th>
                                                <th>สาขา</th>
                                                <th>Edit</th>

                                            </tr>
                                        </thead>
                                </HeaderTemplate>

                                <ItemTemplate>


                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserId") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Name_thai")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Surname_thai")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Email") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Position") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Labelsec" runat="server" Text='<%# Bind("Dept")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Section") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Branch") %>'></asp:Label></td>
                                        <td class="text-center">

                                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="edituser" CommandArgument='<%# Eval("UserID")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                        </td>

                                    </tr>

                                </ItemTemplate>

                                <FooterTemplate>
                                    <tfoot>
                                        <tr>
                                            <th>รหัสพนักงาน</th>
                                            <th>ชื่อ</th>
                                            <th>นามสกุล</th>
                                            <th>อีเมล์</th>
                                            <th>ตำแหน่ง</th>
                                            <th>แผนก</th>
                                            <th>ฝ่าย</th>
                                            <th>สาขา</th>
                                            <th>Edit</th>
                                        </tr>
                                    </tfoot>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
            </div>

        </section>

    </form>
    <script type='text/javascript'>
        function openModal() {
            $('#myModal').modal('show');
        }
        //Sys.Application.add_load(function () {
        //    $('#myModal').modal('show');
        //});
    </script>
</asp:Content>