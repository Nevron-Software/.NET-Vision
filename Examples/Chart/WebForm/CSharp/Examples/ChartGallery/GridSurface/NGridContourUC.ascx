<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NGridContourUC" CodeFile="NGridContourUC.ascx.cs" %>
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
        <asp:CheckBox id="ShowFillingCheckBox" runat="server" Text="Show Filling" Checked="True" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="ShowFrameCheckBox" runat="server" Text="Show Frame" Checked="True" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="PaletteFrameCheckBox" runat="server" Text="Palette Frame" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="SmoothPaletteCheckBox" runat="server" Text="Smooth Palette" AutoPostBack="True"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates a contour chart displayed with the Grid Surface Series. The chart uses 
        orthogonal projection with camera elevation of 90 degrees, the lighting is 
        disabled and the surface is rendered in flat mode.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
