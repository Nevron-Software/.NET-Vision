<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NPriceIndicatorsUC" CodeFile="NPriceIndicatorsUC.ascx.vb" %>
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
		<asp:Label id="Label2" runat="server">Expression:</asp:Label>
		<br />
		<asp:Label id="ExpressionLabel" runat="server"></asp:Label>
		<br />
		<br />
		<asp:Button id="ChangeDataButton" runat="server" Text="Change Data"></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The <strong>Median Price</strong> indicator is the midpoint of each day's 
		price. This average price is useful when you want a simpler view of prices.<br />
		<br />
		The <strong>Typical Price</strong> indicator is an average of each day's price. 
		Some investors use the Typical Price rather than the closing price when 
		creating moving average penetration systems.<br />
		<br />
		The <strong>Weighted Close</strong> indicator is simply an average of each 
		day's price. It gets its name from the fact that extra weight is given to the 
		closing price. When plotting and back-testing moving averages, indicators, 
		trendlines, etc, some investors like the simplicity that a line chart offers. 
		However, line charts that only show the closing price can be misleading since 
		they ignore the high and low price. A Weighted Close chart combines the 
		simplicity of the line chart with the scope of a bar chart, by plotting a 
		single point for each day that includes the high, low, and closing price.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
