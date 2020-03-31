<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStackedAreaUC" CodeFile="NStackedAreaUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">First Area Data Labels:</asp:Label>
		<br />
		<asp:DropDownList id="FirstAreaDataLabelsCombo" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Second Area Data Labels:</asp:Label>
		<br />
		<asp:DropDownList id="SecondAreaDataLabelsCombo" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Third Area Data Labels:</asp:Label>
		<br />
		<asp:DropDownList id="ThirdAreaDataLabelsCombo" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Stack Style:</asp:Label>
		<br />
		<asp:DropDownList id="StackStyleCombo" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates stacked area series. The first series MultiAreaMode is set to 
		Series, while the second and third area series are displayed with MultiAreaMode 
		set to Stacked or StackedPercent.<br />
		Two types of stacking are supported – Stacked and Stacked Percent. The first 
		type simply piles the areas on top of each other. The stacked percent style 
		displays the contribution of each individual stack to the overall pile sum.<br />
		Stack Style combo - controls the stacking style<br />
		Data Labels combo - controls the information displayed on the stacked areas 
		data labels.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
