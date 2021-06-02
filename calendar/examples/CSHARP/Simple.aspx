<%@ Page Language="C#" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_NET" %>

<script runat="server">

	protected OboutInc.Calendar2.Calendar calDefault;
	protected OboutInc.Calendar2.Calendar calDatePicker;
	
	void Page_Load(object o, EventArgs e) {
		if(!Page.IsPostBack) {
			calDefault.StyleFolder = "../../styles/simple";
			calDefault.MonthWidth = 160;
			calDefault.MonthHeight = 130;
			
			calDatePicker.StyleFolder = "../../styles/simple";
			calDatePicker.DatePickerMode = true;
			calDatePicker.TextBoxId = "txtDate";
			calDatePicker.DatePickerImagePath = "../../styles/icon2.gif";
			calDatePicker.MonthWidth = 160;
			calDatePicker.MonthHeight = 130;
			
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