<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NPrintingUC" CodeFile="NPrintingUC.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<!-- Example layout BEGIN -->
<!-- Example layout BEGIN -->
<table id="exampleImageTable" style="width: 600px; vertical-align: top;" summary="Image and description table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 600px; vertical-align: top;">
		<div id="scrollDiv" style="overflow: auto; width: 600px; height: 420px;">
			<!-- Diagram control placeholder BEGIN -->
			<cc1:NDrawingView id="NDrawingView1" runat="server">
			</cc1:NDrawingView>
			<!-- Diagram control placeholder END -->
		</div>
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		<input id="Button1" type="button" value="Show Print Manager" onclick="onPrintButton();" />
		<hr class="WhiteHr" />
        None of the most popular web browsers is capable of printing really large images.
        <br />&nbsp;<br />
        This example demonstrates the application of the NPrintPreviewHttpHandler class, 
        used to display a pop-up window with a vertically arranged tiled diagram
        image, ready for printing from the web browser.
        <br />&nbsp;<br />
        Press the "Print Manager" button to see the print manager pop-up window.
        <br />&nbsp;<br />
        For this example to work, the following code must be added manually to the
        configuration/system.web/httpHandlers section of the web.config file:
        <br />&nbsp;<br />
        &lt;add verb="GET,HEAD" path="NevronPrinting.axd" type="Nevron.UI.WebForm.Controls.NPrintPreviewHttpHandler" validate="false"/>
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder BEGIN -->
<script type="text/javascript" language="javascript">
<!--
	function onPrintButton()
	{
		//	the NevronPrinting.axd HTTP handler is defined in Web.config
		var url = 'NevronPrinting.axd';
		url += '?ControlId=<%Response.Write(NDrawingView1.StateManager.StateId);%>';
		url += '&tileMaxWidth=770';
		url += '&tileMaxHeight=990';
		url += '&imageWidth=<%Response.Write(NDrawingView1.Dimensions.Width.ToString());%>';
		url += '&imageHeight=<%Response.Write(NDrawingView1.Dimensions.Height.ToString());%>';
		url += '&handler=NevronDiagram.axd';
		
		var previewWindow = window.open(url,'_blank','toolbar=1,location=0,directories=0,status=1,menubar=1,scrollbars=1,resizable=1,copyhistory=0,top=0,left=0,width=800,height=550');
	}
//-->
</script>
<!-- Custom JavaScript placeholder END -->
