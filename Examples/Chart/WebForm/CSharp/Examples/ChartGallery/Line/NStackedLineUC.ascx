<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStackedLineUC" CodeFile="NStackedLineUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">First line data labels:</asp:Label>
        <br />
        <asp:DropDownList id="FirstLineLabelsDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Second Line Data Labels:</asp:Label>
        <br />
        <asp:DropDownList id="SecondLineLabelsDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Third Line Data Labels:</asp:Label>
        <br />
        <asp:DropDownList id="ThirdLineLabelsDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" runat="server">Stack style:</asp:Label>
        <br />
        <asp:DropDownList id="StackStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates stacked line series. The first series MultiLineMode is set to 
        Series, while the second and third line series are displayed with MultiBarMode 
        set to Stacked or StackedPercent.<br />
        Two types of stacking are supported – Stacked and Stacked Percent. The first 
        type simply piles the lines on top of each other. The stacked percent style 
        displays the contribution of each individual stack to the overall pile sum.<br />
        You can change the stacking style from the Stack Style combo.<br />
        From the Data Labels combo boxes you can control the information displayed on 
        the stack lines data labels.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->