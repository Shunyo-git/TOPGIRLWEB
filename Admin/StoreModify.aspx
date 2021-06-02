<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true"
    CodeFile="StoreModify.aspx.cs" Inherits="Admin_StoreModify" %>

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
                商品分類設定</td>
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
                                網頁顯示：</td>
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
                <b>商品分類內容</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            所屬地區：</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlArea" runat="server">
                                <asp:ListItem Value="1">北區</asp:ListItem>
                                <asp:ListItem Value="2">中區</asp:ListItem>
                                <asp:ListItem Value="3">南區</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            門市名稱：</td>
                        <td align="left">
                            <asp:TextBox ID="txtStoreName" runat="server" Width="20%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValSubTitle" runat="server" ControlToValidate="txtStoreName"
                                ErrorMessage="門市名稱不能空白" ToolTip="門市名稱不能空白"><img src="image/icon_validate_cross.gif" align="absmiddle" width="12" height="12" /></asp:RequiredFieldValidator><span
                                    style="color: #336600"></span></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                         門市電話：</td>
                        <td align="left">
                            <asp:TextBox ID="txtTel" runat="server" Width="20%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTel"
                                ErrorMessage="門市電話不能空白" ToolTip="門市電話不能空白"><img src="image/icon_validate_cross.gif" align="absmiddle" width="12" height="12" /></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                         門市地址：</td>
                        <td align="left">
                            <asp:TextBox ID="txtAddress" runat="server" Width="50%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                                ErrorMessage="門市地址不能空白" ToolTip="門市地址不能空白"><img src="image/icon_validate_cross.gif" align="absmiddle" width="12" height="12" /></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                <p>
                    
                    <asp:CustomValidator ID="ValidatorResult" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator> &nbsp;</p>
            </td>
        </tr>
    </table>
</asp:Content>
