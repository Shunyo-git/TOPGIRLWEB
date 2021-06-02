<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="Admin_Member_memberList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="790">
        <tr>
            <td id="tabletitlelink" align="left" class="TH">
                <b>會員列表</b>
            </td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="height: 28px">
                <DIV align="left">搜尋會員：<asp:DropDownList ID="ddlSearchType" runat="server">
                    <asp:ListItem>會員帳號</asp:ListItem>
                    <asp:ListItem>會員Email</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox><asp:Button ID="btnSearch"
                    runat="server" Text="搜尋" OnClick="btnSearch_Click" />
                    </DIV>
                共<asp:Label ID="lblTotalCount" runat="server" Text="0"></asp:Label>筆&nbsp;</td>
        </tr>
        <tr>
            <td class="Forumrow" style="height: 460px">
                <font face="新細明體">
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
                        AutoGenerateColumns="False" BorderColor="White" BorderStyle="None" BorderWidth="0px"
                        CellPadding="1" CellSpacing="1" CssClass="tableBorder1" DataKeyNames="UserName"  
                        OnRowDataBound="GridView_RowDataBound"  PageSize="15"
                        Width="100%" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                              <asp:TemplateField HeaderText="管理員">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# IsAdmin(Convert.ToString(Eval("UserName")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserName" HeaderText="會員帳號" >
                                <ItemStyle CssClass="Forumrow" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="電子郵件" >
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="CreationDate" HeaderText="註冊日期" >
                                <ItemStyle CssClass="Forumrow" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                              <asp:BoundField DataField="LastLoginDate" HeaderText="最後登入日期" >
                                <ItemStyle CssClass="Forumrow" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <img alt="" src="image/icon-view.gif" width="15" height="15" /><asp:HyperLink ID="linkView" runat="server">檢視</asp:HyperLink>
                                 <img alt="" src="image/icon-edit.gif" width="14" height="15" /><asp:LinkButton ID="lbtnAdm" CommandName="RoleModify" runat="server" CommandArgument='<%# Eval("UserName") %>' >設定權限</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="ForumrowHighLight" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label10" runat="server" Text="Label">無會員資料！</asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="ItemHeader" />
                        <PagerSettings FirstPageText="最前頁" LastPageText="最末頁" Mode="NextPreviousFirstLast"
                            NextPageText="下一頁" PreviousPageText="上一頁" Visible="False" />
                    </asp:GridView>
                    <br />
                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="pink11_ff9b9b">
                        <tr>
                            <td align="center" style="height: 18px">
                                <asp:HyperLink ID="lnkFirst" runat="server">最前頁</asp:HyperLink>
                                &nbsp;&nbsp;<asp:HyperLink ID="lnkPrev" runat="server">上一頁</asp:HyperLink>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCurrentPage" runat="server"></asp:Label>/<asp:Label ID="lblPageCount"
                                    runat="server"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="lnkNext" runat="server">下一頁</asp:HyperLink>
                                &nbsp;&nbsp;<asp:HyperLink ID="lnkLast" runat="server">最末頁</asp:HyperLink> 
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                跳到第<asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                </asp:DropDownList>頁
                            </td>
                        </tr>
                    </table>
                </font>
               </td>
        </tr>
        <tr>
            <td class="Forumrow" style="height: 30px">
                <font face="新細明體"></font><font face="新細明體" style="background-color: #ffffff"></font>
                &nbsp;<br />
            </td>
        </tr>
    </table>
</asp:Content>

