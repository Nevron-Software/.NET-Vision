<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStandardPointUC" CodeFile="NStandardPointUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Point Shape:</asp:Label>
        <br />
        <asp:DropDownList id="PointShapeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Point size:</asp:Label>
        <br />
        <asp:DropDownList id="PointSizeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="InflateMarginsCheckBox" runat="server" Text="Inflate margins" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="LeftAxisRoundToTickCheckBox" runat="server" Text="Left axis round to tick" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="DifferentColorsCheckBox" runat="server" Text="Different colors" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Point color:</asp:Label>
        <br />
        <asp:DropDownList id="PointColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShowDataLabelsCheckBox" runat="server" Text="Show data labels" AutoPostBack="True"></asp:CheckBox>
        <br />
        <br />
        <asp:Label id="Label4" runat="server">Data label format:</asp:Label>
        <br />
        <asp:DropDownList id="DataLabelFormatDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates a standard point chart.<br />
        You can control the shape of the points from the Point Shape combo box.<br />
        The Point Size combo controls the size of the points.<br />
        When you check the Inflate Margins check the axis scales are adjusted to fit 
        the entire point series in the chart area.<br />
        The Left Axis Round To Tick check controls whether the left axis scale min and 
        max values should be adjusted to end on exact tick marks.<br />
        If you check the Different Colors check the points will be displayed in 
        different programmer specified colors. If this check is not checked the can 
        control the color of the points from the Point Color… button.<br />
        The Show Data Labels check controls the visibility of the point data labels.<br />
        From the Data Label Format combo the user can control the information displayed 
        in the data point labels.		
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->