<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="SearchUser.aspx.vb" Inherits="MainProgram.SearchUser" EnableEventValidation = "false" EnableViewState="true"%>


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
                <li><a href="#">SearchUser</a></li>
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
                                <div class="form-group">
                                    <div class="col-xs-3 col-sm-1">
                                       <%-- <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Add User"/>--%>
                                     
                                        <button type="submit" runat="server" class="btn btn-primary" id="btnSave" title="btnSave" onserverclick="btnAdd_Click"><i class="fa fa-plus"></i> AddUser</button>
                                    </div>
                                </div>
                                <%--<div style="text-align:right;" ">
                                <   label>Search:<input type="search" class="form-control input-sm" placeholder="UserID" aria-controls="example1"/></label>
                           </div>--%>
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
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <HeaderTemplate>
                                    <table id="example1" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>รหัสพนักงาน</th>
                                                <th>ชื่อ</th>
                                                <th>นามสกุล</th>
                                                <th>อีเมล์</th>
                                                <th>สาขา</th>
                                                <th>ฝ่าย</th>
                                                <th>แผนก</th>
                                                <th>ตำแหน่ง</th>
                                                <th>Edit</th>

                                            </tr>
                                        </thead>
                                </HeaderTemplate>

                                <ItemTemplate>

                                    <tr>

                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserId")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Name_thai")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Surname_thai")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Email") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Branch")%>'></asp:Label></td>
                                         <td>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Section")%>'></asp:Label></td>
                                          <td>
                                            <asp:Label ID="Labelsec" runat="server" Text='<%# Bind("Dept")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Position")%>'></asp:Label></td>
                                      
                                        <td class="text-center">

                                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="edituser" CommandArgument='<%# Eval("UserId")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
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
                                                <th>สาขา</th>
                                                <th>ฝ่าย</th>
                                                <th>แผนก</th>
                                                <th>ตำแหน่ง</th>
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
    <script type='text/javascript'>
        function openModal() {
            $('#myModal').modal('show');
        }
        //Sys.Application.add_load(function () {
        //    $('#myModal').modal('show');
        //});
    </script>
</asp:Content>
