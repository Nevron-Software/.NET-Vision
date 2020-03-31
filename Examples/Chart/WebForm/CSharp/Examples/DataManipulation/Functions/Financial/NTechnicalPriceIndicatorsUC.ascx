<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NTechnicalPriceIndicatorsUC" CodeFile="NTechnicalPriceIndicatorsUC.ascx.cs" %>
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
        <asp:DropDownList id="FunctionDropDownList" tabIndex="1" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" tabIndex="2" runat="server">Expression:</asp:Label>
        <br />
        <asp:Label id="ExpressionLabel" tabIndex="3" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label id="PeriodLabel" tabIndex="4" runat="server">Period:</asp:Label>
        <br />
        <asp:DropDownList id="PeriodDropDownList" tabIndex="5" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Button id="ChangeDataButton" tabIndex="6" runat="server" Text="Change Data"></asp:Button>		
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		The <strong>Average True Range</strong> is a volatility indicator. It is 
        calculated as Modified Moving Average of the True Range.<br />
        <br />
        <strong>Chaikin's Volatility</strong> indicator compares the spread between a 
        security's high and low prices. It quantifies volatility as a widening of the 
        range between the high and the low price.<br />
        <br />
        The <strong>Commodity Channel Index (CCI)</strong> measures the variation of a 
        security's price from its statistical mean. High values show that prices are 
        unusually high compared to average prices whereas low values indicate that 
        prices are unusually low. Contrary to its name, the CCI can be used effectively 
        on any type of security, not just commodities.<br />
        <br />
        The <strong>Detrended Price Oscillator</strong> attempts to eliminate the trend 
        in prices. Detrended prices allow you to more easily identify cycles and 
        overbought/oversold levels.<br />
        <br />
        The <strong>Moving Average Convergence Divergence (MACD)</strong> is a trend 
        following momentum indicator that shows the relationship between two moving 
        averages of prices. It is calculated by subtracting the value of a 26-day 
        exponential moving average from a 12-day exponential moving average. The MACD 
        proves most effective in wide-swinging trading markets.<br />
        <br />
        The <strong>Mass Index</strong> was designed to identify trend reversals by 
        measuring the narrowing and widening of the range between the high and low 
        prices. As this range widens, the Mass Index increases; as the range narrows 
        the Mass Index decreases.<br />
        <br />
        The <strong>Momentum</strong> indicator measures the amount that a security's 
        price has changed over a given time span. It can be used as a trend-following 
        oscillator similar to the MACD or as a leading indicator. The formula of the 
        momentum is:<br />
        <br />
        &nbsp;&nbsp;&nbsp; Momentum[n] = A1[n] - A1[n - period]<br />
        The <strong>Momentum Division</strong> function is similar to the Momentum 
        indicator. It calculates the ratio of a value compared to the N-th 
        previous&nbsp;value. The formula is:<br />
        &nbsp;&nbsp;&nbsp; MomentumDiv[n] = 100 * A1[n] / A1[n - period]<br />
        The <strong>Performance</strong> indicator displays a security's price 
        performance as a percentage. This is sometimes called a "normalized" chart.<br />
        <br />
        <strong>Rate of Change</strong> indicator is measuring the rate at which price 
        is changing.<br />
        <br />
        The <strong>RSI</strong> is a price-following oscillator that ranges between 0 
        and 100. The formula of the RSI is:<br />
        <br />
        &nbsp;&nbsp;&nbsp; RSI[n] = 100 - (100 / (1 + U[n] / D[n]))<br />
        U[n] - average value of the upward price change for the given period. D[n] - 
        average value of the downward price change for the given period.<br />
        <br />
        <strong>Standard Deviation</strong> is a statistical measure of volatility. 
        Standard Deviation is typically used as a component of other indicators, rather 
        than as a stand-alone indicator. For example, Bollinger Bands are calculated by 
        adding a security's Standard Deviation to a moving average.<br />
        <br />
        The <strong>Stochastic Oscillator</strong> compares where a security's price 
        closed relative to its price range over a given time period. Closing levels 
        that are consistently near the top of the range indicate buying pressure. Those 
        near the bottom of the range indicate selling pressure.<br />
        <br />
        LL is the current lowest low value for the given time period. HH is the current 
        highest high value for the given time period.<br />
        <br />
        <strong>TRIX</strong> is a momentum indicator that displays the percent 
        rate-of-change of a triple exponentially smoothed moving average of the 
        security's closing price. It is designed to keep you in trends equal to or 
        shorter than the number of periods you specify.<br />
        <br />
        <strong>Williams %R</strong> is a momentum indicator that measures 
        overbought/oversold levels. This indicator was developed by Larry Williams.	    
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
