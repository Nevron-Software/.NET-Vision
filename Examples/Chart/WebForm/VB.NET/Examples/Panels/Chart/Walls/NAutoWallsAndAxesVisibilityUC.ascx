<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAutoWallsAndAxesVisibilityUC" CodeFile="NAutoWallsAndAxesVisibilityUC.ascx.vb"  %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
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
		<asp:CheckBox id="AutoWallsVisibilityCheckBox" runat="server" Text="Auto Walls Visibility" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="LightsInCameraSpaceCheckBox" runat="server" Text="Lights in Camera Space" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Axis Anchors Mode:</asp:Label>
		<br />
		<asp:DropDownList id="AxisAnchorsModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Rotation:</asp:Label>
		<br />
		<asp:TextBox id="RotationTextBox" runat="server" Width="78px"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Elevation:</asp:Label>
		<br />
		<asp:TextBox id="ElevationTextBox" runat="server" Width="78px"></asp:TextBox>
		<br />
		<br />
		<asp:Button id="UpdateButton" runat="server" Text="Update projection"></asp:Button>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
This example demonstrates several features of the Cartesian chart that ensure 
better visibility and readability for 3D charts that are frequently rotated.
<br /><br />
When the automatic visibility mode of the chart walls is enabled, chart 
walls are dynamicaly shown and hidden so that the data is never overlapped by a wall.
<br /><br />
The automatic docking axis anchor chooses an appropriate edge of the Cartesian chart box for an axis,
depending on the current projection properties. The axes are displayed on side edges, not in front 
of the data or behind the chart.
<br /><br />
The light source coordinates can be defined in camera space so that light sources are dynamically 
repositioned as you rotate the chart. In this way the scene is always well lit.
<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>