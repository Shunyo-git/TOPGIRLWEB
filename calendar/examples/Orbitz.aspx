<%@ Page Language="C#" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_NET" %>

<form runat="server">

Default settings: <br>
<obout:Calendar runat="server"
				StyleFolder = "../styles/orbitz"
				TextArrowLeft = "" 
				TextArrowRight = ""
				MonthWidth = "155"
				MonthHeight = "140">
</obout:Calendar>

<br>
<br>

Date picker mode: <br>
<ASP:TextBox runat="server" id="txtDate"></ASP:TextBox>

<obout:Calendar runat="server"
				StyleFolder = "../styles/orbitz"
				DatePickerMode = "true"
				TextBoxId = "txtDate"
				DatePickerImagePath = "../styles/icon2.gif"
				TextArrowLeft = "" 
				TextArrowRight = ""
				MonthWidth = "155"
				MonthHeight = "140">
</obout:Calendar>

</form>