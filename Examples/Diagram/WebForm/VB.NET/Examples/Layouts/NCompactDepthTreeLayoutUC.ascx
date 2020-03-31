<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NCompactDepthTreeLayoutUC" CodeFile="NCompactDepthTreeLayoutUC.ascx.vb" %>

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
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width:300px;">
		<!-- Configuration controls panel placeholder BEGIN -->
			<table id="properties">
				<tr>
					<td style="padding:3px">Orthogonal Edge Routing</td>
					<td style="padding:3px"><input type="checkbox" id="OrthogonalEdgeRouting" checked="checked" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Compact Breadth</td>
					<td style="padding:3px"><input type="checkbox" id="CompactBreadth" checked="checked" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Port Style</td>
					<td style="padding:3px">
						<select id="PortStyle">
							 <option value="Center">Center</option>
							<option value="Sides" selected="selected">Sides</option>
					   </select>
					</td>
				</tr>
				<tr>
					<td style="padding:3px">Bus Alignment [0-1]</td>
					<td style="padding:3px"><input type="text" id="BusAlignment" value="0.5"  maxlength="3" style="width:30px;" onchange="ValidateTextBox(this, 'float', 0.5, 0, 1)" /></td>
				</tr>
			</table>
			
			<hr class="WhiteHr" />
			<p>
				<input type="button" id="btnLayout" value="Layout" style="width:100%" onclick="InvokeCustomCommand(this.id)" /><br />
			</p>
			<p>
				<input type="button" id="RandomTree6Levels" value="Random tree (max 6 levels, max 3 branch nodes)" style="width:100%; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
				<input type="button" id="RandomTree8Levels" value="Random tree (max 8 levels, max 2 branch nodes)" style="width:100%; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
			</p>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		<p>
			The compact depth tree layout represents a classical directed tree layout 
			(e.g. with uniform parent placement), which compacts the depth of the tree drawing area. 
			It produces both straight line and orthogonal tree drawings, which is controlled by the <b>OrthogonalEdgeRouting</b> property.    
			The <b>PlugSpacing</b> property controls the spacing between the plugs of a node.
			You can set a fixed amount of spacing or a proportional spacing, which means that the plugs
			are distributed along the whole side of the node.
			The layout satisfies to the following aesthetic criterias:
			<ul>
				<li>No edge crossings - edges do not cross each other.</li>
				<li>No vertex-vertex overlaps - vertices do not overlap each other.</li>
				<li>No vertex-edge overlaps - vertices do not overlap edges.</li>
				<li>Compactness - you can optimize the compactness of the drawing in the tree breadth dimension 
				by setting the <b>CompactBreadth</b> property to true. This type of layout is by default depth compact.</li>
			</ul>
		</p>    
		<p>
			This layout is very useful when arranging deep, unbalanced trees with different node sizes 
			(class diagrams being a perfect example). In cases like these the layout guarantees 
			that the drawing is with mimimal depth.
		</p>
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