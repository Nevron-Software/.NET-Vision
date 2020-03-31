<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NFinancialChartUC" CodeFile="NFinancialChartUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Candle style:</asp:Label>                        
		<asp:DropDownList id="CandleStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="SMACheckBox" runat="server" AutoPostBack="True" Checked="True" Text="Show Simple Moving Average"></asp:CheckBox>
		<br />
		<asp:CheckBox id="SBBCheckBox" runat="server" AutoPostBack="True" Checked="True" Text="Show Bollinger Bands"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates a financial chart consisting of stock series, Bollinger bands 
		presented as a high-low (range) series and a simple moving average presented as 
		a line.
		<br />
		The chart uses const lines and custom axis labels for the horizontal axis.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
