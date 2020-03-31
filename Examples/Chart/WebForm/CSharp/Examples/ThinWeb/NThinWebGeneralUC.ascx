<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NThinWebGeneralUC" CodeFile="NThinWebGeneralUC.ascx.cs" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NThinChartControl ID="NThinChartControl1" runat="server" Width="420px" Height="320px"/>
        <!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
        <!-- Description box placeholder BEGIN -->
        The example demonstrates general ThinWeb Chart control funcionality. 
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
