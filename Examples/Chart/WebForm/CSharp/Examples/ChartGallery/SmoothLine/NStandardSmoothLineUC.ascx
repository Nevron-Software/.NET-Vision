<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStandardSmoothLineUC" CodeFile="NStandardSmoothLineUC.ascx.cs" %>
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
        <asp:Button id="ChangeDataButton" Height="24" Width="177" runat="server" Text="Change Data"></asp:Button>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Line Width:</asp:Label>
        <br />
        <asp:DropDownList id="LineWidthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" runat="server">Line Color:</asp:Label>
        <br />
        <asp:DropDownList id="LineColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShowMarkersCheckBox" runat="server" Text="Show markers" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:Label id="Label6" runat="server">Marker Shape:</asp:Label>
        <br />
        <asp:DropDownList id="MarkerShapeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label7" runat="server">Marker Size:</asp:Label>
        <br />
        <asp:DropDownList id="MarkerSizeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="InflateMarginsCheckBox" runat="server" Text="Inflate margins" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="LeftAxisRoundToTickCheckBox" runat="server" Text="Left axis round to tick" AutoPostBack="True"></asp:CheckBox>		
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        This example demonstrates a 2D Smooth Line chart. Use the controls to change the 
        stroke style, shadow style, marker style etc. 	
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->