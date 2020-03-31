<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NBackgroundDecoratorUC" CodeFile="NBackgroundDecoratorUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Dock Title:</asp:Label>
		<br />
		<asp:DropDownList id="DockTitleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Dock Legend:</asp:Label>
		<br />
		<asp:DropDownList id="DockLegendDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example shows how to use the background decorator panel in conjunction with 
		the layout manager of the control in order to achieve more visually appealing 
		charts.<br />
		<br />
		Dock Title - allows you to dock the title label to the top or bottom of the 
		control canvas.<br />
		Dock Legend - allows you to dock the legend to the left of right of the control 
		canvas.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
