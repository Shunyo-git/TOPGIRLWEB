<%@ Page Language="VB" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_NET" %>

<script runat="server">

	Protected calDefault As OboutInc.Calendar2.Calendar
	Protected calDatePicker As OboutInc.Calendar2.Calendar
	
	Public Sub Page_Load(o As Object, e As EventArgs)
		If Not Page.IsPostBack Then
			calDefault.StyleFolder = "../../styles/simple"
			calDefault.MonthWidth = 160
			calDefault.MonthHeight = 130
			
			calDatePicker.StyleFolder = "../../styles/simple"
			calDatePicker.DatePickerMode = true
			calDatePicker.TextBoxId = "txtDate"
			calDatePicker.DatePickerImagePath = "../../styles/icon2.gif"
			calDatePicker.MonthWidth = 160
			calDatePicker.MonthHeight = 130
			
			DefaultPlaceholder.Controls.Add(calDefault)
			DatePickerPlaceholder.Controls.Add(calDatePicker)
		End If
	End Sub

	Public Sub Page_Init(o As Object, e As EventArgs)
		calDefault = new OboutInc.Calendar2.Calendar()
		calDatePicker = new OboutInc.Calendar2.Calendar()
		
		calDefault.ID = "calDefault"
		calDatePicker.ID = "calDatePicker"
	End Sub
</script>

<form runat="server">

Default settings: <br>
<ASP:PlaceHolder runat="server" id="DefaultPlaceholder"></ASP:PlaceHolder>

<br>
<br>

Date picker mode: <br>
<ASP:TextBox runat="server" id="txtDate"></ASP:TextBox>

<ASP:PlaceHolder runat="server" id="DatePickerPlaceholder"></ASP:PlaceHolder>

</form>