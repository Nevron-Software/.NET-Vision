<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NPrintingUC" CodeFile="NPrintingUC.ascx.cs" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" style="vertical-align: top; padding: 3px;">
		<table id="Table2" style="vertical-align: top;" summary="Image and description table">
		<tr>
			<td id="Td2" style="vertical-align: top; padding: 3px;">
				<p id="P1" class="Description" style="width: 420px;">
					<!-- Description box placeholder BEGIN -->
                    None of the most popular web browsers is capable of printing really large images.
                    <br />&nbsp;<br />
                    This example demonstrates the application of the NPrintPreviewHttpHandler class, 
                    used to display a pop-up window with a vertically arranged tiled chart
                    image, ready for printing from the web browser.
                    <br />&nbsp;<br />
                    Press the "Print Manager" button to see the print manager pop-up window.
                    <br />&nbsp;<br />
                    For this example to work, the following code must be added manually to the
                    configuration/system.web/httpHandlers section of the web.config file:
                    <br />&nbsp;<br />
                    &lt;add verb="GET,HEAD" path="NevronPrinting.axd" type="Nevron.UI.WebForm.Controls.NPrintPreviewHttpHandler" validate="false"/>
					<!-- Description box placeholder END -->
				</p>
			</td>
		</tr>
		<tr>
			<td id="Td3" style="vertical-align: top; padding: 3px;">
				<input id="Button1" type="button" value="Print Manager" onclick="onPrintButton();" />
				<hr />
				<!-- Diagram control placeholder BEGIN -->
                <ncwc:NChartControl id="nChartControl1" runat="server" Width="2000" Height="2000">
                </ncwc:NChartControl>
				<!-- Diagram control placeholder END -->
			</td>
		</tr>
		</table>
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
		url += '?ControlId=<%Response.Write(nChartControl1.StateManager.StateId);%>';
		url += '&tileMaxWidth=770';
		url += '&tileMaxHeight=990';
		url += '&imageWidth=<%Response.Write(nChartControl1.Dimensions.Width.ToString());%>';
		url += '&imageHeight=<%Response.Write(nChartControl1.Dimensions.Height.ToString());%>';
		url += '&handler=NevronChart.axd';
		
		var previewWindow = window.open(url,'_blank','toolbar=1,location=0,directories=0,status=1,menubar=1,scrollbars=1,resizable=1,copyhistory=0,top=0,left=0,width=800,height=550');
	}
//-->
</script>
<!-- Custom JavaScript placeholder END -->
