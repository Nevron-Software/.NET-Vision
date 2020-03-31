<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NWXamlExportUC" CodeFile="NXamlExportUC.ascx.vb" %>

<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; height: 320px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN 
			 The <object> tag is recognized by Internet Explorer, and Netscape recognizes the
			 <embed> tag and ignores the <object> tag.
		-->
		<object data="data:application/x-silverlight-2," type="application/x-silverlight-2" Width="420px" Height="320px">
			<param name="source" value="../Examples/Silverlight/SilverlightXamlViewer.xap" />
			<param name="initParams" value="XamlFileName=NXamlExportRenderPage.aspx" />
			
			<!-- Display installation image. -->
			<a href="http://go.microsoft.com/fwlink/?LinkID=149156" 
				style="text-decoration: none;">
				<img src="http://go.microsoft.com/fwlink/?LinkId=108181" 
					alt="Get Microsoft Silverlight" 
					style="border-style: none"/>
			</a>
		</object>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 100px;">
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates the ability of Nevron Chart for .NET to stream Silverlight xaml
		to the browser without generating a file on the server. The generated xaml is passed to
		a simple Silverlight application which renders it in the browser.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->