<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="StoreList.aspx.cs" Inherits="Admin_StoreList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="790">
        <tr>
            <td id="tabletitlelink" align="left" class="TH">
                <b>門市列表</b>
            </td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="height: 28px">
                <img src="image/nav.gif" width="9" height="9" />
                <asp:LinkButton ID="lbtnNew" runat="server" OnClick="lbtnNew_Click">新增門市</asp:LinkButton></td>
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
                                <ItemStyle CssClass="Forumrow" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                          
                             <asp:TemplateField HeaderText="區域"  SortExpression="AreaID">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# Eval("AreaName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:BoundField DataField="StoreName" HeaderText="門市名稱" SortExpression="StoreName">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                              <asp:BoundField DataField="Tel" HeaderText="門市電話" SortExpression="Tel">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                              <asp:BoundField DataField="Address" HeaderText="門市地址" SortExpression="Address">
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
                            <asp:Label ID="Label10" runat="server" Text="Label">無門市資料！</asp:Label>
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

