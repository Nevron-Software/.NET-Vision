<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NToolbarConfigurationUC" CodeFile="NToolbarConfigurationUC.ascx.cs" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 600px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 600px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NThinChartControl ID="NThinChartControl1" runat="server" Width="600px" Height="400px"/>
        <!-- Chart control placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 600px;" class="Description">
        <!-- Description box placeholder BEGIN -->
        The example demonstrates the built-in toolbar functionality.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
