<%@ Control Language="C#" Inherits="Nevron.Examples.Chart.WebForm.NHierarchicalScaleUC" CodeFile="NHierarchicalScaleUC.ascx.cs" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
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
		<asp:CheckBox ID="ShowLevelSeparatorsCheckBox" runat="server" Text="Show Level Separators" AutoPostBack="True"/>
        <br/>
		<asp:CheckBox ID="Show2007DataCheckBox" runat="server" Text="Show Data for 2007" AutoPostBack="True"/>
        <br/>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
The example demonstrates how to create a hierachical scale using the built-in NHierarchicalScaleConfigurator.
<br />
When you check the "Create Level Separators" check box the levels on the scale will be delimited with a line.  
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>