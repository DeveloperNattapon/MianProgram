<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Menu.aspx.vb" Inherits="MainProgram.Menu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <section class="content-header">
            <h1>Menu</h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
                <li><a href="#">Menu</a></li>
            </ol>
        </section>

        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-header">        
                       <div class="form-group">
                       <div class="col-xs-3 col-sm-1">
                            <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Add Menu" />

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
                                                <th>Menu</th>
                                                <th>Description</th>
                                                <th>UserBy</th>
                                                <th>UpdateDate	</th>
                                                <th>Delete</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>

                                <ItemTemplate>


                                    <tr>
                                      
                                        <td>
                                            <asp:Label ID="lblMenu" runat="server" Text='<%# Bind("Menu")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblUserBy" runat="server" Text='<%# Bind("UserBy")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblUpdateDate" runat="server" Text='<%# Bind("UpdateDate")%>'></asp:Label></td>
                              
                                        <td class="text-center">

                                            <%--<asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="edituser" CommandArgument='<%# Eval("UserID")%>'><i class="fa fa-pencil"></i></asp:LinkButton>--%>
                                   
                                        <asp:LinkButton ID="lnkDelete" CssClass="btn btn-default" runat="server" CausesValidation="False" CommandName="Delete"> <i class="fa  fa-trash"></i></asp:LinkButton>
                                             </td>
                                    </tr>

                                </ItemTemplate>

                                <FooterTemplate>
                                    <tfoot>
                                        <tr>
                                                <th>Menu</th>
                                                <th>Description</th>
                                                <th>UserBy</th>
                                                <th>UpdateDate	</th>
                                                <th>Delete</th>
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
       
        <!-- Modal modal hind fade -->
        <div id="myModal" class="modal hind fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 id="myModalLabel">Add Menu</h3>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <fieldset>
                                    <div class=" form-horizontal">
                                        <div class="form-group">
                                            <label class=" col-sm-2  control-label" for="txtMenu">Menu</label>
                                            <div class="col-sm-10 ">
                                                <asp:TextBox ID="txtMenu" CssClass="form-control" runat="server" Width="305px"></asp:TextBox>
                                                 
                                                <asp:Label ID="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
                                             
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtDescription">Description</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" Width="305px"></asp:TextBox>
                                           
                                            </div>
                                        </div>

                                    </div>
                                </fieldset>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Close</button>
                                <asp:Button ID="btnSaveChange" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSaveChange_Click" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                            <asp:AsyncPostBackTrigger ControlID="btnSaveChange" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
    <script type='text/javascript'>
        function openModal() {
            $('#myModal').modal('show');
        }
        function hideModal() {
            $('#myModal').modal('hide');
        }
    </script>
</asp:Content>
