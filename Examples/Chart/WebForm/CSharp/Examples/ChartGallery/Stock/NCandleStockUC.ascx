<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStockCandleUC" CodeFile="NCandleStockUC.ascx.cs" %>
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
        <asp:label id="Label3" runat="server">Up candle color:</asp:label>
        <br />
        <asp:dropdownlist id="UpCandleColorDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:label id="Label4" runat="server">Up candle line color:</asp:label>
        <br />
        <asp:dropdownlist id="UpCandleLineColorDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:label id="Label5" runat="server">Down candle color:</asp:label>
        <br />
        <asp:dropdownlist id="DownCandleColorDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:label id="Label6" runat="server">Down candle line color:</asp:label>
        <br />
        <asp:dropdownlist id="DownCandleLineColorDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:label id="Label7" runat="server">High Low line color:</asp:label>
        <br />
        <asp:dropdownlist id="HowLowLineColorDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:checkbox id="ShowHiLowLineCheckBox" runat="server" AutoPostBack="True" Text="Show High Low line"></asp:checkbox>		
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Candle Stock charts are displayed when the CandleStyle property of the Stock 
        series is set to Candle.<br />
        A candle is considered with up orientation if the open value is smaller than 
        the close value – otherwise the candle is considered with down orientation. The 
        Stock series automatically paints the candles in the appropriate color (defined 
        by its orientation).<br />
        The user can control the width of the candles from the Candle Width combo.<br />
        The user can control the depth of the candles in percent of the floor grid cell 
        depth from the Candle Depth % combo.<br />
        The fill color of the up and down candles can be controlled from the Up Candle 
        Color and Down Candle Color buttons respectively.<br />
        The border color of the up and down candles can be controlled from the Up 
        Candle Line Color and Down Candle Line Color buttons respectively.<br />
        The Show High Low Line check controls the visibility of the line connecting the 
        high and low values.<br />
        The user can change the color of the high – low line from the High Low Line 
        Color button.";
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
