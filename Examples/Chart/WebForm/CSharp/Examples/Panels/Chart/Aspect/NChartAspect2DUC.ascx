<%@ Control Language="C#" Inherits="Nevron.Examples.Chart.WebForm.NChartAspect2DUC" CodeFile="NChartAspect2DUC.ascx.cs"  %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
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
		<asp:CheckBox id="FitAxisContentCheckBox" runat="server" Text="Fit Axis Content" AutoPostBack="True"></asp:CheckBox>
		<br />
		<asp:CheckBox id="UsePlotAspectCheckBox" runat="server" Text="Use Plot Aspect" AutoPostBack="True"></asp:CheckBox>
        <table>
        <tr>
            <td><asp:Label id="Label3" runat="server">X:</asp:Label></td>
            <td><asp:DropDownList id="XProportionDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label id="Label1" runat="server">Y:</asp:Label></td>
            <td><asp:DropDownList id="YProportionDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
        </table>
        <br />

		<asp:CheckBox id="ShowContentAreaCheckBox" runat="server" Text="Show Content Area" AutoPostBack="True"></asp:CheckBox>
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
            The example demonstrates the ability of the control to maintain exact aspect ratio in 2D, while still being contained inside it's parent bounds.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>