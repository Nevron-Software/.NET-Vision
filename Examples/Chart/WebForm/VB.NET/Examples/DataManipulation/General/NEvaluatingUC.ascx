<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NEvaluatingUC" CodeFile="NEvaluatingUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Function:</asp:Label>
		<br />
		<asp:DropDownList id="FunctionDropDownList" runat="server"></asp:DropDownList>
		<br />
		<br />
		<asp:Button id="EvaluateButton" runat="server" Height="24px" Width="156px" Text="Evaluate"></asp:Button>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Result:</asp:Label>
		<br />
		<asp:TextBox id="ResultTextBox" runat="server" Width="156" Enabled="False" ReadOnly="True"></asp:TextBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The Nevron Chart for .NET component has built-in data series subset evaluating 
		capabilities. In this example the subset is the whole data serie, but it can 
		also be any other subset.
		<br />
		Function combo – specifies the performed evaluation function. Possible values 
		are:<br />
		MIN – the result is the min value contained in the subset<br />
		MAX – the result is the max value contained in the subset<br />
		AVE - the result is the average of the subset<br />
		SUM – the result is the total sum of all values contained in the subset<br />
		ABSSUM - the result is the absolute sum of all values contained in the subset<br />
		FIRST - the result is the value of the first data point contained in the subset<br />
		LAST - the result is the value of the last data point contained in the subset<br />
		<br />
		Evaluate button – performs the evaluation<br />
		Result edit – shows the evaluation result
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
