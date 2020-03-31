<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NBarycenterLayoutUC" CodeFile="NBarycenterLayoutUC.ascx.vb" %>

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
					<td style="padding:3px">Bounce Back Force</td>
					<td style="padding:3px"><input type="checkbox" id="BounceBackForce" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Gravity Force</td>
					<td style="padding:3px"><input type="checkbox" id="GravityForce" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Min Fixed Vertices</td>
					<td style="padding:3px"><input type="text" id="MinFixedVerticesCount" value="3"  maxlength="2" style="width:30px;" onchange="ValidateTextBox(this, 'int', 3, 3, 20)" /></td>
				</tr>
			</table>
			
			<hr class="WhiteHr" />
			<p>
				<input type="button" id="layout" value="Layout" style="width:100%" onclick="InvokeCustomCommand(this.id)" />
			</p>
			<p>
				<input type="button" id="randomGrid1Button" value="Random grid (fixed 10, free 10)" style="width:100%; font-size:8pt;" onclick="InvokeCustomCommand(this.id)" />
				<input type="button" id="randomGrid2Button" value="Random grid (fixed 15, free 15)" style="width:100%; font-size:8pt;" onclick="InvokeCustomCommand(this.id)" />
				<input type="button" id="triangularGrid1Button" value="Triangular grid (levels 6)" style="width:100%; font-size:8pt;" onclick="InvokeCustomCommand(this.id)" />
				<input type="button" id="triangularGrid2Button" value="Triangular grid (levels 8)" style="width:100%; font-size:8pt;" onclick="InvokeCustomCommand(this.id)" />
			</p>      
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		The barycenter layout method splits the input graph into a set of fixed and free vertices. Fixed vertices are nailed to the corners of a strictly convex polygon, while free vertices are placed in the barycenter of their neighbours. The barycenter force accessible from the BarycenterForce property of the layout is resposible for attracting the vertices to thier barycenter. 
		<br />&nbsp;<br />
		In case there are no fixed vertices this will place all vertices at a single point, which is obviously not a good graph drawing. That is why the barycenter layout needs at least three fixed vertices. 
		<br />&nbsp;<br />
		The minimal amount of fixed vertices is specified by the MinFixedVerticesCount property. If the input graph does not have that many fixed vertices, the layout will automatically forefill this requirement. This is done by fixing the vertices with the smallest degree. 
		<br />&nbsp;<br />
		In this example the fixed vertices are highlighted in orange. 
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

	function InvokeCustomCommand(sender)
	{
		NClientNode.GetFromId("Diagram1").ExecuteCustomRequest("command=" + sender + "\n" + GetPropertiesAsString());
	}
//-->
</script>
<!-- Custom JavaScript placeholder END -->