﻿<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="MiniSiteList.aspx.cs" Inherits="Admin_MiniSiteList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="790">
        <tr>
            <td id="tabletitlelink" align="left" class="TH">
                <b>MiniSite列表</b>
            </td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="height: 28px">
                <img src="image/nav.gif" width="9" height="9" />
                <asp:LinkButton ID="lbtnNew" runat="server" OnClick="lbtnNew_Click">新增MiniSite</asp:LinkButton></td>
        </tr>
        <tr>
            <td class="Forumrow">
                <font face="新細明體">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" BorderColor="White" BorderStyle="None" BorderWidth="0px"
                        CellPadding="1" CellSpacing="1" CssClass="tableBorder1" DataKeyNames="ID"
                        OnPageIndexChanging="GridView_PageIndexChanging" OnRowDataBound="GridView_RowDataBound"
                        OnSorting="GridView_Sorting" PageSize="15" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="自動編號" SortExpression="ID">
                                <ItemStyle CssClass="Forumrow" Width="5%" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                          <asp:TemplateField HeaderText="圖示"   >
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" Width="20%" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <img alt="" src='/images/miniSite/minisite_<%# Eval("ID")%>.gif' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="URL" HeaderText="網址" SortExpression="URL">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" Width="30%" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="網站顯示"  SortExpression="IsDisplay" >
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" Width="10%" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# IsWebDisplay(Convert.ToBoolean(Eval("IsDisplay")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="排列序號">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" Width="15%" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                 <%# Eval("SortID")%>
                                    <asp:ImageButton ID="ibtnUP"  AlternateText="往上移動" CommandName="SortUp" ImageUrl="image/icon-up.gif"  runat="server" CommandArgument='<%# Eval("ID") %>'/>
                                    <asp:ImageButton ID="ibtnDOWN" AlternateText="往下移動"  CommandName="SortDown" ImageUrl="image/icon-down.gif" runat="server" CommandArgument='<%# Eval("ID") %>'/>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功 能">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" Width="20%" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                
                                    
                                    <img alt="" src="image/icon-edit.gif" width="17" height="15" /><asp:HyperLink ID="linkModify" runat="server">編輯</asp:HyperLink> 
                                    <img alt="" src="image/icon-delete.gif" width="14" height="15" /><asp:LinkButton ID="lbtnDelete" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID") %>' >刪除</asp:LinkButton>
                                     
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="ForumrowHighLight" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label10" runat="server" Text="Label">無資料！</asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="ItemHeader" />
                        <PagerSettings FirstPageText="最前頁" LastPageText="最末頁" Mode="NextPreviousFirstLast"
                            NextPageText="下一頁" PreviousPageText="上一頁" />
                    </asp:GridView>
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

