<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAxisDockingUC" CodeFile="NAxisDockingUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server" Font-Size="8pt">Dock Red Axis To:
		</asp:Label>
		<br />
		<asp:DropDownList id="RedAxisZoneDropDownList" runat="server" Font-Size="8pt" AutoPostBack="True" onselectedindexchanged="RedAxisZoneDropDownList_SelectedIndexChanged">
		</asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server" Font-Size="8pt">Dock Green Axis To:
		</asp:Label>
		<br />
		<asp:DropDownList id="GreenAxisZoneDropDownList" runat="server" Font-Size="8pt" AutoPostBack="True" onselectedindexchanged="GreenAxisZoneDropDownList_SelectedIndexChanged">
		</asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server" Font-Size="8pt">Dock Blue Axis To:
		</asp:Label>
		<br />
		<asp:DropDownList id="BlueAxisZoneDropDownList" runat="server" Font-Size="8pt" AutoPostBack="True" onselectedindexchanged="BlueAxisZoneDropDownList_SelectedIndexChanged">
		</asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Nevron Chart can have an unlimited number of custom vertical and horizontal 
		axes. You can specify the axis on which a particular series is scaled.<br />
		In this example there are three series each scaling on a different axis (red, 
		green and blue).<br />
		The axes can be docked to an arbitrary axis dock zone. For simplicity in this 
		example only the Front Left and Front Right zones are included.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
