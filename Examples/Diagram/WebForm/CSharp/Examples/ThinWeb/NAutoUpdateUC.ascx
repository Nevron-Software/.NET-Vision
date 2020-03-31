<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NAutoUpdateUC" CodeFile="NAutoUpdateUC.ascx.cs" %>

<table id="exampleImageTable" style="width: 755px; vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 755px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="416px" Height="336px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="width: 755px; vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to configure a diagram which is automatically updated. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
