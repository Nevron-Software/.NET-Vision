<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NDynamicAxisRangeUC" CodeFile="NDynamicAxisRangeUC.ascx.cs" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
        <ncwc:NThinChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
        </ncwc:NThinChartControl>
        <!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<asp:label id="Label1" runat="server">Series Vertical Axis Mode:</asp:label><br />
        <asp:dropdownlist id="VerticalAxisRangeModeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br /><br />
        <asp:label id="Label3" runat="server">Current Interval:</asp:label><br />
        <asp:dropdownlist id="IntervalDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		The example demonstrates the ability of the chart to dynamically recalculate the Y axis range based on the currently zoomed x axis range.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
