<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NXYScatterLineUC" CodeFile="NXYScatterLineUC.ascx.vb" %>
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
		<asp:Button id="ChangeXValuesButton" runat="server" Text="Change X values"></asp:Button>            
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		XY Scatter line charts are created when the user instructs the line series to 
		use a custom x value for the line data point positions. Note that in this case 
		the Bottom axis is switched in numeric scale mode.<br />
		The Change X Values button changes the X values of the line series.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
