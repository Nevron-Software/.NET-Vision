<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NInteractiveSVGDiagram" CodeFile="NInteractiveSVGDiagram.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<!-- Example layout BEGIN -->
<table id="exampleImageTable" style="width: 566px; vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 566px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<cc1:NDrawingView id="NDrawingView1" Width="540px" Height="344px" runat="server">
		</cc1:NDrawingView>
		<!-- Diagram control placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description" style="vertical-align: top;">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates the ability of Nevron Diagram for .NET to create SVG 
		content with interactivity features such as browser redirection and scripting.
		<br />
		<br />
		Click on a state to view complete information about it from WorldAtlas.com
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
