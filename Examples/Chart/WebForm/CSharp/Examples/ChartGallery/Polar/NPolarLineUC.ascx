﻿<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NPolarLineUC.ascx.cs" Inherits="Nevron.Examples.Chart.WebForm.NPolarLineUC" %>
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
        <asp:label id="Label1" runat="server">Begin Angle:</asp:label>
        <br />
        <asp:dropdownlist id="BeginAngleDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:label id="Label2" runat="server">Angle Step:</asp:label>
        <br />
        <asp:dropdownlist id="AngleStepDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
The example demonstrates the Polar Line series.<br />
Use the begin angle combo on the right to change the orientation of the polar.<br>
In this example the polar angle axis operates in custom angle step mode. You can control the angle 
step with the "Radian Angle Step" combo on the right.<br />
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->