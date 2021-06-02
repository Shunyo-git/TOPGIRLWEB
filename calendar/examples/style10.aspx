<%@ Page Language="C#" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_NET" %>

<html>
<body style="background-color:#dddddd;">

<form runat="server">

Default settings: <br>
<obout:Calendar runat="server"
				StyleFolder="../styles/style10"
				TextArrowLeft=""
				TextArrowRight=""
				MonthWidth="160"
				MonthHEight="130"
				monthmarginwidth="6">
</obout:Calendar>

<br>
<br>

Date picker mode: <br>
<ASP:TextBox runat="server" id="txtDate"></ASP:TextBox>

<obout:Calendar runat="server"
				StyleFolder="../styles/style10"
				TextArrowLeft=""
				TextArrowRight=""
				MonthWidth="160"
				MonthHeight="130"
				DatePickerMode = "true"
				TextBoxId = "txtDate"
				DatePickerImagePath = "../styles/icon2.gif">
</obout:Calendar>

</form>

</body>
</html>