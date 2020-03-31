<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NXYScatterBubbleUC" CodeFile="NXYScatterBubbleUC.ascx.vb" %>
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
		<br />
		<asp:Label id="Label1" runat="server">Bubble shape:</asp:Label>
		<br />
		<asp:DropDownList id="BubbleShapeDropDownList" runat="server" Height="22" Width="117" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Min bubble size:</asp:Label>
		<br />
		<asp:DropDownList id="MinBubbleSizeDropDownList" runat="server" Height="22" Width="117" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Max bubble size:</asp:Label>
		<br />
		<asp:DropDownList id="MaxBubbleSizeDropDownList" runat="server" Height="22" Width="117" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="LightingFilterCheckBox" runat="server" AutoPostBack="True" Text="Lighting Filter"></asp:CheckBox>
		<br />
		<asp:CheckBox id="InflateMarginsCheckBox" runat="server" AutoPostBack="True" Text="Inflate margins"></asp:CheckBox>
		<br />
		<asp:CheckBox id="AxesRoundToTickCheckBox" runat="server" AutoPostBack="True" Text="Axes round to tick"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		XY Scatter bubble charts are created when the user instructs the bubble series 
		to use a custom x value for the bubble data point positions. Note that in this 
		case the Bottom axis is switched in numeric scale mode.
		<br />
		From the Bubble Style Combo the user can control the shape of the bubbles.<br />
		The user controls the size of the smallest bubble from the Min Bubble Size 
		combo.<br />
		The user controls the size of the largest bubble from the Max Bubble Size 
		combo.<br />
		The Change X and Y Values button changes the X and Y values of the bubble 
		series.<br />
		The Bubble Size combo changes the sizes of the displayed bubbles - it can be 
		Equal or Random.<br />
		When the Inflate Margins check is checked the axes scales are adjusted to fit 
		the entire bubble chart.<br />
		When the Axes Round To Tick check is checked the left and bottom axes scales 
		end on exact tick marks.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
