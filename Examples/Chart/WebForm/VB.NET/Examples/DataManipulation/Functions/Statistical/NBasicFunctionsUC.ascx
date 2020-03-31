<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NBasicFunctionsUC" CodeFile="NBasicFunctionsUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Function expression:</asp:Label>
		<br />
		<asp:DropDownList id="ExpressionDropDownList" runat="server" Height="22" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Button id="ChangeDataButton" runat="server" Height="22px" Width="129px" Text="Change Data"></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the usage of the following basic functions: Add, Subtract, 
		Multiply, Divide, High and Low.
		<br />
		<br />
		The two bar series are used as data sources (arguments) for the functions. The 
		line series presents the result of the currently selected function.        
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
