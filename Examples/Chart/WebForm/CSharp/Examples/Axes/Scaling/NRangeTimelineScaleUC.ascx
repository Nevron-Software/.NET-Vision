<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NRangeTimelineScaleUC.ascx.cs" Inherits="Nevron.Examples.Chart.WebForm.NRangeTimelineScaleUC" %>
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
		<asp:CheckBox id="FirstRowVisibleCheckBox" runat="server" AutoPostBack="True" Text="First Row Visible" >
        </asp:CheckBox>
        <br />
        <asp:CheckBox id="SecondRowVisibleCheckBox" runat="server" AutoPostBack="True" Text="Second Row Visible" >
        </asp:CheckBox>
        <br />
		<asp:CheckBox id="ThirdRowVisibleCheckBox" runat="server" AutoPostBack="True" Text="Third Row Visible" >
        </asp:CheckBox>
		<br />
        <br />
		<asp:Label id="Label1" runat="server">Random Data Type:</asp:Label>
        <br />
		<asp:DropDownList id="RandomDataTypeDropDownList" Width="48px" runat="server" AutoPostBack="True" ></asp:DropDownList>
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
The example demonstrates how to create a timeline scale using the built-in NRangeTimelineScaleConfigurator.<br />
This type of date/time scale annotates the scale by using several date time units with varying formatting and levels on the axis. It is useful when you want to 
ensure that the user is aware of the specific date time events that occur within the range of the scale.<br />
On the right side you can can choose to display / hide the levels that build up the scale as well as to generate data that differs in number and time range.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
