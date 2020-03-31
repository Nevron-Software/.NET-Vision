<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NMapProjectionsUC" CodeFile="NMapProjectionsUC.ascx.vb" %>

<table id="exampleImageTable" style="vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="450px" Height="400px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width:300px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<b>Projection:</b><br />
		<asp:Literal id="ProjectionsRadioGroup" runat="server" />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		Nevron Diagram makes it easy to import geographical data from Esri shapefiles. You can import
		the shapes in separate layers and control the way they are rendered applying various styles to
		them. Also additional information is provided for each shape (such as Country Name, Area, Population,
		Currency, etc.). When rendering the map, the 3D geographical data must be projected on the plane to
		produce the 2D map. You can choose among 22 Map projections.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>

<!-- Custom JavaScript placeholder START -->
<script language='javascript'>
	function ChangeProjection(index) {
		NClientNode.GetFromId("Diagram1").ExecuteCustomRequest(index.toString());
	}
</script>
<!-- Custom JavaScript placeholder END -->