<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NAxisAppearanceUC" CodeFile="NAxisTitlesUC.ascx.cs" %>
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
	    <TABLE cellSpacing="0" cellPadding="0" border="0">
		    <TR>
			    <TD colSpan="2" height="25">
				    <asp:Label id="Label1" runat="server" Font-Bold="True" Font-Size="8pt">Y Axis Title</asp:Label></TD>
		    </TR>
		    <TR>
			    <TD align="right" height="25">
				    <asp:Label id="Label2" runat="server" Font-Size="8pt">Title Text:</asp:Label></TD>
			    <TD height="15">
				    <asp:TextBox id="YTitleTextBox" Width="140px" runat="server" Font-Size="8pt" AutoPostBack="True"></asp:TextBox></TD>
		    </TR>
		    <TR>
			    <TD align="right" height="25">
				    <asp:Label id="Label3" runat="server" Font-Size="8pt">Font:</asp:Label></TD>
			    <TD height="25">
				    <asp:DropDownList id="YAxisFontDropDownList" Width="140px" runat="server" AutoPostBack="True" Font-Size="8pt" onselectedindexchanged="YAxisFontDropDownList_SelectedIndexChanged"></asp:DropDownList></TD>
		    </TR>
		    <TR>
			    <TD align="right" height="25">
				    <asp:Label id="Label4" runat="server" Font-Size="8pt">Title Aligment:</asp:Label></TD>
			    <TD height="25">
				    <asp:DropDownList id="YAlignmentDropDownList" Width="85px" runat="server" AutoPostBack="True" Font-Size="8pt" onselectedindexchanged="YAlignmentDropDownList_SelectedIndexChanged">
					    <asp:ListItem Value="Top">Top</asp:ListItem>
					    <asp:ListItem Value="Middle" Selected="True">Middle</asp:ListItem>
					    <asp:ListItem Value="Bottom">Bottom</asp:ListItem>
				    </asp:DropDownList></TD>
		    </TR>
		    <TR>
			    <TD align="right" height="25">
				    <asp:Label id="Label5" runat="server" Font-Size="8pt">Title Offset:</asp:Label></TD>
			    <TD height="25">
				    <asp:DropDownList id="YOffsetDropDownList" Width="50px" runat="server" AutoPostBack="True" Font-Size="8pt" onselectedindexchanged="YOffsetDropDownList_SelectedIndexChanged"></asp:DropDownList></TD>
		    </TR>
		    <TR>
			    <TD colSpan="2" height="25">&nbsp;</TD>
		    </TR>
		    <TR>
			    <TD colSpan="2" height="25">
				    <asp:Label id="Label6" runat="server" Font-Bold="True" Font-Size="8pt">X Axis Title</asp:Label></TD>
		    </TR>
		    <TR>
			    <TD align="right" height="25">
				    <asp:Label id="Label7" runat="server" Font-Size="8pt">Title text:</asp:Label></TD>
			    <TD height="25">
				    <asp:TextBox id="XTitleTextBox" Width="140px" runat="server" Font-Size="8pt" AutoPostBack="True"></asp:TextBox></TD>
		    </TR>
		    <TR>
			    <TD align="right" height="25">
				    <asp:Label id="Label8" runat="server" Font-Size="8pt">Font:</asp:Label></TD>
			    <TD height="25">
				    <asp:DropDownList id="XAxisFontDropDownList" Width="140px" runat="server" AutoPostBack="True" Font-Size="8pt" onselectedindexchanged="XAxisFontDropDownList_SelectedIndexChanged"></asp:DropDownList></TD>
		    </TR>
		    <TR>
			    <TD align="right" height="25">
				    <asp:Label id="Label9" runat="server" Font-Size="8pt">Title Aligment:</asp:Label></TD>
			    <TD height="25">
				    <asp:DropDownList id="XAlignmentDropDownList" Width="85px" runat="server" AutoPostBack="True" Font-Size="8pt" onselectedindexchanged="XAlignmentDropDownList_SelectedIndexChanged">
					    <asp:ListItem Value="Left">Left</asp:ListItem>
					    <asp:ListItem Value="Center" Selected="True">Center</asp:ListItem>
					    <asp:ListItem Value="Right">Right</asp:ListItem>
				    </asp:DropDownList></TD>
		    </TR>
		    <TR>
			    <TD align="right" height="25">
				    <asp:Label id="Label10" runat="server" Font-Size="8pt">Title Offset:</asp:Label></TD>
			    <TD height="25">
				    <asp:DropDownList id="XOffsetDropDownList" Width="50px" runat="server" AutoPostBack="True" Font-Size="8pt" onselectedindexchanged="XOffsetDropDownList_SelectedIndexChanged"></asp:DropDownList></TD>
		    </TR>
	    </TABLE>
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
        This example demonstrates the most important features of the axis titles.
        <!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
