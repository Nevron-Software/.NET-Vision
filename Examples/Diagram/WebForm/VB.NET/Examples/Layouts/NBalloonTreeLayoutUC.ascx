<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NBalloonTreeLayoutUC" CodeFile="NBalloonTreeLayoutUC.ascx.vb" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" summary="Example layout table">
	<tr>
		<td id="exampleImageCell" class="ImageCell">
			<!-- Diagram control placeholder BEGIN -->
			<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="500px" Height="400px">
			</ndwc:NThinDiagramControl>
			<!-- Diagram control placeholder END -->
		</td>
		<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
		<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 250px;">
			<!-- Configuration controls panel placeholder BEGIN -->
				<table id="properties">
					<tr>
						<td style="padding:3px">Start Angle</td>
						<td style="padding:3px"><input type="text" id="StartAngle" value="0" maxlength="3" style="width:56px" onchange="ValidateTextBox(this, 'int', 0, 0, 360)" /></td>
					</tr>
					<tr>
						<td style="padding:3px">Root Wedge</td>
						<td style="padding:3px"><input type="text" id="RootWedge" value="360" maxlength="3" style="width:56px" onchange="ValidateTextBox(this, 'int', 360, 0, 360)" /></td>
					</tr>
					<tr>
						<td style="padding:3px">Children Wedge</td>
						<td style="padding:3px"><input type="text" id="ChildrenWedge" value="360" maxlength="3" style="width:56px" onchange="ValidateTextBox(this, 'int', 360, 0, 360)" /></td>
					</tr>
					<tr>
						<td style="padding:3px">Parent-Child Spacing</td>
						<td style="padding:3px"><input type="text" id="ParentChildSpacing" value="75" maxlength="4" style="width:56px" onchange="ValidateTextBox(this, 'int', 75, 10, 1000)" /></td>
					</tr>
				</table>
				<hr class="WhiteHr" />
				<p>
					<input type="button" id="layout" value="Layout" style="width:100%" onclick="InvokeCustomCommand()" />
				</p>          
			<!-- Configuration controls panel placeholder END -->
		</td>
	</tr>
	<tr>
		<td id="exampleDescriptionCell" class="Description">
			<!-- Description box placeholder BEGIN -->
			<p>
				The baloon tree layout tries to compact the drawing area of the tree 
				by placing the vertices in balloons around the tree root.
				It produces straight line tree drawings. 
			</p>
			<p>        
				Following is a brief description of its properties:
				<ul>
					<li>
						<b>ParentChildSpacing</b> - the preferred spacing between a parent and a child
						vertex in the layout direction. The real spacing may be different for some nodes,
						because the layout does not allow overlappings.
					</li>
					<li>
						<b>VertexSpacing</b> - the minimal spacing between 2 nodes in the layout.
						If set to 0, the nodes will touch each other.
					</li>
					<li>
						<b>ChildWedge</b> - the sector angle (measured in degrees) for the children
						of each vertex.
					</li>
					<li>
						<b>RootWedge</b> - the sector angle (measured in degrees) for the children
						of the root vertex.
					</li>
					<li>
						<b>StartAngle</b> - the start angle for the children of the root vertex, measured in
						degrees anticlockwise from the x-axis.
					</li>
				</ul>
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

	function InvokeCustomCommand() {
		NClientNode.GetFromId("Diagram1").ExecuteCustomRequest(GetPropertiesAsString());
	}
//-->
</script>
<!-- Custom JavaScript placeholder END -->