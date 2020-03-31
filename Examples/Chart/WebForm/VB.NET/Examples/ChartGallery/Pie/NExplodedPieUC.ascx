<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NExplodedPieUC" CodeFile="NExplodedPieUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Explode mode:</asp:Label>
		<br />
		<asp:DropDownList id="ExplodeModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Button id="ChangeDataButton" runat="server" Text="Change data"></asp:Button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Exploded Pie Chart.The Explode mode combo controls which pie segment should 
		explode.<br />
		<br />
		When set to Explode Biggest the chart automatically determines the biggest pie 
		segment and detaches it from the rim.
		<br />
		The Explode Smallest is similar to Explode Biggest except that the chart 
		explodes the smallest pie.<br />
		<br />
		The Change Data button changes the pie values.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
