<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage_Member.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><img src="img/member/title.gif" width="723" height="65" /></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="54" height="408" valign="top"><img src="img/member/left_bg.gif" width="54" height="209" /></td>
                    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="8"><img src="img/member/frameleft.gif" width="8" height="408" /></td>
                        <td valign="top" background="img/member/in_bg.gif"><table border="0" align="center" cellpadding="5" cellspacing="0" class="white22" width="350">
                          <tr>
                            <td height="80">&nbsp;</td>
                          </tr>
                          <tr>
                            <td bgcolor="#666666"><strong>會員密碼查詢</strong></td>
                          </tr>
                          <tr>
                            <td bgcolor="#666666">
                                 
                            
                                  
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                              <tr>
                                <td align="right" style="height: 19px">
                                                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">會員帳號</asp:Label></td>
                                <td width="10" style="height: 19px">&nbsp;</td>
                                <td style="height: 19px">
                                    &nbsp;<asp:TextBox ID="UserName" runat="server" Style="border-right: #666666 1px solid;
                                                                                border-top: #666666 1px solid; font-size: 9pt; border-left: #666666 1px solid;
                                                                                border-bottom: #666666 1px solid; height: 16px; background-color: #ffffff" Width="100px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                    ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="請輸入帳號。"
                                                                                    ToolTip="必須提供使用者名稱。" ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator></td>
                              </tr>
                              <tr>
                                <td height="10" colspan="3" align="right"></td>
                                </tr>
                              <tr>
                                <td align="right">
                                                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Email">會員Email</asp:Label></td>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="Email" runat="server" Style="border-right: #666666 1px solid;
                                                                                border-top: #666666 1px solid; font-size: 9pt; border-left: #666666 1px solid;
                                                                                border-bottom: #666666 1px solid; background-color: #ffffff"
                                                                                Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                                                    ControlToValidate="Email" ErrorMessage="必須提供Email。" ToolTip="請輸入Email。" ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                    <asp:Button ID="btnLogin" runat="server" Text="查詢" ValidationGroup="ctl00$Login1" OnClick="btnLogin_Click"/></td>
                              </tr>
                                                <tr>
                                                    <td align="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></td>
                                                </tr>
                              <tr>
                                <td height="30" colspan="3" align="right" class="gray11"><a href="MemberRegister.aspx"></a><a href="#"></a></td>
                                </tr>
                            </table>
                                            
                            </td>
                          </tr>
                        </table>
                        </td>
                        <td width="10"><img src="img/member/frameright.gif" width="10" height="408" /></td>
                      </tr>
                    </table></td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><img src="img/member/framede.gif" width="723" height="19" /></td>
              </tr>
            </table>
</asp:Content>

