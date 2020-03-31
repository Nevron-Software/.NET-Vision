<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NPointChartAndBoxPlotUC" CodeFile="NPointChartAndBoxPlotUC.ascx.cs" %>
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
        <asp:CheckBox id="ShowAverageCheckBox" runat="server" AutoPostBack="True" Text="Show Average"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="ShowOutliersCheckBox" runat="server" AutoPostBack="True" Text="Show Outliers"></asp:CheckBox>
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        This example demonstrates a combination of a point chart and box and whiskers 
        chart which represent the same set of values.<br />
        The calculation of the data distribution is performed by the box and whiskers 
        data point object.				
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
