<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NClusterBarUC" CodeFile="NClusterBarUC.ascx.cs" %>
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
        <asp:Button id="PositiveAndNegativeDataButton" runat="server" Width="174px" Text="Positive and negative data" onclick="PositiveAndNegativeDataButton_Click"></asp:Button>
        <br />
        <br />
        <asp:Button id="PositiveDataButton" runat="server" Width="173px" Text="Positive data" onclick="PositiveDataButton_Click"></asp:Button>
        <br />
        <br />
        <asp:CheckBox id="ScaleSecondaryClusterCheckBox" runat="server" Width="193px" Text="Scale the secondary cluster on the Secondary Y axis" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Width percent:</asp:Label>
        <br />
        <asp:DropDownList id="WidthPercentDropDownList" runat="server" Width="100px" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label1" runat="server">Gap percent:</asp:Label>
        <br />
        <asp:DropDownList id="GapPercentDropDownList" runat="server" Width="100px" AutoPostBack="True"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates a clustered bar.<br />
        Gap Percent combo - controls the distance between the clusters in percents of 
        the floor grid cell width.<br />
        Postive Data button - fills the bars value series with random positive values.<br />
        Postive and Negative Data button - fills the bars value series with random 
        positive and negative values.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
