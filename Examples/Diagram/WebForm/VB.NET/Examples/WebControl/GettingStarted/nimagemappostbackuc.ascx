<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.GettingStarted.NImageMapPostback" CodeFile="NImageMapPostbackUC.ascx.vb" %>
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
	<td id="exampleDescriptionCell" class="Description" style="vertical-align: top;">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates 
		the ability of Nevron Diagram for .NET to create HTML image maps.
		<br />
		<br />
		Click on a personal info icon to shade it in red.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
