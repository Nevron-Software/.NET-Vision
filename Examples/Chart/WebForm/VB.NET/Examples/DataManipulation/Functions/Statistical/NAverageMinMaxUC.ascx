<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAverageMinMaxUC" CodeFile="NAverageMinMaxUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Function:</asp:Label>
		<br />
		<asp:DropDownList id="FunctionDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Grouping:</asp:Label>
		<br />
		<asp:DropDownList id="GroupingDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Expression:</asp:Label>
		<br />
		<asp:TextBox id="ExpressionTextBox" runat="server" Height="22px" Width="155px"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Data:</asp:Label>
		<br />
		<asp:DropDownList id="DataDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Example demonstrating the Min, Max and Average functions. Use the 'Function' combo to switch between 
		them.
		<br />
		<br />
		The expression which is used for the calculation of the selected function is 
		displayed in the expression text box.
		<br />
		<br />
		The Min, Max and Average functions support grouping of the input values - in 
		this way a result value is calculated for every group of N elements, and not 
		for the whole input data series. This feature is controlled by the 'Grouping' 
		combo.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
