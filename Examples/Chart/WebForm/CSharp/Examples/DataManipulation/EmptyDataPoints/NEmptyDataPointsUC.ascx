<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NEmptyDataPointsUC" CodeFile="NEmptyDataPointsUC.ascx.cs" %>
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
        <asp:Label id="Label1" Height="19" Width="198" runat="server">Chart Type:</asp:Label>
        <br />
        <asp:DropDownList id="ChartTypeDropDownList" Height="19" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" Height="19px" Width="198px" runat="server">Empty Data Points Value Mode:</asp:Label>
        <br />
        <asp:DropDownList id="EmptyDataPointsValueModeDropDownList" Height="19px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label3" Height="19" Width="198" runat="server">Empty Data Points Appearance:</asp:Label>
        <br />
        <asp:DropDownList id="EmptyDataPointsAppearanceDropDownList" Height="19px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" Height="19" Width="198" runat="server">Empty Data Points Fill Color:</asp:Label>
        <br />
        <asp:DropDownList id="EmptyDataPointsColorDropDownList" Height="19px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShowMarkersCheckBox" runat="server" AutoPostBack="True" Text="Show Markers"
        Checked="True"></asp:CheckBox>
        <br />
        <asp:Label id="Label5" Height="19" Width="198" runat="server">Empty Data Points Marker Mode:</asp:Label>
        <br />
        <asp:DropDownList id="EmptyDataPointsMarkerModeDropDown" Height="19px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label6" Height="19px" Width="198px" runat="server">Marker Shape:</asp:Label>
        <br />
        <asp:DropDownList id="MarkerShapeDropDownList" Height="19px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label7" Height="19px" Width="198px" runat="server">Marker Color:</asp:Label>
        <br />
        <asp:DropDownList id="MarkerColorDropDownList" Height="19px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Nevron Chart for .NET supports empty data points. A data point is considered 
        empty if one of its values is set to DBNull.<br />
        <br />
        The user has control over two aspects of empty data points - their value and 
        their appearance.<br />
        <br />
        If the value mode is set to Skip and a data point is empty it is not rendered 
        and does not appear in the legend.<br />
        <br />
        If the value mode is set to Average the value of the empty data point is 
        calculated as the average of the valid previous and next values.<br />
        <br />
        If the value mode is set to CustomValue the value of the empty data point is an 
        user defined value - in this example 0.<br />
        <br />
        Empty data points can be displayed with markers or with regular data point 
        appearance (as a normal data point) or custom data appearance (user defined 
        appearance).
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
