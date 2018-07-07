<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Increase.aspx.vb" Inherits="MainProgram.Increase" MasterPageFile="~/Site1.Master" EnableEventValidation="false" EnableViewState="true"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

           <section class="content-header">
            <h1>Increase</h1>
            <ol class="breadcrumb">
                <li><a href="UserProject.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li>Increase</li>
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
                            <h3 class="box-title">Edit Increase</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="row">

                            <form class="form-horizontal">
                            <div class="col-lg-6 col-md-12 col-md-offset-3">
                                 <div class="box-body">   

                              <div class="form-group">
                                <div class="col-xs-3">
                                    <label class="control-label">สาขา</label>
                                    <div class="controls ">
                                    <input class="form-control" runat="server" id="Text1" disabled="disabled"/>
                                          </div>

                                    <label class="control-label">เลือกสาขา</label>
                                    <div class="controls ">
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" DataTextField="BranchName" DataValueField="BranchID"></asp:DropDownList>
                                    </div>
                                    <label class="control-label">เลือกฝ่าย</label>
                                    <div class="controls ">
                                        <asp:DropDownList ID="ddlSide" runat="server" CssClass="form-control" DataTextField="SideName" DataValueField="SideID"></asp:DropDownList>
                                    </div>
                                    <label class="control-label">เลือกแผนก</label>
                                    <div class="controls ">
                                        <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control" DataTextField="DepartmentName" DataValueField="DepartmentID"></asp:DropDownList>
                                    </div>

                                </div>



                                <div class="col-xs-6">

                                    <label class="control-label" for="txtBranch">สาขา</label>
                                    <div class="controls ">
                                        <input class="form-control" runat="server" id="txtBranch" />
                                    </div>

                                    <label class="control-label" for="txtside">ฝ่าย</label>
                                    <div class="controls ">
                                        <input class="form-control" runat="server" id="txtside" />
                                    </div>
                                     <label class="control-label" for="txtdepartment">แผนก</label>
                                    <div class="controls ">
                                         <input class="form-control" runat="server" id="txtdepartment" />
                                    </div>
                                     <label class="control-label" for="txtside">ตำแหน่ง</label>
                                    <div class="controls ">
                                        <input class="form-control" runat="server" id="txtPosition" />
                                    </div>
                                </div>
                                <div class="col-xs-3">

                                    <label class="control-label" for="txtSurname_thai">'</label>
                                    <div class="controls ">
                                        <asp:Button ID="btnBranch" CssClass="btn btn-primary" runat="server" Text="บันทึกสาขา" OnClick="btnBranch_Click" />
                                    </div>


                                    <label class="control-label" for="txtSurname_eng">'</label>
                                    <div class="controls ">

                                        <asp:Button ID="btnSide" CssClass="btn btn-primary" runat="server" Text="บันทึกฝ่าย" OnClick="btnside_Click" />
                                    </div>
                                    <label class="control-label" for="txtSurname_eng">'</label>
                                    <div class="controls ">

                                       <asp:Button ID="btndepartment" CssClass="btn btn-primary" runat="server" Text="บันทึกแผนก" OnClick="btndepartment_Click" />
                                    </div>
                                     <label class="control-label" for="txtSurname_eng">'</label>
                                    <div class="controls ">

                                     <asp:Button ID="btnPosition" CssClass="btn btn-primary" runat="server" Text="บันทึกตำแหน่ง" OnClick="btnPosition_Click" />
                                    </div>
                                </div>
                            </div>
                             
               </div>
                            </div>
                             
          </form>
                                     
                        </div>
                    
                            <!--/.row-->
                    </div>


                    <!--/.row-->
                </div>

                <!--/.box box-primary-->
            </div>
            <!--/.col-lg-12 -->
     
            <!--/.col (right) -->

            <!-- /.row -->
        </section>
        <!-- /.content -->

         <!-- Main content -->
        <section class="content">

            <div class="row">
                <!-- left column -->
                <div class="col-lg-12 col-md-12 ">

                    <!-- general form elements -->
                    <div class="box box-primary">
                  <%--      <div class="box-header with-border">
                            <h3 class="box-title">Edit Permission</h3>
                        </div>--%>
                        <!-- /.box-header -->
                        <div class="row">

                            <form class="form-horizontal">
                            <div class="col-lg-12 col-md-12">
                                 <div class="box-body">   

                          <div class="col-md-12">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <HeaderTemplate>
                                    <table id="example1" class="table table-bordered table-hover">
                                        <thead>
                                            <tr>
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
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("BranchName")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("SideName")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("DepartmentName")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("PositionName")%>'></asp:Label></td>
                                        
                                        <td class="text-center">

                                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="edituser" CommandArgument='<%# Eval("BranchName")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                        </td>

                                    </tr>

                                </ItemTemplate>

                                <FooterTemplate>
                                    <tfoot>
                                        <tr>
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
                             
               </div>
                            </div>
                             
          </form>
                                     
                        </div>
                    
                            <!--/.row-->
                    </div>


                    <!--/.row-->
                </div>

                <!--/.box box-primary-->
            </div>
            <!--/.col-lg-12 -->
     
            <!--/.col (right) -->

            <!-- /.row -->
        </section>
        <!-- /.content -->
    </form>
</asp:Content>
