<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NTriangulatedSurfaceUC" CodeFile="NTriangulatedSurfaceUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Surface Filling</asp:Label>
		<br />
		<asp:Label id="Label2" runat="server">Fill Mode:</asp:Label>
		<br />
		<asp:DropDownList id="fillDropDownList" Width="152px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:CheckBox id="smoothShadingCheck" runat="server" AutoPostBack="True" Text="Smooth Shading"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Surface Frame</asp:Label>
		<br />
		<asp:Label id="Label4" runat="server">Frame Mode:</asp:Label>
		<br />
		<asp:DropDownList id="frameModeDropDownList" Width="152px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label5" runat="server">Frame Color Mode:</asp:Label>
		<br />
		<asp:DropDownList id="frameColorModeDropDownList" Width="152px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label6" runat="server">Pallete</asp:Label>
		<br />
		<asp:CheckBox id="smoothPaletteCheck" runat="server" AutoPostBack="True" Text="Smooth Palette"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label7" runat="server">Flat Mode</asp:Label>
		<br />
		<asp:CheckBox id="drawFlatCheck" runat="server" AutoPostBack="True" Text="Draw Flat"></asp:CheckBox>
		<br />
		<asp:Label id="Label8" runat="server">Position Mode:</asp:Label>
		<br />
		<asp:DropDownList id="positionModeDropDownList" Width="152px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label9" runat="server">Custom Value:</asp:Label>
		<br />
		<asp:DropDownList id="customValueDropDownList" Width="152px" runat="server" AutoPostBack="True"></asp:DropDownList>        
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
		gradate smoothly from one to another. The Filling Transparency scroll controls 
		the transparency percent of the surface filling. The example also demonstrates 
		the 'flat surface' rendring mode (for contour charts).
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
