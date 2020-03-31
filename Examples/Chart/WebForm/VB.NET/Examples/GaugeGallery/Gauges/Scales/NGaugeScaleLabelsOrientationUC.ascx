<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NGaugeScaleLabelsOrientationUC" CodeFile="NGaugeScaleLabelsOrientationUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Angle Mode:</asp:Label>
		<br />
		<asp:DropDownList id="angleModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<asp:Label id="Label5" runat="server">Custom Angle:</asp:Label>
		<br />
		<asp:TextBox ID="CustomAngleTextBox" runat="server" Width="62px"></asp:TextBox><br />
		<br />
		<asp:CheckBox ID="allowFlipCheckBox" runat="server" Text="Allow Labels To Flip" AutoPostBack="True" />
		<hr />
		<asp:Label ID="Label2" runat="server">Begin Angle:</asp:Label>
		<br />
		<asp:TextBox ID="BeginAngleTextBox" runat="server" Width="62px"></asp:TextBox>
		<br />
		<asp:Label ID="Label3" runat="server">Sweep Angle:</asp:Label>
		<br />
		<asp:TextBox ID="SweepAngleTextBox" runat="server" Width="62px"></asp:TextBox>
		<br />
		<hr />
		<asp:Button ID="updateButton" runat="server" Text="Update" /> 
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the how to set orientation to the gauge axis labels.
		<br />
		You can use the angle mode combo to select the mode in which labels operate. There are three options:
		<br />&nbsp;<br />
		- Auto - the angle is automatically computed by the scale (orthogonal to the to the ruler at the point of the label) 
		<br />
		- Custom - the angle is specified by the user 
		<br />
		- AutoAndCustom - the angle is first automatically computed and then the custom angle specified by the user is added 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
