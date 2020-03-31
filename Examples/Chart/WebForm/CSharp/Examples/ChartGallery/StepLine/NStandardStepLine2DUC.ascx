<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStandardStepLine2DUC" CodeFile="NStandardStepLine2DUC.ascx.cs" %>
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
        <asp:CheckBox id="InflateMarginsCheck" runat="server" Text="Inflate Margins" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="RoundToTickCheck" runat="server" Text="Left Axis Round to Tick " AutoPostBack="True"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        This example demonstrates a 2D step line chart. When you check the Inflate 
        Margins check the axis scales are adjusted to fit the entire chart including 
        the series markers. The Left Axis Round to tick check controls whether the left 
        axis should automatically round its min and max values to end on exact ticks.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->