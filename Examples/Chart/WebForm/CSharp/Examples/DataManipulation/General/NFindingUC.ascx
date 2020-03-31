<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NFindingUC" CodeFile="NFindingUC.ascx.cs" %>
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
		<asp:Label id="Label1" runat="server">Search for:</asp:Label>
		<br />
		<asp:DropDownList id="SearchForDropDownList" runat="server" Height="22" Width="116"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Custom value:</asp:Label>
		<br />
		<asp:TextBox id="CustomValueTextBox" runat="server" Height="22px" Width="116px"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Custom string:</asp:Label>
		<br />
		<asp:TextBox id="CustomStringTextBox" runat="server" Height="22px" Width="116px"></asp:TextBox>
		<br />
		<br />
		<asp:Button id="FindDataButton" runat="server" Height="22px" Width="115px" Text="Find"></asp:Button>		
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        The data series of the component have built-in finding functions.<br />
        In the case when the data series contains objects of type double the user can 
        perform the following finding operations:<br />
        - find the index of the min value<br />
        - find the index of the max value<br />
        - find the index of the first item in the series with the specified value<br />
        <br />
        In the case when the data series contains objects of type string the user can 
        find the index of the first string which is equal to a user specified string.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
