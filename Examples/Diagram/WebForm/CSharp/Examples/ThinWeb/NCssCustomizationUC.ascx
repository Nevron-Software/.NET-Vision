<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NCssCustomizationUC" CodeFile="NCssCustomizationUC.ascx.cs" %>

<table id="exampleImageTable" style="width: 755px; vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 755px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="730px" Height="500px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="width: 755px; vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to modify the build-in CSS styles. This is commonly required when you have to integrate the control in different web site designs.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
