<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NMarkersUC" CodeFile="NMarkersUC.ascx.vb" %>
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
		<asp:CheckBox id="MarkersVisibleCheckBox" runat="server" AutoPostBack="True" Text="Visible"></asp:CheckBox>
		<br />
		<asp:Label id="Label1" runat="server">Width:</asp:Label>
		<br />
		<asp:DropDownList id="WidthDropDownList" Height="22" Width="103" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Height:</asp:Label>
		<br />
		<asp:DropDownList id="HeightDropDownList" Height="22" Width="103" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="AutoDepthCheckBox" runat="server" AutoPostBack="True" Text="Auto depth"></asp:CheckBox>
		<br />
		<asp:Label id="Label3" runat="server">Depth:</asp:Label>
		<br />
		<asp:DropDownList id="DepthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Line depth %:</asp:Label>
		<br />
		<asp:DropDownList id="LineDepthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label5" runat="server">Marker Shape:</asp:Label>
		<br />
		<asp:DropDownList id="MarkerShapeDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label6" runat="server">Marker Color:</asp:Label>
		<br />
		<asp:DropDownList id="MarkerColorDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label7" runat="server">Marker 3 Shape:</asp:Label>
		<br />
		<asp:DropDownList id="Marker3ShapeDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label8" runat="server">Marker 3 Color:</asp:Label>
		<br />
		<asp:DropDownList id="Marker3ColorDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example shows how to apply individual marker styles to data points. You can choose to 
		edit either the default marker style of each series or the individual marker style for a 
		specific data point.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->