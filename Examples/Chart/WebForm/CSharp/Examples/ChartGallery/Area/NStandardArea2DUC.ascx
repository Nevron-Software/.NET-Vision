<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStandardArea2DUC" CodeFile="NStandardArea2DUC.ascx.cs" %>
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
        <asp:checkbox id="ShowDataLabelsCheckBox" runat="server" AutoPostBack="True" Text="Show Data Labels"></asp:checkbox>
        <br />
        <br />
        <asp:checkbox id="ShowMarkersCheckBox" runat="server" AutoPostBack="True" Text="Show Markers"></asp:checkbox>
        <br />
        <br />
        <asp:label id="Label3" runat="server">Marker Shape:</asp:label>
        <br />
        <asp:dropdownlist id="MarkerShapeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:label id="Label4" runat="server">Marker Size:</asp:label>
        <br />
        <asp:dropdownlist id="MarkerSizeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:Label id="Label5" runat="server">Area Color:</asp:Label>
        <br />
        <asp:DropDownList id="AreaColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:checkbox id="DropLinesCheckBox" runat="server" AutoPostBack="True" Text="Drop Lines"></asp:checkbox>
        <br />
        <br />
        <asp:checkbox id="UseOriginCheckBox" runat="server" AutoPostBack="True" Text="Use Origin"></asp:checkbox>
        <br />
        <br />
        <asp:Label id="Label1" runat="server">Origin Value:</asp:Label>
        <br />
        <asp:textbox id="OriginTextBox" Width="50" runat="server" AutoPostBack="True"></asp:textbox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Demonstrates a standard area chart. Following is a brief description of the controls in the 
        form<br />
        <br />
        Depth % combo - controls the depth of the area in percents of the floor grid 
        cell depth.<br />
        Drop Lines check - controls the visibility of the area drop lines between the 
        area segments.<br />
        Use Origin check - when checked the area will begin from the value specified in 
        the Origin edit. Otherwise the area will begin from the minimum area value.
        <br />
        Show Data Labels - controls the visibility of the data point labels.<br />
        Data Label Format combo - controls the information displayed in the data point 
        labels.<br />
        Show markers check - controls the visibility of the data point markers.<br />
        Marker Shape combo - changes the shape of the data point markers.<br />
        Marker Size combo - controls the width and height of the data point markers.					
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
