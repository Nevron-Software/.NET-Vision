<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NDateTimeScaleUC" CodeFile="NDateTimeScaleUC.ascx.cs" %>
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
        <asp:CheckBox id="EnableUnitSensitiveFormattingCheckBox" runat="server" AutoPostBack="True" Text="Enable Unit Sensitive Formatting">
        </asp:CheckBox>
        <br />
        <asp:Label id="StartDateLabel" runat="server">Start date:
        </asp:Label>
        <br />
        <asp:Calendar id="StartDateCalendar" Height="152px" Width="212px" runat="server" DayNameFormat="FirstTwoLetters"
            Font-Size="5pt" CssClass="Description" BorderColor="#EAEAF4" ShowGridLines="True" onselectionchanged="StartDateCalendar_SelectionChanged">
            <TodayDayStyle Font-Bold="True" BackColor="OldLace"></TodayDayStyle>
            <DayStyle BorderColor="#E0E0E0"></DayStyle>
            <DayHeaderStyle BackColor="#E0E0E0"></DayHeaderStyle>
            <TitleStyle Font-Size="8pt" ForeColor="Teal" BackColor="#EAEAF4"></TitleStyle>
            <WeekendDayStyle ForeColor="Maroon"></WeekendDayStyle>
            <OtherMonthDayStyle BackColor="#E4EAFA"></OtherMonthDayStyle>
        </asp:Calendar>
        <br />
        <asp:Label id="EndDateLabel" runat="server">End date:
        </asp:Label>
        <br />
        <asp:Calendar id="EndDateCalendar" Height="152px" Width="212px" runat="server" DayNameFormat="FirstTwoLetters"
            Font-Size="5pt" BorderColor="#EAEAF4" ShowGridLines="True" onselectionchanged="EndDateCalendar_SelectionChanged">
            <TodayDayStyle Font-Bold="True" BackColor="OldLace"></TodayDayStyle>
            <DayHeaderStyle BackColor="#E0E0E0"></DayHeaderStyle>
            <TitleStyle Font-Size="8pt" ForeColor="Teal" BackColor="#EAEAF4"></TitleStyle>
            <WeekendDayStyle ForeColor="Maroon"></WeekendDayStyle>
            <OtherMonthDayStyle BackColor="#E4EAFA"></OtherMonthDayStyle>
        </asp:Calendar>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
        <!-- Description box placeholder BEGIN -->
        The example demonstrates the date time scaling features in Nevron Chart.<br />
        In this example the scale will automatically select a date time unit and step 
        in this date time unit according to the date time range you specify using the 
        date time pickers.<br />
        When you check the Enable Unit Sensitive Formatting check box the scale will also 
        use a date time formatting string that is most appropriate for the currently 
        determined unit for the scale.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
