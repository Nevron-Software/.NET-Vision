<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NDataZoomToolUC" CodeFile="NDataZoomToolUC.ascx.cs" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NThinChartControl ID="NThinChartControl1" runat="server" Width="420px" Height="320px"/>
        <!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        <asp:CheckBox id="ShowScrollbarsCheckBox" runat="server" Checked = "true" Text="Show Scrollbars" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="ZoomOutResetsAxesCheckBox" runat="server" Checked = "false" Text="Zoom Out Resets Axes" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="UseTilingCheckBox" runat="server" Checked = "true" Text="Use Tiling" AutoPostBack="True"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
        <!-- Description box placeholder BEGIN -->
        The NDataZoomTool allows the user to zoom in / out a range on the chart. 
        Press the left mouse button over the chart and select a region to zoom in. The control will automatically show scrollbars (if set to visible) on all zoomed axes. <br />
         <br />
        Show Scrollbars - whether the axis scrollbars are visible. <br />
        Zoom Out Resets Axes - whether a zoom out operation resets the chart axes. <br />
        Use Tiling - whether the chart will tile the scrolled axes and chart plot, which results in smooth scrolling.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
