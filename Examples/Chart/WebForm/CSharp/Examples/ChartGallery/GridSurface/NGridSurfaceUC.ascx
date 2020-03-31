<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NGridSurfaceUC" CodeFile="NGridSurfaceUC.ascx.cs" %>
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
        <asp:TextBox id="RotationTextBox" Width="84" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Elevation:</asp:Label>
        <br />
        <asp:TextBox id="ElevationTextBox" Width="84px" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button id="UpdateButton" runat="server" Text="Update"></asp:Button>
        <br />
        <br />
		<asp:CheckBox id="DrawFlatCheckBox" runat="server" Text="Draw flat" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:Label id="Label4" runat="server">Position Mode:</asp:Label>
        <br />
        <asp:DropDownList id="PositionModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label5" runat="server">Custom value:</asp:Label>
        <br />
        <asp:DropDownList id="CustomValueDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label6" runat="server">Frame style:</asp:Label>
        <br />
        <asp:DropDownList id="FrameStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label7" runat="server">Transparency:</asp:Label>
        <br />
        <asp:DropDownList id="TransparencyDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="PaletteFrameCheckBox" runat="server" Text="Palette Frame" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="SmoothPaletteCheckBox" runat="server" Text="Smooth Palette" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="smoothShadingCheck" runat="server" Text="Smooth Shading" AutoPostBack="True"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        A general demonstration of the capabilities of the Grid Surface Series. Use the 
        Frame Style combo to switch between the different frame modes. The Palette 
        Frame check defines whether the frame lines are colored uniformly, or with 
        palette-defined colors. If the Smooth Palette check is checked the zone colors 
        gradate smoothly from one to another. The Filling Transparency combo controls 
        the transparency percent of the surface filling. The example also demonstrates 
        the 'flat surface' rendring mode (for contour charts).
        <br />
        <br />
        Use the Rotation and Elevation edit controls to change the surface view.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->