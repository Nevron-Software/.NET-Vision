<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NLegendGeneralUC" CodeFile="NLegendGeneralUC.ascx.vb" %>
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
		<asp:Label id="Label2" runat="server">Legend header:</asp:Label>
		<br />
		<asp:TextBox id="LegendHeaderTextBox" runat="server" Width="140px"></asp:TextBox>
		<br />
		<br />
		<asp:Label id="Label3" runat="server">Legend footer:</asp:Label>
		<br />
		<asp:TextBox id="LegendFooterTextBox" runat="server" Width="141"></asp:TextBox>
		<br />
		<br />
		<asp:Button id="Button1" runat="server" Width="141px" Text="Update texts"></asp:Button>
		<br />
		<br />
		<asp:Label id="Label1" runat="server">Legend mode:</asp:Label>
		<br />
		<asp:DropDownList id="LegendModeDropDownList" runat="server" Height="22" Width="141" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label4" runat="server">Expand mode:</asp:Label>
		<br />
		<asp:DropDownList id="ExpandModeDropDownList" runat="server" Height="22px" Width="140px" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label5" runat="server">Row count:</asp:Label>
		<br />
		<asp:DropDownList id="RowCountDropDownList" runat="server" Height="22px" Width="140px" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label6" runat="server">Col count:</asp:Label>
		<br />
		<asp:DropDownList id="ColCountDropDownList" runat="server" Height="22px" Width="140px" AutoPostBack="True"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label7" runat="server">Predefined style:</asp:Label>
		<br />
		<asp:DropDownList id="PredefinedStyleDropDownList" runat="server" Height="22px" Width="140px" AutoPostBack="True" onselectedindexchanged="PredefinedStyleDropDownList_SelectedIndexChanged"></asp:DropDownList>
		<br />
		<br />
		<asp:Label id="Label8" runat="server">Manual items:</asp:Label>
		<br />
		<asp:DropDownList id="ManualItemsDropDownList" runat="server" Height="22px" Width="140px" AutoPostBack="True"></asp:DropDownList>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates basic features of the Nevron Chart integrated legend.
		<br />
		From the Legend mode combo box you can choose how to feed the data to the 
		legend. In Disabled mode the legend will not appear. When you set the legend 
		mode to Automatic the legend will present the data according to the displayed 
		series. In Manual mode you can feed the data displayed by the legend manually 
		by using the Manual items combo.
		<br />
		The Header and Footer text boxs control the header and footer applied on the 
		the legend.<br />
		The Expand mode combo controls how the legend expands when you add new items – 
		when set to “Rows only” the legend will add new rows and will not add new 
		columns regardless of how many items you’ve added. The “Cols only” mode is 
		similar except that it will instruct the legend to expand by adding new 
		columns.<br />
		The “Rows fixed” and “Cols fixed” mode allow you to control the maximum number 
		of rows or columns respectively displayed by the legend. When the data items 
		are more than the specified limit the legend will add new columns or rows until 
		it displays all the data.<br />
		The Predefined style combo positions the legend in the control window and sets 
		the expand mode to the most appropriate value for the current position. For 
		example when you set the style to Bottom the legend will automatically 
		configure itself to expand horizontally (by adding columns). You can of course 
		later modify the expand mode.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->


