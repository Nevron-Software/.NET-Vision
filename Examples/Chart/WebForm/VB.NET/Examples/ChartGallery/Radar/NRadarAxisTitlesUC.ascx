<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NRadarAxisTitlesUC" CodeFile="NRadarAxisTitlesUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Title Offset:</asp:Label>
		<br />
		<asp:DropDownList id="TitleOffsetDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Title Angle Mode:</asp:Label>
		<br />
		<asp:DropDownList id="TitleAngleModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label3" runat="server">Title Angle:</asp:Label>
		<br />
		<asp:DropDownList id="TitleAngleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Title Position Mode:</asp:Label>
		<br />
		<asp:DropDownList id="TitlePositionModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label5" runat="server">Title Fit Mode:</asp:Label>
		<br />
		<br />
		<asp:DropDownList id="TitleFitModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label6" runat="server">Title Max Width:</asp:Label>
		<br />
		<asp:DropDownList id="TitleMaxWidthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="TitleAutomaticAlignmentCheck" runat="server" AutoPostBack="True" Text="Automatic Alignment"></asp:CheckBox>
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates various radar axis title features like the ability to position the radar titles close to the radar rim, specify angle, max width etc.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
