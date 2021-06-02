<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true"
    CodeFile="Desktop.aspx.cs" Inherits="Admin_Desktop" %>

<%@ Register Src="UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="input-warn-content"
        ValidationGroup="VGroup1" Width="758px" ForeColor="" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="input-warn-content"
        ValidationGroup="VGroup2" Width="758px" ForeColor="" />
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" CssClass="input-warn-content"
        ValidationGroup="VGroup3" Width="758px" ForeColor="" />
    <asp:Label ID="lblSuccess" runat="server" BorderStyle="Solid" CssClass="input-ok-content"
        Text="<li>上傳成功，桌布圖片已更新。</li>" Width="758px"></asp:Label>
    <table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" style="width: 758px">
                <b>桌布圖片設定</b></td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="width: 758px">
                
                
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td colspan="3">
                            <img height="149" src="/download/desktop/1_Thumb.jpg" width="199" /></td>
                        <td rowspan="5" width="13">
                            &nbsp;</td>
                        <td colspan="3">
                            <img height="149" src="/download/desktop/2_Thumb.jpg" width="199" /></td>
                        <td rowspan="5" width="13">
                            &nbsp;</td>
                        <td colspan="3">
                            <img height="149" src="/download/desktop/3_Thumb.jpg" width="199" /></td>
                        <td rowspan="5" width="13">
                            &nbsp;</td>
                        <td colspan="3">
                            <img height="149" src="/download/desktop/4_Thumb.jpg" width="199" /></td>
                    </tr>
                    <tr>
                        <td class="white11" height="25" >
                             <a href="/download/desktop/1_1024_768.jpg" target="_blank">1204x768</a></td>
                        <td class="ColumnTD">
                            圖片1</td>
                        <td align="right" class="white11" >
                             <a href="/download/desktop/1_800_600.jpg" target="_blank">800x600</a></td>
                        <td class="white11" height="25">
                            <a href="/download/desktop/2_1024_768.jpg" target="_blank">1204x768</a></td>
                        <td class="ColumnTD">
                           圖片2 </td>
                        <td align="right" class="white11">
                              <a href="/download/desktop/2_800_600.jpg" target="_blank">800x600</a></td>
                        <td class="white11" height="25">
                              <a href="/download/desktop/3_1024_768.jpg" target="_blank">1204x768</a></td>
                        <td class="ColumnTD">
                           圖片3</td>
                        <td align="right" class="white11">
                             <a href="/download/desktop/3_800_600.jpg" target="_blank">800x600</a></td>
                        <td class="white11" height="25">
                              <a href="/download/desktop/4_1024_768.jpg" target="_blank">1204x768</a></td>
                        <td class="ColumnTD">
                            圖片4</td>
                        <td align="right" class="white11">
                             <a href="/download/desktop/4_800_600.jpg" target="_blank">800x600</a></td>
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
                            <img height="149" src="/download/desktop/5_Thumb.jpg" width="199" /></td>
                        <td colspan="3">
                            <img height="149" src="/download/desktop/6_Thumb.jpg" width="199" /></td>
                        <td colspan="3">
                            <img height="149" src="/download/desktop/7_Thumb.jpg" width="199" /></td>
                        <td colspan="3">
                            <img height="149" src="/download/desktop/8_Thumb.jpg" width="199" /></td>
                    </tr>
                    <tr>
                        <td class="white11" height="25" >
                             <a href="/download/desktop/5_1024_768.jpg" target="_blank">1204x768</a></td>
                        <td class="ColumnTD" >
                            圖片5</td>
                        <td align="right" class="white11" >
                              <a href="/download/desktop/5_800_600.jpg" target="_blank">800x600</a></td>
                        <td class="white11" height="25">
                              <a href="/download/desktop/6_1024_768.jpg" target="_blank">1204x768</a></td>
                        <td class="ColumnTD">
                            圖片6</td>
                        <td align="right" class="white11">
                           <a href="/download/desktop/6_800_600.jpg" target="_blank">800x600</a></td>
                        <td class="white11" height="25">
                            <a href="/download/desktop/7_1024_768.jpg" target="_blank">1204x768</a></td>
                        <td class="ColumnTD">
                             圖片7</td>
                        <td align="right" class="white11">
                             <a href="/download/desktop/7_800_600.jpg" target="_blank">800x600</a></td>
                        <td class="white11" height="25">
                             <a href="/download/desktop/8_1024_768.jpg" target="_blank">1204x768</a></td>
                        <td class="ColumnTD">
                             圖片8</td>
                        <td align="right" class="white11">
                           <a href="/download/desktop/8_800_600.jpg" target="_blank">800x600</a></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="width: 758px">
                </td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="width: 758px">
                ‧更新編號：<asp:DropDownList ID="ddlImageID" runat="server">
                    <asp:ListItem Value="1">圖片1</asp:ListItem>
                    <asp:ListItem Value="2">圖片2</asp:ListItem>
                    <asp:ListItem Value="3">圖片3</asp:ListItem>
                    <asp:ListItem Value="4">圖片4</asp:ListItem>
                    <asp:ListItem Value="5">圖片5</asp:ListItem>
                    <asp:ListItem Value="6">圖片6</asp:ListItem>
                    <asp:ListItem Value="7">圖片7</asp:ListItem>
                    <asp:ListItem Value="8">圖片8</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="width: 758px">
                ‧圖片尺寸：<asp:RadioButtonList ID="rbtnImageSize" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="800_600">800x600</asp:ListItem>
                    <asp:ListItem Value="1024_768">1024x768</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="width: 758px">
                ‧更新縮圖：<asp:CheckBox ID="chkThumb" runat="server" Text="同步更新為封面縮圖" /></td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" >
                ‧圖檔上傳：
                <uc1:UploadControl ID="UploadControl1" runat="server" Required="true" FileTypeRange="jpg,jpeg"
                    ValidationGroup="VGroup1" Icon_Validate_Cross="image/icon_validate_cross.gif"
                    Icon_Validate_Spacer="image/icon_validate_Spacer.gif" Icon_Validate_Tick="image/icon_validate_Tick.gif"
                    MinWidth="800" MaxWidth="1024" MinHeight="600" MaxHeight="768"
                    >
                </uc1:UploadControl>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上傳" ValidationGroup="VGroup1" />
                (尺寸限制 800x600或1024x768，檔案格式JPG。)
            </td>
        </tr>
       
    </table>
</asp:Content>
