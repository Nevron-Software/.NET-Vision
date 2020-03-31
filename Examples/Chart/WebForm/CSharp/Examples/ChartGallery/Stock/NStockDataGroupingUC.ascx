<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStockDataGroupingUC" CodeFile="NStockDataGroupingUC.ascx.cs" %>
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
        <asp:label id="Label3" runat="server">Grouping Mode:</asp:label><br />
        <asp:dropdownlist id="GroupingModeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<br />
		<asp:label id="Label1" runat="server">Min Group Distance:</asp:label><br />
        <asp:dropdownlist id="MinGroupDistanceDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<br />
		<asp:label id="Label2" runat="server">Custom Date Time Span:</asp:label><br />
        <asp:dropdownlist id="CustomDateTimeSpanDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<br />
		<asp:label id="Label4" runat="server">Group Percent Width:</asp:label><br />
		<asp:dropdownlist id="GroupPercendWidthDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		The example demonstrate how to apply stock data grouping to stock charts. Stock grouping allows you to visualize stock data by aggregating values that are close together in time in order not to overpopulate the chart.
		On the right side you can modify the grouping mode and other properties of the stock series.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
