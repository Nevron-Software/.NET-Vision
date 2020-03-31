<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NSortedPieUC" CodeFile="NSortedPieUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Sort:</asp:Label>
        <br />
        <asp:DropDownList id="SortDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Button id="ChangeDataButton" runat="server" Text="Change data"></asp:Button>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Sorted Pie.<br />
        This example uses the built-in data series sorting functionality to implement 
        Ascending and Descending sorting of the pie segments. See the Data Manipulation 
        topics in the Users Guide for more information.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
