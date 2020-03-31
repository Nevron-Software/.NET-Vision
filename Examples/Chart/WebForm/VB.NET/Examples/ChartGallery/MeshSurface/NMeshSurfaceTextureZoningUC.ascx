<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NMeshSurfaceTextureZoningUC" CodeFile="NMeshSurfaceTextureZoningUC.ascx.vb" %>
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
		<asp:Label id="Label2" runat="server">Palette Mode:</asp:Label><br />
		<asp:DropDownList id="PaletteModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label1" runat="server">Palette Steps:</asp:Label><br />
		<asp:DropDownList id="PaletteStepsDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:CheckBox id="SmoothPaletteCheckBox" runat="server" Text="Smooth Palette" AutoPostBack="True"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		<p>Texture Zoning is a fast method for surface elevation zoning. It produces the same results as the standard zoning mode, but the performance impact is minimal.</p>
		<p>The only notable disadvantage of this zoning mode is that it is not applicable for flat surfaces (i.e. when the DrawFlat property is set to true).</p>
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->