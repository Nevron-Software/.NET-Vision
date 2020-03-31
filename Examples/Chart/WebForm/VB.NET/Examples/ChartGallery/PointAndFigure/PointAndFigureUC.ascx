<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" AutoEventWireup="true" CodeFile="PointAndFigureUC.ascx.vb" Inherits="Nevron.Examples.Chart.WebForm.PointAndFigureUC" %>
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
		<asp:CheckBox ID="ProportionalXCheckBox" runat="server" AutoPostBack="true" Text="Proportional X" />
		<br />
		<asp:CheckBox ID="ProportionalYCheckBox" runat="server" AutoPostBack="true" Text="Proportional Y" />
		<br />
		<br />                    
		<asp:label id="Label3" runat="server">Box Size:</asp:label>
		<br />
		<asp:dropdownlist id="BoxSizeDropdownlist" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<br />
		<asp:label id="Label4" runat="server">Reversal Amount:</asp:label>
		<br />
		<asp:dropdownlist id="ReversalAmountDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Point and Figure charts display series of columns that are made up of 'X' or 'O' signs. 
		A column of X's represents an uptrend, while a column of O's represents a downtrend. 
		The charts ignore the time factor and focus on price movements. 
		Point and Figure charts are used to identify support levels, resistance levels and chart patterns. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
