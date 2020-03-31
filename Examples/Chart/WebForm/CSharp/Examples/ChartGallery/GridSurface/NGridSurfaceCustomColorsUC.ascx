<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NGridSurfaceCustomColorsUC" CodeFile="NGridSurfaceCustomColorsUC.ascx.cs" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
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
		<asp:CheckBox id="SmoothShadingCheckBox" runat="server" Text="Smooth Shading" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="HasFillingCheckBox" runat="server" Text="Has Filing" AutoPostBack="True"></asp:CheckBox>
        <br />
		<asp:Label id="Label1" runat="server">Frame Mode:</asp:Label>
		<asp:DropDownList id="FrameModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		The example demonstrates the ability of the Grid Surface Series to assign custom color per each individual surface vertex.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
