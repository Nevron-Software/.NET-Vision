<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAdvancedHighLowUC" CodeFile="NAdvancedHighLowUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">High label:</asp:Label><br />
		<asp:TextBox id="HighLabelTextBox" Width="156px" runat="server"></asp:TextBox>
		<br /><br />
		<asp:Label id="Label2" runat="server">Low label:</asp:Label>
		<br />
		<asp:TextBox id="LowLabelTextBox" Width="156px" runat="server"></asp:TextBox>
		<br />
		<br />
		<asp:Button id="ChangeDataButton" Height="24px" Width="156px" runat="server" Text="Change data"></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates the advanced High Low chart features.<br />
		High Low series can operate in XY scatter mode.<br />
		The user is able to easily apply labels on the high and low data points.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->