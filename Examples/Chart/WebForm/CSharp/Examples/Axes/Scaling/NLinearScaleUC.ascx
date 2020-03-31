<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NLinearScaleUC" CodeFile="NLinearScaleUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server" Font-Bold="True">Major Tick Modes
        </asp:Label>
        <br />
        <br />
        <asp:RadioButton id="AutoMaxCountRadioButton" runat="server" Text="AutoMaxCount" AutoPostBack="True" GroupName="a">
        </asp:RadioButton>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label id="Label2" runat="server">Max Count:
        </asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList id="MaxCountDropDownList" Width="50px" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:RadioButton id="AutoMinDistanceRadioButton" runat="server" Text="AutoMinDistance" AutoPostBack="True" GroupName="a">
        </asp:RadioButton>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label id="Label3" runat="server">Min Distance:
        </asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList id="MinDistanceDropDownList" Width="50px" runat="server" AutoPostBack="True"></asp:DropDownList><asp:Label id="Label4" runat="server">pt
        </asp:Label>
        <br />
        <br />
        <asp:RadioButton id="CustomStepRadioButton" runat="server" Text="Custom Step" AutoPostBack="True" GroupName="a">
        </asp:RadioButton>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label id="Label5" runat="server">Custom Step:
        </asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList id="CustomStepDropDownList" Width="50px" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:RadioButton id="CustomStepsRadioButton" runat="server" Text="Custom Steps" AutoPostBack="True" GroupName="a">
        </asp:RadioButton>
        <br />
        <br />
        <asp:RadioButton id="CustomTicksRadioButton" runat="server" Text="Custom Ticks" AutoPostBack="True" GroupName="a">
        </asp:RadioButton>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
	    Linear axis scale is primary used for the Y axes of the components, but can 
        also be applied to the X and Z axes when you want to display a generic XY or 
        XYZ scatter.<br />
        On the example panel you can choose how the Primary Y axis major are to be 
        generated:<br />
        AutoMaxCount - in this mode the number of ticks cannot exceed a certain number. 
        The scale will automatically generate a step so that it decorates the axis with 
        a number of ticks that is less than the specified value
        <br />
        AutoMinDistance - in this mode the ticks cannot be closer on the screen than a 
        certain distance. The scale will automatically generate a step so that the 
        ticks are not closer than the specified distance. This is the default mode.
        <br />
        CustomStep - in this mode you can provide a custom step to be used when 
        generating the axis ticks
        <br />
        CustomSteps - in this mode you can provide a set of custom steps to be used 
        when generating the axis ticks. In this example the custom steps are set to 10, 
        20.
        <br />
        CustomTicks - in this mode you can provide a set of values to be used for the 
        major ticks. In this example the custom ticks are copied from line series 
        Values collection.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
