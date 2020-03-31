<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NSortingUC" CodeFile="NSortingUC.ascx.vb" %>
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
		<asp:label id="Label1" runat="server">Sort order:</asp:label>
		<br />
		<asp:dropdownlist id="SortOrderDropDownList" runat="server" Height="22" Width="111"></asp:dropdownlist>
		<br />
		<br />
		<asp:button id="Button1" runat="server" Height="22px" Width="111px" Text="Change data"></asp:button>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The component has build data sorting capabilities. Sorting can be applied on 
		individual data series as well as on collections of data series. In the second 
		case the user specifies a master data series on which the sorting is performed.<br />
		<br />
		Sort Order combo – specifies the sort order in which the data series should be 
		sorted
		<br />
		<br />
		Change Data button – changes the Values, Labels and FillEffects data series of 
		the bar series.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
