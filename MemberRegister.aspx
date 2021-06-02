<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage_Member.master" AutoEventWireup="true"
    CodeFile="MemberRegister.aspx.cs" Inherits="MemberRegister"  %>

<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder1" runat="Server">

    <script type="text/javascript">
			//this function is called when date is selected in calendar
			var selMonthID ;
			var selDayID ;
			var selYearID ;
			var calDateID ;
			
			function onDateChange(sender, selectedDate) {
				var month = selectedDate.getMonth();
				var day = selectedDate.getDate() - 1;
				var year = selectedDate.getFullYear() - 1900;
				
				document.getElementById(selMonthID).options[month].selected = true;
				document.getElementById(selDayID).options[day].selected = true;
				document.getElementById(selYearID).options[year].selected = true;
			}
			
			//called when one of the comboboxes is changed
			function selectDate() {
				var month = document.getElementById(selMonthID).selectedIndex;
				var day = document.getElementById(selDayID).selectedIndex;
				var year = document.getElementById(selYearID).selectedIndex;
				
				var selectedDate = new Date(year + 1900, month, day + 1);
				var calDate = eval(calDateID) ;
				calDate.setDate(selectedDate, selectedDate);
			}
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        <td width="8"  style="background-image: url(img/member/frameleft.gif);" valign=top><img src="img/member/frameleft.gif" width="8" height="408" /></td>
                        <td valign="top" background="img/member/in_bg.gif">
						 <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" CreateUserButtonText="Sign Up" PasswordRegularExpressionErrorMessage="Please enter a more secure password."  Width="100%" OnCreatedUser="CreateUserWizard1_CreatedUser">
                                <WizardSteps>
                                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                        <CustomNavigationTemplate>
                                        </CustomNavigationTemplate>
                                        <ContentTemplate>
                                            <asp:Panel ID="panFocus" runat="server" DefaultButton="StepNextButton">
                                             
                                               
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="50%">
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                                        ErrorMessage="帳號不能空白." ToolTip="帳號不能空白." ValidationGroup="CreateUserWizard" CssClass="pink11_ff9b9b"
                                                                                        ForeColor="#FF9B9B">*</asp:RequiredFieldValidator>
                                                                                    帳號</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="UserName" runat="server" CssClass="deepgry11" Width="100px"></asp:TextBox>
                                                                                    英數4~16字，字首需為英文字母<asp:RegularExpressionValidator ID="valUserNameLength" runat="server"
                                                                                        ControlToValidate="UserName" ErrorMessage="格式不正確." ValidationExpression="[a-zA-Z]{1}[a-zA-Z0-9]{3,}"
                                                                                        ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                                                        ErrorMessage="密碼不能空白." ToolTip="密碼不能空白." ValidationGroup="CreateUserWizard" CssClass="pink11_ff9b9b"
                                                                                        ForeColor="#FF9B9B">*</asp:RequiredFieldValidator>密碼</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="Password" runat="server" CssClass="deepgry11" TextMode="Password"
                                                                                        Width="100px"></asp:TextBox>
                                                                                    英數4~16字
                                                                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                                                                        ErrorMessage="密碼確認不能空白." ToolTip="密碼確認不能空白." ValidationGroup="CreateUserWizard"
                                                                                        CssClass="pink11_ff9b9b" ForeColor="#FF9B9B">*</asp:RequiredFieldValidator>
                                                                                    密碼確認
                                                                                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="deepgry11" TextMode="Password"
                                                                                        Width="100px"></asp:TextBox> <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                                            ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="您輸入的密碼不一致"
                                                                            ValidationGroup="CreateUserWizard"></asp:CompareValidator>
                                                                                    <asp:RegularExpressionValidator ID="valPasswordLength" runat="server" ControlToValidate="Password"
                                                                                        ErrorMessage="字元數錯誤." ValidationExpression="[a-zA-Z0-9]{4,16}" ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    <asp:RequiredFieldValidator ID="valChineseName" runat="server" ControlToValidate="txtChineseName"
                                                                                        ErrorMessage="*" ValidationGroup="CreateUserWizard" CssClass="pink11_ff9b9b"
                                                                                        ForeColor="#FF9B9B"></asp:RequiredFieldValidator>姓名</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    &nbsp;<asp:TextBox ID="txtChineseName" runat="server" CssClass="deepgry11" MaxLength="20"></asp:TextBox>中英文皆可，20字內</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    <asp:RequiredFieldValidator ID="valGender" runat="server" ControlToValidate="rbtnGender"
                                                                                        ErrorMessage="*" ValidationGroup="CreateUserWizard" CssClass="pink11_ff9b9b"
                                                                                        ForeColor="#FF9B9B"></asp:RequiredFieldValidator>
                                                                                    性別</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="height: 100%">
                                                                                        <tr>
                                                                                            <td style="width: 100px">
                                                                                                <asp:RadioButtonList ID="rbtnGender" runat="server" RepeatDirection="Horizontal"
                                                                                                    Width="157px" CssClass="white12">
                                                                                                    <asp:ListItem Value="male">男</asp:ListItem>
                                                                                                    <asp:ListItem Value="female">女</asp:ListItem>
                                                                                                </asp:RadioButtonList></td>
                                                                                            <td style="width: 100px" valign="top">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    <span class="pink11_ff9b9b"></span>生日</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="selYear" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    年
                                                                                    <asp:DropDownList ID="selMonth" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    月
                                                                                    <asp:DropDownList ID="selDay" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    日
                                                                                    <obout:Calendar runat="server" ID="calDate" DatePickerMode="true" DatePickerImagePath="~/calendar/styles/icon2.gif"
                                                                                        OnClientDateChanged="onDateChange" DateMin="1/1/1900" DateMax="12/31/1990" DateFormat="YYYY/MM/DD"
                                                                                        DateToday="1/1/1980" CultureName="zh-TW" ShortDayNames="日, 一, 二, 三, 四, 五, 六"
                                                                                        ShortMonthNames="一月,二月,三月,四月,五月,六月,七月,八月,九月,十月,十一月,十二月" Columns="1" ScrollBy="1"
                                                                                        ShowYearSelector="false" TextArrowLeft="&lt;" TextArrowRight="&gt;" AllowSelectSpecial="False"
                                                                                        TextBoxId="Birth" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTelphone"
                                                                                        ErrorMessage="*" ValidationGroup="CreateUserWizard" CssClass="pink11_ff9b9b"
                                                                                        ForeColor="#FF9B9B"></asp:RequiredFieldValidator>聯絡電話</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    &nbsp;<asp:TextBox ID="txtTelphone" runat="server" CssClass="deepgry11" MaxLength="11"
                                                                                        Width="100px"></asp:TextBox>&nbsp; 行動電話
                                                                                    <asp:TextBox ID="txtMobilePhone" runat="server" CssClass="deepgry11" MaxLength="10" Width="100px"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                                                                        ErrorMessage="Email不能空白." ToolTip="Email不能空白." ValidationGroup="CreateUserWizard"
                                                                                        CssClass="pink11_ff9b9b" ForeColor="#FF9B9B">*</asp:RequiredFieldValidator>電子郵件</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>

                                                                                    <asp:TextBox ID="Email" runat="server" CssClass="deepgry11" Width="200px"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="valEmail1" runat="server" ControlToValidate="Email"
                                                                                        CssClass="asterisk" Display="Dynamic" ErrorMessage="Email 不是正確的格式." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                        ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                                                                                        ErrorMessage="*" ValidationGroup="CreateUserWizard" CssClass="pink11_ff9b9b"
                                                                                        ForeColor="#FF9B9B"></asp:RequiredFieldValidator>居住地址</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="deepgry11" Width="250px"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    職業</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlCareer" runat="server">
                                                                                        <asp:ListItem Text="請選擇" Value=""></asp:ListItem>
                                                                                        <asp:ListItem Text="公司負責人/自僱業者" Value="公司負責人/自僱業者"></asp:ListItem>
                                                                                        <asp:ListItem Text="專業人士" Value="專業人士"></asp:ListItem>
                                                                                        <asp:ListItem Text="上班族" Value="上班族"></asp:ListItem>
                                                                                        <asp:ListItem Text="藍領" Value="藍領"></asp:ListItem>
                                                                                        <asp:ListItem Text="公職人員" Value="公職人員"></asp:ListItem>
                                                                                        <asp:ListItem Text="家庭主婦" Value="家庭主婦"></asp:ListItem>
                                                                                        <asp:ListItem Text="學生" Value="學生"></asp:ListItem>
                                                                                        <asp:ListItem Text="其他" Value="其他"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="90" align="right">
                                                                                    <asp:RequiredFieldValidator ID="valMarital" runat="server" ControlToValidate="rbtnMarital"
                                                                                        CssClass="pink11_ff9b9b" ErrorMessage="*" ForeColor="#FF9B9B" ValidationGroup="CreateUserWizard"></asp:RequiredFieldValidator>婚姻狀況</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td><asp:RadioButtonList ID="rbtnMarital" runat="server" RepeatDirection="Horizontal"
                                                                                                    Width="157px" CssClass="white12">
                                                                                    <asp:ListItem Value="已婚">已婚</asp:ListItem>
                                                                                    <asp:ListItem Value="未婚">未婚</asp:ListItem>
                                                                                </asp:RadioButtonList></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="100" align="right" NOWRAP>
                                                                                    <span class="pink11_ff9b9b">&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                                                        runat="server" ControlToValidate="rbtnIsSubscription" CssClass="pink11_ff9b9b"
                                                                                        ErrorMessage="*" ForeColor="#FF9B9B" ValidationGroup="CreateUserWizard"></asp:RequiredFieldValidator>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rbtnIsMemberCard"
                                                                                            CssClass="pink11_ff9b9b" ErrorMessage="*" ForeColor="#FF9B9B" ValidationGroup="CreateUserWizard"></asp:RequiredFieldValidator></span>會員專屬權益</td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    未來是否願意收到更多Top Girl好康活動訊息
                                                                                    <asp:RadioButtonList ID="rbtnIsSubscription" runat="server" RepeatDirection="Horizontal" CssClass="white12" RepeatLayout="Flow">
                                                                                        <asp:ListItem Value="true">我願意收到</asp:ListItem>
                                                                                        <asp:ListItem Value="false">我不願意收到</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" class="white12">
                                                                        <table border="0" align="left" cellpadding="0" cellspacing="0" class="white12">
                                                                            <tr>
                                                                                <td width="100" align="right">&nbsp;
                                                                                    </td>
                                                                                <td width="10">&nbsp;
                                                                                    </td>
                                                                                <td>
                                                                                    是否持有Top Girl會員卡
                                                                                    <asp:RadioButtonList ID="rbtnIsMemberCard" runat="server" RepeatDirection="Horizontal" CssClass="white12" RepeatLayout="Flow">
                                                                                        <asp:ListItem Value="true">是</asp:ListItem>
                                                                                        <asp:ListItem Value="false">不是</asp:ListItem>
                                                                                    </asp:RadioButtonList></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" class="white12">&nbsp;
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td   class="white12" style="color: red" align="center">
                                                                       <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="height: 30px">
                                                                        <asp:LinkButton ID="StepNextButton" runat="server" CommandName="MoveNext" CssClass="signinButton"
                                                                            Text="Sign Up" ValidationGroup="CreateUserWizard">
                                            <img src="img/hire/send.gif" alt="確認送出" name="Image8" width="87" height="30" border="0"
                                                            id="Image8" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image8','','img/hire/send_1.gif',1)"/>
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                         
            
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:CreateUserWizardStep>
                                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                        <ContentTemplate>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                            <tr>
                                                <td height="100">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <strong>恭喜您註冊成功!</strong><br />
                                                    <br />
                                                    <a href="/" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image8','','img/hire/backindex_1.gif',1)">
                                                        <img src="img/hire/backindex.gif" alt="回首頁" name="Image8" width="87" height="30"
                                                            border="0" id="Image8" /></a></td>
                                            </tr>
                                        </table>
                                           
                                        </ContentTemplate>
                                    </asp:CompleteWizardStep>
                                </WizardSteps>
                            </asp:CreateUserWizard>
						</td>
                        <td width="10"  style="background-image: url(img/member/frameright.gif);" valign=top><img src="img/member/frameright.gif" width="10" height="408" /></td>
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
