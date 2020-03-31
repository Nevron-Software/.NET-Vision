<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NHorizontalBarUC" CodeFile="NHorizontalBarUC.ascx.vb" %>
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
		<asp:Button id="PositiveDataButton" Height="24" Width="177" runat="server" Text="Positive data" onclick="PositiveDataButton_Click"></asp:Button>
		<br />
		<br />
		<asp:Button id="PositiveAndNegativeDataButton" Height="24px" Width="177px" runat="server" Text="Positive and Negative data" onclick="PositiveAndNegativeDataButton_Click"></asp:Button>
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Bar Shape:</asp:Label>
		<br />
		<asp:DropDownList id="BarShapeDropDownList" Width="120px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="PositiveDataCheckBox" runat="server" Visible="False"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates a horizontal bar chart. The component has built-in functionality 
		for automatic configuration of left and right horizontally oriented charts.<br />
		Bar Shape – changes the shape of the bars.<br />
		Different Colors – when checked, each bar is filled with different color.<br />
		Positive Data button – fills the bar value series with random positive data.<br />
		Positive and Negative Data button – fills the bar value series with random 
		positive and negative data.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
