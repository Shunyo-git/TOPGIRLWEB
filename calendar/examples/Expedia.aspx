<%@ Page Language="C#" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_NET" %>

<form runat="server">

Default settings: <br>
<obout:Calendar runat="server"
				StyleFolder = "../styles/expedia"
				TextArrowLeft = "" 
				TextArrowRight = ""
				MonthWidth = "147"
				MonthHeight = "150">
</obout:Calendar>

<br>
<br>

Date picker mode: <br>
<ASP:TextBox runat="server" id="txtDate"></ASP:TextBox>

<obout:Calendar runat="server"
				StyleFolder = "../styles/expedia"
				DatePickerMode = "true"
				TextBoxId = "txtDate"
				DatePickerImagePath = "../styles/icon2.gif"
				TextArrowLeft = "" 
				TextArrowRight = ""
				MonthWidth = "147"
				MonthHeight = "150">
</obout:Calendar>

</form>