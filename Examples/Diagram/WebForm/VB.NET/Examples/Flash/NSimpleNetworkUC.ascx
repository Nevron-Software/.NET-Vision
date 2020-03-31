<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NSimpleNetworkUC" CodeFile="NSimpleNetworkUC.ascx.vb" %>

<!-- Example layout BEGIN -->
<table id="exampleImageTable" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell">
		<!-- The <object> tag is recognized by Internet Explorer, and Netscape recognizes the
			 <embed> tag and ignores the <object> tag.
		-->
		<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="600" height="600">
			<param name="movie" value="../Examples/Flash/NSimpleNetworkRenderPage.aspx" />
			<embed src="../Examples/Flash/NSimpleNetworkRenderPage.aspx" width="538" height="440" />
		</object>
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width:150px">
		<asp:Button Text="Replay" runat="server" style="width:100%" />
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates the ability of Nevron Diagram for .NET to binary stream flash animations
		to the browser without generating a file on the server.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
