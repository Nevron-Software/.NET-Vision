<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NDataLabelsUC" CodeFile="NDataLabelsUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Default Label Vertical Align:</asp:Label>
		<br />
		<asp:DropDownList id="DefaultVerticalAlignDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Default Label Format:</asp:Label>
		<br />
		<asp:DropDownList id="DefaultFormatDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="DefaultLabelVisibleCheck" runat="server" AutoPostBack="True" Text="Show Labels"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="DefaultBackplaneVisibleCheck" runat="server" AutoPostBack="True" Text="Show Backplanes"></asp:CheckBox>
		<br />
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Label 3 Vertical Align:</asp:Label>
		<br />
		<asp:DropDownList id="Label3VerticalAlignDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Label 3 Format:</asp:Label>
		<br />
		<asp:DropDownList id="Label3FormatDropDown" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:CheckBox id="Label3VisibleCheck" runat="server" AutoPostBack="True" Text="Show Label 3"></asp:CheckBox>
		<br />
		<br />
		<asp:CheckBox id="Backplane3VisibleCheck" runat="server" AutoPostBack="True" Text="Show Backplane 3"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		Data Labels are texts displayed on data points, which 
		contain information regarding the data point.<br />The information displayed in 
		the labels is specified in string format containing tags for each value, which 
		should be displayed.<br />The data labels are connected to the data points with 
		arrows. You can control the arrow length and color.<br />By default all data 
		labels are displayed with the same data label style, but you are able to assign 
		individual data label styles for particular data points. 
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
