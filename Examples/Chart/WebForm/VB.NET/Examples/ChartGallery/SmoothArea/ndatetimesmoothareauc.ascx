<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NDateTimeSmoothAreaUC" CodeFile="NDateTimeSmoothAreaUC.ascx.vb" %>
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
		<asp:Button id="btnChangeYValues" runat="server" Text="Change Values">
		</asp:Button>
		<br />
		<br />
		<asp:CheckBox id="ShowMarkersCheck" runat="server" Text="Show Markers" AutoPostBack="True">
		</asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="ShowDropLinesCheck" runat="server" Text="Show Drop Lines" AutoPostBack="True">
		</asp:CheckBox>
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Area Origin Mode:
		</asp:Label>
		<br />
		<asp:DropDownList id="AreaOriginModeCombo" runat="server" AutoPostBack="True">
		</asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Origin Value:
		</asp:Label>&nbsp; 
		<asp:TextBox id="OriginValueTextBox" Width="56px" runat="server" AutoPostBack="True">
		</asp:TextBox>
		<br />
		<br />
		<asp:CheckBox id="RoundToTickCheck" runat="server" Text="Axis Round To Tick " AutoPostBack="True">
		</asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates a 2D Smooth Area chart with custom DateTime 
		values along the X axis.        
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
