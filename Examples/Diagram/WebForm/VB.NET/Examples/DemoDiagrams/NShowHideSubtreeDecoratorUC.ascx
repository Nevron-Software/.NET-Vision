<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NShowHideSubtreeDecoratorUC" CodeFile="NShowHideSubtreeDecoratorUC.ascx.vb" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="480px" Height="360px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 270px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<form>
			<div>Background Shape:<br />
				<input type="radio" name="background" onclick="InvokeCustomCommand(this)" value="Ellipse" />Ellipse<br />
				<input type="radio" name="background" onclick="InvokeCustomCommand(this)" value="Rectangle" checked="checked" />Rectangle<br />
				<input type="radio" name="background" onclick="InvokeCustomCommand(this)" value="RoundedRectangle" />Rounded Rectangle
			</div>            
			<p>Symbol Shape:<br />
				<input type="radio" name="symbol" onclick="InvokeCustomCommand(this)" value="PlusMinus" checked="checked" />Plus Minus<br />
				<input type="radio" name="symbol" onclick="InvokeCustomCommand(this)" value="UpDownArrow" />Up-Down Arrow<br />
				<input type="radio" name="symbol" onclick="InvokeCustomCommand(this)" value="UpDownTriangle" />Up-Down Triangle<br />
				<input type="radio" name="symbol" onclick="InvokeCustomCommand(this)" value="UpDownDoubleArrow" />Up-Down Double Arrow<br />
				<input type="radio" name="symbol" onclick="InvokeCustomCommand(this)" value="UpDownDoubleTriangle" />Up-Down Double Triangle<br />
				<input type="radio" name="symbol" onclick="InvokeCustomCommand(this)" value="RightDownArrow" />Right-Down Arrow<br />
				<input type="radio" name="symbol" onclick="InvokeCustomCommand(this)" value="RightDownTriangle" />Right-Down Triangle
			</p>
			<p>Position:<br />
				<input type="radio" name="position" onclick="InvokeCustomCommand(this)" value="Left" checked="checked" />Left<br />
				<input type="radio" name="position" onclick="InvokeCustomCommand(this)" value="Right" />Right
			</p>            
		</form>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		The show-hide subtree decorator is a decorator, which consists of a symbol and background. Clicking the expand-collapse decorator
		toggles the visibility state of the shape destination shapes and the outgoing shapes. When hiding the subtree, this process is
		repeated for each destination shape. When showing the subtree this process is repeated for each destination shape if the
		ShowChildrenOnly property is set to false.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder START -->
<script language='javascript'>
	function InvokeCustomCommand(radioButton) {
		NClientNode.GetFromId("Diagram1").ExecuteCustomRequest(radioButton.name + "=" + radioButton.value);
	}
</script>
<!-- Custom JavaScript placeholder END -->
