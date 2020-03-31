<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NWXamlExportUC" CodeFile="NXamlExportUC.ascx.cs" %>

<!-- Example layout BEGIN -->
<table id="exampleImageTable" style="width:830px; vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width:620px; height:650px; vertical-align:top;">
		<!-- Diagram control placeholder BEGIN 
		     The <object> tag is recognized by Internet Explorer, and Netscape recognizes the
		     <embed> tag and ignores the <object> tag.
		-->
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="620" height="620">
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
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 100px;">
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates the ability of Nevron Diagram for .NET to binary stream silverlight xaml
		to the browser without generating a file on the server. The generated xaml is passed to
		a simple silverlight application which renders it in the browser.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->