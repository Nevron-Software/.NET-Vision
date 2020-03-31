<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStandardLine2DUC" CodeFile="NStandardLine2DUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Line Style:</asp:Label>
		<br />
		<asp:DropDownList id="LineStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
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
		<asp:Label id="Label5" runat="server">Line Fill Color:</asp:Label>
		<br />
		<asp:DropDownList id="LineFillColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="ShowMarkersCheckBox" runat="server" AutoPostBack="True" Text="Show markers"></asp:CheckBox>
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
		<asp:CheckBox id="InflateMarginsCheckBox" runat="server" AutoPostBack="True" Text="Inflate margins"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="LeftAxisRoundToTickCheckBox" runat="server" AutoPostBack="True" Text="Left axis round to tick"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates a standard line chart.<br />
		The user can control the style of the line from the Line Style combo. When set 
		to Line the line width is controlled by the Line Width combo.<br />
		When the line style is set to Tape, Tube or Ellipsoid the Line Depth controls 
		the depth of the line segments in percents of the floor grid cell depth. In 
		this case the Line Width combo controls the width of the tape or tube border.<br />
		The user can control the visibility of the data point markers with the help of 
		the Show Markers check. From the Markers Style combo the user can change the 
		shape of the data point markers. The size of the markers is controlled with the 
		help of the Marker Size combo.<br />
		When the user checks the Inflate Margins check the axis scales are adjust to 
		fit the entire chart with the displayed markers.<br />
		The Left Axis Round to tick check controls whether the left axis should 
		automatically round its min and max values to end on exact ticks.";
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
