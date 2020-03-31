<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NCustomCommandsUC" CodeFile="NCustomCommandsUC.ascx.cs" %>
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
        Knob Value:<br />
        <input id = "KnobValue" value = "00.00" />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        The example demonstrates how to inject custom commands in the ThinWeb Chart response.<br />
        Press the mouse over the knob and start to drag to update the Knob Value text box.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<script language='javascript'>
    $(document).ready()
    {
        var gaugeHost = NClientNode.GetFromId("Gauge1");
        gaugeHost.CustomCommandCallback = function (argument) {
            $("input[id='KnobValue']")[0].value = argument;
        };
    }
</script>
<!-- Example layout END -->
