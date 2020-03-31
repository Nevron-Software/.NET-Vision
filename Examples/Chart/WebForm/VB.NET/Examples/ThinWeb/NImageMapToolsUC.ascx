<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NImageMapToolsUC" CodeFile="NImageMapToolsUC.ascx.vb" %>
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
		<asp:CheckBox id="EnableBrowserRedirectCheckBox" runat="server" Checked = "true" Text="Enable Browser Redirect Tool" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="EnableTooltipsCheckBox" runat="server" Checked = "true" Text="Enable Tooltips Tool" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="EnableCursorChangeCheckBox" runat="server" Checked = "true" Text="Enable Cursor Change Tool" AutoPostBack="True"></asp:CheckBox>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The NTooltipTool, NCursorTool and NBrowserRedirectTool tools are used to achieve image map functionality.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
