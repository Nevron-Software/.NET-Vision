<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NImageMapPostbackResponseUC" CodeFile="NImageMapPostbackResponseUC.ascx.vb" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" style="width: 420px; vertical-align: top; padding: 3px;">
		<!-- Chart control placeholder BEGIN -->        
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="345" Height="336">
		</ncwc:NChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleImageCell1" style="width: 420px; vertical-align: top; padding: 3px;">
		<!-- Chart control placeholder BEGIN -->        
		<ncwc:NChartControl id="nChartControl2" runat="server" Height="336px" Width="345px">
		</ncwc:NChartControl>
		<!-- Chart control placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates server side events. Click on a pie slice to detach it.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
