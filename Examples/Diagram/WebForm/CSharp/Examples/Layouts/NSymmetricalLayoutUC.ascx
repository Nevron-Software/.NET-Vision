<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="C#" Inherits="Nevron.Examples.Diagram.Webform.NSymmetricalLayoutUC" CodeFile="NSymmetricalLayoutUC.ascx.cs" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
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
                <td style="padding:3px">Magnetic Field Force</td>
                <td style="padding:3px"><input type="checkbox" id="MagneticFieldForce" /></td>
            </tr>
        </table>
		
	    <hr class="WhiteHr" />
	    
	    <p>
            <input type="button" id="btnLayout" value="Layout" style="width:100%" onclick="InvokeCustomCommand(this.id)" /><br />
	    </p>
	    <p>
            <input type="button" id="Tree4Levels" value="Tree 1 (levels 4, degree 3)" style="width:100%; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
            <input type="button" id="Tree5Levels" value="Tree 2 (levels 5, degree 2)" style="width:100%; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
        </p>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
	    <p>
            The symmetrical layout represents an implementation of the Fruchertman and Reingold force directed layout (with some modifications).
        </p>
	    <p>
            It uses attractive and repulsive forces, which aim to produce a drawing with uniform distance between each set of connected vertices. Because of that the drawing tends to be symmetrical.
	    </p>
	    <p>
	        The attractive and repulsive forces are coupled in an instance of the <b>NDesiredDistanceForce</b> class, accessible from the <b>DesiredDistanceForce</b> property. 
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