<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAxisTicksUC" CodeFile="NAxisTicksUC.ascx.cs" %>
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
        <asp:CheckBox id="ShowOuterMajorTicksCheckBox" runat="server" Text="Show Major Outer Ticks" AutoPostBack="True" oncheckedchanged="ShowOuterMajorTicksCheckBox_CheckedChanged"></asp:CheckBox>
        <br />
        <asp:Label id="Label1" runat="server">Tick Length:</asp:Label>
        <asp:DropDownList id="OuterMajorTickLengthDropDownList" Width="48px" runat="server" AutoPostBack="True" onselectedindexchanged="OuterMajorTickLengthDropDownList_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />                
        <asp:CheckBox id="ShowInnerMajorTicksCheckBox" runat="server" Text="Show Major Inner Ticks" AutoPostBack="True" oncheckedchanged="ShowInnerMajorTicksCheckBox_CheckedChanged"></asp:CheckBox>
        <br />
        <asp:Label id="Label2" runat="server">Tick Length:</asp:Label>
        <asp:DropDownList id="InnerMajorTickLengthDropDownList" Width="48px" runat="server" AutoPostBack="True" onselectedindexchanged="InnerMajorTickLengthDropDownList_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShowOuterMinorTicksCheckBox" runat="server" Text="Show Minor Outer Ticks" AutoPostBack="True" oncheckedchanged="ShowOuterMinorTicksCheckBox_CheckedChanged"></asp:CheckBox>
        <br />
        <asp:Label id="Label3" runat="server">Tick Length:</asp:Label>
        <asp:DropDownList id="OuterMinorTickLengthDropDownList" Width="48px" runat="server" AutoPostBack="True" onselectedindexchanged="OuterMinorTickLengthDropDownList_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShowInnerMinorTicksCheckBox" runat="server" Text="Show Minor Inner Ticks" AutoPostBack="True" oncheckedchanged="ShowInnerMinorTicksCheckBox_CheckedChanged"></asp:CheckBox>
        <br />
        <asp:Label id="Label4" runat="server">TickLabel</asp:Label>
        <asp:DropDownList id="InnerMinorTickLengthDropDownList" Width="48px" runat="server" AutoPostBack="True" onselectedindexchanged="InnerMinorTickLengthDropDownList_SelectedIndexChanged"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td1" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
        This example demonstraets the appearance features of the axis tick marks.
        <br />
        Show Ticks check - controls the visibility of the ticks.
        <br />
        Tick Length scroller - controls the length of the ticks.
        <br />
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->