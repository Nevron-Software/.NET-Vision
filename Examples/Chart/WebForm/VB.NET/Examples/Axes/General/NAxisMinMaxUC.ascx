<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAxisMinMaxUC" CodeFile="NAxisMinMaxUC.ascx.vb" %>
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
		<asp:Button id="ChangeDataButton" runat="server" Width="177" Height="24" Text="Change Data" onclick="ChangeDataButton_Click"></asp:Button>
		<asp:Label id="Label3" runat="server" Font-Size="8pt"></asp:Label>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates how the Min and Max values of an axis can be retrieved at 
		runtime. The Min and Max properties of the axis scale are accessed in a handler 
		of the BeforePaint event. This happens after the axes are calculated and before 
		the chart is rendered.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
