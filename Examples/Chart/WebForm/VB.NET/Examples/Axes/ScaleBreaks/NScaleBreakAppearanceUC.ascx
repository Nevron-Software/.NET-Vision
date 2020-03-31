<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NScaleBreakAppearanceUC" CodeFile="NScaleBreakAppearanceUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Style:</asp:Label>
		<br />
		<asp:DropDownList id="styleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label6" runat="server">Pattern:</asp:Label>
		<br />
		<asp:DropDownList id="patternDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList><br />
		<br />
		<asp:Label id="Label5" runat="server">Horz Step:</asp:Label> 
		<br />
		<asp:TextBox ID="horzStepTextBox" runat="server" Width="62px"></asp:TextBox><br />
		<br />
		<asp:Label id="Label2" runat="server">Vert Step:</asp:Label> 
		<br />
		<asp:TextBox ID="vertStepTextBox" runat="server" Width="62px"></asp:TextBox><br />
		<br />
		<asp:Label id="Label3" runat="server">Length:</asp:Label> 
		<br />
		<asp:TextBox ID="lengthTextBox" runat="server" Width="62px"></asp:TextBox><br />
		<hr />
		<asp:Button ID="updateButton" runat="server" Text="Update" /> 
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example shows how to modify the appearance (style) of scale breaks.
		<br />
		When you choose Line scale break style you can control the scale break length in points on the Y primary axis.
		<br />
		When you choose Wave or Zig Zag you can additionally control the wave/zigzag pattern and the horizontal 
		and vertical pattern steps.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->