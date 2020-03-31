<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NXYZScatterPointUC" CodeFile="NXYZScatterPointUC.ascx.cs" %>
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
        <asp:CheckBox id="AxesRoundToTickCheckBox" runat="server" Checked="True" Text="Axes round to tick"
        AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="InflateMarginsCheckBox" runat="server" Checked="True" Text="Inflate margins"
        AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:Button id="ChangeDataButton" runat="server" Text="Change data"></asp:Button>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		XYZ Scatter point charts are created when the user instructs the point series 
        to use custom x and z values for the data point x and z coordinates. Note that 
        in this case the Bottom and Depth axes are switched in numeric scale mode.<br />
        The Change Data button changes the X and Z values of the point series.<br />
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
