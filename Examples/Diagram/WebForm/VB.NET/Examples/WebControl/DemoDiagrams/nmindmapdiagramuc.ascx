<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NMindMapDiagramUC" CodeFile="nmindmapdiagramuc.ascx.vb" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<table id="exampleRootTable" style="width:650px;vertical-align:top;" summary="Example layout table">
	<tr>
		<td id="exampleImageCell" class="ImageCell">
			<cc1:NDrawingView id="NDrawingView1" runat="server" Width="650px" Height="520px" AjaxEnabled="True"
				AsyncCallbackTimeout="1000" OnAsyncClick="NDrawingView1_AsyncClick"
				OnQueryAjaxTools="NDrawingView1_QueryAjaxTools"/>
		</td>
	</tr>
	<tr>
		<td id="exampleDescriptionCell" class="Description">
		This example demonstrates how to display a mind map diagram and uses the following features:
			<ul>
				<li>1D and 2D Shapes - shows how to create 2D and 1D shapes and how to 
					connect them.</li>
				<li>Show/Hide Subtree Decorators - shows how to use decorators to show/hide the whole subtree
					(i.e. all descendants) of a shape.</li>
				<li>Layouting and relayouting of the diagram - demonstrates how to layout and relayout the diagram
					when the user toggles a decorator. In that way the diagram always occupies the smallest possible
					area.</li>
			</ul>
		</td>
	</tr>
</p>

