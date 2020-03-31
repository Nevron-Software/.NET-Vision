<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NRangeIndicatorsUC" CodeFile="NRangeIndicatorsUC.ascx.vb" %>
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
		<asp:Label id="Label2" runat="server">Period:</asp:Label>
		<br />
		<asp:DropDownList id="PeriodDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Deviation:</asp:Label>
		<br />
		<asp:DropDownList id="DeviationDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="ShowPricesCheckBox" runat="server" AutoPostBack="True" Text="Show Prices"></asp:CheckBox>
		<br />
		<asp:CheckBox id="ShowSMACheckBox" runat="server" AutoPostBack="True" Text="Show Moving Average"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		<strong>Bollinger Bands</strong> are drawn at a given number of standard 
		deviations from a moving average of a price. Since standard deviation is a 
		measure of volatility, the bands are self-adjusting: widening during volatile 
		markets and contracting during calmer periods. Bollinger Bands were created by 
		John Bollinger.<br />
		<br />
		An <strong>Envelope</strong> is comprised of two moving averages. One moving 
		average is shifted upward and the second moving average is shifted downward.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
