<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAxisGridlinesUC" CodeFile="NAxisGridlinesUC.ascx.cs" %>
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
        <asp:Label id="Label5" runat="server" Font-Bold="True">Left axis major gridlines</asp:Label>
        <br />
        <br />
        <asp:CheckBox id="MajorGridLineAtLeftWallCheckBox" runat="server" Text="Show at left wall" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="MajorGridLineAtBackWallCheckBox" runat="server" Text="Show at back wall" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:Label id="Label1" runat="server">Color:</asp:Label>
        <br />
        <asp:DropDownList id="MajorGridLineColorDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Style:</asp:Label>
        <br />
        <asp:DropDownList id="MajorGridLineStyleDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label6" runat="server" Font-Bold="True">Left axis minor gridlines</asp:Label>
        <br />
        <br />
        <asp:CheckBox id="MinorGridLineAtLeftWallCheckBox" runat="server" Text="Show at left wall" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:CheckBox id="MinorGridLineAtBackwallCheckBox" runat="server" Text="Show at back wall" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Color:</asp:Label>
        <br />
        <asp:DropDownList id="MinorGridLineColorDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" runat="server">Style:</asp:Label>
        <br />
        <asp:DropDownList id="MinorGridLineStyleDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
        Demonstrates the user control over the axis gridlines. Major gridlines are 
        displayed at axis major tick marks values. Minor gridlines are displayed at 
        axis minor tick marks values.<br />
        <br />
        The gridlines can be displayed on several visible chart walls. In this example 
        the user can show the gridlines of the left axis on the left and back chart 
        walls. The gridlines of the Bottom axis can be displayed on the bottom and back 
        walls, while the gridlines of the Depth axis can be displayed on the floor and 
        left walls.<br />
        <br />
        The example demonstrates left axis minor gridlines displayed on the left and 
        (or) back chart walls.<br />
        <br />
        The user can control the color and style of the gridlines.<br />
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
