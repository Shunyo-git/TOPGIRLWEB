<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true"
    CodeFile="Screen.aspx.cs" Inherits="Admin_Screen" %>

<%@ Register Src="UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="input-warn-content"
        ValidationGroup="VGroup1" Width="758px" ForeColor="" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="input-warn-content"
        ValidationGroup="VGroup2" Width="758px" ForeColor="" />
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" CssClass="input-warn-content"
        ValidationGroup="VGroup3" Width="758px" ForeColor="" />
    <asp:Label ID="lblSuccess" runat="server" BorderStyle="Solid" CssClass="input-ok-content"
        Text="<li>上傳成功，檔案已更新。</li>" Width="758px"></asp:Label>
    <table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" style="width: 758px">
                <b>螢幕保護程式設定</b></td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="width: 758px">
                
                
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td colspan="3">
                            <img height="149" src="/download/screen/sc_1.jpg" width="199" /></td>
                        <td rowspan="5" width="13">
                            &nbsp;</td>
                        <td colspan="3">
                            <img height="149" src="/download/screen/sc_2.jpg" width="199" /></td>
                        <td rowspan="5" width="13">
                            &nbsp;</td>
                        <td colspan="3">
                            <img height="149" src="/download/screen/sc_3.jpg" width="199" /></td>
                        <td rowspan="5" width="13">
                            &nbsp;</td>
                        <td colspan="3">
                            <img height="149" src="/download/screen/sc_4.jpg" width="199" /></td>
                    </tr>
                    <tr>
                        <td class="white11" height="25" >
                              </td>
                        <td class="ColumnTD">
                            編號1</td>
                        <td align="right" class="white11" >
                             <a href="/download/screen/sc_1.exe" target="_blank">下載</a> | <asp:LinkButton ID="lbtnDelete01"
                                 runat="server" OnClick="lbtnDelete01_Click">刪除</asp:LinkButton></td>
                        <td class="white11" height="25">
                             </td>
                        <td class="ColumnTD">
                           編號2 </td>
                        <td align="right" class="white11">
                              <a href="/download/screen/sc_2.exe" target="_blank">下載</a> | <asp:LinkButton ID="lbtnDelete02"
                                 runat="server" OnClick="lbtnDelete02_Click">刪除</asp:LinkButton></td>
                        <td class="white11" height="25">
                               </td>
                        <td class="ColumnTD">
                           編號3</td>
                        <td align="right" class="white11">
                             <a href="/download/screen/sc_3.exe" target="_blank">下載</a> | <asp:LinkButton ID="lbtnDelete03"
                                 runat="server" OnClick="lbtnDelete03_Click">刪除</asp:LinkButton></td>
                        <td class="white11" height="25">
                               </td>
                        <td class="ColumnTD">
                            編號4</td>
                        <td align="right" class="white11">
                             <a href="/download/screen/sc_4.exe" target="_blank">下載</a> | <asp:LinkButton ID="lbtnDelete04"
                                 runat="server" OnClick="lbtnDelete04_Click">刪除</asp:LinkButton></td>
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
                            <img height="149" src="/download/screen/sc_5.jpg" width="199" /></td>
                        <td colspan="3">
                            <img height="149" src="/download/screen/sc_6.jpg" width="199" /></td>
                        <td colspan="3">
                            <img height="149" src="/download/screen/sc_7.jpg" width="199" /></td>
                        <td colspan="3">
                            <img height="149" src="/download/screen/sc_8.jpg" width="199" /></td>
                    </tr>
                    <tr>
                        <td class="white11" height="25" >
                             </td>
                        <td class="ColumnTD" >
                            編號5</td>
                        <td align="right" class="white11" >
                              <a href="/download/screen/sc_5.exe" target="_blank">下載</a> | <asp:LinkButton ID="lbtnDelete05"
                                 runat="server" OnClick="lbtnDelete05_Click">刪除</asp:LinkButton></td>
                        <td class="white11" height="25">
                              </td>
                        <td class="ColumnTD">
                            編號6</td>
                        <td align="right" class="white11">
                           <a href="/download/screen/sc_6.exe" target="_blank">下載</a> | <asp:LinkButton ID="lbtnDelete06"
                                 runat="server" OnClick="lbtnDelete06_Click">刪除</asp:LinkButton></td>
                        <td class="white11" height="25">
                            </td>
                        <td class="ColumnTD">
                             編號7</td>
                        <td align="right" class="white11">
                             <a href="/download/screen/sc_7.exe" target="_blank">下載</a> | <asp:LinkButton ID="lbtnDelete07"
                                 runat="server" OnClick="lbtnDelete07_Click">刪除</asp:LinkButton></td>
                        <td class="white11" height="25">
                              </td>
                        <td class="ColumnTD">
                             編號8</td>
                        <td align="right" class="white11">
                           <a href="/download/screen/sc_8.exe" target="_blank">下載</a> | <asp:LinkButton ID="lbtnDelete08"
                                 runat="server" OnClick="lbtnDelete08_Click">刪除</asp:LinkButton></td>
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
                ‧上傳種類：<asp:RadioButtonList ID="rbtnUploadType" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="pic">封面縮圖</asp:ListItem>
                    <asp:ListItem Value="exe">螢幕保護程式</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        
        <tr>
            <td align="left" class="Forumrow" >
                ‧檔案上傳：
                <uc1:UploadControl ID="UploadControl1" runat="server" Required="true" FileTypeRange="jpg,jpeg,exe"
                    ValidationGroup="VGroup1" Icon_Validate_Cross="image/icon_validate_cross.gif"
                    Icon_Validate_Spacer="image/icon_validate_Spacer.gif" Icon_Validate_Tick="image/icon_validate_Tick.gif"
                    >
                </uc1:UploadControl>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上傳" ValidationGroup="VGroup1" />
                (封面圖檔格式為JPG，螢幕保護程式為EXE。)
            </td>
        </tr>
       
    </table>
</asp:Content>
