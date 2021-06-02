<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage_Hire.master" AutoEventWireup="true" CodeFile="Job.aspx.cs" Inherits="Job" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder1" Runat="Server">

 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server"  >
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><img src="img/hire/title.gif" width="775" height="65" /></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="35">&nbsp;</td>
                    <td width="8"><img src="img/hire/frameleft.gif" width="8" height="408" /></td>
                    <td valign="top" background="img/hire/content_bg.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="50%"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right"><span class="pink11_ff9b9b">*</span> 應徵項目</td>
                            <td width="10">&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtJobTitle" runat="server" CssClass="deepgry11" Width="165px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtJobTitle"
                                    CssClass="pink11_ff9b9b" ErrorMessage="不能空白." ToolTip="不能空白." ValidationGroup="CreateJob">不能空白</asp:RequiredFieldValidator></td>
                          </tr>
                        </table></td>
                        <td width="50%"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right">婚姻狀況</td>
                            <td width="10">&nbsp;</td>
                            <td><asp:RadioButtonList ID="rbtnMarital" runat="server" CssClass="white12" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem>已婚</asp:ListItem>
                                <asp:ListItem>未婚</asp:ListItem>
                            </asp:RadioButtonList></td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td height="10" colspan="2"></td>
                        </tr>
                      <tr>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right"><span class="pink11_ff9b9b">* </span>姓名</td>
                            <td width="10">&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtName" runat="server" CssClass="deepgry11" Width="110px"></asp:TextBox>
                              <asp:RadioButtonList ID="rbtnGender" runat="server" CssClass="white12" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Selected="True">男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    CssClass="pink11_ff9b9b" ErrorMessage="不能空白." ToolTip="不能空白." ValidationGroup="CreateJob">不能空白</asp:RequiredFieldValidator></td>
                          </tr>
                        </table></td>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right" style="height: 20px"><span class="pink11_ff9b9b">*</span> 希望待遇</td>
                            <td width="10" style="height: 20px">&nbsp;</td>
                            <td style="height: 20px">
                                &nbsp;<asp:TextBox ID="txtExpectedSalary" runat="server" CssClass="deepgry11" Width="110px"></asp:TextBox>NT<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtExpectedSalary"
                                    CssClass="pink11_ff9b9b" ErrorMessage="不能空白." ToolTip="不能空白." ValidationGroup="CreateJob">不能空白</asp:RequiredFieldValidator></td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td height="10" colspan="2"></td>
                      </tr>
                      <tr>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right" style="height: 20px">聯絡電話</td>
                            <td width="10" style="height: 20px">&nbsp;</td>
                            <td style="height: 20px">
                                &nbsp;<asp:TextBox ID="txtTelArea" runat="server" CssClass="deepgry11" MaxLength="2"
                                    Width="25px"></asp:TextBox>–&nbsp;
                                <asp:TextBox ID="txtTelphone" runat="server" CssClass="deepgry11" MaxLength="14"
                                    Width="110px"></asp:TextBox></td>
                          </tr>
                        </table></td>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right"><span class="pink11_ff9b9b">*</span> 目前待遇</td>
                            <td width="10">&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtCurrentSalary" runat="server" CssClass="deepgry11" Width="110px"></asp:TextBox>NT<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCurrentSalary"
                                    CssClass="pink11_ff9b9b" ErrorMessage="不能空白." ToolTip="不能空白." ValidationGroup="CreateJob">不能空白</asp:RequiredFieldValidator></td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td height="10" colspan="2"></td>
                      </tr>
                      <tr>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right"><span class="pink11_ff9b9b">*</span> 行動電話</td>
                            <td width="10">&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtMobile" runat="server" CssClass="deepgry11" Width="110px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobile"
                                    CssClass="pink11_ff9b9b" ErrorMessage="不能空白." ToolTip="不能空白." ValidationGroup="CreateJob">不能空白</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                                    ErrorMessage="格式不正確." ValidationExpression="09[0-9]{8}" ValidationGroup="CreateJob"></asp:RegularExpressionValidator></td>
                          </tr>
                        </table></td>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right"><span class="pink11_ff9b9b">*</span> 最快可上班日</td>
                            <td width="10">&nbsp;</td>
                            <td> <asp:DropDownList ID="ddlOnDutyYear" runat="server" CssClass="deepgry11">
                            </asp:DropDownList>
                            年
                            <asp:DropDownList ID="ddlOnDutyMonth" runat="server" CssClass="deepgry11">
                            </asp:DropDownList>
                            月
                            <asp:DropDownList ID="ddlOnDutyDay" runat="server" CssClass="deepgry11">
                            </asp:DropDownList>
                            日
                            </td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td height="10" colspan="2"></td>
                      </tr>
                      <tr>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right"><span class="pink11_ff9b9b">* </span>電子郵件</td>
                            <td width="10">&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtEmail" runat="server" CssClass="deepgry11" Width="165px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail"
                                    CssClass="pink11_ff9b9b" ErrorMessage="不能空白." ToolTip="不能空白." ValidationGroup="CreateJob">不能空白</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="valEmail1" runat="server" ControlToValidate="txtEmail"
                                    CssClass="asterisk" Display="Dynamic" ErrorMessage="Email 不是正確的格式." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="CreateJob"></asp:RegularExpressionValidator></td>
                          </tr>
                        </table></td>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right" style="height: 20px"><span class="pink11_ff9b9b">*</span> 最高學歷校名</td>
                            <td width="10" style="height: 20px">&nbsp;</td>
                            <td style="height: 20px">
                                &nbsp;<asp:TextBox ID="txtSchool" runat="server" CssClass="deepgry11" Width="165px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSchool"
                                    CssClass="pink11_ff9b9b" ErrorMessage="不能空白." ToolTip="不能空白." ValidationGroup="CreateJob">不能空白</asp:RequiredFieldValidator></td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td colspan="2" style="height: 10px"></td>
                      </tr>
                      <tr>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right" style="height: 18px"><span class="pink11_ff9b9b">*</span> 生日</td>
                            <td width="10" style="height: 18px">&nbsp;</td>
                            <td style="height: 18px">
                              <asp:DropDownList ID="selYear" runat="server" CssClass="deepgry11">
                            </asp:DropDownList>
                            年
                            <asp:DropDownList ID="selMonth" runat="server" CssClass="deepgry11">
                            </asp:DropDownList>
                            月
                            <asp:DropDownList ID="selDay" runat="server" CssClass="deepgry11">
                            </asp:DropDownList>
                            日
                            </td>
                          </tr>
                        </table></td>
                        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right" style="height: 20px">科系名稱</td>
                            <td width="10" style="height: 20px">&nbsp;</td>
                            <td style="height: 20px">
                                <asp:TextBox ID="txtStudy" runat="server" CssClass="deepgry11" Width="165px"></asp:TextBox></td>
                          </tr>
                        </table></td>
                      </tr>
                      <tr>
                        <td height="10" colspan="2"></td>
                      </tr>
                      <tr>
                        <td colspan="2"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right"><span class="pink11_ff9b9b">*</span> 工作經歷</td>
                            <td width="10">&nbsp;</td>
                            <td>
                               
                                <asp:TextBox ID="txtCareer" runat="server" CssClass="deepgry11" Width="315px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCareer"
                                    CssClass="pink11_ff9b9b" ErrorMessage="不能空白." ToolTip="不能空白." ValidationGroup="CreateJob">不能空白</asp:RequiredFieldValidator></td>
                          </tr>
                        </table></td>
                        </tr>
                      <tr>
                        <td height="10" colspan="2"></td>
                        </tr>
                      <tr>
                        <td colspan="2"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                          <tr>
                            <td width="90" align="right" valign="top"><span class="pink11_ff9b9b">*</span> 自傳</td>
                            <td width="10">&nbsp;</td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtIntro" runat="server" CssClass="deepgry11" Rows="10" TextMode="MultiLine"
                                    Width="572px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtIntro"
                                    CssClass="pink11_ff9b9b" ErrorMessage="不能空白." ToolTip="不能空白." ValidationGroup="CreateJob">不能空白</asp:RequiredFieldValidator></td>
                          </tr>
                        </table></td>
                        </tr>
                      
                      <tr>
                        <td colspan="2" align="center" class="white12">備註：(*)號為重要資料欄，請務必配合填寫，我們將於最短的時間內與您聯繫，謝謝。</td>
                        </tr>
                      <tr>
                        <td height="10" colspan="2"></td>
                        </tr>
                      <tr>
                        <td colspan="2" align="center">
                        <asp:ImageButton
                                ID="ibtnSubmit" runat="server"  ImageUrl="img/hire/send.gif" ValidationGroup="CreateJob" OnClick="ibtnSubmit_Click"  /></td>
                        </tr>
                    </table></td>
                    <td width="10"><img src="img/hire/frameright.gif" width="10" height="408" /></td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td><img src="img/hire/framede.gif" width="775" height="19" /></td>
              </tr>
            </table>
    </asp:Panel>
</asp:Content>

