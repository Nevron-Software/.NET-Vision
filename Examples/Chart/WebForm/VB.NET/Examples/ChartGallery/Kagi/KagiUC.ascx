<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" AutoEventWireup="true" CodeFile="KagiUC.ascx.vb" Inherits="Nevron.Examples.Chart.WebForm.KagiUC" %>
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
		<asp:label id="Label4" runat="server">Up Stroke Width:</asp:label>
		<br />
		<asp:dropdownlist id="UpStrokeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>

		<br />
		<asp:label id="Label3" runat="server">Down Stroke Width:</asp:label>
		<br />
		<asp:dropdownlist id="DownStrokeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<br />
		<asp:label id="Label5" runat="server">Reversal Amount:</asp:label>
		<br />
		<asp:dropdownlist id="reversalAmountDropdownlist" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Kagi charts display series of vertical lines to illustrate general levels of supply and demand for certain assets. 
		The thickness and direction of the lines are dependent on the price action. 
		Thick lines are drawn when the price breaks above the previous high price and is interpreted as an increase in demand. 
		Thin lines are used to represent increased supply when the price falls below the previous low. 
		Kagi charts ignore the passage of time.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
