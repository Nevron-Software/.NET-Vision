<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NTriangulatedSurfaceSimplificationUC" CodeFile="NTriangulatedSurfaceSimplificationUC.ascx.vb" %>
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
		<!-- Configuration controls panel placeholder BEGIN -->
		<asp:CheckBox id="SimplifySurfaceCheckBox" runat="server" AutoPostBack="True" Text="Simplify Surface"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the clustering feature of the Triangulated Surface. With its help the number of rendered points can be decreased by 
		a large amount, while at the same time the surface's visual representation is not changed significantly. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
