<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NFloatBarConnectorLinesUC" CodeFile="NFloatBarConnectorLinesUC.ascx.vb" %>
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
		<asp:CheckBox id="ShowConnectorLinesCheckBox" runat="server" AutoPostBack="True" Text="Show Connector Lines"></asp:CheckBox>
		<br />
		<asp:CheckBox id="ShowGanttConnectorLinesCheckBox" runat="server" AutoPostBack="True" Text="Show Gantt Connector Lines"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates the ability of the float bar series to draw connector lines between adjacent bars.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
