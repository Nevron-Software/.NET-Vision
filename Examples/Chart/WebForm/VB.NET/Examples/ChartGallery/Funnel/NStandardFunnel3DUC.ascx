<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NStandardFunnel3DUC" CodeFile="NStandardFunnel3DUC.ascx.vb" %>
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
		<asp:Label id="Label1" runat="server">Funnel Radius:</asp:Label>
		<br />
		<asp:DropDownList id="FunnelRadiusDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label2" runat="server">Funnel Point Gap:</asp:Label>
		<br />
		<asp:DropDownList id="FunnelPointGapDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Neck Width:</asp:Label>
		<br />
		<asp:DropDownList id="NeckWidthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Neck Height:</asp:Label>
		<br />
		<asp:DropDownList id="NeckHeightDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label5" runat="server">Funnel Label Mode:</asp:Label>
		<br />
		<asp:DropDownList id="FunnelLabelModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label6" runat="server">Label Arrow Length:</asp:Label>
		<br />
		<asp:DropDownList id="LabelArrowLengthDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates a standard 3D Funnel Chart. Use the controls to 
		modify different parameters of the funnel like radius, neck width, neck height 
		and gap size. You can also change the placement of the funnel data point 
		labels.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
