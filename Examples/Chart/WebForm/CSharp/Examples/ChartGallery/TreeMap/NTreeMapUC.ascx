<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NTreeMapUC.ascx.cs" Inherits="Nevron.Examples.Chart.WebForm.NThreeMapUC" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
        <ncwc:NThinChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
        </ncwc:NThinChartControl>
        <!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
        <asp:label id="Label1" runat="server">Vertical Fill Mode:</asp:label>
        <br />
        <asp:dropdownlist id="VerticalFillModeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:label id="Label2" runat="server">Horizontal Fill Mode:</asp:label>
        <br />
        <asp:dropdownlist id="HorizontalFillModeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:label id="Label4" runat="server">Color Mode:</asp:label>
        <br />
        <asp:dropdownlist id="ColorModeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		Treemaps display hierarchical (tree-structured) data as a set of nested rectangles. Each branch of the tree is represented by NTreeMapGroupNode object which is 
		given a rectangle proportional to the aggregate value of its sub nodes. A leaf node's rectangle has an area proportional to its value compared to the total area of all leaf nodes.<br />
		Leaf nodes can be colored using a palette or have their own custom colors.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
