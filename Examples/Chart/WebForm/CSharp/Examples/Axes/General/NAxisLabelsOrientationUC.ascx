<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAxisLabelsOrientationUC" CodeFile="NAxisLabelsOrientationUC.ascx.cs" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 682px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 420px; vertical-align: top;">
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
	    <asp:DropDownList id="AngleModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
	    <asp:Label id="Label5" runat="server">Custom Angle:</asp:Label> 
	    <br />
		<asp:TextBox ID="CustomAngleTextBox" runat="server" Width="62px"></asp:TextBox><br />
		<br />
		<asp:CheckBox ID="AllowFlipCheckBox" runat="server" Text="Allow Labels To Flip" AutoPostBack="True" />
		<hr class="WhiteHr" />
		<asp:CheckBox ID="FitAxisContentInBox" runat="server" Text="Fit Axis Content in Box" AutoPostBack="True" />
		<hr class="WhiteHr" />
		<asp:Button ID="updateButton" runat="server" Text="Update" /> 
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the how to set orientation to the chart axis labels as well as how to enable axis content fitting in 3D. The example affects only the labels of the PrimaryX and Depth axes, but the code is applicable for all axis labels including titles.
		<br />
		You can use the angle mode combo to select the mode in which labels operate. There are three options:
		<br />&nbsp;<br />
		- Auto - the angle is automatically computed by the scale (orthogonal to the to the ruler at the point of the label) 
		<br />
		- Custom - the angle is specified by the user 
		<br />
		- AutoAndCustom - the angle is first automatically computed and then the custom angle specified by the user is added 
		<br />&nbsp;<br />
		To experiment how scale labels orientation works press the left mouse button over the chart and begin to drag. The chart orientation and rotation will change accordingly and the axis labels will change their orientation according to the setttings you have selected. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->