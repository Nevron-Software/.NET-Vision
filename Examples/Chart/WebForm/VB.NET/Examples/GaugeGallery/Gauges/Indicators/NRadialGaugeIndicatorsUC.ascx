<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NRadialGaugeIndicatorsUC" CodeFile="NRadialGaugeIndicatorsUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Value Indicator</asp:Label>
		<br/>
		<asp:Label id="Label2" runat="server">Value:</asp:Label>
		<br/>
		<asp:DropDownList id="ValueIndicatorDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label3" runat="server">Shape:</asp:Label>
		<br/>
		<asp:DropDownList id="ValueIndicatorShapeDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br/>
		<br/>
		<asp:Label id="Label4" runat="server">Range Indicator</asp:Label>
		<br/>
		<asp:Label id="Label5" runat="server">Value:</asp:Label>
		<br/>
		<asp:DropDownList id="RangeIndicatorValueDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br/>
		<asp:Label id="Label6" runat="server">Origin Mode:</asp:Label>
		<br/>
		<asp:DropDownList id="RangeIndicatorOriginModeDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br/>
		<asp:Label id="Label7" runat="server">Origin:</asp:Label>
		<br/>
		<asp:DropDownList id="RangeIndicatorOriginDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br/>
		<br/>
		<asp:Label id="Label8" runat="server">Begin Angle:</asp:Label>
		<br/>
		<asp:DropDownList id="BeginAngleDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br/>
		<asp:Label id="Label9" runat="server">Sweep Angle:</asp:Label>
		<br/>
		<asp:DropDownList id="SweepAngleDropDownList" Width="136px" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates the functionality of the NRadialGaugePanel.<br />
		Use the Begin and Sweep angle to tilt and sweep the gauge and its axis and 
		indicators.
		<br/>
		You can also modify the parameters of the range and needle indicators.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
