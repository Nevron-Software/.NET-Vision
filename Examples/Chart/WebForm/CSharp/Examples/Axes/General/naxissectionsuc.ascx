<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAxisSectionsUC" CodeFile="NAxisSectionsUC.ascx.cs" %>
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
        <br />
        <asp:CheckBox id="ShowFirstVerticalSectionCheck" runat="server" AutoPostBack="True" Text="Show Y Section [20, 40]" oncheckedchanged="ShowFirstVerticalSectionCheck_CheckedChanged">
        </asp:CheckBox>
        <br />
        <asp:CheckBox id="ShowSecondVerticalSectionCheck" runat="server" AutoPostBack="True" Text="Show Y Section [70, 90]" oncheckedchanged="ShowSecondVerticalSectionCheck_CheckedChanged">
        </asp:CheckBox>
        <br />
        <asp:CheckBox id="ShowFirstHorizontalSectionCheck" runat="server" AutoPostBack="True" Text="Show X Section [2, 8]" oncheckedchanged="ShowFirstHorizontalSectionCheck_CheckedChanged">
        </asp:CheckBox>
        <br />
        <asp:CheckBox id="ShowSecondHorizontalSectionCheck" runat="server" AutoPostBack="True" Text="Show X Section [14, 18]" oncheckedchanged="ShowSecondHorizontalSectionCheck_CheckedChanged">
        </asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        The example demonstrates the Axis Sections feature of the component. Axis 
        sections allow you to modify the style of major and minor grid lines and ticks 
        as well as the style of the automatically generated labels when they fall in a 
        certain range (defined by the section). This allows you to visually highlight 
        important ranges of data.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
