<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NSampledLine3DUC" CodeFile="NSampledLine3DUC.ascx.cs" %>
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
		<asp:Label id="Label1" runat="server">Sample Distance (in pixels):</asp:Label>
        <br />
        <asp:DropDownList id="SampleDistanceDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Number of Turns:</asp:Label>
        <br />
        <asp:DropDownList id="NumberOfTurnsDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
		<asp:Label id="Label3" runat="server">Number of Points in Turn:</asp:Label>
        <br />
        <asp:DropDownList id="NumberOfPointsInTurnDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
		<asp:Label id="NumberOfDataPointsLabel" runat="server">Number Of Data Points:</asp:Label>
        <br />
        <br />
        <asp:Button id="ChangeDataButton" runat="server" Text="Generate Data"></asp:Button>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
This example demonstrates how to enable sampling for the line series.<br /><br />
When using sampling the line will ignore settings for markers and data labels and will also automatically resample the data storage depending on the 
size of the chart on the screen. This allows for the visualization of massive amount of data.<br /><br />
The sample distance combo on the right allows you to modify the sampling distance.<br/><br />
The "Use X Values" check box controls whether the area will use the custom generated X values or use categorical numbers (increasing by one).<br /><br />
The "Number of Turns" and "Number of Points In Turn" control how the sample data set is generated.<br /><br />
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
