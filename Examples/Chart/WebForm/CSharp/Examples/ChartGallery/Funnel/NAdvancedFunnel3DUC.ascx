<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAdvancedFunnel3DUC" CodeFile="NAdvancedFunnel3DUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Funnel Radius:</asp:Label>
        <br />
        <asp:DropDownList id="FunnelRadiusDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Funnel Point Gap:</asp:Label>
        <br />
        <asp:DropDownList id="FunnelPointGapDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Funnel Label Mode:</asp:Label>
        <br />
        <asp:DropDownList id="FunnelLabelModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" runat="server">Label Arrow Length:</asp:Label>
        <br />
        <asp:DropDownList id="FunnelArrowLengthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        This example demonstrates a 3D Funnel Chart with custom X sizes of the funnel 
        data items. Use the controls to modify the funnel radius and gap size. You can 
        also change the placement of the funnel data point labels.					
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
