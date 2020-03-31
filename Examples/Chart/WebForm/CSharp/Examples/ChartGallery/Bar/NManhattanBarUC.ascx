<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NManhattanBarUC" CodeFile="NManhattanBarUC.ascx.cs" %>
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
        <asp:Button id="PositiveDataButton" runat="server" Text="Positive data" Width="178px"></asp:Button>
        <br />
        <br />
        <asp:Button id="PositiveAndNegativeDataButton" runat="server" Text="Positive and Negative data" Width="177px"></asp:Button>
        <br />
        <br />
        <asp:CheckBox id="PositiveDataCheckBox" runat="server" Width="185px" Checked="True" Height="21px" Visible="False"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates a Manhattan bar chart. This type of chart is created with several 
        bar series displayed with MultiBarMode set to Series.<br />
        Press the Postive Data button to fill the chart with random positive values.<br />
        Press the Postive and Negative Data button to fill the chart with random positive and negative values.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
