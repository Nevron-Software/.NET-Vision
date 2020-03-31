<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" AutoEventWireup="true" CodeFile="NPolarValueAxisPositionUC.ascx.vb" Inherits="Nevron.Examples.Chart.WebForm.NPolarValueAxisPositionUC" %>
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
		<br />
		<asp:label id="Label1" runat="server">Begin Angle:</asp:label>
		<br />
		<asp:dropdownlist id="BeginAngleDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		<br />
		<br />
		<asp:label id="Label2" runat="server">Red Axis:</asp:label>
		<br />
		<asp:CheckBox id="DockRedAxisCheckBox" Width="132px" runat="server" AutoPostBack="True" Text="Dock Bottom"></asp:CheckBox>
		<br />
		<asp:CheckBox id="PaintReflectionOfRedAxisCheckBox" Width="132px" runat="server" AutoPostBack="True" Text="Paint Reflection"></asp:CheckBox>
		<br />
		<br />
		<asp:label id="Label3" runat="server">Green Axis:</asp:label>
		<br />
		<asp:CheckBox id="DockGreenAxisCheckBox" Width="132px" runat="server" AutoPostBack="True" Text="Dock Left"></asp:CheckBox>
		<br />
		<asp:CheckBox id="PaintReflectionOfGreenAxisCheckBox" Width="132px" runat="server" AutoPostBack="True" Text="Paint Reflection"></asp:CheckBox>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
The example demonstrates how to position polar value axes.<br />
You can dock polar value axes to one of the four cartesian zones attached to the polar (Left, Top, Right and Bottom). In this example this is achieved by
checking the "Dock Bottom" and "Dock Left" check boxes will dock the Red and Green to the Bottom and Left zones respectively.<br />
Check the "Paint Reflection" check box if you want to display the axis reflection.<br />
The "Begin Angle" combo allows you to control the orientation of the polar.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->