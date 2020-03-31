<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.GettingStarted.NBinaryStreamingImageUC" CodeFile="NBinaryStreamingImageUC.ascx.vb" %>
<!-- Example layout BEGIN -->
<table id="exampleImageTable" style="width: 600px; vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 600px; vertical-align: top;">
		<div id="scrollDiv" style="overflow: auto; width: 600px; height: 420px;">
			<!-- Diagram control placeholder BEGIN -->
			<img width="1040" height="670" alt="" src="../Examples/WebControl/GettingStarted/NBinaryStreamingImageRenderPage.aspx" />
			<!-- Diagram control placeholder END -->
		</div>
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates the ability of Nevron Diagram for .NET to binary stream an image 
		to the browser without generating a file on the server.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
