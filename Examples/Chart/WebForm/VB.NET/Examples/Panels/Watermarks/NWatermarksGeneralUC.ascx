<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NWatermarksGeneralUC" CodeFile="NWatermarksGeneralUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 669px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageRootCell" style="width: 420px; vertical-align: top; padding: 3px;">
		<table id="exampleImageTable" style="width: 420px; vertical-align: top;" summary="Image and description table">
		<tr>
			<td id="exampleImageCell" style="width: 420px; vertical-align: top; padding: 3px;">
			<!-- Chart control placeholder BEGIN -->    
			<ncwc:NChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
			</ncwc:NChartControl>
			<!-- Chart control placeholder END -->
			</td>
		</tr>
		<tr>
			<td id="exampleDescriptionCell" style="width: 420px; vertical-align: top; padding: 3px;">
				<p id="exampleDescriptionParagraph" class="Description">
					<!-- Description box placeholder BEGIN -->
					Watermarks are images displayed by the control at the top or bottom of the z 
					order.
					<br />
					The Sales for country controls the watermark used to display for a country 
					selected from the list.<br />
					The Show flag above chart allows you to place the watermark at the top or 
					bottom of the image.<br />
					The content alignment combo box allows you to select how the legend content will 
					align relative to the location defined by the X Margin nad Y Margin combos.
					<br />
					Use the Transparency combo to control the transparency of the watermark.
					<!-- Description box placeholder END -->
				</p>
			</td>
		</tr>
		</table>
	</td>
	<td id="exampleControlsRootCell" style="width: 249px; vertical-align: top; padding: 3px;">
		<table id="exampleControlsTable" style="width: 249px; vertical-align: top;" summary="Example configuration table">
			<tr>
				<td id="exampleControlsCell" style="width: 249px; vertical-align: top; padding: 3px;">
					<!-- Configuration controls panel placeholder BEGIN -->    
					<asp:Panel id="Panel1" runat="server" Width="249px" Height="480px">
						<asp:Label id="Label1" runat="server">Sales for country:</asp:Label>
						<br />
						<asp:DropDownList id="CountryDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
						<br />
						<br />
						<asp:CheckBox id="ShowFlagAboveChartBox" runat="server" AutoPostBack="True" Text="Show flag on top"></asp:CheckBox>
						<br />
						<br />
						<asp:Label id="Label4" runat="server">Content alignment:</asp:Label>
						<br />
						<asp:DropDownList id="ContentAlignmentDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
						<br />
						<br />
						<asp:Label id="Label2" runat="server">X margin  (percent):</asp:Label>
						<br />
						<asp:DropDownList id="XPositionDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
						<br />
						<br />
						<asp:Label id="Label3" runat="server">Y margin (percent):</asp:Label>
						<br />
						<asp:DropDownList id="YPositionDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
						<br />
						<br />
						<asp:Label id="Label7" runat="server">Flag transparency:</asp:Label>
						<br />
						<asp:DropDownList id="FlagTransparencyDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
					</asp:Panel>
					<!-- Configuration controls panel placeholder END -->
				</td>
			</tr>
		</table>
	</td>
</tr>
</table>
<!-- Example layout END -->