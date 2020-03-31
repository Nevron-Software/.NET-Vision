<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NXYZScatterPointClusterUC" CodeFile="NXYZScatterPointClusterUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Cluster Mode:</asp:Label>
        <br />
        <asp:DropDownList id="ClusterModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
		<asp:Label id="Label2" runat="server">Cluster Distance Factor:</asp:Label>
        <br />
        <asp:DropDownList id="ClusterDistanceFactorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
		<asp:Label id="Label3" runat="server">Number of Point Groups:</asp:Label>
        <br />
        <asp:DropDownList id="NumberOfPointGroupsDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label4" runat="server">Number of Points in Group:</asp:Label>
        <br />
        <asp:DropDownList id="NumberOfPointsInGroupDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
		<br />
		<asp:Label id="NumberOfDataPointsLabel" runat="server">Number of Data Points:</asp:Label>
        <br />
        <br />
        <asp:Button id="ChangeDataButton" runat="server" Text="Generate Data"></asp:Button>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		The example demonstrates the ability of the point series to build and render a 2D scatter point cluster. Clustering allows you to visualize massive amounts of data by identifying densly populated regions of data. On the right you can control varios cluster parameters.<br/><br/>
		The Cluster Mode combo allows you to enable/disable clustering.<br/><br/>
		The Distance Factor allows you to control the precision of the cluster. Lower values will result in greater precision at the cost of more points being plotted.<br/><br/>
		The "Number Of Point Groups" and "Number of Points Per Group" allow you to generate data sets with different number of randomly populated groups of points.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
