<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionDetail.aspx.cs" Inherits="PromotionDetail" %>

 

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Welcome to TOP GIRL</title>
    <link href="/css/topgirl.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body {
	background-image: url(/img/location/in_bg.gif);
	background-attachment: fixed;
	
}
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="540">
            <tr>
                <td height="50">
                    <table border="0" cellpadding="0" cellspacing="0" width="90%">
                        <tr>
                            <td class="white22" style="height: 25px" valign="bottom">
                                <asp:Label ID="lblSubTitle" runat="server"></asp:Label></td>
                            <td style="height: 25px" valign="bottom" width="10">
                                &nbsp;
                            </td>
                            <td class="white12" style="height: 25px" valign="bottom">
                                <asp:Label ID="lblReleaseDate" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="white12" height="207" valign="top">
                    <table id="TableEventImage" runat="server" align="right" border="0" cellpadding="0"
                        cellspacing="0" width="274">
                        <tr>
                            <td align="center" style="border-right: gray solid; border-top: gray solid; border-left: gray solid; border-bottom: gray solid;">
                                <asp:HyperLink ID="linkEventImage" runat="server" Target="_blank"><asp:Image ID="imgEvent" runat="server" Width="264" /></asp:HyperLink></td>
                        </tr>
                    </table>
                    <asp:Label ID="lblContent" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    </div>
    </form>
</body>
</html>
