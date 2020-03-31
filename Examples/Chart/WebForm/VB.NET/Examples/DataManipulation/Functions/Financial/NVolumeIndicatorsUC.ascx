<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NVolumeIndicatorsUC" CodeFile="NVolumeIndicatorsUC.ascx.vb" %>
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
		<asp:DropDownList id="FunctionDropDownList" tabIndex="1" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" tabIndex="2" runat="server">Expression:</asp:Label>
		<br />
		<asp:Label id="ExpressionLabel" tabIndex="3" runat="server"></asp:Label>
		<br />
		<br />
		<asp:Label id="ParameterLabel" tabIndex="4" runat="server">Parameter:</asp:Label>
		<br />
		<asp:DropDownList id="ParameterDropDownList" tabIndex="5" runat="server"></asp:DropDownList>
		<br />
		<br />
		<asp:Button id="Button1" tabIndex="6" runat="server" Text="Change Data"></asp:Button>        
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The <strong>Accumulation/Distribution</strong> is a momentum indicator that 
		associates changes in price and volume. The indicator is based on the premise 
		that the more volume that accompanies a price move, the more significant the 
		price move.<br />
		<br />
		The <strong>Chaikin Oscillator</strong> is a moving average oscillator based on 
		the Accumulation/Distribution indicator.<br />
		<br />
		The <strong>Ease of Movement</strong> indicator shows the relationship between 
		volume and price change. As with Equivolume charting, this indicator shows how 
		much volume is required to move prices.<br />
		<br />
		The <strong>Money Flow Index</strong> is a momentum indicator that is similar 
		to the Relative Strength Index (RSI). It compares upward changes and downward 
		changes of volume-weighted typical prices. This indicator can be used to 
		identify the strength or weakness of a trend.<br />
		<br />
		The <strong>Negative Volume Index</strong> focuses on days where the volume 
		decreases from the previous day. The premise being that the "smart money" takes 
		positions on days when volume decreases.<br />
		<br />
		<strong>On Balance Volume</strong> is a momentum indicator that relates volume 
		to price change.<br />
		<br />
		The <strong>Positive Volume Index</strong> focuses on days where the volume 
		increased from the previous day. The premise being that the "crowd" takes 
		positions on days when volume increases.<br />
		<br />
		The <strong>Price and Volume Trend</strong> is similar to On Balance Volume, in 
		that it is a cumulative total of volume that is adjusted depending on changes 
		in closing prices. But where OBV adds all volume on days when prices close 
		higher and subtracts all volume on days when prices close lower, the PVT 
		adds/subtracts only a portion of the daily volume. The amount of volume added 
		to the PVT is determined by the amount that prices rose or fell relative to the 
		previous day's close.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
