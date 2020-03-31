<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NSeriesZOrderUC" CodeFile="NSeriesZOrderUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Z Order:</asp:Label>
        <br />
        <asp:DropDownList id="ZOrderModeCombo" runat="server" AutoPostBack="True"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        The example demonstrates the effect of the series ZOrder property. This property allows you to control whether a series appears on top of another series regardless of its position in the series collection. Series with higher z order will always appear on top of series with lower z order.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->