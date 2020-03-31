<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NHeatMapContourUC.ascx.cs" Inherits="Nevron.Examples.Chart.WebForm.NHeatMapContourUC" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
        <ncwc:NThinChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
        </ncwc:NThinChartControl>
        <!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        <asp:Label id="Label1" runat="server">Contour Display Mode:</asp:Label>
        <br />
        <asp:DropDownList id="ContourDisplayModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br /><br />
        <asp:Label id="Label2" runat="server">Contour Color Mode:</asp:Label>
        <br />
        <asp:DropDownList id="ContourColorModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />    
        <br />
		<asp:CheckBox id="ShowFillCheckBox" Width="132px" runat="server" AutoPostBack="True" Text="Show Fill"></asp:CheckBox>
		<br />
        <asp:CheckBox id="SmoothPaletteCheckBox" Width="132px" runat="server" AutoPostBack="True" Text="Smooth Palette"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		The example demonstrates the capabilities of the heat map series to render contour lines.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
