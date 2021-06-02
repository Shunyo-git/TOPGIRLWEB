<%@ Control Language="C#" AutoEventWireup="true" CodeFile="inc_Category_Left.ascx.cs"
    Inherits="Template_inc_Category_Left" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:DataList ID="DataListCategory" runat="server" ShowFooter="False" ShowHeader="False"
                Width="100%">
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" height="18" width="164">
                        <tr>
                            <td height="5">
                            </td>
                        </tr>
                        <tr>
                            <td background="/img/product/menu_bg.gif">
                                <table border="0" cellpadding="0" cellspacing="0" class="white12" width="100%">
                                    <tr>
                                        <td align="right">
                                            <a href='/ProductList.aspx?CategoryID=<%# TopGirl.Web.WebUtility.ToBase64String(Convert.ToString(DataBinder.Eval(Container.DataItem,"ID")))%>'>
                                                <%# DataBinder.Eval(Container.DataItem,"Name")%>
                                            </a>
                                        </td>
                                        <td width="25">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
