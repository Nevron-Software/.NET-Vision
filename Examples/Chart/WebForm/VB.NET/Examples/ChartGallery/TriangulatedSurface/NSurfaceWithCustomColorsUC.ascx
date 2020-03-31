<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NSurfaceWithCustomColorsUC" CodeFile="NSurfaceWithCustomColorsUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Surface Filling</asp:Label>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Fill Mode:</asp:Label>
		<br />
		<asp:DropDownList id="fillModeDropDownList" runat="server" Width="128px" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="smoothShadingCheck" runat="server" Text="Smooth Shading" AutoPostBack="True"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Surface Frame</asp:Label>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Frame Mode:</asp:Label>
		<br />
		<asp:DropDownList id="frameModeDropDownList" runat="server" Width="128px" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label5" runat="server">Frame Color Mode:</asp:Label>
		<br />
		<asp:DropDownList id="frameColorModeDropDownList" runat="server" Width="128px" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The Triangulated Surface allows you to assign a custom color for each data point. Custom Colors 
		can be used both for the surface filling and frame. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
