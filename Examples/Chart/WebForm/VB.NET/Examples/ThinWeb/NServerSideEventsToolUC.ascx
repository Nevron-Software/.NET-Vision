<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NServerSideEventsToolUC" CodeFile="NServerSideEventsToolUC.ascx.vb" %>
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
		<asp:CheckBox id="MouseDownCheckBox" runat="server" Checked = "true" Text="Mouse Down" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="MouseMoveCheckBox" runat="server" Checked = "false" Text="Mouse Move" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="MouseUpCheckBox" runat="server" Checked = "false" Text="Mouse Up" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="MouseOverCheckBox" runat="server" Checked = "false" Text="Mouse Over" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="MouseLeaveCheckBox" runat="server" Checked = "false" Text="Mouse Leave" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="MouseEnterCheckBox" runat="server" Checked = "false" Text="Mouse Enter" AutoPostBack="True"></asp:CheckBox>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example shows how to intercept server side events. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
