<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThreeLineBreakUC.ascx.cs" Inherits="Nevron.Examples.Chart.WebForm.ThreeLineBreakUC" %>
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
        <asp:label id="Label4" runat="server">Box Width Percent:</asp:label>
        <br />
        <asp:dropdownlist id="BoxWidthDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:label id="Label3" runat="server">Number of Lines to Break:</asp:label>
        <br />
        <asp:dropdownlist id="NumberOfLinesDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Three Line Break charts display a series of vertical boxes ("lines") that are based on changes in prices. 
        A new rising line is drawn if the closing price is higher than the previous one. 
        A new falling line is drawn if the closing price is lower than the previous one. 
        If a rally or a sell-off is powerful enough to form several consecutive lines with the same direction, 
        then prices must reverse by the extreme price of the last several lines in order to create a new line. 
        Usually three consecutive lines are used for the reversal criterion, hence the name Three Line Break. 
        As with Kagi, Point and Figure, and Renko charts, Three Line Break charts ignore the passage of time. 
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
