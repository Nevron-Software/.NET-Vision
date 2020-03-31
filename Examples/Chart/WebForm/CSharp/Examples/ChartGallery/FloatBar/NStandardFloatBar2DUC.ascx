<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStandardFloatBar2DUC" CodeFile="NStandardFloatBar2DUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Bar Shape:</asp:Label>
        <br />
        <asp:DropDownList id="BarShapeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Width %:</asp:Label>
        <br />
        <asp:DropDownList id="WidthPercentDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="DifferentColorsCheckBox" runat="server" AutoPostBack="True" Text="Different colors"></asp:CheckBox>
        <br />
        <br />
        <asp:Label id="Label5" runat="server">Bar color:</asp:Label>
        <br />
        <asp:DropDownList id="BarColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShadowsCheckBox" Width="118px" runat="server" AutoPostBack="True" Text="Shadows"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates a standard Float Bar chart.<br />
        You can change the shape of the bars from the Bar Shape combo box.<br />
        The width of the bars is set in percents of the floor grid cell 
        width from the Width % combo.<br />
        You can control the depth of the bars in percents of the floor grid cell 
        depth from the Depth % combo.<br />
        When you check the Different Colors check the bars will be displayed in 
        different programmer specified colors.<br />
        Otherwise the color of the bars can be controlled from the Bar Color combo.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
