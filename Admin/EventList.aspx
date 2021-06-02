<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="EventList.aspx.cs" Inherits="Admin_EventList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="790">
        <tr>
            <td id="tabletitlelink" align="left" class="TH">
                <b>促銷活動列表</b>
            </td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="height: 28px">
                <img src="image/nav.gif" width="9" height="9" />
                <asp:LinkButton ID="lbtnNew" runat="server" OnClick="lbtnNew_Click">新增一則活動</asp:LinkButton></td>
        </tr>
        <tr>
            <td class="Forumrow">
                <font face="新細明體">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="False" AllowSorting="True"
                        AutoGenerateColumns="False" BorderColor="White" BorderStyle="None" BorderWidth="0px"
                        CellPadding="1" CellSpacing="1" CssClass="tableBorder1" DataKeyNames="ID"
                         OnRowDataBound="GridView_RowDataBound"
                        OnSorting="GridView_Sorting"   Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="自動編號" SortExpression="ID">
                                <ItemStyle CssClass="Forumrow" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="分 類" SortExpression="GroupID">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# GetEventGroupName(Convert.ToInt32(Eval("GroupID")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Title" HeaderText="標 題" SortExpression="Title">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="網站顯示"  SortExpression="IsDisplay" >
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# IsWebDisplay(Convert.ToBoolean(Eval("IsDisplay")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="首頁顯示"  SortExpression="HomePageAreaID">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# GetHomePageAreaName(Convert.ToInt32(Eval("HomePageAreaID")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ReleaseDate" HeaderText="標示日期" SortExpression="ReleaseDate">
                                <ItemStyle CssClass="Forumrow" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="功 能">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                <img alt="" src="image/icon-view.gif" width="15" height="15" /><asp:HyperLink ID="linkView" runat="server">檢視</asp:HyperLink>  
                                     <img alt="" src="image/icon-edit.gif" width="17" height="15" /><asp:HyperLink ID="linkModify" runat="server">編輯</asp:HyperLink> 
                                    <img alt="" src="image/icon-delete.gif" width="14" height="15" /><asp:LinkButton ID="lbtnDelete" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID") %>' >刪除</asp:LinkButton>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="ForumrowHighLight" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label10" runat="server" Text="Label">無活動資料！</asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="ItemHeader" />
                        <PagerSettings FirstPageText="最前頁" LastPageText="最末頁" Mode="NextPreviousFirstLast"
                            NextPageText="下一頁" PreviousPageText="上一頁" />
                    </asp:GridView>
                    <br />
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

