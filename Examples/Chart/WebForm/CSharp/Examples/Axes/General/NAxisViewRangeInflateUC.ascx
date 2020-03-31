<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAxisViewRangeInflateUC" CodeFile="NAxisViewRangeInflateUC.ascx.cs" %>
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
		<asp:Label id="Label1" runat="server">View Range Inflate Mode:</asp:Label>
        <asp:DropDownList id="ViewRangeInflateModeDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br/>
        <asp:CheckBox id="InflateMinCheckBox" runat="server" AutoPostBack="True" Text="Inflate Min" ></asp:CheckBox>
        <br/>
        <asp:CheckBox id="InflateMaxCheckBox" runat="server" AutoPostBack="True" Text="Inflate Max" ></asp:CheckBox>
        <br />
        <br/>
		<asp:Label id="Label4" runat="server">Logical Inflate Min/Max:</asp:Label>
		<br/>
        <asp:DropDownList id="LogicalInflateMinMaxDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br/>
        <br/>
		<asp:Label id="Label5" runat="server">Absolute Inflate Min/Max:</asp:Label>
		<br/>
        <asp:DropDownList id="AbsoluteInflateMinMaxDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br/>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
This example demonstrates the ability of Nevron Chart to inflate the logical range of the axis in several modes.
<br />
You can change the inflate mode using the "View Range Inflate Mode" combo on the right. There are four options:
<li>Major Tick - inflate the range so that it always ends to an exact major tick value</li>
<li>Major Tick Extend - inflate the range so that it always ends to an exact major tick value. If original range ends at exact tick value it will be extended with one tick.</li>
<li>Logical - inflate the range in logical units</li>
<li>Absolute - inflate the range in points (allows you to specify margins for the series content from the chart edges)</li>
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
