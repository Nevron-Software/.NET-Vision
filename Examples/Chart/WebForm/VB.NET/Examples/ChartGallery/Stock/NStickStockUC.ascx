<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStickStockUC" CodeFile="NStickStockUC.ascx.vb" %>
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
		<asp:CheckBox id="ShowOpenCheckBox" runat="server" Text="Show Open" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="ShowCloseCheckBox" runat="server" Text="Show Close" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="ShowHighLowCheckBox" runat="server" Text="Show High Low" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Up stick color:</asp:Label>
		<br />
		<asp:DropDownList id="UpStickColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Down stick color:</asp:Label>
		<br />
		<asp:DropDownList id="DownStickColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Stick Stock charts are displayed when the CandleStyle property of the Stock 
		series is set to Stick.<br />
		A stick is considered with up orientation if the open value is smaller than the 
		close value – otherwise the stick is considered with down orientation. The 
		Stock series automatically paints the sticks in the appropriate color (defined 
		by its orientation).<br />
		The user can control the width of the candles from the Candle Width scroll.<br />
		The color of the up and down sticks can be controlled from the Up Stick Color 
		and Down Stick Color buttons respectively.<br />
		The user can control the visibility of the Open, Close and High – Low stick 
		segments with the help of the Show Open, Show Close and Show High Low checks 
		respectively.        
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
