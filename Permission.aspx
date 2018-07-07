<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Permission.aspx.vb" Inherits="MainProgram.Permission" EnableEventValidation="false" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="form-horizontal">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <section class="content-header">
            <h1>Permission</h1>
            <ol class="breadcrumb">
                <li><a href="UserProject.aspx"><i class="fa fa-home"></i>Home</a></li>
                <li><a class="active">Pro File</a></li>
                <li>Permission</li>
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
                            <h3 class="box-title">Edit Permission</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="row">

                            <form class="form-horizontal">
                            <div class="col-lg-6 col-md-12 col-md-offset-3">
                                 <div class="box-body">   

                              
                                   <div class="col-lg-8 col-sm-12">
                                    
                                         <div class="form-group">
                                             <div class="col-lg-8 col-sm-6 col-xs-6">
                                                   <asp:TextBox ID="txtSearchUser" CssClass="form-control" runat="server" placeholder="UserID" autocomplete="off"></asp:TextBox>
                                             </div>
                                           <div class="col-lg-2 col-sm-6 col-xs-6">
                                                   <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search UserID" />
                                                
                                           </div>
                                       
                                       </div>
                          
                        </div>
                      
                    <div class="col-lg-8 col-sm-10 ">

   
                        <div class="form-group">
                            <div class="col-lg-8 col-sm-8 col-xs-6">
                                <asp:DropDownList ID="ddlCopyUser" runat="server" CssClass="form-control"> </asp:DropDownList>  
                            </div>
                               <div class="col-lg-2 col-sm-6 col-xs-6">
                                  
                                   <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Copy From User" />
                      
                               </div>
                            
                         
                        </div>
                        <div class="form-group text-center ">
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            </div>
                    </div>
                    </div>              
            </div>
  
            
            <div class="form-group col-md-12">

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" Font-Size="Small" HorizontalAlign="Center" Width="673px" DataKeyNames="Menu"
                    OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="Menu" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblMenu" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center"></HeaderStyle>
                            <ItemStyle Width="250px" Height="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center"></HeaderStyle>
                            <ItemStyle Width="250px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList>
                            </EditItemTemplate>

                            <HeaderStyle CssClass="text-center" />
                            <ItemStyle Width="80px" CssClass="text-center" />
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Link" ShowEditButton="True">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />

                </asp:GridView>
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

            <!--/.col (right) -->

            <!-- /.row -->
        </section>
        <!-- /.content -->

    </form>
</asp:Content>
