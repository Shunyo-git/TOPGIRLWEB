<%@ Page Language="C#" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_NET" %>

<form runat="server">

Default settings: <br>
<obout:Calendar runat="server"
				StyleFolder="../styles/desert"
				TextArrowLeft=""
				TextArrowRight=""
				MonthWidth="171"
				MonthHEight="147"
				monthmarginwidth="6">
</obout:Calendar>

<br>
<br>

Date picker mode: <br>
<ASP:TextBox runat="server" id="txtDate"></ASP:TextBox>

<obout:Calendar runat="server"
				StyleFolder="../styles/desert"
				TextArrowLeft=""
				TextArrowRight=""
				MonthWidth="171"
				MonthHeight="147"
				DatePickerMode = "true"
				TextBoxId = "txtDate"
				DatePickerImagePath = "../styles/icon2.gif">
</obout:Calendar>

</form>