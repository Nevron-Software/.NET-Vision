<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NSimpleFlash2DUC" CodeFile="NAnimationThemes2UC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Animation Theme Type:</asp:Label>
        <br />
        <asp:DropDownList id="AnimationThemeTypeCombo" Height="22" Width="179" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Animation Duration (seconds):</asp:Label>
        <br />
        <asp:Label id="Label4" Width="60" runat="server">Axes:</asp:Label>
        <asp:DropDownList id="AxesAnimationDurationCombo" Height="22" Width="115" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <asp:Label id="Label5" Width="60" runat="server">Indicators:</asp:Label>
        <asp:DropDownList id="IndicatorsAnimationDurationCombo" Height="22" Width="115" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label9" runat="server">Animation Sequence:</asp:Label>
		<br />
        <asp:CheckBox id="SequentialPanels" runat="server" AutoPostBack="True" Text="Sequential Panels"></asp:CheckBox>
        <br />
        <asp:CheckBox id="SequentialGauges" runat="server" AutoPostBack="True" Text="Sequential Gauges"></asp:CheckBox>
        <br />
        <asp:CheckBox id="SequentialIndicators" runat="server" AutoPostBack="True" Text="Sequential Indicators"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
	    The example demonstrate how to generate animated gauges in Flash.<br />
	    The Animation Theme Type combo allows you to select the type of animation effect to be applied on different gauge elements.<br/>
	    The Animation Duration group of controls allows you modify the duration of animations applied on different gauge elements.<br/>
	    The Animation Sequence group of controls allows to change the sequence of animations from simulataneous to sequential.<br/>
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
