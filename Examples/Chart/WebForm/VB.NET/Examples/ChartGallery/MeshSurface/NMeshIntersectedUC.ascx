<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NMeshIntersectedUC" CodeFile="NMeshIntersectedUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NThinChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
		</ncwc:NThinChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<br />
		<asp:CheckBox id="Surface1ShowFrameCheckBox" runat="server" Checked="True" AutoPostBack="True"
		Text="Surface 1 Show Frame"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="Surface1SmoothPaletteCheckBox" runat="server" Checked="True" AutoPostBack="True"
		Text="Surface 1 Smooth Palette"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="Surface2ShowFrameCheckBox" runat="server" Checked="True" AutoPostBack="True"
		Text="Surface 2 Show Frame"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="Surface2SmoothPaletteCheckBox" runat="server" Checked="True" AutoPostBack="True"
		Text="Surface 2 Smooth Palette"></asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Fill Transparency:</asp:Label>
		<br />
		<asp:DropDownList id="TransparencyDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates rendering of intersecting surfaces with proper z-order. 
		UNIQUE FEATURE!
		<br />
		<br />
		Use the Rotation and Elevation edit controls to change the surface view.        
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
