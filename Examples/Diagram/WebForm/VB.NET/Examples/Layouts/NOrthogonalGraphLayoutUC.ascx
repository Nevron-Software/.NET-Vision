<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NOrthogonalGraphLayoutUC" CodeFile="NOrthogonalGraphLayoutUC.ascx.vb" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="450px" Height="400px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 250px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<table id="properties">
			<tr>
				<td style="padding:3px">Compact</td>
				<td style="padding:3px"><input type="checkbox" id="Compact" checked="checked" /></td>
			</tr>
			<tr>
				<td style="padding:3px">Cell Spacing</td>
				<td style="padding:3px"><input type="text" id="CellSpacing" value="10"  maxlength="3" style="width:30px;" onchange="ValidateTextBox(this, 'float', 10, 0, 999)" /></td>
			</tr>
		</table>
		
		<hr class="WhiteHr" />
		
		<p>
			<input type="button" id="btnLayout" value="Layout" style="width:100%" onclick="InvokeCustomCommand(this.id)" /><br />
		</p>
		<p>
			<input type="button" id="RandomGraph10" value="Random graph (10 vertices, 15 edges)" style="width:100%; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
			<input type="button" id="RandomGraph20" value="Random graph (20 vertices, 25 edges)" style="width:100%; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
		</p>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		<p>
			The orthogonal graph layout produces orthogonal graph drawings of all types of graphs
			(including those with self-loops and duplicate edges). It tries to compact the graph
			drawing area and also to minimize the number of edge crossings and bends.
		</p>
		<p>
			The most important properties are:
			<ul>
				<li>
					<b>CellSpacing</b> - determines the distance between 2 grid cells. For example if a grid
					cell is calculated to have a size of 100 x 100 and the CellSpacing property is set to
					10, then the cell size will be 120 x 120. Note that the node is always placed in the
					middle of the cell.
				</li>
				<li>
					<b>Compact</b> - if set to true, a compaction algorithm will be applied to the embedded
					graph. This will decrease the total area of the drawing with 20 to 50 % (in the average
					case) at the cost of some additional time needed for the calculations.
				</li>
				<li>
					<b>PlugSpacing</b> - determines the spacing between the plugs of a node.
					You can set a fixed amount of spacing or a proportional spacing, which means that the plugs
					are distributed along the whole side of the node.
				</li>
			</ul>
		</p>
		<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder START -->
<script type="text/javascript" language="javascript">
<!--
	// Gets all properties name/value pairs as string in the format:
	// name1=value1
	// name2=value2
	// etc.
	function GetPropertiesAsString() {
		var el = document.getElementById("properties");
		if (typeof (el) == "undefined")
			return properties;

		var i, el, count;
		var inputs = el.getElementsByTagName("input");
		var selects = el.getElementsByTagName("select");
		var result = "";

		// The input elements
		count = inputs.length;
		for (i = 0; i < count; i++) {
			el = inputs[i];
			switch (el.type) {
				case "text":
					result += el.id + "=" + el.value + "\n";
					break;
				case "checkbox":
					result += el.id + "=" + el.checked + "\n";
					break;
				case "radio":
					if (el.checked) {
						result += el.name + "=" + el.value + "\n";
					}
					break;
			}
		}

		// The select elements
		count = selects.length;
		for (i = 0; i < count; i++) {
			el = selects[i];
			result += el.id + "=" + el.options[el.selectedIndex].value + "\n";
		}

		return result;
	}

	function InvokeCustomCommand(sender) {
		NClientNode.GetFromId("Diagram1").ExecuteCustomRequest("command=" + sender + "\n" + GetPropertiesAsString());
	}
//-->
</script>
<!-- Custom JavaScript placeholder END -->