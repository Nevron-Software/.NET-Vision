<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NGridEmptyDataPointsUC" CodeFile="NGridEmptyDataPointsUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Rotation:</asp:Label>
        <br />
        <asp:TextBox id="RotationTextBox" Width="84px" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Elevation:</asp:Label>
        <br />
        <asp:TextBox id="ElevationTextBox" Width="84px" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button id="UpdateButton" runat="server" Text="Update"></asp:Button>
        <br />
        <asp:CheckBox id="smoothShadingCheck" runat="server" Text="Smooth Shading" AutoPostBack="True"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates the support for the 'Empty Data Points' feature.
        <br />
        <br />
        Use the Rotation and Elevation edit controls you to change the surface view.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->