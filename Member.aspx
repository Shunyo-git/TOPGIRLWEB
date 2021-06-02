<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage_Member.master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member"   %>
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
                        <td valign="top" background="img/member/in_bg.gif"><table border="0" align="center" cellpadding="5" cellspacing="0" class="white22">
                          <tr>
                            <td height="80">&nbsp;</td>
                          </tr>
                          <tr>
                            <td bgcolor="#dcdcdc"><strong>會員登入</strong></td>
                          </tr>
                          <tr>
                            <td bgcolor="#dcdcdc">
                                <asp:LoginView ID="LoginView1" runat="server">
                                    <LoggedInTemplate>
                                         <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                              <tr>
                                <td align="center">
                                        <asp:LoginName ID="LoginName1" runat="server" />
                                        &nbsp;歡迎光臨 ～
                                        <asp:LoginStatus ID="LoginStatus1" runat="server" />
                                        </td>
                                </tr>
                            </table>
                                    </LoggedInTemplate>
                                    <AnonymousTemplate>
                                        <asp:Login ID="Login1" runat="server" Width="450px">
                                            <LayoutTemplate>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                              <tr>
                                <td align="right">
                                                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">帳號</asp:Label></td>
                                <td width="10">&nbsp;</td>
                                <td>
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
                                                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密碼</asp:Label></td>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="Password" runat="server" Style="border-right: #666666 1px solid;
                                                                                border-top: #666666 1px solid; font-size: 9pt; border-left: #666666 1px solid;
                                                                                border-bottom: #666666 1px solid; background-color: #ffffff" TextMode="Password"
                                                                                Width="100px"></asp:TextBox><asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                                                    ControlToValidate="Password" ErrorMessage="必須提供密碼。" ToolTip="請輸入密碼。" ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                    <asp:Button ID="btnLogin" runat="server" CommandName="Login" Text="登入" ValidationGroup="ctl00$Login1"/></td>
                              </tr>
                                                <tr>
                                                    <td align="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                                        <asp:CheckBox ID="RememberMe" runat="server" Text="記憶密碼供下次使用。" /></td>
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
                                <td height="30" colspan="3" align="right" class="gray11"><a href="MemberRegister.aspx">加入會員</a>｜<a href="ForgotPassword.aspx">查詢密碼</a></td>
                                </tr>
                            </table>
                                            </LayoutTemplate>
                                        </asp:Login>
                                    </AnonymousTemplate>
                                </asp:LoginView>
                            </td>
                          </tr>
                        </table></td>
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

