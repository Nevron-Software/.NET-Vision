<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NLegendItemTextFitModeUC" CodeFile="NLegendItemTextFitModeUC.ascx.vb" %>
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
			
		<asp:Label id="Label1" runat="server">Text Fit Mode:</asp:Label><br />
		<asp:DropDownList id="LegendItemTextFitModeDropDownList" runat="server" Height="22" Width="141" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label2" runat="server">Maximum Width:</asp:Label><br />
		<asp:DropDownList id="LegendItemMaximumWidthDropDownList" runat="server" Height="22" Width="141" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates how to use the legend maximum item width and text wrap mode properties in order to control the legend size. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
