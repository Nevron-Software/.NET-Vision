<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NTooltipsUC" CodeFile="NTooltipsUC.ascx.cs" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 686px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 424px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="420px" Height="320px" AjaxEnabled="True" AsyncAutoRefreshEnabled="False" AsyncClickEventEnabled="False" AsyncCallbackTimeout="10000" AsyncRequestWaitCursorEnabled="False" OnQueryAjaxTools="nChartControl1_QueryAjaxTools">
		</ncwc:NChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="width: 424px; vertical-align: top;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the client side tooltip AJAX tool. Move the mouse over
		the pie slices to see the tooltips.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->