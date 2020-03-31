<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAutomaticScaleBreaksUC" CodeFile="NAutomaticScaleBreaksUC.ascx.cs" %>
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
        <asp:CheckBox ID="enableBreaksCheckBox" runat="server" Text="Enable Automatic Scale Breaks" AutoPostBack="True" OnCheckedChanged="enableBreaksCheckBox_CheckedChanged" />
        <hr />
        <asp:Label id="Label2" runat="server">Threshold:</asp:Label> 
        <br />
        <asp:TextBox ID="thresholdTextBox" runat="server" Width="62px"></asp:TextBox><br />
        <br />
        <asp:Label id="Label3" runat="server">Length:</asp:Label> 
        <br />
        <asp:TextBox ID="lengthTextBox" runat="server" Width="62px"></asp:TextBox><br />
        <br />
        <asp:Label id="Label4" runat="server">Max Breaks:</asp:Label> 
        <br />
        <asp:TextBox ID="maxBreaksTextBox" runat="server" Width="62px"></asp:TextBox><br />
        <br />					
        <asp:Label id="Label1" runat="server">Position Mode:</asp:Label>
        <br />
        <asp:DropDownList id="positionModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label5" runat="server">Position Percent:</asp:Label> 
        <br />
        <asp:TextBox ID="positionPercentTextBox" runat="server" Width="62px"></asp:TextBox><br />
        <hr />
        <asp:Button ID="updateButton" runat="server" Text="Update" /> 
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        This example shows how to add automatic scale breaks on the Y chart axis. Scale breaks 
        will be introduced when the data shown on the axis is not regularly spread over the axis range. 
        <br />
        Use the Enable Automatic Scale Breaks check box to enable / disable scale breaks on the primary Y axis.
        <br />
        The Threshold factor controls when a scale break should be introduced - bigger values for this property 
        will descrease the number of possible scale breaks. The example has been designed to work with threshold of
        0.25 and up to three scale breaks. 
        <br />
        The Length control allows you to modify the length of the scale break on the axis.
        <br />
        The Position mode combo box allows you to control the placement of the automatic scale breaks on the
        axis.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->