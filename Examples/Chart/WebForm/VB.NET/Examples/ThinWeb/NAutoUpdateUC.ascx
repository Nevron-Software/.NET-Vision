<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAutoUpdateUC" CodeFile="NAutoUpdateUC.ascx.vb" %>
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
		<asp:Button ID="ToggleAutoUpdateButton" runat="server" Text="Stop Auto Update" OnClick="ToggleAutoUpdateButton_Click" ></asp:Button>
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Auto Update Interval (ms):</asp:Label>
		<br />
		<asp:TextBox id="AutoUpdateIntervalTextBox" runat="server" Height="22px" Width="116px"></asp:TextBox>
		<br />
		<asp:Button ID="SetAutoUpdateIntervalButton" runat="server" 
			Text="Set Auto Update Interval" onclick="SetAutoUpdateIntervalButton_Click" ></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to configure a chart which is automatically updated.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
