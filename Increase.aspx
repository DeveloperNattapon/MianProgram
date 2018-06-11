<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Increase.aspx.vb" Inherits="MainProgram.Increase" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-offset-2">
                    <fieldset>
                        <legend>Increase
                        </legend>
                        <div class="col-lg-12">

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

                    </fieldset>

                </div>
                </div>
                <br />
                <br />
                <br />
              
                <div class="form-group col-md-12">
                <asp:UpdatePanel ID="UpModal" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="BranchName" Width="1090px" ForeColor="Black"  HorizontalAlign="Center" Font-Size="Small" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                            <AlternatingRowStyle CssClass="altrowstyle" BackColor="#CCCCCC" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle CssClass="headerstyle" BackColor="Black" Font-Bold="True" ForeColor="White" Height="30px" />
                            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First " LastPageText=" Last" NextPageText="Next " PreviousPageText=" Previous " />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" Height="20px" />
                            <RowStyle CssClass="rowstyle" HorizontalAlign="Center" Height="20px" />
                            <Columns>
                                <asp:TemplateField HeaderText="สาขา" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("BranchName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ฝ่าย" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("SideName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="แผนก" HeaderStyle-CssClass="text-center">

                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DepartmentName")%>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ตำแหน่ง" HeaderStyle-CssClass="text-center">

                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PositionName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center" />
                                    <ItemStyle Width="250px" />
                                </asp:TemplateField>
                                
                            </Columns>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </form>
</asp:Content>
