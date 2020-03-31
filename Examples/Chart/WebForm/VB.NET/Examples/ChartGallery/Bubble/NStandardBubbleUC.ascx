<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStandardBubbleUC" CodeFile="NStandardBubbleUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Bubble shape:</asp:Label>
		<br />
		<asp:DropDownList id="BubbleShapeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Min bubble size:</asp:Label>
		<br />
		<asp:DropDownList id="MinBubbleSizeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Max bubble size:</asp:Label>
		<br />
		<asp:DropDownList id="MaxBubbleSizeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="DifferentColorsCheckBox" runat="server" Text="Different colors" AutoPostBack="True"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates a standard Bubble chart.<br />
		From the Bubble Style Combo the user can control the shape of the bubbles.<br />
		The user controls the size of the smallest bubble from the Min Bubble Size 
		combo.<br />
		The user controls the size of the largest bubble from the Max Bubble Size 
		combo.<br />
		When you check the Different Colors check the bubbles will be displayed in 
		different programmer specified colors.<br />
		Otherwise the color of the bubbles can be controlled from the Bubble Color 
		button.<br />
		The Show Data Labels check controls the visibility of the bubble labels.<br />
		From the Data Label Format combo the user controls the information displayed in 
		the bubble data point labels.<br />
		The Show Legend check controls the visibility of the legend.<br />
		From the Legend Label Format combo the user controls the information displayed 
		about each bubble in the legend
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
