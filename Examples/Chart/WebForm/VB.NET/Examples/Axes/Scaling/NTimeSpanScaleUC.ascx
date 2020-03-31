<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NTimeSpanScaleUC" CodeFile="NTimeSpanScaleUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
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
		<asp:CheckBox id="EnableUnitSensitiveFormattingCheckBox" runat="server" AutoPostBack="True" Text="Enable Unit Sensitive Formatting" />
		<br />
		<br />
		<asp:Label id="AllowedTimSpanUnitsLabel" runat="server">Allowed Time Span Units:</asp:Label>
		<br />
		<asp:CheckBox id="MillisecondCheckBox" Checked="true" runat="server" AutoPostBack="True" Text="Millisecond" />
		<br />
		<asp:CheckBox id="SecondCheckBox" Checked="true" runat="server" AutoPostBack="True" Text="Second" />
		<br />
		<asp:CheckBox id="MinuteCheckBox" Checked="true" runat="server" AutoPostBack="True" Text="Minute" />
		<br />
		<asp:CheckBox id="HourCheckBox" Checked="true" runat="server" AutoPostBack="True" Text="Hour" />
		<br />
		<asp:CheckBox id="DayCheckBox" Checked="true" runat="server" AutoPostBack="True" Text="Day" />
		<br />
		<asp:CheckBox id="WeekCheckBox" Checked="true" runat="server" AutoPostBack="True" Text="Week" />
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Sample Time Range:</asp:Label>
		<br />
		<asp:DropDownList id="SampleTimeRangeDropDownList" runat="server" AutoPostBack="True">
		</asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates the time span scaling features in Nevron Chart.<br />
		In this example the scale will automatically select a time span unit and step 
		in this unit according to the time range you specify.<br />
		When you check the Enable Unit Sensitive Formatting check box the scale will also 
		use a date time formatting string that is most appropriate for the currently 
		determined unit for the scale.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
