<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStandard2DHighLowUC" CodeFile="NStandard2DHighLowUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">High area color:</asp:Label>
        <br />
        <asp:DropDownList id="HighAreaColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Low area color:</asp:Label>
        <br />
        <asp:DropDownList id="LowAreaColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShowDataLabelsCheckBox" runat="server" AutoPostBack="True" Text="Show data labels"></asp:CheckBox>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Data label format:</asp:Label>
        <br />
        <asp:DropDownList id="DataLabelFormatDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="ShowDropLinesCheckBox" runat="server" AutoPostBack="True" Text="Show drop lines"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="ShowMarkersCheckBox" runat="server" AutoPostBack="True" Text="Show markers"></asp:CheckBox>
        <br />
        <br />
        <asp:Label id="Label5" runat="server">Marker Shape:</asp:Label>
        <br />
        <asp:DropDownList id="MarkerShapeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label6" runat="server">Marker size:</asp:Label>
        <br />
        <asp:DropDownList id="MarkerSizeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates a standard high low chart.<br />
	    High Area Color combo- changes the color of the high areas.<br />
	    Low Area Color combo- changes the color of the low areas.<br />
	    Drop Lines check - controls the visibility of the area drop lines between the 
	    area segments.<br />
	    Show Data Labels - controls the visibility of the data point labels.<br />
	    Data Label Format combo - controls the information displayed in the data point 
	    labels.<br />
	    Show markers check - controls the visibility of the data point markers.<br />
	    Marker Shape combo - changes the shape of the data point markers.<br />
	    Marker Size combo - controls the width and height of the data point markers.<br />	    
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
