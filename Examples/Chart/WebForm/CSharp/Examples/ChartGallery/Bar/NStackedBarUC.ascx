<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NStackedBarUC" CodeFile="NStackedBarUC.ascx.cs" %>
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
        <asp:Label id="Label4" runat="server">Stack style:</asp:Label>
        <br />
        <asp:DropDownList id="StackStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label1" runat="server">Frist bar data labels</asp:Label>
        <br />
        <asp:DropDownList id="FirstBarLabelsDropDownList" Height="22" Width="139" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Second bar data labels</asp:Label>
        <br />
        <asp:DropDownList id="SecondBarLabelsDropDownList" Height="22px" Width="139px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Third bar data labels</asp:Label>
        <br />
        <asp:DropDownList id="ThirdBarLabelsDropDownList" Height="22px" Width="139px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label5" runat="server">Bar Shape:</asp:Label>
        <br />
        <asp:DropDownList id="BarShapeDropDownList" Width="157px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Button id="PositiveDataButton" Height="24px" Width="173px" runat="server" Text="Positive data"></asp:Button>
        <br />
        <br />
        <asp:Button id="PositivAndNegativeDataButton" Height="24" Width="173" runat="server" Text="Positive and Negative data"></asp:Button>
        <br />
        <br />
        <asp:CheckBox id="FirstHasTopEdgeCheckBox" Height="24px" Width="139px" runat="server" AutoPostBack="True"
            Text="First has top edge" Enabled="False"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="FirstHasBottomEdgeCheckBox" runat="server" AutoPostBack="True" Text="First has bottom edge"
            Enabled="False"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="SecondHasTopEdgeCheckBox" runat="server" AutoPostBack="True" Text="Second has top edge"
            Enabled="False"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="SecondHasBottomEdgeCheckBox" Width="174px" runat="server" AutoPostBack="True"
            Text="Second has bottom edge" Enabled="False"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="ThirdHasTopEdgeCheckBox" runat="server" AutoPostBack="True" Text="Third has top edge"
            Enabled="False"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="ThirdHasBottomEdgeCheckBox" Width="157px" runat="server" AutoPostBack="True"
            Text="Third has bottom edge" Enabled="False"></asp:CheckBox>
        <br />
        <br />
        <asp:CheckBox id="PositiveDataCheckBox" runat="server" Visible="False"></asp:CheckBox>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
        <!-- Description box placeholder BEGIN -->
        Demonstrates stacked bar series. The first series MultiBarMode is set to 
        Series, while the second and third bar series are displayed with MultiBarMode 
        set to Stacked or StackedPercent.<br />
        Two types of stacking are supported – Stacked and Stacked Percent. The first 
        type simply piles the bars on top of each other. The stacked percent style 
        displays the contribution of each individual stack to the overall pile sum.<br />
        Stack Style combo - changes the stacking style<br />
        The Positive Data and Positive and Negative Data button change the data with 
        random positive and positive and positive and negative data respectively. Note 
        that in Stacked percent mode all data is processed by its absolute value.<br />
        Data Labels combos - controls the information displayed on each stack.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
