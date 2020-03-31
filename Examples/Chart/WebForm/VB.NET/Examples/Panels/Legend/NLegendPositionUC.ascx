<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NLegendPositionUC" CodeFile="NLegendPositionUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Horizontal margin:</asp:Label>
		<br />
		<asp:DropDownList id="HorizontalMarginDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Vertical margin:</asp:Label>
		<br />
		<asp:DropDownList id="VerticalMarginDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Content alignment:</asp:Label>
		<br />
		<asp:DropDownList id="ContentAlignmentDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label5" runat="server">Data font:</asp:Label>
		<br />
		<asp:DropDownList id="DataFontDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label6" runat="server">Data font size:</asp:Label>
		<br />
		<asp:DropDownList id="DataFontSizeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="HasShadowCheckBox" runat="server" AutoPostBack="True" Text="Legend Shadow"></asp:CheckBox>
		<br />
		<asp:CheckBox id="ShowLegendGridCheckBox" runat="server" AutoPostBack="True" Text="Show legend grid"></asp:CheckBox>&nbsp;
		<br />
		<br />
		<asp:Label id="Label8" runat="server">Legend Background Transparency:</asp:Label>
		<br />
		<asp:DropDownList id="BackplaneTransparencyDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates how to position the legend in the control window. It also shows how to
		customize the legend appearance like grid lines, fonts etc.<br />
		The horizontal and vertical margin combos allow you to change the origin point 
		of the legend. The content alignment combo box allows you to select how the legend content will 
		align relative to the location.
		The Data font and Data font size combos allow you to change the font used by 
		the legend to display the data items.<br />
		You can also choose whether to set a shadow style, to show the legend grid or to set different transparency.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
