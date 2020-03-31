<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NIndicatorDragToolUC" CodeFile="NIndicatorDragToolUC.ascx.vb" %>
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
		<asp:CheckBox id="EnableRangeIndicatorDraggingCheckBox" runat="server" Checked = "false" Text="Enable Range Dragging" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="EnableNeedleIndicatorDraggingCheckBox" runat="server" Checked = "true" Text="Enable Needle Dragging" AutoPostBack="True"></asp:CheckBox>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The NIndicatorDrag tool allows you to interactively change indicator values by pressing an indicator and then dragging the mouse.<br />
		Enable Range Dragging - whether dragging the range indicator is allowed.<br />
		Enable Needle Dragging - whether dragging the needle indicator is allowed.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
