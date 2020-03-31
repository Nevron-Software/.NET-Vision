<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NDataPanToolUC" CodeFile="NDataPanToolUC.ascx.vb" %>
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
		<asp:CheckBox id="UseTilingCheckBox" runat="server" Text="Use Tiling" Checked = "true" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="UpdateRangeInTitleCheckBox" runat="server" Text="Update Range in Title" Checked = "true" AutoPostBack="True"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The NDataPanTool allows the user to drag the currently zoomed range of the chart. Press the left mouse button over the chart and drag to move the current range.<br /><br />
		Show Scrollbars - whether the axis scrollbars are visible. <br />
		Use Tiling - whether the chart will tile the scrolled axes and chart plot which results in smooth panning and scrolling.<br />
		Update Range in Title - whether to update the currently zoomed range in the chart title.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
