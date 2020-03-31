<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NBarycenterLayoutUC" CodeFile="NBarycenterLayoutUC.ascx.cs" %>
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
                <input type="button" id="layout" value="Layout" style="width:218px" onclick="InvokeCustomCommand(this.id)" />
            </p>
            <p>
                <input type="button" id="randomGrid1Button" value="Random grid (fixed 10, free 10)" style="width:218px; font-size: 8pt;" onclick="InvokeCustomCommand(this.id)" />
                <input type="button" id="randomGrid2Button" value="Random grid (fixed 15, free 15)" style="width:218px; font-size: 8pt;" onclick="InvokeCustomCommand(this.id)" />
                <input type="button" id="triangularGrid1Button" value="Triangular grid (levels 6)" style="width:218px; font-size: 8pt;" onclick="InvokeCustomCommand(this.id)" />
                <input type="button" id="triangularGrid2Button" value="Triangular grid (levels 8)" style="width:218px; font-size: 8pt;" onclick="InvokeCustomCommand(this.id)" />
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
		In this example the fixed vertices are highlighted in red. 
		<br />
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