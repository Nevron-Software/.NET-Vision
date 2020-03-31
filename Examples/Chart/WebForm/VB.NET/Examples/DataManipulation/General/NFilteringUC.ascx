<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NFilteringUC" CodeFile="NFilteringUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Value:</asp:Label>
		<br />
		<asp:TextBox id="ValueTextBox" runat="server" Height="24" Width="140"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Filter:</asp:Label>
		<br />
		<asp:DropDownList id="FilterDropDownList" runat="server" Height="24px"></asp:DropDownList>
		<br />
		<br />
		<asp:Button id="Button1" runat="server" Height="24px" Width="140px" Text="Filter"></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Filtering can be very useful if you want to apply some data driven logic in 
		your application. In this example the items, which are contained in the current 
		filter are displayed in red.
		<br />
		Filter combo – specifies the comparison, which must be performed on the data 
		series elements.
		<br />
		When you press the Filter button the chart will display the data items that 
		match the current filter with blue.        
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

