<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NAxisValueCrossingUC" CodeFile="NAxisValueCrossingUC.ascx.vb" %>
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
		<asp:CheckBox id="LeftUsePositionCheckBox" runat="server" Font-Size="8pt" Checked="True" Text="Use Position"
			AutoPostBack="True" oncheckedchanged="LeftUsePositionCheckBox_CheckedChanged">
			</asp:CheckBox>
		<br />
		<br />
		<asp:Label id="LeftPositionValueLabel" runat="server" Font-Size="8pt">Position Value:
		</asp:Label>
		<br />
		<asp:DropDownList id="LeftAxisPositionValueDropDownList" runat="server" Font-Size="8pt" AutoPostBack="True">
		</asp:DropDownList>
		<br />
		<br />
		<asp:Label id="bottomAxisLabel" runat="server" Font-Size="8pt" Font-Bold="True">Bottom Axis</asp:Label>
		<hr />
		<asp:CheckBox id="BottomUsePositionCheckBox" runat="server" Font-Size="8pt" Checked="True" Text="Use Position"
			AutoPostBack="True" oncheckedchanged="BottomUsePositionCheckbox_CheckedChanged">
			</asp:CheckBox>
		<br />
		<br />
		<asp:Label id="BottomPositionValueLabel" runat="server" Font-Size="8pt">Position Value:
		</asp:Label>
		<br />
		<asp:DropDownList id="BottomAxisPositionValueDropdownList" runat="server" Font-Size="8pt" AutoPostBack="True">
		</asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the ability of Nevron Chart to 
		synchronize the position of an axis with a value on another axis. This is 
		achieved by using the NCrossAxisAnchor in combination with a NValueCrossing 
		object specifing the axis that is used for crossing.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
