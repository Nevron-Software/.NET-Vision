<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NNonoverlappingLabelsUC" CodeFile="NNonoverlappingLabelsUC.ascx.cs" %>
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
        <asp:CheckBox ID="clockwiseCheckBox" runat="server" Text="Clockwise" AutoPostBack="true" /><br />
        <br />
        <asp:Button id="ChangeDataButton" runat="server" Text="Change data" OnClick="ChangeDataButton_Click"></asp:Button>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        This example demonstrates the nonoverlapping pie labels feature. The pie chart labels
        are automatically positioned in a manner that doesn't allow them to overlap with
        each other. The label layout is similar to the spider mode.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
