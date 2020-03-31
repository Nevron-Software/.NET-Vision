<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" AutoEventWireup="true" CodeFile="RenkoUC.ascx.vb" Inherits="Nevron.Examples.Chart.WebForm.RenkoUC" %>
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
		<asp:label id="Label1" runat="server">Up Color:</asp:label>
		<br />
		<asp:dropdownlist id="UpColorDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<br />
		<asp:label id="Label2" runat="server">Down Color:</asp:label>
		<br />
		<asp:dropdownlist id="DownColorDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<br />
		<asp:label id="Label4" runat="server">Box size:</asp:label>
		<br />
		<asp:dropdownlist id="BoxSizeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<br />
		<asp:label id="Label3" runat="server">Box Width Pecent:</asp:label>
		<br />
		<asp:dropdownlist id="BoxWidthDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Renko charts display series of white and black boxes (bricks) to illustrate general price movement and trend reversals. 
		A Renko chart is constructed by placing a brick in the next column once the price surpasses the top or bottom of the previous brick by a predefined amount. 
		White bricks are used when the direction of the trend is up, black bricks are used when the trend is down. 
		All bricks are equal in size. This type of chart helps traders to identify key support/resistance levels.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
