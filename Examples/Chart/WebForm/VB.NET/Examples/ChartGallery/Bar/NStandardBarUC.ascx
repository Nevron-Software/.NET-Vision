<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStandardBarUC" CodeFile="NStandardBarUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Bar Shape:</asp:Label>
		<br />
		<asp:DropDownList id="ShapeCombo" runat="server" Height="22" Width="179" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="ShowDataLabelsCheck" runat="server" Width="132px" AutoPostBack="True" Text="Show data labels"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="DifferentColorsCheckBox" runat="server" AutoPostBack="True" Text="Different colors"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="UseOriginCheck" runat="server" AutoPostBack="True" Text="Use Origin"></asp:CheckBox>
		<br />
		<asp:TextBox id="OriginTextBox" runat="server" Width="106px" AutoPostBack="True"></asp:TextBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates a standard bar chart.<br />
		The appearance of the bars is controlled from the Bar Shape combo<br />
		If you check the Different colors check all bars will be displayed in 
		different colors (specified by the programmer)<br />
		Otherwise all bars will be displayed with the color which you chose from the 
		Bar color combo.<br />
		The Show Data Labels check controls the visibility of the data point labels<br />
		From the Data Label Format combo you can control the information displayed by 
		the data labels.<br />
		The Use Origin check box controls whether or not the bars should use an origin 
		when they are visualized. If the check is checked all bars will begin from the 
		value specified in the Origin edit. Otherwise the bars will begin from the 
		value of the minimum bar.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
