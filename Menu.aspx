<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Menu.aspx.vb" Inherits="MainProgram.Menu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="form-horizontal">
            <div class ="col-lg-12 col-md-12">
                
                <div class="col-lg-6 col-md-6">
                    <div class="form-group">
                          <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Add Menu" />
                    </div>
                     
               </div>
           
            
                <div class="col-md-12 col-lg-12">
                    <div class="form-group">
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Font-Size="Small" HorizontalAlign="Center" Width="834px" DataKeyNames="Menu"
                    OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Menu" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblMenu" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center"></HeaderStyle>
                            <ItemStyle Width="250px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center"></HeaderStyle>
                            <ItemStyle Width="250px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UserBy" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblUserBy" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center"></HeaderStyle>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UpdateDate" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Label ID="lblUpdateDate" runat="server"></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center"></HeaderStyle>

                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                </asp:GridView>
                </div>
                
            </div>
          </div>
           
        </div>
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
                                                <asp:TextBox ID="txtMenu" CssClass="input-sm" runat="server" Width="305px"></asp:TextBox>
                                                <asp:Label ID="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="txtDescription">Description</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtDescription" CssClass="input-sm" runat="server" Width="305px"></asp:TextBox>

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
