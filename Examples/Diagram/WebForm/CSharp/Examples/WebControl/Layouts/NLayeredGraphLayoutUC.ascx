<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NLayeredGraphLayoutUC" CodeFile="NLayeredGraphLayoutUC.ascx.cs" %>
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
                    <td style="padding:3px">Direction</td>
                    <td style="padding:3px">
                        <select id="Direction" style="width:100%">
 				            <option value="TopToBottom" selected="selected">TopToBottom</option>
 				            <option value="BottomToTop">BottomToTop</option>
 				            <option value="LeftToRight">LeftToRight</option>
 				            <option value="RightToLeft">RightToLeft</option>
                       </select>
                    </td>
                </tr>
                <tr>
                    <td style="padding:3px">Layer Alignment</td>
                    <td style="padding:3px">
                        <select id="LayerAlignment" style="width:100%">
 				            <option value="Near">Near</option>
 				            <option value="Center" selected="selected">Center</option>
 				            <option value="Far">Far</option>
                       </select>
                    </td>
                </tr>
                <tr>
                    <td style="padding:3px">Edge Routing</td>
                    <td style="padding:3px">
                        <select id="EdgeRouting" style="width:100%">
 				            <option value="Orthogonal" selected="selected">Orthogonal</option>
 				            <option value="Polyline">Polyline</option>
                       </select>
                    </td>
                </tr>
                <tr>
                    <td style="padding:3px">Node Rank</td>
                    <td style="padding:3px">
                        <select id="NodeRank" style="width:100%">
 				            <option value="TopMost">TopMost</option>
 				            <option value="Optimal" selected="selected">Optimal</option>
 				            <option value="Gravity">Gravity</option>
                       </select>
                    </td>
                </tr>
            </table>
    		
		    <hr class="WhiteHr" />
		    <p>
	            <input type="button" id="btnLayout" value="Layout" style="width:240px" onclick="InvokeCustomCommand(this.id)" /><br />
		    </p>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
	    <p>     
            The layered graph layout strives to minimize the number of crossings between edges 
            and produces a polyline graph drawing. This type of layout is very useful
            for the arrangement of flow diagrams, since it works well on all types of graphs
            (including those with self-loops and duplicate edges).
        </p>
	    <p>
	        The most important properties are:
		    <ul>
			    <li>
			        <b>Direction</b> - determines the flow direction of the layout. By default set to <i>TopToBottom</i>.
			    </li>
			    <li>
			        <b>EdgeRouting</b> - determines what edge routing is applied.
			    </li>
			    <li>
			        <b>NodeRank</b> - specifies the node ranking policy used by the layout. It can be:
			        <ul>
			            <li><i>TopMost</i> - all nodes without incomming edges are assigned to the topmost layer</li>
			            <li><i>Gravity</i> - layer distribution is done in such a way that the total length of all edges is minimized</li>
			            <li><i>Optimal</i> - similar to the topmost, but after the initial assignment all nodes fall downwards as much as possible</li>
			        </ul>
			    </li>
			    <li>
			        <b>LayerAlignment</b> - determines the vertical alignment of the nodes in the layers.
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