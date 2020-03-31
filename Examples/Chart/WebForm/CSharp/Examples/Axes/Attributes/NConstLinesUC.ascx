<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NConstLinesUC" CodeFile="NConstLinesUC.ascx.cs" %>
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
        <p><b>Left axis const line</b></p>
        <hr />
        <asp:Label id="Label3" runat="server">Value:</asp:Label>
        <br />
        <asp:DropDownList id="LAValueDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label4" runat="server">Style:</asp:Label>
        <br />
        <asp:DropDownList id="LAStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="LAUseBeginEndValueCheckBox" runat="server" AutoPostBack="True" Text="Use Begin-End value"></asp:CheckBox>
        <br />
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
		        <asp:DropDownList id="LABeginValueDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		        </td>    
		        <td>
		        <asp:DropDownList id="LAEndValueDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		        </td>
		    </tr>
		</table>
        <br />
        <p><b>Bottom axis const line</b></p>
        <hr />
        <asp:Label id="Label7" runat="server">Value:</asp:Label>
        <br />
        <asp:DropDownList id="BAValueDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label id="Label8" runat="server">Style:</asp:Label>
        <br />
        <asp:DropDownList id="BAStyleDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:CheckBox id="BAUseBeginEndValueCheckBox" runat="server" AutoPostBack="True" Text="Use Begin-End value"></asp:CheckBox>
        <br />
        <table>
		    <tr>
		        <td>
		        <asp:Label id="Label9" runat="server">Begin:</asp:Label>
		        </td>
		        <td>
		        <asp:Label id="Label10" runat="server">End:</asp:Label>
		        </td>
		    </tr>
		    <tr>
		        <td>
		        <asp:DropDownList id="BABeginValueDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		        </td>    
		        <td>
		        <asp:DropDownList id="BAEndValueDropDownList" runat="server" AutoPostBack="True"></asp:DropDownList>
		        </td>
		    </tr>
		</table>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
	    <!-- Description box placeholder BEGIN -->
        Const lines are lines displayed at axis values and are usually used to display 
        some chart specific limit or targeted value.
        <br />
        <br />
        Value combo - controls the value at which the const line is displayed.<br />
        Style combo - controls the style of the line.<br />
        Use Begin - End Values check – controls whether or not const line extend should 
        be synchronized with the values of an axis collinear with the axis const line 
        orientation.<br />
        Begin Value combo – controls the const lines begin value<br />
        End Value combo – controls the const lines end value<br />
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
