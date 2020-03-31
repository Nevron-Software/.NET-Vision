<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAnnotationsGeneralUC" CodeFile="NAnnotationsGeneralUC.ascx.vb" %>
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
		<asp:CheckBox ID="rectPanelCheck" runat="server" AutoPostBack="True" Text="Rectangular Callout" />
		<br />
		<asp:CheckBox ID="roundRectCalloutCheck" runat="server" AutoPostBack="True" Text="Rounded Rectangular Callout" />
		<br />
		<asp:CheckBox ID="cutedgeRectPanelCheck" runat="server" AutoPostBack="True" Text="Cut Edge Rectangular Callout" />
		<br />
		<asp:CheckBox ID="ovalPanelCheck" runat="server" AutoPostBack="True" Text="Oval Callout" />
		<br />
		<asp:CheckBox ID="arrowCheck" runat="server" AutoPostBack="True" Text="Arrow Annotation" />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Annotations are anchor panels that also posses an anchor (pivot) point. The 
		anchor is calculated at runtime and depends on position of the scene item the 
		annotation is attached to.<br />
		Each scene item has a corresponding anchor object - for example you can use the 
		NDataPointAnchor object to attach annotations to chart data points.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->