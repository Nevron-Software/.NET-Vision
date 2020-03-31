<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NBindingToDataAdapterUC" CodeFile="NBindingToDataAdapterUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.ThinWeb" Assembly="Nevron.Chart.ThinWeb" %>
<!-- Example layout BEGIN -->
<table id="Table1" style="width: 745px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="Td1" class="ImageCell" style="width: 420px; vertical-align: top;">
		<!-- Chart control placeholder BEGIN -->
		<ncwc:NThinChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
		</ncwc:NThinChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 325px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<asp:DataGrid id="DataGrid1" runat="server" Font-Size="9pt" DataMember="MyTable" DataKeyField="id" DataSource="<%#dsTable1%>" BorderStyle="None" BorderColor="#999999" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
		<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
		<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
		<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
		<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
		<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="DarkBlue"></HeaderStyle>
		<Columns>
		<asp:EditCommandColumn UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
		</Columns>
		<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#EEEEEE" Mode="NumericPages"></PagerStyle>
		</asp:DataGrid>                    
		<asp:CheckBox id="CheckBoxEnableDatabindig" runat="server" Checked="True" Text="Enable Databinding"
		AutoPostBack="True"></asp:CheckBox>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to bind a chart series to an OleDbDataAdapter. The 
		data table on the right side of the page is bound to the data adapter. The 
		"Enable Databinding" check box controls whether the chart will also be bound to 
		this data adapter. If “Enable Databinding” is checked and you modify the values 
		in the table this will also reflect the data displayed by the chart.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
