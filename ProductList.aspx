<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<%@ Register Src="Template/inc_Category_Left.ascx" TagName="inc_Category_Left" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td background="/img/product/frame_head.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="186" height="58" background="/img/product/frame_head.gif">
                            <img src="/img/product/title.gif" width="186" height="58" /></td>
                        <td width="380">
                            <img src="/img/product/product_name.gif" width="380" height="58" id="imgCategoryTitle" runat="server" /></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td background="/img/product/bg_content.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="185" valign="top" class="productlightbg_menu">
                            <uc1:inc_Category_Left ID="Inc_Category_Left1" runat="server" />
                        </td>
                        <td width="1">
                            <img src="/img/product/midline.gif" width="1" height="429" /></td>
                        <td class="productlightbg_content">
                            <table border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td rowspan="5">
                                        <asp:DataList ID="dListProduct" RepeatColumns="6" RepeatDirection="Horizontal" runat="server">
                                            <ItemTemplate>
                                                <table border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="155" align="center" valign="top">
                                                            <table border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="100" height="150" align="center" valign="middle" background="/img/product/productlist_frame.gif">
                                                                        <table border="0" cellpadding="1" cellspacing="0">
                                                                            <tr>
                                                                                <td onmouseover="this.style.backgroundColor='#cc3366';" onmouseout="this.style.backgroundColor='';">
                                                                                    <a href='ProductDetail.aspx?ID=<%# TopGirl.Web.WebUtility.ToBase64String(Convert.ToString(DataBinder.Eval(Container.DataItem, "ID")))%>'>
                                                                                        <img src='/images/product/Thumb/<%# DataBinder.Eval(Container.DataItem, "FileName_Thumb")%>'
                                                                                            width="90" height="140" border="0" /></a></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="20">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="gray12b">
                                                            <strong>
                                                                <%# Convert.ToString(DataBinder.Eval(Container.DataItem, "SKU")).Replace("+", "｜").Replace(",", "｜").Replace(";", "｜")%>
                                                            </strong>
                                                        </td>
                                                        <td width="20">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td width="20">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList></td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td style="height: 37px">
                                        <table border="0" align="center" cellpadding="0" cellspacing="0" class="pink11_ff9b9b">
                                            <tr>
                                                <td  align="center" style="height: 18px">
                                                   
                                                     <asp:HyperLink ID="lnkFirst" runat="server">最前頁</asp:HyperLink>
                                        &nbsp;<asp:HyperLink ID="lnkPrev" runat="server">上一頁</asp:HyperLink>
                                        
                                        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>/<asp:Label ID="lblPageCount"
                                            runat="server"></asp:Label>
                                        <asp:HyperLink ID="lnkNext" runat="server">下一頁</asp:HyperLink>
                                        &nbsp;<asp:HyperLink ID="lnkLast" runat="server">最末頁</asp:HyperLink>
                                                    </td>
                                               
                                            </tr>
                                        </table>
                                       
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="10" background="/img/product/frame_de.gif">
            </td>
        </tr>
    </table>
</asp:Content>
