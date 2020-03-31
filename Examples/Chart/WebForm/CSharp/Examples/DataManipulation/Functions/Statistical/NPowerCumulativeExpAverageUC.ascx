<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NPowerCumulativeExpAverageUC" CodeFile="NPowerCumulativeExpAverageUC.ascx.cs" %>
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
        <asp:DropDownList id="FunctionDropDownList" runat="server" Width="156px" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Expression:</asp:Label>
        <br />
        <asp:TextBox id="ExpressionTextBox" runat="server" Width="156"></asp:TextBox>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Power:</asp:Label>
        <br />
        <asp:DropDownList id="PowerDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" runat="server">Exponential weight:</asp:Label>
        <br />
        <asp:DropDownList id="ExponentialWeightDropDownList" runat="server" Width="78px" AutoPostBack="True"></asp:DropDownList>		
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        POW function rises each element of the first argument to the power defined by 
        the second argument.<br />
        <br />
        The CUMSUM function calculates the cumulative sum of the elements in the input 
        array..<br />
        <br />
        The EXPAVG function calculates the exponential average of the input array. The 
        formula is:<br />
        Result[n] = A1[n] * weight + A1[n-1] * (1 - weight)
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
