<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAxisStripLinesUC" CodeFile="NAxisStriplinesUC.ascx.cs" %>
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
        <br />
            <asp:Label id="Label1" runat="server">Highlight Range:
            </asp:Label>
        <br />
            <asp:DropDownList id="HighLightRangeDropDownList" Width="120px" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
        The example demonstrates how to use the scale strip lines to visually highlight 
        repeating ranges of data. You can have an unlimited number of strips per axis.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
