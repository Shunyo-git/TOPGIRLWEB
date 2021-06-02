<%@ Page Language="C#" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_NET" %>

<form runat="server">

Default settings: <br>
<obout:Calendar runat="server"
				StyleFolder = "../styles/blue"
				MonthWidth="160" 
				MonthHeight="170">
</obout:Calendar>

<br>
<br>

Date picker mode: <br>
<ASP:TextBox runat="server" id="txtDate"></ASP:TextBox>

<obout:Calendar runat="server"
				StyleFolder = "../styles/blue"
				DatePickerMode = "true"
				TextBoxId = "txtDate"
				DatePickerImagePath = "../styles/icon2.gif"
				MonthWidth="160" 
				MonthHeight="170">
</obout:Calendar>

</form>
