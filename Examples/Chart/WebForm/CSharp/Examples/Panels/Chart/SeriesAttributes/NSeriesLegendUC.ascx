<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NSeriesLegendUC" CodeFile="NSeriesLegendUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Legend mode:</asp:Label>
        <br />
        <asp:DropDownList id="ModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Format:</asp:Label>
        <br />
        <asp:DropDownList id="FormatDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Point Shape:</asp:Label>
        <br />
        <asp:DropDownList id="PointShapeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="DifferentColorsCheckBox" runat="server" AutoPostBack="True" Text="Different colors"></asp:CheckBox>
        <br />
        <asp:Label id="Label4" runat="server">Color:</asp:Label>
        <br />
        <asp:DropDownList id="ColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Each series displayed in the chart can add some series information in the 
        legend.<br />
        The series can add information in the several modes:<br />
        Disabled – no information will be added to the legend for this series.<br />
        Series – only one legend item will be added. The legend mark will be painted 
        with the series defined fill effect.<br />
        DataPoints – the series will insert as many legend items as there are data 
        points in the series. The legend mark will be painted with the fill effect of 
        the respective data point.<br />
        SeriesCustom – custom information about the series will be inserted in the 
        legend item collection.<br />
        Format combo - controls the legend label information when the Mode combo is set 
        to Data Points.<br />
        Point Shape combo – controls the shape of the points.<br />
        Different Colors check – when checked all points will be displayed in different 
        colors. Otherwise the user can control the point color from the Point Color… 
        button.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->