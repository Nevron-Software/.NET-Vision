<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="C#" Inherits="Nevron.Examples.Diagram.Webform.NWorldMapUC" CodeFile="NWorldMapUC.ascx.cs" %>

<table id="exampleImageTable" style="vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="500px" Height="400px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width:250px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		City:<br />
		<asp:Literal id="CitiesComboBox" runat="server" /><br />
		<input type="button" value="Navigate to City" onclick="NavigateToCity();" /><p />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		Nevron Diagram makes it easy to import geographical data from Esri shapefiles. You can import
		the shapes in separate layers and control the way they are rendered applying various styles to
		them. Also additional information is provided for each shape (such as Country Name, Area,
		Population, Currency, etc.)<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>

<!-- Custom JavaScript placeholder START -->
<script language='javascript'>
	function NavigateToCity() {
		var citiesCombo = document.getElementById("citiesCombo");
		var argument = citiesCombo.options[citiesCombo.selectedIndex].text + ",";
		argument += citiesCombo.options[citiesCombo.selectedIndex].value;
		NClientNode.GetFromId("Diagram1").ExecuteCustomRequest(argument);
	}
</script>
<!-- Custom JavaScript placeholder END -->