<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="MemberDetail.aspx.cs" Inherits="Admin_Member_MemberDetail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="table4" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="95%">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" height="25" style="width: 759px">
                帳號資料</td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <font face="新細明體">
                    <table id="Table2" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                        border-collapse: collapse" width="100%">
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                帳號：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                類別：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblUserType" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                Email：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                是否啟用：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblIsApproved" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td align="left" class="TH" style="width: 759px; height: 22px">
                <b>
                會員資料</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            姓名：</td>
                        <td align="left">
                            <asp:Label ID="lblChineseName" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            性別：</td>
                        <td align="left">
                            <asp:Label ID="lblGender" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            生日：</td>
                        <td align="left">
                            <asp:Label ID="lblBirthday" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            住址：</td>
                        <td align="left">
                            <asp:Label ID="lblAddr" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            聯絡電話：</td>
                        <td align="left">
                            <asp:Label ID="lblTelPhone" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            行動電話：</td>
                        <td align="left">
                            <asp:Label ID="lblMobilePhone" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            職業：</td>
                        <td align="left">
                            <asp:Label ID="lblCareer" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            婚姻狀態：</td>
                        <td align="left">
                            <asp:Label ID="lblMarital" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            是否持有會員卡：</td>
                        <td align="left">
                            <asp:Label ID="lblIsMemberCard" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            訂閱活動訊息：</td>
                        <td align="left">
                            <asp:Label ID="lblIsSubscription" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <br />
                <p>
                </p>
            </td>
        </tr>
        <tr>
            <td align="left" class="TH" style="width: 759px; height: 22px">
                相關資訊</td>
        </tr>
        <tr>
            <td class="Forumrow" style="width: 759px">
                <table id="Table8" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse">
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            &nbsp;註冊日期：</td>
                        <td align="left">
                            &nbsp;<asp:Label ID="lblCreationDate" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                            <td align="right" class="ColumnTD" style="height: 25px">
                                最後活動時間：</td>
                            <td align="left" style="height: 25px">
                                &nbsp;<asp:Label ID="lblLastActivityDate" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                            <td align="right" class="ColumnTD" height="20">
                                最後登入時間：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblLastLoginDate" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                            <td align="right" class="ColumnTD" height="20">
                                最後密碼變更時間：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblLastPasswordChangedDate" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" class="Forumrow" style="width: 759px; height: 18px">
            </td>
        </tr>
    </table>
</asp:Content>

