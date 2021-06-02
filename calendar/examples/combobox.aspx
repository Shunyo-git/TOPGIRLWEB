<%@ Page Language="C#" EnableViewState="False" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>

<html>
	<head>
		<script type="text/javascript">
			//this function is called when date is selected in calendar
			function onDateChange(sender, selectedDate) {
				var month = selectedDate.getMonth();
				var day = selectedDate.getDate() - 1;
				var year = selectedDate.getFullYear() - 1999;
				
				document.getElementById("selMonth").options[month].selected = true;
				document.getElementById("selDay").options[day].selected = true;
				document.getElementById("selYear").options[year].selected = true;
			}
			
			//called when one of the comboboxes is changed
			function selectDate() {
				var month = document.getElementById("selMonth").selectedIndex;
				var day = document.getElementById("selDay").selectedIndex;
				var year = document.getElementById("selYear").selectedIndex;
				
				var selectedDate = new Date(year + 1999, month, day + 1);
				
				calDate.setDate(selectedDate, selectedDate);
			}
		</script>

	</head>
	<body>
		<select id="selMonth" onChange="selectDate()">
			<option >January</option>
			<option>February</option>
			<option>March</option>
			<option>April</option>
			<option>May</option>
			<option>June</option>
			<option>July</option>
			<option>August</option>
			<option>September</option>
			<option>October</option>
			<option>November</option>
			<option>December</option>
		</select>
		
		<select id="selDay" onChange="selectDate()">
			<option>1</option>
			<option>2</option>
			<option>3</option>
			<option>4</option>
			<option>5</option>
			<option>6</option>
			<option>7</option>
			<option>8</option>
			<option>9</option>
			<option>10</option>
			<option>11</option>
			<option>12</option>
			<option>13</option>
			<option>14</option>
			<option>15</option>
			<option>16</option>
			<option>17</option>
			<option>18</option>
			<option>19</option>
			<option>20</option>
			<option>21</option>
			<option>22</option>
			<option>23</option>
			<option>24</option>
			<option>25</option>
			<option>26</option>
			<option>27</option>
			<option>28</option>
			<option>29</option>
			<option>30</option>
			<option>31</option>
		</select>
		
		<select id="selYear" onChange="selectDate()">
			<option>1999</option>
			<option>2000</option>
			<option>2001</option>
			<option>2002</option>
			<option>2003</option>
			<option>2004</option>
			<option>2005</option>
			<option>2006</option>
			<option>2007</option>
			<option>2008</option>
			<option>2009</option>
			<option>2010</option>
		</select>&#160;

		<obout:Calendar runat="server" id="calDate"
						DatePickerMode="true"
						DatePickerImagePath ="~/calendar/styles/icon2.gif"
						OnClientDateChanged="onDateChange"
						DateMin="1/1/1999"
						DateMax = "12/31/2010" />
	</body>
</html>