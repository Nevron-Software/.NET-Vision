<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAutoLabelsStepLineUC" CodeFile="NAutoLabelsStepLineUC.ascx.cs" %>
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
        <asp:checkbox id="EnableLabelAdjustmentCheckBox" runat="server" AutoPostBack="True" Text="Enable Label Adjustment"></asp:checkbox>
        <br />
		<br />
        <asp:label id="Label1" runat="server">Proposals for Label Location:</asp:label>
        <br />
        <asp:dropdownlist id="LocationProposalsDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
		<br />
        <asp:checkbox id="InvertForDownwardDPCheckBox" runat="server" AutoPostBack="True" Text="Invert Locations for Downward Data Points"></asp:checkbox>
        <br />
		<br />
        <asp:checkbox id="InvertIfOutOfBoundsCheckBox" runat="server" AutoPostBack="True" Text="Invert Locations If All Are Out of Bounds"></asp:checkbox>
        <br />
        <!-- Configuration controls panel placeholder END -->
        <asp:HiddenField ID="HiddenField1" runat="server" />
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
		<p>
		The example demonstrates automatic data label layout for a step line chart with a single series.
		</p>
		<p>
		The two stages of the layout (initial positioning and adjustment) can be activated or deactivated independently using the respective check boxes.
		</p>
		<p>
		When initial positioning is enabled you can choose the allowed locations for a data label from the "Proposals for Label Location" combo box.
		When "Top" is selected the labels are placed above their origin points.
		When "Top-Bottom" is selected the auto label system may choose between two positions (top and bottom) for each label.
		When "Top-Bottom-Left-Right" is selected the auto label system may choose between four positions for each label.
		</p>
		<p>
		The "Invert Locations for Downward Data Points" check box inverts the proposed locations vertically so that the labels for 
		data points with downward orientation are placed below the data points.
		</p>
		<p>
		The "Invert Locations If All Are Out of Bounds" check box inverts the proposed locations when all of them fall out of the control bounds.
		The effect of this option can be observed when "Top" is the only proposed location.
		</p>
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
