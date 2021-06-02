<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="EventDetail.aspx.cs" Inherits="Admin_EventDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 759px">
        <tr>
            <td style="height: 22px">
            </td>
            <td align="right" style="height: 22px">
                <img src="/Admin/image/icon-edit.gif" width="17" height="15" />&nbsp;
                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click">編輯</asp:LinkButton>&nbsp;
                <img src="/Admin/image/icon-delete.gif" width="14" height="15" />
                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click">刪除</asp:LinkButton>
                <img src="/Admin/image/icon-cancel.gif" width="18" height="18" /><asp:LinkButton ID="lbtnCancel" runat="server"
                    OnClick="lbtnCancel_Click">取消</asp:LinkButton>&nbsp;</td>
        </tr>
    </table>
    <table id="table4" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="95%">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" height="25" style="width: 759px">
                活動訊息設定</td>
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
                                &nbsp;<asp:Label ID="lblID" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                活動訊息類別：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblGroupName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                網頁顯示：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblIsDisplay" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                首頁顯示：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblHopageAreaDisplay" runat="server"></asp:Label>
                                </td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td align="left" class="TH" style="width: 759px; height: 22px;">
                <b>活動訊息本文</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            短標題：</td>
                        <td align="left">
                            <asp:Label ID="lblSubTitle" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%; height: 28px">
                            標題：
                        </td>
                        <td align="left" style="height: 28px">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%; height: 28px">
                            日期：
                        </td>
                        <td align="left" style="height: 28px">
                            <asp:Label ID="lblReleaseDate" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            活動訊息內文：</td>
                        <td align="left">
                            <asp:Label ID="lblContent" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            活動圖片：</td>
                        <td align="left">
                           <asp:HyperLink ID="linkEventImage" runat="server" Target="_blank"><asp:Image ID="imgEvent" runat="server" Width="264" /></asp:HyperLink>
                        </td>
                    </tr>
                </table>
                <br />
                <p>
                </p>
            </td>
        </tr>
      
        <tr>
            <td align="center" class="Forumrow" style="width: 759px">
            </td>
        </tr>
    </table>
</asp:Content>

