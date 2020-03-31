<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NLinearGaugeIndicatorsUC" CodeFile="NGaugeBordersUC.ascx.cs" %>
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
		<asp:Label id="Label1" runat="server">Border Type:</asp:Label>
		<br/>
		<asp:DropDownList id="BorderTypeDropDownList" Width="144px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br/>
		<asp:Label id="Label2" runat="server">Radial Gauge Auto Border Type:</asp:Label>
		<br/>
		<asp:DropDownList id="RadialGaugeAutoBorderDropDownList" Width="144px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br/>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates how to apply border style to gauges.<br />
		You can choose the border type from "Border Type" combo on the right. There are three options:<br />
		<ul>
		<li>Rectangular - applies a standard rectangular border to the gauges.</li>
		<li>Rounded Rectangular - applies a standard rounded rectangular border to the gauges.</li>
		<li>Auto - the border is applied depending on the gauge type. For radial gauges you can choose from Circle, Cut Circle and Rounded Outline.</li>
		</ul>
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
