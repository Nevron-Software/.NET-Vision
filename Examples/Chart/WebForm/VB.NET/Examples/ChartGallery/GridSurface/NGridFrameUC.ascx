<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NGridFrameUC" CodeFile="NGridFrameUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
		</ncwc:NChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<asp:Label id="Label1" runat="server">Rotation:</asp:Label>
		<br />
		<asp:TextBox id="RotationTextBox" runat="server" Width="84px"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Elevation:</asp:Label>
		<br />
		<asp:TextBox id="ElevationTextBox" runat="server" Width="84px"></asp:TextBox>
		<br />
		<br />
		<asp:Button id="UpdateButton" runat="server" Text="Update"></asp:Button>
		<br />
		<br />
		<asp:CheckBox id="PaletteFrameCheckBox" runat="server" Text="Palette frame" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="SmoothPaletteCheckBox" runat="server" Text="Smooth Palette" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Line color:</asp:Label>
		<br />
		<asp:DropDownList id="LineColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label5" runat="server">Line width:</asp:Label>
		<br />
		<asp:DropDownList id="LineWidhtDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates wireframe surface rendering. The surface filling is disabled and 
		the frame style is 'Mesh' - in this way only mesh lines are displayed. Use the 
		form controls to change the appearance of the mesh frame.
		<br />
		<br />
		Use the Rotation and Elevation edit controls to change the surface view.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->