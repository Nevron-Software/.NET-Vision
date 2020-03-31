<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NSumElementsUC" CodeFile="NSumElementsUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Grouping:</asp:Label>
		<br />
		<asp:DropDownList id="GroupingDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Data:</asp:Label>
		<br />
		<asp:DropDownList id="DataDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Expression:</asp:Label>
		<br />
		<asp:TextBox id="ExpressionTextBox" Width="156" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Sum:</asp:Label>
		<br />
		<asp:TextBox id="SumTextBox" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
		<br />
		<br />
		<asp:Button id="Button1" runat="server" Text="New Data"></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates the SUM function. The MIN and MAX functions are also used in this 
		example to ensure proper scaling of the vertical axis."
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
