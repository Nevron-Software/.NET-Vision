<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NRadialGaugeKnobsUC" CodeFile="NRadialGaugeKnobsUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Marker Shape</asp:Label>
		<asp:DropDownList id="MarkerShapeDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br/>
		<asp:Label id="Label3" runat="server">Outer Rim Pattern:</asp:Label>
		<asp:DropDownList id="OuterRimPatternDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br/>
		<br/>
		<asp:Label id="Label2" runat="server">Inner Rim Pattern:</asp:Label>
		<asp:DropDownList id="InnerRimPatternDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br/>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
The example demonstrates how to add knob indicators to radial gauges.<br />
Use the controls on the right to modify different settings for the knob inner and outer rim as well as the knob marker.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
