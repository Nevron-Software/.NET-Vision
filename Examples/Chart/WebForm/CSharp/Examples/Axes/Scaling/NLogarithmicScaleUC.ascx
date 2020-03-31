<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NLogarithmicScaleUC" CodeFile="NLogarithmicScaleUC.ascx.cs" %>
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
        <asp:Label id="LogarithmBaseLabel" runat="server" Width="104px">Logarithm Base:
        </asp:Label>
        <br />
        <asp:TextBox id="LogarithmBaseTextBox" runat="server" Width="40px" AutoPostBack="True" MaxLength="2">
        </asp:TextBox>
        <br />
        <asp:Label id="LabelFormatLabel" runat="server">Label Format:
        </asp:Label>
        <br />
        <asp:DropDownList id="LabelFormatDropDownList" runat="server" Width="152px" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="RoundToTickMin" runat="server" AutoPostBack="True" Text="Round To Tick Min">
        </asp:CheckBox>
        <br />
        <asp:CheckBox id="RoundToTickMax" runat="server" AutoPostBack="True" Text="Round To Tick Max">
        </asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	<!-- Description box placeholder BEGIN -->
	Logarithmic scaling is primary used for the Y axes of the component when you 
    have to display data which varies in orders of magnitude.
    <br />
    Use the Logarithm Base control to modify the base of the logarithm (accepted 
    values by the example are in the range [2, 30]).
    <br />
    The label format combo allows you to modify the format string used for the axis 
    labels.
    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

