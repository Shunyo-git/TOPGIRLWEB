<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Download.aspx.cs" Inherits="Download"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50" >
                            <img src="/img/download/title.gif" width="501" height="65" /></td>
                        <td width="280" >
                            &nbsp;</td>
                        <td valign="bottom" class="white11" >
                           
                                <asp:LinkButton ID="LbtnDesktop" runat="server" OnClick="LbtnDesktop_Click">桌布下載</asp:LinkButton> | 
                            <asp:LinkButton ID="LbtnScreen" runat="server" OnClick="LbtnScreen_Click">螢幕保護程式</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="62" height="401">
                            &nbsp;</td>
                        <td width="862" background="/img/download/content_bg.gif">
                            <asp:Panel ID="PanelDesktop" runat="server">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3">
                                            <img src="/img/download/upframe.gif" width="862" height="10" /></td>
                                    </tr>
                                    <tr>
                                        <td width="12">
                                            <img src="/img/download/leftframe.gif" width="12" height="380" /></td>
                                        <td width="838">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td colspan="3">
                                                        <img src="download/desktop/1_Thumb.jpg" width="199" height="149" /></td>
                                                    <td width="13" rowspan="5">
                                                        &nbsp;</td>
                                                    <td colspan="3">
                                                        <img src="download/desktop/2_Thumb.jpg" width="199" height="149" /></td>
                                                    <td width="13" rowspan="5">
                                                        &nbsp;</td>
                                                    <td colspan="3">
                                                        <img src="download/desktop/3_Thumb.jpg" width="199" height="149" /></td>
                                                    <td width="13" rowspan="5">
                                                        &nbsp;</td>
                                                    <td colspan="3">
                                                        <img src="download/desktop/4_Thumb.jpg" width="199" height="149" /></td>
                                                </tr>
                                                <tr>
                                                    <td width="97" height="25" class="white11">
                                                        1204x768 <a href="download/desktop/1_1024_768.jpg" target="_blank">下載</a></td>
                                                    <td width="5" class="white11">
                                                        |</td>
                                                    <td width="97" align="right" class="white11">
                                                        800x600 <a href="download/desktop/1_800_600.jpg" target="_blank">下載</a></td>
                                                    <td height="25" class="white11">
                                                        1204x768 <a href="download/desktop/2_1024_768.jpg" target="_blank">下載</a></td>
                                                    <td class="white11">
                                                        |</td>
                                                    <td align="right" class="white11">
                                                        800x600 <a href="download/desktop/2_800_600.jpg" target="_blank">下載</a></td>
                                                    <td height="25" class="white11">
                                                        1204x768 <a href="download/desktop/3_1024_768.jpg" target="_blank">下載</a></td>
                                                    <td class="white11">
                                                        |</td>
                                                    <td align="right" class="white11">
                                                        800x600 <a href="download/desktop/3_800_600.jpg" target="_blank">下載</a></td>
                                                    <td height="25" class="white11">
                                                        1204x768 <a href="download/desktop/4_1024_768.jpg" target="_blank">下載</a></td>
                                                    <td class="white11">
                                                        |</td>
                                                    <td align="right" class="white11">
                                                        800x600 <a href="download/desktop/4_800_600.jpg" target="_blank">下載</a></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <img src="download/desktop/5_Thumb.jpg" width="199" height="149" /></td>
                                                    <td colspan="3">
                                                        <img src="download/desktop/6_Thumb.jpg" width="199" height="149" /></td>
                                                    <td colspan="3">
                                                        <img src="download/desktop/7_Thumb.jpg" width="199" height="149" /></td>
                                                    <td colspan="3">
                                                        <img src="download/desktop/8_Thumb.jpg" width="199" height="149" /></td>
                                                </tr>
                                                <tr>
                                                    <td width="97" height="25" class="white11">
                                                        1204x768 <a href="download/desktop/5_1024_768.jpg" target="_blank">下載</a></td>
                                                    <td width="5" class="white11">
                                                        |</td>
                                                    <td width="97" align="right" class="white11">
                                                        800x600 <a href="download/desktop/5_800_600.jpg" target="_blank">下載</a></td>
                                                    <td height="25" class="white11">
                                                        1204x768 <a href="download/desktop/6_1024_768.jpg" target="_blank">下載</a></td>
                                                    <td class="white11">
                                                        |</td>
                                                    <td align="right" class="white11">
                                                        800x600 <a href="download/desktop/6_800_600.jpg" target="_blank">下載</a></td>
                                                    <td height="25" class="white11">
                                                        1204x768 <a href="download/desktop/7_1024_768.jpg" target="_blank">下載</a></td>
                                                    <td class="white11">
                                                        |</td>
                                                    <td align="right" class="white11">
                                                        800x600 <a href="download/desktop/7_800_600.jpg" target="_blank">下載</a></td>
                                                    <td height="25" class="white11">
                                                        1204x768 <a href="download/desktop/8_1024_768.jpg" target="_blank">下載</a></td>
                                                    <td class="white11">
                                                        |</td>
                                                    <td align="right" class="white11">
                                                        800x600 <a href="download/desktop/8_800_600.jpg" target="_blank">下載</a></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="12">
                                            <img src="/img/download/rightframe.gif" width="12" height="380" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <img src="/img/download/deframe.gif" width="862" height="11" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="PanelScreen" runat="server" Visible="False">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3">
                                            <img src="/img/download/upframe.gif" width="862" height="10" /></td>
                                    </tr>
                                    <tr>
                                        <td width="12">
                                            <img src="/img/download/leftframe.gif" width="12" height="380" /></td>
                                        <td width="838">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="width: 199px; height: 149px">
                                                        <asp:Image ID="imgScreen1" runat="server" Height="149px" ImageUrl="download/screen/sc_1.jpg"
                                                            Width="199px" /></td>
                                                    <td width="13" rowspan="5">
                                                        &nbsp;</td>
                                                    <td style="width: 199px; height: 149px">
                                                        <asp:Image ID="imgScreen2" runat="server" Height="149px" ImageUrl="download/screen/sc_2.jpg"
                                                            Width="199px" /></td>
                                                    <td width="13" rowspan="5">
                                                        &nbsp;</td>
                                                    <td style="width: 199px; height: 149px">
                                                        <asp:Image ID="imgScreen3" runat="server" Height="149px" ImageUrl="download/screen/sc_3.jpg"
                                                            Width="199px" /></td>
                                                    <td width="13" rowspan="5">
                                                        &nbsp;</td>
                                                    <td style="width: 199px; height: 149px">
                                                        <asp:Image ID="imgScreen4" runat="server" Height="149px" ImageUrl="download/screen/sc_4.jpg"
                                                            Width="199px" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="25" align="right" class="white11">
                                                        <asp:Label ID="lblScnLink1" runat="server">螢幕保護程式 <a href="download/screen/sc_1.exe">下載</a></asp:Label></td>
                                                    <td height="25" align="right" class="white11">
                                                        <asp:Label ID="lblScnLink2" runat="server">螢幕保護程式 <a href="download/screen/sc_2.exe">下載</a></asp:Label></td>
                                                    <td height="25" align="right" class="white11">
                                                        <asp:Label ID="lblScnLink3" runat="server">螢幕保護程式 <a href="download/screen/sc_3.exe">下載</a></asp:Label></td>
                                                    <td height="25" align="right" class="white11">
                                                        <asp:Label ID="lblScnLink4" runat="server">螢幕保護程式 <a href="download/screen/sc_4.exe">下載</a></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 199px; height: 149px">
                                                        <asp:Image ID="imgScreen5" runat="server" Height="149px" ImageUrl="download/screen/sc_5.jpg"
                                                            Width="199px" /></td>
                                                    <td style="width: 199px; height: 149px">
                                                        <asp:Image ID="imgScreen6" runat="server" Height="149px" ImageUrl="download/screen/sc_6.jpg"
                                                            Width="199px" /></td>
                                                    <td style="width: 199px; height: 149px">
                                                        <asp:Image ID="imgScreen7" runat="server" Height="149px" ImageUrl="download/screen/sc_7.jpg"
                                                            Width="199px" /></td>
                                                    <td>
                                                        <asp:Image ID="imgScreen8" runat="server" Height="149px" ImageUrl="download/screen/sc_8.jpg"
                                                            Width="199px" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="25" align="right" class="white11">
                                                        <asp:Label ID="lblScnLink5" runat="server">螢幕保護程式 <a href="download/screen/sc_5.exe">下載</a></asp:Label></td>
                                                    <td height="25" align="right" class="white11">
                                                        <asp:Label ID="lblScnLink6" runat="server">螢幕保護程式 <a href="download/screen/sc_6.exe">下載</a></asp:Label></td>
                                                    <td height="25" align="right" class="white11">
                                                        <asp:Label ID="lblScnLink7" runat="server">螢幕保護程式 <a href="download/screen/sc_7.exe">下載</a></asp:Label></td>
                                                    <td height="25" align="right" class="white11">
                                                        <asp:Label ID="lblScnLink8" runat="server">螢幕保護程式 <a href="download/screen/sc_8.exe">下載</a></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="12">
                                            <img src="/img/download/rightframe.gif" width="12" height="380" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <img src="/img/download/deframe.gif" width="862" height="11" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
