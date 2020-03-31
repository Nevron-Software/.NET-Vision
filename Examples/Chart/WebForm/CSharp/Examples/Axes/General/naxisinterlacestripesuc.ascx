<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAxisInterlaceStripesUC" CodeFile="NAxisinterlaceStripesUC.ascx.cs" %>
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
        <br />
            <asp:CheckBox id="YAxisInterlacedStripesCheckBox" runat="server" AutoPostBack="True" Text="Enable Vertical Interlacing">
            </asp:CheckBox>
        <br />
            <asp:CheckBox id="XAxisInterlacedStripesCheckBox" runat="server" AutoPostBack="True" Text="Enable Horizontal Interlacing">
            </asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
        The example demonstrates how to add interlace stripes synchronized with the major ticks generated 
    	of the axes. This is the default mode of the interlace stripes. You can enable or disable the appearance 
        of the stripes from the check boxes on the right side of the example.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->



