<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NCustomRequestsUC" CodeFile="NCustomRequestsUC.ascx.vb" %>
<!-- Example layout BEGIN -->

<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NThinChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
		</ncwc:NThinChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		Zoom to:
		<select id = "Period" onchange="UpdateChartPeriod(this)">
			  <option value="LastWeek">Last Week Data</option>
			  <option value="LastMonth">Last Month Data</option>
			  <option selected="selected" value="LastYear">All Data</option>
		</select>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to execute custom requests. Custom requests allow you to initiate AJAX updates from the client.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<script language='javascript'>
	function UpdateChartPeriod(periodDropDown) {
		var period = periodDropDown.options[periodDropDown.selectedIndex].value;
		NClientNode.GetFromId("Chart1").ExecuteCustomRequest(period);
	}
</script>
<!-- Example layout END -->
