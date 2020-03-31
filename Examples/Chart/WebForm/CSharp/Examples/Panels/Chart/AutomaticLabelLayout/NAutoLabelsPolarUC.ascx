<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAutoLabelsPolarUC" CodeFile="NAutoLabelsPolarUC.ascx.cs" %>
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
        <asp:checkbox id="EnableInitialPositioningCheckBox" runat="server" AutoPostBack="True" Text="Enable Initial Positioning"></asp:checkbox>
        <br />

		<br />
        <asp:checkbox id="RemoveOverlappedLabelsCheckBox" runat="server" AutoPostBack="True" Text="Remove Overlapped Labels After Initial Positioning"></asp:checkbox>
        <br />

		<br />
        <asp:checkbox id="EnableLabelAdjustmentCheckBox" runat="server" AutoPostBack="True" Text="Enable Label Adjustment"></asp:checkbox>
        <br />

        <br />
        <asp:checkbox id="EnableDataPointSafeguardCheckBox" runat="server" AutoPostBack="True" Text="Enable Data Point Safeguard"></asp:checkbox>
        <br />

		<br />
        <asp:label id="Label1" runat="server">Safeguard Size (in Points):</asp:label>
        <br />
        <asp:dropdownlist id="SafeguardSizeDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        
        <!-- Configuration controls panel placeholder END -->
        <asp:HiddenField ID="HiddenField1" runat="server" />
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		<p>
		Automatic data label layout is supported by Polar charts.
		</p>
		<p>
		The two stages of the layout (initial positioning and adjustment) can be 
		activated or deactivated independently using the respective check boxes.
		</p>
		<p>
		The "Remove Overlapped Label ..." checkbox enables an option which removes from display overlapped labels after the 
		initial positioning stage is performed. When this option is enabled the label adjustment stage has little or no 
		effect and can be turned off.
		</p>
		<p>
		The "Enable Data Point Safeguard" check enables functionality that protects the series data points from being overlapped by data labels.
		The "Safeguard Size" edit box specifies the size of the protected area.
		</p>
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
