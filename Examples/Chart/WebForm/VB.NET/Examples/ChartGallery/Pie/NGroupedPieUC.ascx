<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NGroupedPieUC" CodeFile="NGroupedPieUC.ascx.vb" %>
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
		<asp:Button id="ChangeDataButton" runat="server" Text="Change data"></asp:Button>
		<br />
		<br />
		<asp:CheckBox id="GroupPiesCheckBox" runat="server" Text="Group pies below value" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Value:</asp:Label>
		<br />
		<asp:TextBox id="ThresholdValueTextBox" runat="server" Width="60px" AutoPostBack="True"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Grouped pie color:</asp:Label>
		<br />
		<asp:DropDownList id="GroupedPieColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Grouped pie label:</asp:Label>
		<br />
		<asp:TextBox id="GroupedPieLabelTextBox" runat="server" Width="120" AutoPostBack="True"></asp:TextBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Grouped Pie. Values below a certain value are grouped in one pie slice.<br />
		This example demonstrates the built-in functionality for data series filtering
		<br />
		and subset evaluation to create a grouped pie chart.<br />
		When you click the Group Below Value button all pie values which are below the 
		value specified in the Group Below Value edit will be displayed in one pie 
		slice with label determined from the Label edit and the color specified from 
		the Color combo.<br />
		When you click the Ungroup Data button the pie will show the original data 
		set."
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
