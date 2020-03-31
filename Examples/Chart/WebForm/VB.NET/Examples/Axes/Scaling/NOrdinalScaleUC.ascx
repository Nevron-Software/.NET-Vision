<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NOrdinalScaleUC" CodeFile="NOrdinalScaleUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Primary X axis
		</asp:Label>
		<br />
		<asp:CheckBox id="PrimaryXAxisInvertCheckBox" runat="server" AutoPostBack="True" Text="Display Datapoints Between Ticks" oncheckedchanged="PrimaryXAxisInvertCheckBox_CheckedChanged">
		</asp:CheckBox>
		<br />
		<asp:CheckBox id="PrimaryXAxisAutoLabelsCheckBox" runat="server" AutoPostBack="True" Text="Auto labels" oncheckedchanged="PrimaryXAxisAutoLabelsCheckBox_CheckedChanged">
		</asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Depth axis
		</asp:Label>
		<br />
		<asp:CheckBox id="DepthAxisInvertAxisCheckBox" runat="server" AutoPostBack="True" Text="Display Datapoints Between Ticks" oncheckedchanged="DepthAxisInvertAxisCheckBox_CheckedChanged">
		</asp:CheckBox>
		<br />
		<asp:CheckBox id="DepthAxisAutoLabelsCheckBox" runat="server" AutoPostBack="True" Text="Auto labels" oncheckedchanged="DepthAxisAutoLabelsCheckBox_CheckedChanged">
		</asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The Ordinal axis scale mode is used to display categorical data.<br />
		You can optionally change the labels displayed by the axis by turning off the 
		AutoLabels and feeding custom labels to the scale.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
