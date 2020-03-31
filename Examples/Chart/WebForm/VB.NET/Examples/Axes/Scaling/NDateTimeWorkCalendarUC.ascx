<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" AutoEventWireup="true" CodeFile="NDateTimeWorkCalendarUC.ascx.vb" Inherits="Nevron.Examples.Chart.WebForm.NDateTimeWorkCalendarUC" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
		</ncwc:NChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<asp:CheckBox id="EnableWeekRuleCheckBox" runat="server" AutoPostBack="True" Text="Enable Week Rule" />
		<br />
		<p style="margin-left : 10px">
			<asp:CheckBox id="MondayCheckBox" runat="server" AutoPostBack="True" Text="Monday" />
			<br />
			<asp:CheckBox id="TuesdayCheckBox" runat="server" AutoPostBack="True" Text="Tuesday" />
			<br />
			<asp:CheckBox id="WednesdayCheckBox" runat="server" AutoPostBack="True" Text="Wednesday" />
			<br />
			<asp:CheckBox id="ThursdayCheckBox" runat="server" AutoPostBack="True" Text="Thursday" />
			<br />
			<asp:CheckBox id="FridayCheckBox" runat="server" AutoPostBack="True" Text="Friday" />
			<br />
			<asp:CheckBox id="SaturdayCheckBox" runat="server" AutoPostBack="True" Text="Saturday" />
			<br />
			<asp:CheckBox id="SundayCheckBox" runat="server" AutoPostBack="True" Text="Sunday" />
			<br />
		</p>
		<asp:CheckBox id="EnableMonthDayRuleCheckBox" runat="server" AutoPostBack="True" Text="Enable Month Day Rule" />
		<br />
		<p style="margin-left : 10px">
			<asp:Label id="Label1" runat="server">Day of Month:</asp:Label>
			<asp:DropDownList id="MonthDayDropDownList" Width="48px" runat="server" AutoPostBack="True" ></asp:DropDownList>
			<br />
			<asp:CheckBox id="MonthDayWorkingCheckBox" runat="server" AutoPostBack="True" Text="Working" />
			<br /><br />
		</p>
		<asp:Label id="Label2" runat="server">Zoom Mode:</asp:Label>
		<br />
		<asp:DropDownList id="ZoomModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br /><br />
		<asp:Button id="GenerateDataButton" runat="server" Width="173px" Text="Generate Data " ></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
The example demonstrates the ability of the timeline and date/time scales to skip date time 
ranges, when it is expected that there is no data for them. Common applications of this feature 
are financial charts that usually display only working week days as stock markets are 
closed on weekends.<br /><br/>
Click on the "Enable Week Rule" if you want to enable/disable weekday working or non 
working pattern. The check boxes below allow you to select the working days in a week.<br /><br/>
Click on the "Enable Month Day Rule" if you want to enable/disable a specific month day 
(each first month day in this example).<br /><br/>
The chart will generate data that does not contain information for the non working days 
defined by the above rules.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
