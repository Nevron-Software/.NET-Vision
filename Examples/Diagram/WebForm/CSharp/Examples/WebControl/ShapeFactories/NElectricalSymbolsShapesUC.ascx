<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NElectricalSymbolsShapesUC" CodeFile="NElectricalSymbolsShapesUC.ascx.cs" %>
<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 729px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<div id="scrollDiv" style="overflow: auto; width: 442px; height: 420px;">
			<!-- Diagram control placeholder BEGIN -->
			<cc1:NDrawingView id="NDrawingView1" runat="server" Width="416px" Height="312px">
			</cc1:NDrawingView>
			<!-- Diagram control placeholder END -->
		</div>
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 300px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<asp:Label id="Label1" runat="server">Shape Size:</asp:Label>
		<br />
		<asp:DropDownList id="shapeSizeDropDownList" runat="server" AutoPostBack="True">
			<asp:ListItem>Small</asp:ListItem>
			<asp:ListItem Selected="True">Medium</asp:ListItem>
			<asp:ListItem>Large</asp:ListItem>
		</asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to use the built in shape factories to dynamically 
		create new shapes.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
