<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAppearanceUC" CodeFile="NAppearanceUC.ascx.cs" %>
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
        <asp:Label id="Label1" runat="server">Fill mode:</asp:Label>
        <br />
        <asp:DropDownList id="FillModeDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Bar count:</asp:Label>
        <br />
        <asp:DropDownList id="BarCountDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Bar color:</asp:Label>
        <br />
        <asp:DropDownList id="BarColorDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" runat="server">Cycle count:</asp:Label>
        <br />
        <asp:DropDownList id="CycleCountDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        The data point fill effects and borders can be specified in several modes.<br />
        Series – in this mode all series data points are displayed in an uniform series 
        defined manner. For example the bar series have two properties BarFillEffect 
        and BarBorder, which control the appearance of the bars. The series can also 
        implement some built-in logic and use the appearance of the data points to 
        express it. This is the case of the Stock chart, which paints the data points 
        with user specified up and down fill effects (controlled by the UpFillEffect 
        and DownFillEffect properties of the Stock Series object).<br />
        Cycle – in this mode the appearance of the data points is defined by user 
        specified arrays of fill effects and line properties. This allows the user to 
        specify individual filling and border for each data point. If the count of the 
        fill effects or borders array is smaller than the data point count the control 
        will cycle trough the available fill effects or borders respectively. If the 
        fill effects or borders array is empty a default fill effect or border will be 
        used.<br />
        Predefined – in this mode the control uses predefined colors for the filling 
        and borders of the data points. No user action is required – this can be very 
        helpful if you just want to display your data points in different colors, but 
        do not want to bother to specify them exactly.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
