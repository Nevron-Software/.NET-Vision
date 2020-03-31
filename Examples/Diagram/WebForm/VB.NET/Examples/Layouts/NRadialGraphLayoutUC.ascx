<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NRadialGraphLayoutUC" CodeFile="NRadialGraphLayoutUC.ascx.vb" %>

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
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width:250px">
		<!-- Configuration controls panel placeholder BEGIN -->
		<table id="properties">
			<tr>
				<td style="padding:3px">Auto Size Rings</td>
				<td style="padding:3px"><input type="checkbox" id="AutoSizeRings" checked="checked" /></td>
			</tr>
			<tr>
				<td style="padding:3px">Ring Radius</td>
				<td style="padding:3px"><input type="text" id="RingRadius" value="100"  maxlength="4" style="width:40px;" onchange="ValidateTextBox(this, 'float', 100, 10, 1000)" /></td>
			</tr>
			<tr>
				<td style="padding:3px">Aspect Ratio</td>
				<td style="padding:3px"><input type="text" id="AspectRatio" value="1"  maxlength="4" style="width:40px;" onchange="ValidateTextBox(this, 'float', 1, 0, 1000)" /></td>
			</tr>
		</table>
		
		<hr class="WhiteHr" />
		
		<p>
			<input type="button" id="btnLayout" value="Layout" style="width:100%" onclick="ApplyLayout()" /><br />
		</p>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		<p>
			The radial graph layout layouts the graphs in concentric circles. The vertices with no
			predecessors are placed in the center and their descendants are placed on the next circle
			and so on. It produces a straight line graph drawing. The most important properties are:
		</p>
		<ul>
			<li>
				<b>Aspect Ratio</b> - determines the aspect (width/height) ratio of the layout.
				By default set to 1 which layouts the nodes in a circle. A value different from 1
				will make the layout order the nodes in an ellipse.
			</li>
			<li>
				<b>AutoSizeRings</b> - if set to true the RingRadius property is automatically
				calculated to have such value that the total area of the drawing is minimized and there
				is no node overlapping.
			</li>
			<li>
				<b>RingRadius</b> - determines the size of the radius of the first imaginary circle where
				nodes are placed. The radius of each other circle is a sum of the RingRadius value and
				the radius of the previous circle. This value is automatically determined if the 
				AutoSizeRings property is set to true.
			</li>
		</ul>
		<p>
			To experiment with their behavior just change the properties of the layout in the property
			grid and click the <b>Layout</b> button.
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

	function ApplyLayout() {
		NClientNode.GetFromId("Diagram1").ExecuteCustomRequest(GetPropertiesAsString());
	}
//-->
</script>
<!-- Custom JavaScript placeholder END -->