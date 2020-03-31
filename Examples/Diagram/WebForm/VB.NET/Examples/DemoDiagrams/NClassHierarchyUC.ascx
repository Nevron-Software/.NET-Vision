<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NClassHierarchyUC" CodeFile="NClassHierarchyUC.ascx.vb" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="550px" Height="450px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" style="width:200px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		Root Type:<br />
		<input type="radio" name="RootTypeRadioGroup" value="Nevron.Diagram.Layout.NLayout, Nevron.Diagram" onclick="UpdateBaseClass(this)" checked="checked" />NLayout<br />
		<input type="radio" name="RootTypeRadioGroup" value="Nevron.Diagram.NPrimitiveShape, Nevron.Diagram" onclick="UpdateBaseClass(this)" />NPrimitiveShape<br />
		<input type="radio" name="RootTypeRadioGroup" value="Nevron.Diagram.NShapePoint, Nevron.Diagram" onclick="UpdateBaseClass(this)" />NShapePoint<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
</table>
<script language='javascript'>
	function UpdateBaseClass(radioButton) {
		NClientNode.GetFromId("Diagram1").ExecuteCustomRequest(radioButton.value);
	}
</script>
<!-- Example layout END -->
