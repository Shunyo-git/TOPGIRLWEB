<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StoreDetail.aspx.cs" Inherits="StoreDetail" %>

<html xmlns="http://www.w3.org/1999/xhtml">
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
            <table width="447" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="38">
                                    <img src="img/location/north.gif" width="45" height="24" /></td>
                            </tr>
                            <tr>
                                <td background="img/location/locatitle_bg.gif">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                        <tr>
                                            <td width="10">
                                                &nbsp;</td>
                                            <td width="133">
                                                店名</td>
                                            <td width="8">
                                                │</td>
                                            <td width="92">
                                                電話</td>
                                            <td width="8">
                                                │</td>
                                            <td width="196">
                                                店址</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DataList ID="DataListArea_1" runat="server" ShowFooter="False" ShowHeader="False"
                                        Width="100%">
                                        <ItemTemplate>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                <tr>
                                                    <td  width="10">
                                                        &nbsp;</td>
                                                    <td width="133">
                                                        <%# DataBinder.Eval(Container.DataItem,"StoreName")%>
                                                    </td>
                                                    <td  width="8">
                                                        &nbsp;</td>
                                                    <td  width="92">
                                                        <%# DataBinder.Eval(Container.DataItem,"Tel")%>
                                                    </td>
                                                    <td width="8">
                                                        &nbsp;</td>
                                                    <td width="196">
                                                        <%# DataBinder.Eval(Container.DataItem,"Address")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td height="7" colspan="5">
                                                        <img src="img/location/line.gif" width="415" height="5" /></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                            <tr>
                                <td height="38">
                                    <img src="img/location/midland.gif" width="45" height="24" /></td>
                            </tr>
                            <tr>
                                <td background="img/location/locatitle_bg.gif">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                        <tr>
                                            <td width="10">
                                                &nbsp;</td>
                                            <td width="133">
                                                店名</td>
                                            <td width="8">
                                                │</td>
                                            <td width="92">
                                                電話</td>
                                            <td width="8">
                                                │</td>
                                            <td width="196">
                                                店址</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                     <asp:DataList ID="DataListArea_2" runat="server" ShowFooter="False" ShowHeader="False"
                                        Width="100%">
                                        <ItemTemplate>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                <tr>
                                                    <td  width="10">
                                                        &nbsp;</td>
                                                    <td width="133">
                                                        <%# DataBinder.Eval(Container.DataItem,"StoreName")%>
                                                    </td>
                                                    <td  width="8">
                                                        &nbsp;</td>
                                                    <td  width="92">
                                                        <%# DataBinder.Eval(Container.DataItem,"Tel")%>
                                                    </td>
                                                    <td width="8">
                                                        &nbsp;</td>
                                                    <td width="196">
                                                        <%# DataBinder.Eval(Container.DataItem,"Address")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td height="7" colspan="5">
                                                        <img src="img/location/line.gif" width="415" height="5" /></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                            <tr>
                                <td height="38">
                                    <img src="img/location/south.gif" width="45" height="24" /></td>
                            </tr>
                            <tr>
                                <td background="img/location/locatitle_bg.gif">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                        <tr>
                                            <td width="10">
                                                &nbsp;</td>
                                            <td width="133">
                                                店名</td>
                                            <td width="8">
                                                │</td>
                                            <td width="92">
                                                電話</td>
                                            <td width="8">
                                                │</td>
                                            <td width="196">
                                                店址</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                     <asp:DataList ID="DataListArea_3" runat="server" ShowFooter="False" ShowHeader="False"
                                        Width="100%">
                                        <ItemTemplate>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                <tr>
                                                    <td  width="10">
                                                        &nbsp;</td>
                                                    <td width="133">
                                                        <%# DataBinder.Eval(Container.DataItem,"StoreName")%>
                                                    </td>
                                                    <td  width="8">
                                                        &nbsp;</td>
                                                    <td  width="92">
                                                        <%# DataBinder.Eval(Container.DataItem,"Tel")%>
                                                    </td>
                                                    <td width="8">
                                                        &nbsp;</td>
                                                    <td width="196">
                                                        <%# DataBinder.Eval(Container.DataItem,"Address")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td height="7" colspan="5">
                                                        <img src="img/location/line.gif" width="415" height="5" /></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
