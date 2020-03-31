<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NLabelsGeneralUC" CodeFile="NLabelsGeneralUC.ascx.cs" %>
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
        <asp:Label id="Label1" Width="69px" runat="server">Label text:</asp:Label>
        <br />
        <asp:TextBox id="LabelTextBox" Width="174px" runat="server"></asp:TextBox>
        <br />
        <asp:Button id="UpdateButton" runat="server" Text="Update text"></asp:Button>
        <br />
        <br />
        <asp:Label id="Label2" runat="server">Horizontal margin:</asp:Label>
        <br />
        <asp:DropDownList id="HorizontalMarginDropDownList" Height="22" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label3" runat="server">Vertical margin:</asp:Label>
        <br />
        <asp:DropDownList id="VerticalMarginDropDownList" Height="22" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" runat="server">Content alignment:</asp:Label>
        <br />
        <asp:DropDownList id="ContentAlignmentDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label6" runat="server">Font:</asp:Label>
        <br />
        <asp:DropDownList id="FontDropDownList" Height="22px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <asp:Label id="Label7" runat="server">Font size:</asp:Label>
        <br />
        <asp:DropDownList id="FontSizeDropDownList" Height="22px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label8" runat="server">Font color:</asp:Label>
        <br />
        <asp:DropDownList id="FontColorDropDownList" Height="22px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label9" runat="server">Orientation:</asp:Label>
        <br />
        <asp:DropDownList id="FontOrientationDropDownList" Height="22px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="HasBackplaneCheckBox" runat="server" Text="Has Backplane" AutoPostBack="True"></asp:CheckBox>
        <br />
        <asp:Label id="Label10" runat="server">Backplane Shape:</asp:Label>
        <br />
        <asp:DropDownList id="BackplaneStyleDropDownList" Height="22px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        This example demonstrates how to modify various properties of the NLabel object.<br />
        <br />
        Label text – the text displayed by the label.<br />
        Horz margin – the margin of the label in percents of the control width.<br />
        Vert margin – the margin of the label in percents of the control height.<br />
        Font – the font used to visualize the label.<br />
        Font size – the font size in pixels.<br />
        Font color – the color of the label font.<br />
        Orientation – the label rotation in degrees.<br />
        Has BackplaneStyle check – controls whether or not the label must have a 
        BackplaneStyle.<br />
        Style combo – the style of the legend BackplaneStyle.<br />
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->