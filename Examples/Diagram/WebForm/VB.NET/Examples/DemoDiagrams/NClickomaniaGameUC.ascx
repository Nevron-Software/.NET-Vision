<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NClickomaniaGameUC" CodeFile="NClickomaniaGameUC.ascx.vb" %>

<table id="exampleImageTable" style="width: 755px; vertical-align: top;" summary="Image and description table">
	<tr>
		<td id="exampleImageCell" class="ImageCell" style="vertical-align: top;">
			<!-- Diagram control placeholder BEGIN -->
			<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="720px" Height="500px">
			</ndwc:NThinDiagramControl>
			<!-- Diagram control placeholder END -->
		</td>
	</tr>
	<tr>
		<td id="exampleDescriptionCell" style="width: 755px; vertical-align: top;" class="Description">
			<!-- Description box placeholder BEGIN -->
			This example demonstrates how to use table shapes, mouse down event handlers and the auto update feature by
			implememnting the popular game "Clickomania". The player should click on a cell tha has at least one other
			neighbour with the same color. The goal is to clear all cells.
			<!-- Description box placeholder END -->
		</td>
	</tr>
</table>

