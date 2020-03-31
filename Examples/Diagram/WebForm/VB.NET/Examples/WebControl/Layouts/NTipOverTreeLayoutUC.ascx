<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NTipOverTreeLayoutUC"
	CodeFile="NTipOverTreeLayoutUC.ascx.vb" %>
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
				<td style="padding:3px">Compact</td>
				<td style="padding:3px"><input type="checkbox" id="Compact" checked="checked" /></td>
			</tr>
			<tr>
				<td style="padding:3px">Horizontal Spacing</td>
				<td style="padding:3px"><input type="text" id="HorizontalSpacing" value="20"  maxlength="5" style="width:50px;" onchange="ValidateTextBox(this, 'float', 20, 0, 1000)" /></td>
			</tr>
			<tr>
				<td style="padding:3px">Vertical Spacing</td>
				<td style="padding:3px"><input type="text" id="VerticalSpacing" value="20"  maxlength="5" style="width:50px;" onchange="ValidateTextBox(this, 'float', 20, 0, 1000)" /></td>
			</tr>
			<tr>
				<td style="padding:3px">Row Bus Factor [0-1]</td>
				<td style="padding:3px"><input type="text" id="RowBusFactor" value="0.5"  maxlength="5" style="width:50px;" onchange="ValidateTextBox(this, 'float', 0.5, 0, 1)" /></td>
			</tr>
			<tr>
				<td style="padding:3px">Column Bus Factor [0-1]</td>
				<td style="padding:3px"><input type="text" id="ColumnBusFactor" value="0.5"  maxlength="5" style="width:50px;" onchange="ValidateTextBox(this, 'float', 0.5, 0, 1)" /></td>
			</tr>
			<tr>
				<td style="padding:3px">Children Placement</td>
				<td style="padding:3px">
					<select id="ChildrenPlacement">
						<option value="Inherit">Inherit</option>
						<option value="Row" selected="selected">Row</option>
						<option value="ColLeft">ColLeft</option>
						<option value="ColRight">ColRight</option>
						<option value="ColBoth">ColBoth</option>
				   </select>
				</td>
			</tr>
			<tr>
				<td style="padding:3px">Leafs Placement</td>
				<td style="padding:3px">
					<select id="LeafsPlacement">
						<option value="Inherit" selected="selected">Inherit</option>
						<option value="Row">Row</option>
						<option value="ColLeft">ColLeft</option>
						<option value="ColRight">ColRight</option>
						<option value="ColBoth">ColBoth</option>
				   </select>
				</td>
			</tr>
		</table>
		<hr class="WhiteHr" />
		<p>
			<input type="button" id="btnLayout" value="Layout" style="width:240px" onclick="InvokeCustomCommand(this.id)" /><br />
		</p>
		<p>
			<input type="button" id="btn1" value="Predefined org chart" style="width:240px; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
			<input type="button" id="btn2" value="Random tree (5 col shapes)" style="width:240px; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
			<input type="button" id="btn3" value="Random tree (7 col shapes)" style="width:240px; font-size:8pt" onclick="InvokeCustomCommand(this.id)" /><br />
		</p>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		<p>
			The tip-over tree layout is a tree layout, which uses shapes provided data to determine
			whether the vertex children should be placed in a row, column or 2 columns. It produces
			orthogonal tree drawings. The layout satisfies to the following aesthetic criterias:
			<ul>
				<li><b>No edge crossings</b> - edges do not cross each other.</li>
				<li><b>No vertex-vertex overlaps</b> - vertices do not overlap each other.</li>
				<li><b>No vertex-edge overlaps</b> - vertices do not overlap edges.</li>
				<li><b>Compactness</b> - you can optimize the compactness of the drawing in both
					the breadth and depth dimensions of the the tree by setting the <b>Compact</b>
					property to true.</li>
			</ul>
		</p>
			You can change the tha way the children and the leafs are placed using the corresponding
			properties. You can also set the children placement for the children of each vertex
			individually using the <b>TipOverChildrenPlacement</b> property in the LayoutData
			collection of the shape.
		<p>
			This type of layout is typically used in Org Charts, but can also be used in all cases
			where classical tree layouts (e.g. layouts with uniform parent placement) do not produce
			width/height ratio compact results.
		</p>
		<p>
			In this example the nodes whose children are arranged in cols are highlighted with orange.
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