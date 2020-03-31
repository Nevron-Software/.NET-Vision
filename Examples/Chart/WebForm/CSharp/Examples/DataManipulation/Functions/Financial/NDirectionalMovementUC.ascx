<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NDirectionalMovementUC" CodeFile="NDirectionalMovementUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Period:</asp:Label>
        <br />
        <asp:DropDownList id="PeriodDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShowPosDICheckBox" runat="server" AutoPostBack="True" Checked="True" Text="Show +DI"></asp:CheckBox>
        <br />
        <asp:TextBox id="PosDITextBox" runat="server" Width="195px" ReadOnly="True" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox id="ShowNegDICheckBox" runat="server" AutoPostBack="True" Checked="True" Text="Show -DI"></asp:CheckBox>
        <br />
        <asp:TextBox id="NegDITextBox" runat="server" Width="195px" ReadOnly="True" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox id="ShowADXCheckBox" runat="server" AutoPostBack="True" Checked="True" Text="Show ADX"></asp:CheckBox>
        <br />
        <asp:TextBox id="ADXTextBox" runat="server" Width="195px" ReadOnly="True" Enabled="False"></asp:TextBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        The Directional Movement System consists of three lines:<br />
        <br />
        The Positive Direction Indicator (+DI) summarizes upward trend movement<br />
        The Negative Direction Indicator (-DI) summarizes downward trend movement<br />
        The Average Directional Movement Index (ADX) indicates whether the market is 
        trending or ranging.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
