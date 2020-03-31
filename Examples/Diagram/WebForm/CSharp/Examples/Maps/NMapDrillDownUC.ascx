<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="C#" Inherits="Nevron.Examples.Diagram.Webform.NMapDrillDownUC" CodeFile="NMapDrillDownUC.ascx.cs" %>

<table id="exampleImageTable" style="vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="720px" Height="500px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		Click a state to see a map of its counties. Then click a county to select/deselect it or click outside the state (in the blue area)
		to go back to the States map. When you sect a country you will see it's FIPS code. All states and counties have a tooltip. It can
		be turned off for all element from the toolbar above the map.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>