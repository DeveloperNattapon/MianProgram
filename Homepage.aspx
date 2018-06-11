<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Homepage.aspx.vb" Inherits="MainProgram.HomePage" %>

<link href="Content/css/bootstrap.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Eagles Air&Sea</title>

    <!-- Le styles -->

    <style type="text/css">
        .div {
            background-color: #FFCC66;
        }

        .bghp {
            background-color: #FFCC99;
        }

        .auto-style1 {
            text-align: center;
            background-color:#fde8a7;
        }

        .btn-logout {
            width: 100%;
            padding: 3px 20px !important;
            text-align: left !important;
        }
        .auto-style3 {
            text-align: center;
            background-color: #fde8a7;
            width: 199px;
        }
        .auto-style4 {
            text-align: center;
            font-size: 10pt;
        }
    </style>
</head>

<body class="bghp">
    <form id="form1" runat="server">
        <div class="div" style="text-align: center">
            <asp:Image ID="headermain" runat="server" ImageUrl="~/Images/headermain.png" Width="800px" align="center" />
        </div>
    
        <div class="div" style="text-align: center">
            <table style="height: 600px; width: 800px" align="center" class="bg table-bordered">
                <%--           <tr>
                    <td colspan="4" class="auto-style2">


                    </td>
                </tr>--%>
                <tr>
                    <td class="auto-style3">
                        <asp:ImageButton ID="iconus" runat="server" ImageUrl="~/Images/iconus.png" Width="120px" />
                        <br />
                        <br />
                        <asp:Image ID="textus" runat="server" ImageUrl="~/Images/textus.png" Width="140px" />
                    </td>
                    <td class="auto-style1">
                        <asp:Image ID="icondm" runat="server" ImageUrl="~/Images/icondm.png" Width="120px" />
                        <br />
                        <br />
                        <asp:Image ID="textdm" runat="server" ImageUrl="~/Images/textdm.png" Width="140px" />
                    </td>
                    <td class="auto-style1">
                        <asp:ImageButton ID="ImgMessenger" runat="server" ImageUrl="~/Images/iconms.png" Width="120px" />
                        <br />
                        <br />
                        <asp:Image ID="textms" runat="server" ImageUrl="~/Images/textms.png" Width="140px" />
                    </td>
                    <td class="auto-style1">
                        <asp:ImageButton ID="Imgehr" runat="server" ImageUrl="~/Images/iconhr.png" Width="120px" />
                        <br />
                        <br />
                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/texthr.png" Width="140px" />
                    </td>

                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:ImageButton ID="Imgreferal" runat="server" ImageUrl="~/Images/iconrf.png" Width="120px" />
                        <br />
                        <br />
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/textrf.png" Width="140px" />
                    </td>
                    <td class="auto-style1">
                        <asp:ImageButton ID="Imgewh" runat="server" ImageUrl="~/Images/iconwh.png" Width="120px" />
                        <br />
                        <br />
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/textwh.png" Width="140px" />
                    </td>
                    <td class="auto-style1">
                         <asp:ImageButton ID="Imageit" runat="server" ImageUrl="~/Images/iconit.png" Width="120px" />
                        <br />
                        <br />
                        <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/textit.png" Width="140px" />
                    </td>
                    <td class="auto-style1">
                        <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/iconcs.png" Width="120px" />
                        <br />
                        <br />
                        <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/textcs.png" Width="140px" />
                    </td>

                </tr>
            </table>
        </div>

    </form>
    <p  style="font-variant-ligatures: normal; font-variant-caps: normal; orphans: 2; widows: 2; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;" class="auto-style4">
        © COPYRIGHT 2017 BY IT Dept Eagles Air and Sea(Thailand) CO,. LTD. ALL RIGHT RESERVED </p>
</body>
</html>
