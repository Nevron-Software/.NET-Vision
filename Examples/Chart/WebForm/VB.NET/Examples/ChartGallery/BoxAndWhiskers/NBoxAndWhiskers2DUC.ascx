<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NBoxAndWhiskers2DUC" CodeFile="NBoxAndWhiskers2DUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Box Width:</asp:Label>
		<br />
		<asp:DropDownList id="BoxWidthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Whiskers Width:</asp:Label>
		<br />
		<asp:DropDownList id="WhiskersWidthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="InflateMarginsCheckBox" runat="server" AutoPostBack="True" Text="Inflate Margins"></asp:CheckBox>
		<br />
		<asp:CheckBox id="LeftAxisRoundToTickCheckBox" runat="server" AutoPostBack="True" Text="Left Axis Round To Tick"></asp:CheckBox>
		<br />
		<br />
		<asp:Button id="GenerateDataButton" runat="server" Text="Generate Data"></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Box and whiskers plots are very helpful in interpreting the distribution of 
		data. Each box and whiskers item represents a set of values and displays 
		statistical information for it like minimum, maximum and median values, upper 
		and lower quartiles, outliers and optionally a mean value.<br />
		This example demonstrates a box and whiskers series that lets you compare the 
		statistical parameters of several different data sets.<br />
		You can use the controls to modify different properties of the box and whiskers 
		series like box size, whiskers size etc.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
	
