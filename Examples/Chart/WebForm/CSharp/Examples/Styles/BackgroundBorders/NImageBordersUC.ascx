<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NImageBordersUC" CodeFile="NImageBordersUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server" Height="22px" Width="211px">Image border:</asp:Label>
        <br />
        <asp:DropDownList id="ImageBorderDropDownList" runat="server" Height="22" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server" Height="22px" Width="211px">Filling color:</asp:Label>
        <br />
        <asp:DropDownList id="FillingColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" runat="server" Height="22px" Width="211px">Border color:</asp:Label>
        <br />
        <asp:DropDownList id="BorderColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label3" runat="server" Height="22px" Width="211px">Page background color:</asp:Label>
        <br />
        <asp:DropDownList id="PageBackgroundColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="HasShadowCheckBox" runat="server" AutoPostBack="True" Text="Has ShadowStyle"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates the built-in Image (artistic) borders of the component. Image 
        borders can come handy when you have to build presentation quality charts or 
        you simply want to achieve better integration with your website design.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
