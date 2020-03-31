<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NPointDropLines2DUC" CodeFile="NPointDropLinesUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Point Shape:</asp:Label>
        <br />
        <asp:CheckBox id="Enable3DCheckBox" runat="server" Text="Enable 3D" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="ShowVerticalDropLinesCheckBox" runat="server" Text="Show Vertical Droplines" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="ShowHorizontalDropLinesCheckBox" runat="server" Text="Show Horizontal Droplines" AutoPostBack="True"></asp:CheckBox>
        <br />
        
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		Demonstrates the ability of the point series to display horizontal, vertical and depth drop lines.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->