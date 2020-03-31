<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NCountStdDevRmsUC" CodeFile="NCountStdDevRmsUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Function:</asp:Label>
		<br />
		<asp:DropDownList id="FunctionDropDownList" runat="server" Height="22" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Expression:</asp:Label>
		<br />
		<asp:TextBox id="ExpressionTextBox" runat="server" Height="22px" Width="154px" ReadOnly="True"
		Enabled="False"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Result:</asp:Label>
		<br />
		<asp:TextBox id="ResultTextBox" runat="server" Height="22px" Width="154px" ReadOnly="True" Enabled="False"></asp:TextBox>
		<br />
		<br />
		<asp:Button id="NewDataButton" runat="server" Text="New Data"></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The COUNT function returns the number of elements in the input array.<br />
		<br />
		The STDDEV function calculates the Standard Deviation of the input array.<br />
		<br />
		The Root Mean Square is implemented as a composite function.        
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
