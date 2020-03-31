<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStandardPieUC" CodeFile="NStandardPieUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Pie style:</asp:Label>
		<br />
		<asp:DropDownList id="PieStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Pie label mode:</asp:Label>
		<br />
		<asp:DropDownList id="PieLabelModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Arrow length:</asp:Label>
		<br />
		<asp:DropDownList id="ArrowLengthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Arrow pointer length:</asp:Label>
		<br />
		<asp:DropDownList id="ArrowPointerLengthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label6" runat="server">Depth:</asp:Label>
		<br />
		<asp:DropDownList id="DepthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label8" runat="server">Begin angle:</asp:Label>
		<br />
		<asp:DropDownList id="BeginAngleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label9" runat="server">Total angle:</asp:Label>
		<br />
		<asp:DropDownList id="TotalAngleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="LightsCheckBox" runat="server" AutoPostBack="True" Text="Lights"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Standard Pie Chart.<br />
		The user can control the shape of the pie segments from the Pie Style combo.<br />
		The Pie Label Mode combo controls the mode in which the pie chart visualizes 
		the data point labels associated with each pie segment. When set to Rim or 
		Spider the user can control the length of the arrow and arrow pointer from the 
		Arrow Length and Arrow Pointer Length combos respectively.<br />
		If you check the Different Colors check all pies will be displayed in different 
		programmer specified colors.<br />
		Otherwise all pies are displayed in one color, which the user can change from 
		the Pie Color button.<br />
		The Depth combo controls the depth of the pie segments.<br />
		The Radius combo controls the radius of the pie.<br />
		The Begin Angle combo controls the beginning angle of the first pie segment – 
		by default 0.<br />
		The Total Angle combo controls the total angle of the pie – by default 360.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
