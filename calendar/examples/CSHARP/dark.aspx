<%@ Page Language="C#" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_NET" %>

<script runat="server">

	protected OboutInc.Calendar2.Calendar calDefault;
	protected OboutInc.Calendar2.Calendar calDatePicker;
	
	void Page_Load(object o, EventArgs e) {
		if(!Page.IsPostBack) {
			calDefault.StyleFolder = "../../styles/dark";
			calDefault.MonthWidth = 147;
			calDefault.MonthHeight = 133;
			
			calDatePicker.StyleFolder = "../../styles/dark";
			calDatePicker.DatePickerMode = true;
			calDatePicker.TextBoxId = "txtDate";
			calDatePicker.DatePickerImagePath = "../../styles/icon2.gif";
			calDatePicker.MonthWidth = 147;
			calDatePicker.MonthHeight = 133;
			
			DefaultPlaceholder.Controls.Add(calDefault);
			DatePickerPlaceholder.Controls.Add(calDatePicker);
		}
	}

	void Page_Init(object o, EventArgs e) {
		calDefault = new OboutInc.Calendar2.Calendar();
		calDatePicker = new OboutInc.Calendar2.Calendar();
		
		calDefault.ID = "calDefault";
		calDatePicker.ID = "calDatePicker";
	}
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