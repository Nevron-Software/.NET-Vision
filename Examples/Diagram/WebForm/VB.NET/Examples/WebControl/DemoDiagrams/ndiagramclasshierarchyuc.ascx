<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NDiagramClassHierarchyUC" CodeFile="NDiagramClassHierarchyUC.ascx.vb" %>
<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 729px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<div id="scrollDiv" style="overflow: auto; width: 550px; height: 500px;">
			<!-- Diagram control placeholder BEGIN -->
			<cc1:NDrawingView id="NDrawingView1" runat="server" />
			<!-- Diagram control placeholder END -->
		</div>
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" style="width: 300px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<asp:Label id="Label2" runat="server">Select Root Type:<br /></asp:Label>
		<br />
		<asp:DropDownList id="RootTypesDropDownList" runat="server" AutoPostBack="True" onselectedindexchanged="RootTypesDropDownList_SelectedIndexChanged"></asp:DropDownList>&nbsp;<br />
		<br />
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
