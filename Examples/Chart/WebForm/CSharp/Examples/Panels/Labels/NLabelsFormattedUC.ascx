<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NLabelsFormattedUC" CodeFile="NLabelsFormattedUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server" Width="168px">Sample formatted label:</asp:Label>
        <br />
        <asp:DropDownList id="SampleFormattedLabelDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label6" runat="server">Font:</asp:Label>
        <br />
        <asp:DropDownList id="FontDropDownList" runat="server" Height="22px" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label7" runat="server">Font size:</asp:Label>
        <br />
        <asp:DropDownList id="FontSizeDropDownList" runat="server" Height="22px" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label8" runat="server">Font color:</asp:Label>
        <br />
        <asp:DropDownList id="FontColorDropDownList" runat="server" Height="22px" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="HasBackplaneCheckBox" runat="server" AutoPostBack="True" Text="Has BackplaneStyle"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        The example demonstrates how to use XML formatted texts for labels. XML 
        formatted texts are similar to HTML formatting, but with some advanced features 
        like text border, fill style and image filters.<br />Use the load sample text 
        combo on the right side to load a predefined XML formatted text showing how to 
        use a particular feature.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
