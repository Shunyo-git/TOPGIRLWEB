<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true"
    CodeFile="HomePageImage.aspx.cs" Inherits="Admin_HomePageImage" %>

<%@ Register Src="UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="input-warn-content"
        ValidationGroup="VGroup1" Width="758px" ForeColor="" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="input-warn-content"
        ValidationGroup="VGroup2" Width="758px" ForeColor="" />
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" CssClass="input-warn-content"
        ValidationGroup="VGroup3" Width="758px" ForeColor="" />
    <asp:Label ID="lblSuccess" runat="server" BorderStyle="Solid" CssClass="input-ok-content"
        Text="<li>上傳成功，首頁輪播圖片已更新。</li>" Width="758px"></asp:Label>
    <table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" style="width: 758px">
                <b>首頁輪播圖片設定</b></td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="width: 758px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="width: 35%">
                            <a href="/images/index/1.jpg" target="_blank">
                                <asp:Image ID="Image1" runat="server" Width="200px" ImageUrl="~/images/index/1.jpg"
                                    BorderWidth="0" /></a></td>
                        <td style="width: 35%">
                            <a href="/images/index/2.jpg" target="_blank">
                                <asp:Image ID="Image2" runat="server" Width="200px" ImageUrl="~/images/index/2.jpg"
                                    BorderWidth="0" /></a></td>
                        <td style="width: 30%">
                            <a href="/images/index/3.jpg" target="_blank">
                                <asp:Image ID="Image3" runat="server" Width="200px" ImageUrl="~/images/index/3.jpg"
                                    BorderWidth="0" /></a></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="width: 758px">
                ‧ <strong>圖片1：</strong>
                <uc1:UploadControl ID="UploadControl1" runat="server" Required="true" FileTypeRange="jpg,jpeg"
                    ValidationGroup="VGroup1" Icon_Validate_Cross="image/icon_validate_cross.gif"
                    Icon_Validate_Spacer="image/icon_validate_Spacer.gif" Icon_Validate_Tick="image/icon_validate_Tick.gif"
                    MinWidth="458" MaxWidth="458" MinHeight="596" MaxHeight="596"
                    >
                </uc1:UploadControl>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上傳更新" ValidationGroup="VGroup1" />
                (圖檔尺寸限制為 458px*596px)
            </td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="width: 758px">
                <span style="background-color: #f1f3f5">‧ </span><strong>圖片2：</strong>
                <uc1:UploadControl ID="UploadControl2" runat="server" Required="true" FileTypeRange="jpg,jpeg"
                    ValidationGroup="VGroup2" Icon_Validate_Cross="image/icon_validate_cross.gif"
                    Icon_Validate_Spacer="image/icon_validate_Spacer.gif" Icon_Validate_Tick="image/icon_validate_Tick.gif"
                    MinWidth="458" MaxWidth="458" MinHeight="596" MaxHeight="596"
                    >
                </uc1:UploadControl>
                <asp:Button ID="Button2" runat="server" Text="上傳更新" ValidationGroup="VGroup2" OnClick="Button2_Click" />
                (圖檔尺寸限制為 458px*596px)
                </td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="height: 30px; width: 758px;">
                ‧ <strong>圖片3：</strong>
                <uc1:UploadControl ID="UploadControl3" runat="server" Required="true" FileTypeRange="jpg,jpeg"
                    ValidationGroup="VGroup3" Icon_Validate_Cross="image/icon_validate_cross.gif"
                    Icon_Validate_Spacer="image/icon_validate_Spacer.gif" Icon_Validate_Tick="image/icon_validate_Tick.gif"
                    MinWidth="458" MaxWidth="458" MinHeight="596" MaxHeight="596"
                    >
                </uc1:UploadControl>
                <asp:Button ID="Button3" runat="server" Text="上傳更新" ValidationGroup="VGroup3" OnClick="Button3_Click" />
                (圖檔尺寸限制為 458px*596px)
                </td>
        </tr>
    </table>
</asp:Content>
