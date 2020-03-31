<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NTreeDataImportUC" CodeFile="ntreedataimportuc.ascx.vb" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<table style="width:580px;">
	<tr>
		<td>
			<cc1:NDrawingView id="NDrawingView1" runat="server" Width="580px" Height="450px"></cc1:NDrawingView>
		</td>
	</tr>
	<tr>
		<td class="Description">
			This example demonstrates how to use the NTreeDatasourceImporter to import and automatically arrange a tree data structures from a database.
		</td>
	</tr>
</table>