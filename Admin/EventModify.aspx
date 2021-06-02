<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="EventModify.aspx.cs" Inherits="Admin_EventModify" %>

<%@ Register Src="UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="input-warn-content"
        ForeColor="" Width="758px" />
<table border="0" cellpadding="0" cellspacing="0" style="width: 759px">
        <tr>
            <td style="height: 22px; width: 8px;">
            </td>
            <td align="right" style="height: 22px">
                <img src="/Admin/image/icon-save.gif" width="14" height="18" />&nbsp;
                <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">儲存</asp:LinkButton>&nbsp;
                <img src="/Admin/image/icon-cancel.gif" width="18" height="18" />
                <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click" CausesValidation="False">取消</asp:LinkButton></td>
        </tr>
    </table>
    <table id="table4" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="95%">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" height="25" style="width: 759px">
                活動訊息設定</td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <font face="新細明體">
                    <table id="Table2" border="1" cellspacing="0" class="Forumrow"  rules="all"
                        style="width: 100%; border-collapse: collapse" width="100%">
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                自動編號：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblID" runat="server">新增後自動產生</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                活動訊息類別：</td>
                            <td align="left" height="20">
                                <asp:DropDownList ID="ddlEventGroup" runat="server" DataTextField="Name" DataValueField="GroupID">
                                </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                網頁顯示：</td>
                            <td align="left" height="20" class="ColumnTD">
                               <asp:RadioButtonList ID="rbtnIsDisplay" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">顯示</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">不顯示</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                首頁顯示：</td>
                            <td align="left" height="20" class="ColumnTD">
                                <asp:RadioButtonList ID="rbtnIsHomepageDisplay" runat="server" BorderStyle="None"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">不顯示</asp:ListItem>
                                    <asp:ListItem Value="1">本季活動快訊</asp:ListItem>
                                    <asp:ListItem Value="2">最新消息</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td class="TH" style="width: 759px" align="left">
                <b>活動訊息本文</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            短&nbsp; 標 &nbsp;題：</td>
                        <td align="left">
                            <asp:TextBox ID="txtTitle" runat="server" Width="20%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValSubTitle" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="短標題不能空白" ToolTip="短標題不能空白"><img src="image/icon_validate_cross.gif" align="absmiddle" width="12" height="12" /></asp:RequiredFieldValidator><span style="color: #336600">(10字以內)</span></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" width="15%" style="height: 28px">
                            標 題：
                        </td>
                        <td align="left" style="height: 28px" >
                                <asp:TextBox ID="txtSubTitle" runat="server" Width="90%" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValTitle" runat="server" ControlToValidate="txtSubTitle"
                                ErrorMessage="標題不能空白" ToolTip="標題不能空白"><img src="image/icon_validate_cross.gif" align="absmiddle" width="12" height="12" /></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                            <td align="right" class="ColumnTD" >
                                日 期：</td>
                            <td align="left" height="20" class="ColumnTD">	 <ASP:TextBox ID="txtReleaseDate" runat="server" Width="80px" />
                                <obout:Calendar ID="Calendar1" runat="server"
				StyleFolder = "/calendar/styles/blue"
				DatePickerMode = "true"
				TextBoxId = "txtReleaseDate"
				DatePickerImagePath = "/calendar/styles/icon2.gif"
				 DateMin="2006-01-01" DateMax="2046-12-31" DateFormat="yyyy/MM/dd"
				 CultureName="zh-TW" ShortDayNames="日, 一, 二, 三, 四, 五, 六"
                                ShortMonthNames="一月,二月,三月,四月,五月,六月,七月,八月,九月,十月,十一月,十二月" 
				MonthWidth="200" 
				MonthHeight="30" Columns="1" MonthMarginWidth="10">
</obout:Calendar>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtReleaseDate"
                                    Display="Dynamic" ErrorMessage="*日期需為2006/01/01 以後" Operator="GreaterThan"
                                    Type="Date" ValueToCompare="2000/01/01">日期格式範例 (2006/03/01)</asp:CompareValidator>
                                </td>
                        </tr>
                    
                    <tr>
                        <td align="right" class="ColumnTD" width="15%" valign="top">
                            活動訊息內文：</td>
                        <td align="left"  >
                            <asp:TextBox ID="txtContent" runat="server" Rows="20" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" width="15%" valign="top">
                            活動照片上傳：</td>
                        <td align="left">
                            &nbsp;<uc1:UploadControl ID="UploadControl1" runat="server" FileTypeRange="jpg,jpeg"
                                Icon_Validate_Cross="image/icon_validate_cross.gif" Icon_Validate_Spacer="image/icon_validate_Spacer.gif"
                                Icon_Validate_Tick="image/icon_validate_Tick.gif" MaxWidth="1024" MinWidth="264"
                                Required="false" FileControlWidth="90%" />
                                <p>◎圖檔尺寸長、寬小於1024像素以內，格式Jpg,Jpeg。</p>
                            <asp:HyperLink ID="linkEventImage" runat="server" Target="_blank"><asp:Image ID="imgEvent" runat="server" Width="264" /></asp:HyperLink>
                        </td>
                    </tr>
                </table>
                <p>
                    <asp:CustomValidator ID="ValidatorResult" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>&nbsp;</p>
               
            </td>
        </tr>
    </table>
</asp:Content>

