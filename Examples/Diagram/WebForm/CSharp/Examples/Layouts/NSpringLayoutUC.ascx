<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="C#" Inherits="Nevron.Examples.Diagram.Webform.NSpringLayoutUC" CodeFile="NSpringLayoutUC.ascx.cs" %>

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
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width:250px;">
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
                <td style="padding:3px">Log Base</td>
                <td style="padding:3px"><input type="text" id="LogBase" value="2.71828175"  maxlength="10" style="width:100px" onchange="ValidateTextBox(this, 'float', 2.71828175, 0, 99.999999)" /></td>
            </tr>
            <tr>
                <td style="padding:3px">Nominal Distance</td>
                <td style="padding:3px"><input type="text" id="NominalDistance" value="100"  maxlength="3" style="width:100px" onchange="ValidateTextBox(this, 'float', 100, 0, 999)" /></td>
            </tr>
            <tr>
                <td style="padding:3px">Spring Force Law</td>
                <td style="padding:3px">
                    <select id="SpringForceLaw" style="width:100px">
			            <option value="HookeLaw" selected="selected">HookeLaw</option>
			            <option value="Logarithmic">Logarithmic</option>
                   </select>
                </td>
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
            The spring layout method is a classical force directed layout, which uses spring and ellectrical forces.
        </p>
        <p>
            Graph edges are threated as springs. Springs aim to ensure that the distance between adjacent vertices is approximately equal to the spring length. The parameters of the spring force are controlled by an instance of the <b>NSpringForce</b> class, accessible from the SpringForce property.
	    </p>
        <p>
            Graph vertices are threated as ellectically charged particles, which repel each other. The electical force aims to ensure that vertices should not be close together. The parameters of the electrical force are controlled by an instance of the <b>NElectricalForce</b> class, accessible from the ElectricalForce property.
        </p>
	    <p>
	        The spring force accepts per edge defined spring lengths and spring stiffness. In this example the red connectors are with smaller spring lenght are with greater stiffness than the blue connectors. Because of that they tend to be displayed closer to each other.
	    </p>
	    <p> 
	        The electrical force accepts per vertex provided ellectric charges. Thus some vertices may be more repulsive than others.
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