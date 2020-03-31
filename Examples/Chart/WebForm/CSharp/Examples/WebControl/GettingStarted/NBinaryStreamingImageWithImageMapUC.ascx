<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NBinaryStreamingImageWithImageMapUC" CodeFile="NBinaryStreamingImageWithImageMapUC.ascx.cs" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
        <img id = "NChartImageMap" border = "0" height="320" alt=""	usemap="#MAP_NChartImageMap" src="../Examples/WebControl/GettingStarted/NBinaryStreamingImageWithImageMapRenderPage.aspx" width="420" />
        <!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates the ability of Nevron Chart for .NET to binary stream an image to the browser 
        without generating a file on the server and to generate the HTML image map corresponding to it.	    
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
