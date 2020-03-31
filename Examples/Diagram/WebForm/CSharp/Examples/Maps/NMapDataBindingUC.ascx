<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="C#" Inherits="Nevron.Examples.Diagram.Webform.NMapDataBindingUC" CodeFile="NMapDataBindingUC.ascx.cs" %>

<table id="exampleImageTable" style="vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="460px" Height="400px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width:290px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        <table id="properties">
            <tr>
                <td style="padding:3px">Data Grouping</td>
                <td style="padding:3px">
					<select id="dataGroupingSelect" onchange="RecreateMap();">
						<option value="EqualDistribution">Equal Distribution</option>
						<option value="EqualInterval">Equal Interval</option>
						<option selected="selected" value="Optimal">Optimal</option>
					</select>                
                </td>
            </tr>
            <tr>
                <td style="padding:3px">Rounded Ranges</td>
                <td style="padding:3px"><input id="chkRoundedRanges" type="checkbox" name="chkRoundedRanges" checked="checked" onclick="RecreateMap();" /></td>
            </tr>
        </table>
		<img id="legend" src="../Examples/Maps/NMapLegendRenderPage.aspx" alt="Map Legend" />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
        <p>
            <b>Nevron Diagram</b> makes it easy to import geographical data from Esri shapefiles. You
            can import the shapes in separate layers and control the way they are rendered applying
            various styles to them. Also additional information is provided for each shape
            (such as Country Name, Area, Population, Currency, etc.)
        </p>        
        <p>
            You can add more attributes to the shapes by means of data binding. All you have to do is to
            call one of the DataBind methods of the <i>NEsriShapefile</i> specifying the data source, the
            primary and foreign key columns and the binding column. <b>Map fill rules</b> and <b>data grouping
            policies</b> can be used to automatically color map shapes based on the value of a specified shape
            attribute.
        </p>
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>

<!-- Custom JavaScript placeholder START -->
<script language='javascript'>
	function RecreateMap() {
		var dataGroupingSelect = document.getElementById("dataGroupingSelect");
		var argument = dataGroupingSelect.options[dataGroupingSelect.selectedIndex].value + ",";
		argument += document.getElementById("chkRoundedRanges").checked ? "true" : "false";
		NClientNode.GetFromId("Diagram1").ExecuteCustomRequest(argument);
	}

	$(document).ready()
	{
		var diagramHost = NClientNode.GetFromId("Diagram1");
		diagramHost.CustomCommandCallback = function (argument) {
			if (argument == "UpdateLegend") {
				var imageSrc = "../Examples/Maps/NMapLegendRenderPage.aspx?a=" + Math.random();
				document.getElementById("legend").src = imageSrc;
			}
		};
	}

</script>
<!-- Custom JavaScript placeholder END -->