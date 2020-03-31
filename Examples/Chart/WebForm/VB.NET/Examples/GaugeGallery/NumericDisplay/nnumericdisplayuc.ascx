<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NNumericDisplayUC" CodeFile="NNumericDisplayUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Dsiplay Style:</asp:Label>
		<br />
		<asp:DropDownList id="DisplayStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label2" runat="server">Sign Mode:</asp:Label>
		<asp:DropDownList id="SignModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:CheckBox ID="ShowLeadingZerosCheckBox" runat="server" Text="Show Leading Zeros" AutoPostBack="True"/>
		<br/>
		<asp:CheckBox ID="AttachSignToNumberCheckBox" runat="server" Text="Attach Sign To Number" AutoPostBack="True"/>
		<br/>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the functionality of the NNumericDisplayPanel.<br />
		It can be very useful to display numeric information (values) in LED fashion 
		with different styles.<br />
		<br />
		Use the combo on the right side to modify the style of the numeric display.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
