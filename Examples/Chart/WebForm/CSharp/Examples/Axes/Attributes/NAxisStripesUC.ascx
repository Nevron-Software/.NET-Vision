<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAxisStripesUC" CodeFile="NAxisStripesUC.ascx.cs" %>
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
        <p><b>Left axis stripe</b></p>
        <hr />
        <table>
		    <tr>
		        <td>
		        <asp:label id="Label1" runat="server">Begin:</asp:label>
		        </td>
		        <td>
		        <asp:label id="Label2" runat="server">End:</asp:label>
		        </td>
		    </tr>
		    <tr>
		        <td>
		        <asp:dropdownlist id="LABeginValueDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		        </td>    
		        <td>
		        <asp:dropdownlist id="LAEndValueDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		        </td>
		    </tr>
		</table>
        <br />
        <asp:label id="Label3" runat="server">Stripe color:</asp:label>
        <br />
        <asp:dropdownlist id="LAColorDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:checkbox id="LAShowAtBackWallCheckBox" runat="server" AutoPostBack="True" Text="Show at back wall"></asp:checkbox>
        <br />
        <asp:checkbox id="LAShowAtLeftWallCheckBox" runat="server" AutoPostBack="True" Text="Show at left wall"></asp:checkbox>
        <br />
        <br />
        <p><b>Bottom axis stripe</b></p>
        <hr />
         <table>
		    <tr>
		        <td>
		        <asp:label id="Label5" runat="server">Begin:</asp:label>
		        </td>
		        <td>
		        <asp:label id="Label7" runat="server">End:</asp:label>
		        </td>
		    </tr>
		    <tr>
		        <td>
		        <asp:dropdownlist id="BABeginValueDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		        </td>    
		        <td>
		        <asp:dropdownlist id="BAEndValueDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
		        </td>
		    </tr>
		</table>
        <br />
        <asp:label id="Label4" runat="server">Stripe color:</asp:label>
        <br />
        <asp:dropdownlist id="BAStripeColorDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist>
        <br />
        <br />
        <asp:checkbox id="BAShowAtBackWallCheckBox" runat="server" AutoPostBack="True" Text="Show at back wall"></asp:checkbox>
        <br />
        <asp:checkbox id="BAShowAtFloorCheckBox" runat="server" AutoPostBack="True" Text="Show at floor"></asp:checkbox>
        <br />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
        <!-- Description box placeholder BEGIN -->
        The examples demonstrates how to use axis stripes in order to highlighting
        ranges of data in the chart area. 
        <br />
        <br />
        Begin Value combo – controls the beginning of the stripe<br />
        End Value combo – controls the ending of the stripe<br />
        Stripe Color button – controls the color of the stripe<br />
        Show At Wall checks – controls whether the respective stripe should be 
        displayed on the specified chart wall.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
