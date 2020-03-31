<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NRulesSizeUC" CodeFile="NRulerSizeUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Red axis end percent:</asp:Label>
		<br />
		<asp:DropDownList id="RedAxisEndPercentDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Blue axis begin percent:</asp:Label>
		<br />
		<asp:DropDownList id="BlueAxisEndPercentDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		When you use axis docking you can also specify whether the axis will create a 
		separate level in the dock zone or use the last created one. This allows you to 
		have two or more axes in a zone level that share a percentage of the chart 
		wall.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
