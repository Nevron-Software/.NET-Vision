<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAutoLabelsAreaUC" CodeFile="NAutoLabelsAreaUC.ascx.vb" %>
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
		<asp:checkbox id="EnableLabelAdjustmentCheckBox" runat="server" AutoPostBack="True" Text="Enable Label Adjustment"></asp:checkbox>
		<br />

		<br />
		<asp:checkbox id="EnableDataPointSafeguardCheckBox" runat="server" AutoPostBack="True" Text="Enable Data Point Safeguard"></asp:checkbox>
		<br />
		<!-- Configuration controls panel placeholder END -->
		<asp:HiddenField ID="HiddenField1" runat="server" />
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		<p>
		This example demonstrates the basic usage of automatic data label layout.
		</p>
		<p>
		The "Enable Label Adjustment" check enables an option that shifts the data labels from their initial positions when necessary in order to avoid overlaps.
		</p>
		<p>
		The "Enable Data Point Safeguard" check enables functionality that protects the series data points from being overlapped by data labels.
		</p>
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
