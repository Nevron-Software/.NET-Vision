<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NLayeredTreeLayoutUC" CodeFile="NLayeredTreeLayoutUC.ascx.vb" %>
<%@ Register TagPrefix="ncwd" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 704px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ncwd:NDrawingView id="NDrawingView1" runat="server" Width="416px" Height="336px"
			AjaxEnabled="True" OnAsyncCustomCommand="NDrawingView1_AsyncCustomCommand"
			OnAsyncQueryCommandResult="NDrawingView1_AsyncQueryCommandResult" />
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 249px;">
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
				<td style="padding:3px">Bus Between Layers</td>
				<td style="padding:3px"><input type="checkbox" id="BusBetweenLayers" checked="checked" /></td>
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
		</table>
		
		<hr class="WhiteHr" />
		<p>
			<input type="button" id="btnLayout" value="Layout" style="width:240px" onclick="InvokeCustomCommand(this.id)" /><br />
		</p>
		<p>
			<input type="button" id="btn1" value="Random tree (max 6 levels, max 3 branch nodes)" style="width:240px; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
			<input type="button" id="btn2" value="Random tree (max 8 levels, max 2 branch nodes)" style="width:240px; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
		</p>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		<p>
			The layered tree layout represents a classical directed tree layout 
			(e.g. with uniform parent placement), which places vertices from the same level in layers.
			It produces both straight line and orthogonal tree drawings, which is controlled by the <b>OrthogonalEdgeRouting</b> property.
			The <b>PlugSpacing</b> property controls the spacing between the plugs of a node.
			You can set a fixed amount of spacing or a proportional spacing, which means that the plugs
			are distributed along the whole side of the node.
			The layout satisfies the following aesthetic criterias:
			<ul>
				<li>No edge crossings - edges do not cross each other.</li>
				<li>No vertex-vertex overlaps - vertices do not overlap each other.</li>
				<li>No vertex-edge overlaps - in case of orthogonal edge routing, this criteria is met when the <b>BusBetweenLayers</b> property is set to true. </li>
				In the case of straight line routing, this criteria is met when the <b>PortStyle</b> property is set to Sides and the nodes in the same layer are with equal height.
				<li>Compactness - you can optimize the compactness of the drawing in the tree breadth dimension 
				by setting the <b>CompactBreadth</b> property to true.</li>
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
	//  sends a custom command to the server using async callback
	function InvokeCustomCommand(sender)
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;
			
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_NDrawingView1"
		//	rather than just "NDrawingView1". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		cs.InvokeCustomCommand(sender, GetProperties());
	}
//-->
</script>
<!-- Custom JavaScript placeholder END -->