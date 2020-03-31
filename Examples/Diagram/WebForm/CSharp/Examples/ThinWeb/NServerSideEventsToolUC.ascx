<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NServerSideEventsToolUC" CodeFile="NServerSideEventsToolUC.ascx.cs" %>

<table id="exampleImageTable" style="width: 682px; vertical-align: top;" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 755px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="416px" Height="336px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
    <td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 300px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        <asp:CheckBox id="MouseDownCheckBox" runat="server" Checked = "true" Text="Mouse Down" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="MouseMoveCheckBox" runat="server" Checked = "false" Text="Mouse Move" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="MouseUpCheckBox" runat="server" Checked = "false" Text="Mouse Up" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="MouseOverCheckBox" runat="server" Checked = "false" Text="Mouse Over" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="MouseLeaveCheckBox" runat="server" Checked = "false" Text="Mouse Leave" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="MouseEnterCheckBox" runat="server" Checked = "false" Text="Mouse Enter" AutoPostBack="True"></asp:CheckBox>
        <br />
		<asp:CheckBox id="MouseClickCheckBox" runat="server" Checked = "false" Text="Mouse Click" AutoPostBack="True"></asp:CheckBox>
        <br />
		<asp:CheckBox id="MouseDoubleClickCheckBox" runat="server" Checked = "false" Text="Mouse Double Click" AutoPostBack="True"></asp:CheckBox>
        <br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="width: 755px; vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example shows how to intercept server side events. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
