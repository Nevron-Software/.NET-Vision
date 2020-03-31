<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.Examples.DataManipulation.Binding.NBindingToIBindingListUC" CodeFile="NBindingToIBindingListUC.ascx.cs" %>
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
        <br/>
        <asp:Label id="Label1" runat="server">Bind To:</asp:Label><br/>
        <br/>
        <asp:DropDownList id="DropDownList1" Width="169px" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br/>
        <asp:DataGrid id="DataGrid1" Width="171px" runat="server" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Font-Size="9pt">
        <HeaderStyle BackColor="DarkBlue" Font-Bold="True" ForeColor="White" />
        <FooterStyle BackColor="#CCCCCC" />
        <SelectedItemStyle BackColor="#008A8C" />
        <PagerStyle BackColor="#EEEEEE" ForeColor="Black" />
        <AlternatingItemStyle BackColor="Gainsboro" />
        <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
        </asp:DataGrid>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        The example demonstrates how to bind a chart series to an object that implement 
        IBindingList interface. The DataGrid control and the chart control both are 
        bound to such an object. In the first case they are bind to an IBindingList 
        which content a list of user define objects. The second case the chart and the 
        grid both are bind to an IBindingList object which is also&nbsp;ITypedList.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
