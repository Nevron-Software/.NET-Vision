<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NLineStudiesUC" CodeFile="NLineStudiesUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Line Study:</asp:Label>
        <br />
        <asp:DropDownList id="LineStudyDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Trendline Mode:</asp:Label>
        <br />
        <asp:DropDownList id="TrendlineModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShowTextsCheckBox" runat="server" Text="Show Texts" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:Button id="NewDataButton" runat="server" Text="Generate New Data"></asp:Button>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Line Studies are lines and various geometric figures that are plotted in price 
        charts or in indicator charts. They are used as analytical instruments helping 
        to define channels, support and resistance levels, trend changes and to 
        forecast price dynamics.<br />
        This example demonstrates the line studies supported by Nevron Chart for .NET - 
        Fibonacci Arcs, Fibonacci Fans, Fibonacci Retracements, Quadrant Lines, Speed 
        Resistence Lines and Trendline. You can use the "Line Study" combo box to 
        select one of them.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->