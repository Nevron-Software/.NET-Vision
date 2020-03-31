<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NRulerCapsUC" CodeFile="NRulerCapsUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Begin Cap Style:</asp:Label>
		<br />
		<asp:DropDownList id="BeginCapStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Scale Break Cap Style:</asp:Label>
		<br />
		<asp:DropDownList id="ScaleBreakCapStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">End Cap Style:</asp:Label>
		<br />
		<asp:DropDownList id="EndCapStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="PaintOnScaleBreaksCheckBox" runat="server" AutoPostBack="True" Text="Paint On Scale Breaks" >
		</asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to apply caps to the axis scale ruler. Additional features demonstrated by the example are the ability to apply caps when the ruler is split from scale breaks. This allows for the display of "scientific looking" charts. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->