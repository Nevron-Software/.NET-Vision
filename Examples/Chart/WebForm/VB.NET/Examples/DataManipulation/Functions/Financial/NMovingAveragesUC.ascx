<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NMovingAveragesUC" CodeFile="NMovingAveragesUC.ascx.vb" %>
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
		<asp:DropDownList id="FunctionDropDownList" runat="server" Height="22" Width="157" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Apply function to:</asp:Label>
		<br />
		<asp:DropDownList id="ApplyFunctionToDropDownList" runat="server" Height="22" Width="157" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Expression:</asp:Label>
		<br />
		<asp:TextBox id="ExpressionTextBox" runat="server" Height="22px" Width="157px" ReadOnly="True"
		Enabled="False"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Period:</asp:Label>
		<br />
		<asp:DropDownList id="PeriodDropDownList" runat="server" Height="22" Width="157" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Button id="Button1" runat="server" Text="New data"></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		A Moving Average is an indicator that shows the average value of a security's 
		price over a period of time. A simple, or arithmetic, moving average is 
		calculated by adding the price of the security for a number of time periods 
		(e.g., 12 days) and then dividing this total by the number of time periods. The 
		result is the average price of the security over the time period. Simple moving 
		averages give equal weight to each daily price.<br />
		<br />
		A Weighted Moving Average is designed to put more weight on recent data and 
		less weight on past data. A weighted moving average is calculated by 
		multiplying each of the previous day's data by a weight (the weight is the 
		index of the data).<br />
		<br />
		An Exponential Moving Average is calculated by applying a percentage of today's 
		closing price to yesterday's moving average value. Exponential moving averages 
		place more weight on recent prices.<br />
		<br />
		The Modified Moving Average is the same as the Exponential Moving Average. The 
		only difference is in the period of the functions. For example a 14-day MMA is 
		the same as 27-day EMA.        
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->