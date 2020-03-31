<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NXYZErrorBarUC" CodeFile="NXYZErrorBarUC.ascx.cs" %>
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
        <asp:CheckBox id="ShowUpperYErrorCheck" runat="server" AutoPostBack="True" Text="Show Upper Y Error"></asp:CheckBox>
        <br />
        <asp:CheckBox id="ShowLowerYErrorCheck" runat="server" AutoPostBack="True" Text="Show Lower Y Error"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="ShowUpperXErrorCheck" runat="server" AutoPostBack="True" Text="Show Upper X Error"></asp:CheckBox>
        <br />
        <asp:CheckBox id="ShowLowerXErrorCheck" runat="server" AutoPostBack="True" Text="Show Lower X Error"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="ShowUpperZErrorCheck" runat="server" AutoPostBack="True" Text="Show Upper Z Error"></asp:CheckBox>
        <br />
        <asp:CheckBox id="ShowLowerZErrorCheck" runat="server" AutoPostBack="True" Text="Show Lower Z Error"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="InflateMarginsCheck" runat="server" AutoPostBack="True" Text="Inflate Margins"></asp:CheckBox>
        <br />
        <asp:CheckBox id="RoundToTickCheck" runat="server" AutoPostBack="True" Text="Round to Tick" Checked="True"></asp:CheckBox>
        <br />
        <br />
        <asp:Button id="ChangeDataButton" runat="server" Text="Change Data"></asp:Button>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        This example demonstrates a 3D step line chart.<br />
        You can change the style of the line from the Line Style combo. The "Line Depth 
        %" scroller controls the size of the Tape lines. The "Line Size" scroller 
        controls the size of the Tube and Ellipsoid lines.<br />
        <br />
        When you check the Inflate Margins check the axis scales are adjusted to fit 
        the entire chart including the series markers.<br />
        <br />
        The Left Axis Round to tick check controls whether the left axis should 
        automatically round its min and max values to end on exact ticks.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->