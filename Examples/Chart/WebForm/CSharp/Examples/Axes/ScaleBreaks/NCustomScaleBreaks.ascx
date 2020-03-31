<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NCustomScaleBreaks" CodeFile="NCustomScaleBreaks.ascx.cs" %>
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
		<asp:Label id="Label1" runat="server">First Horizontal Scale Break:</asp:Label>
		<hr />
		<table>
		    <tr>
		        <td>
		        <asp:Label id="Label2" runat="server">Begin:</asp:Label>
		        </td>
		        <td>
		        <asp:Label id="Label3" runat="server">End:</asp:Label>
		        </td>
		    </tr>
		    <tr>
		        <td>
		        <asp:TextBox ID="sb1BeginTextBox" runat="server" Width="62px"></asp:TextBox>
		        </td>    
		        <td>
		        <asp:TextBox ID="sb1EndTextBox" runat="server" Width="62px"></asp:TextBox>
		        </td>
		    </tr>
		</table>
		<br />
		<asp:Label id="Label4" runat="server">Second Horizontal Scale Break:</asp:Label>
		<hr />
        <table>
		    <tr>
		        <td>
		        <asp:Label id="Label5" runat="server">Begin:</asp:Label>
		        </td>
		        <td>
		        <asp:Label id="Label6" runat="server">End:</asp:Label>
		        </td>
		    </tr>
		    <tr>
		        <td>
		        <asp:TextBox ID="sb2BeginTextBox" runat="server" Width="62px"></asp:TextBox>
		        </td>    
		        <td>
		        <asp:TextBox ID="sb2EndTextBox" runat="server" Width="62px"></asp:TextBox>
		        </td>
		    </tr>
		</table>
		<br />
		<asp:Label id="Label7" runat="server">First Vertical Scale Break:</asp:Label>
		<hr />
        <table>
		    <tr>
		        <td>
		        <asp:Label id="Label8" runat="server">Begin:</asp:Label>
		        </td>
		        <td>
		        <asp:Label id="Label9" runat="server">End:</asp:Label>
		        </td>
		    </tr>
		    <tr>
		        <td>
		        <asp:TextBox ID="sb3BeginTextBox" runat="server" Width="62px"></asp:TextBox>
		        </td>    
		        <td>
		        <asp:TextBox ID="sb3EndTextBox" runat="server" Width="62px"></asp:TextBox>
		        </td>
		    </tr>
		</table>
        <br />
		<asp:Label id="Label10" runat="server">Second Vertical Scale Break:</asp:Label>
		<hr />
        <table>
		    <tr>
		        <td>
		        <asp:Label id="Label11" runat="server">Begin:</asp:Label>
		        </td>
		        <td>
		        <asp:Label id="Label12" runat="server">End:</asp:Label>
		        </td>
		    </tr>
		    <tr>
		        <td>
		        <asp:TextBox ID="sb4BeginTextBox" runat="server" Width="62px"></asp:TextBox>
		        </td>    
		        <td>
		        <asp:TextBox ID="sb4EndTextBox" runat="server" Width="62px"></asp:TextBox>
		        </td>
		    </tr>
		</table>
		<br />
		<hr />
		<asp:Button ID="updateButton" runat="server" Text="Update" /> 
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        This example demonstrates how to add custom scale breaks on the chart primary X and Y axes.
        <br />
        You can use the controls on the right side to modify the scale break ranges.
	    <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->