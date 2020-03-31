<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NTernaryPointUC" CodeFile="NTernaryPointUC.ascx.vb" %>
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
		<asp:label id="Label3" runat="server">Point Shape:</asp:label>
		<br />
		<asp:dropdownlist id="PointShapeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<asp:checkbox id="DifferentColorsCheckBox" runat="server" AutoPostBack="True" Text="Different Colors"></asp:checkbox>        
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to create a ternary point chart.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
