<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true"
    CodeFile="MiniSiteModify.aspx.cs" Inherits="Admin_MiniSiteModify" %>

<%@ Register Src="UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="input-warn-content"
        ForeColor="" Width="758px" />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 759px">
        <tr>
            <td style="height: 22px; width: 8px;">
            </td>
            <td align="right" style="height: 22px">
                <img src="/Admin/image/icon-save.gif" width="14" height="18" />&nbsp;
                <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">儲存</asp:LinkButton>&nbsp;
                <img src="/Admin/image/icon-cancel.gif" width="18" height="18" />
                <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click" CausesValidation="False">取消</asp:LinkButton></td>
        </tr>
    </table>
    <table id="table4" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="95%">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" height="25" style="width: 759px">
                MiniSite設定</td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <font face="新細明體">
                    <table id="Table2" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                        border-collapse: collapse" width="100%">
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                自動編號：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblID" runat="server">新增後自動產生</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                網站顯示：</td>
                            <td align="left" height="20" class="ColumnTD">
                                <asp:RadioButtonList ID="rbtnIsDisplay" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">顯示</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">不顯示</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                         
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td class="TH" style="width: 759px" align="left">
                <b>MiniSite內容</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            URL網址：</td>
                        <td align="left">
                            <asp:TextBox ID="txtURL" runat="server" Width="80%" MaxLength="200"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValSubTitle" runat="server" ControlToValidate="txtURL"
                                ErrorMessage="URL不能空白" ToolTip="URL不能空白"><img src="image/icon_validate_cross.gif" align="absmiddle" width="12" height="12" /></asp:RequiredFieldValidator><span
                                    style="color: #336600">(200字以內)</span></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" width="15%" valign="top">
                            圖示上傳：</td>
                        <td align="left">
                            &nbsp;<uc1:UploadControl  ID="UploadControl1" runat="server" FileTypeRange="gif"
                                Icon_Validate_Cross="image/icon_validate_cross.gif" Icon_Validate_Spacer="image/icon_validate_Spacer.gif"
                                Icon_Validate_Tick="image/icon_validate_Tick.gif" MaxWidth="88" MinWidth="88" MaxHeight="55" MinHeight="55"
                                 FileControlWidth="90%" />
                            <p>
                                ◎圖檔尺寸88像素x55像素，格式GIF。</p>
                            <asp:HyperLink ID="linkSiteImage" runat="server" Target="_blank">
                                <asp:Image ID="imgSite" runat="server" Width="88" Height="55" /></asp:HyperLink>
                        </td>
                    </tr>
                </table>
                <p>
                    
                    <asp:CustomValidator ID="ValidatorResult" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>&nbsp;</p>
            </td>
        </tr>
    </table>
</asp:Content>
