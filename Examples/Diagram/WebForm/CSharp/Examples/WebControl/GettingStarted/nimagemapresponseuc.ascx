<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.GettingStarted.NImageMapResponseUC" CodeFile="NImageMapResponseUC.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<!-- Example layout BEGIN -->
<table id="exampleImageTable" style="width: 442px; vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<cc1:NDrawingView id="NDrawingView1" runat="server" Width="416px" Height="336px">
		</cc1:NDrawingView>
		<!-- Diagram control placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="width: 442px; vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates the ability of Nevron Diagram for .NET to create HTML 
		image maps.
		<br />
		<br />
		Click on a personal info icon to show more detailed information.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

