<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NImageResponseUC" CodeFile="NImageResponseUC.ascx.cs" %>
<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 704px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<cc1:NDrawingView id="NDrawingView1" runat="server" Width="416px" Height="336px" ImageAcquisitionMode="TempFile">
		</cc1:NDrawingView>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 249px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<asp:Label id="Label1" runat="server">Image type:</asp:Label>
		<br />
		<asp:DropDownList id="ImageTypeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">JPEG quality:</asp:Label>
		<br />
		<asp:DropDownList id="JPEGQualityDropDownList" runat="server" AutoPostBack="True" Enabled="False"></asp:DropDownList>
		<br />
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		The 
		example demonstrates the ability of Nevron Diagram for .NET to generate static 
		images in several image formats. The image is stored in temporary directory on 
		the server and the HTML contains an img tag.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
