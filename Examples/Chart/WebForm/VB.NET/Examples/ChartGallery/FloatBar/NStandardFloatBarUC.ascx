<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStandardFloatBarUC" CodeFile="NStandardFloatBarUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Bar Shape:</asp:Label>
		<br />
		<asp:DropDownList id="BarShapeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Width %:</asp:Label>
		<br />
		<asp:DropDownList id="WidthPercentDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Depth %:</asp:Label>
		<br />
		<asp:DropDownList id="DepthPercentDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates a standard Float Bar chart.<br />
		From the Bar Shape combo box you can control the shape of the bars.<br />
		The user controls the width of the bars in percents of the floor grid cell 
		width from the Width % combo.<br />
		The user controls the depth of the bars in percents of the floor grid cell 
		depth from the Depth % combo.<br />
		When you check the Different Colors check the bars will be displayed in 
		different programmer specified colors.<br />
		Otherwise the color of the bars can be controlled from the Bar Color combo.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
