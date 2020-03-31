<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NRadarLineUC" CodeFile="NRadarLineUC.ascx.vb" %>
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
		<asp:CheckBox id="ShowDataLabelsCheckBox" runat="server" AutoPostBack="True" Text="Show data labels"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="ShowMarkersCheckBox" runat="server" AutoPostBack="True" Text="Show markers"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label7" runat="server">Marker Shape:</asp:Label>
		<br />
		<asp:DropDownList id="MarkerShapeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Radar 1 Color:</asp:Label>
		<br />
		<asp:DropDownList id="RadarAreaColor1DropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Radar 2 Color:</asp:Label>
		<br />
		<asp:DropDownList id="RadarAreaColor2DropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates the Radar Line series.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->