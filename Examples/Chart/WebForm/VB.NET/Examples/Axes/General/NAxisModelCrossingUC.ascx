<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAxisModelCrossingUC" CodeFile="NAxisModelCrossingUC.ascx.vb" %>
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
		<asp:Label id="LeftAxisLabel" runat="server" Font-Size="8pt" Font-Bold="True">Left Axis</asp:Label>
		<hr />
		<asp:Label id="LeftAxisAlignmentLabel" runat="server" Font-Size="8pt">Alignment:
		</asp:Label>
		<asp:DropDownList id="LeftAxisAligmentDropDownList" runat="server" Width="100px" AutoPostBack="True">
			<asp:ListItem Value="Center" Selected="True">Center</asp:ListItem>
			<asp:ListItem Value="Left">Left</asp:ListItem>
			<asp:ListItem Value="Right">Right</asp:ListItem>
		</asp:DropDownList>
		<br />
		<br />
		<asp:Label id="LengthLeftAxisLabel" runat="server" Font-Size="8pt">Length:
		</asp:Label>
		<asp:DropDownList id="LengthLeftAxisDropDownList" runat="server" Width="55px" AutoPostBack="True">
		</asp:DropDownList>
		<br />
		<br />           
		<asp:Label id="BottomAxisLabel" runat="server" Font-Size="8pt" Font-Bold="True">Bottom Axis
		</asp:Label>
		<hr />
		<asp:Label id="BottomAxisAlignmentLabel" runat="server" Font-Size="8pt">Alignment:
		</asp:Label>
		<asp:DropDownList id="BottomAxisDropDownList" runat="server" Width="100px" AutoPostBack="True">
			<asp:ListItem Value="Center" Selected="True">Center</asp:ListItem>
			<asp:ListItem Value="Bottom">Bottom</asp:ListItem>
			<asp:ListItem Value="Top">Top</asp:ListItem>
		</asp:DropDownList>
		<br />
		<br />            
		<asp:Label id="BottomAxisLengthLabel" runat="server" Font-Size="8pt">Length:
		</asp:Label>
		<asp:DropDownList id="LengthBottomAxisDropDownList" runat="server" Width="55px" AutoPostBack="True">
		</asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the ability of Nevron Chart to synchronize the 
		position of an axis with a model coordinate on the chart area. This is achieved 
		by using the NCrossAxisAnchor in combination with a NModelCrossing object 
		specifying the offset and alignment from the chart area used for crossing.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
