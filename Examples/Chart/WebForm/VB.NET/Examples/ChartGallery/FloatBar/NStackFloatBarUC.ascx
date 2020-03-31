<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStackFloatBarUC" CodeFile="NStackFloatBarUC.ascx.vb" %>
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
		<asp:Label id="Label3" runat="server">Bar Shape:</asp:Label>
		<br />
		<asp:DropDownList id="BarShapeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Data Type:</asp:Label>
		<br />
		<asp:DropDownList id="DataTypeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Stack Float Bar is created by stacking one or more Bar series over a FloatBar series. The bars 
		with positive values are stacked on top of the floating bars, while the ones with negative values 
		are stacked under the floating bars.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

