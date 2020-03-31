<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NGraphDataImportUC" CodeFile="NGraphDataImportUC.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<table style="width:755px;">
    <tr>
        <td>
            <cc1:NDrawingView id="NDrawingView1" runat="server" Width="720px" Height="500px"></cc1:NDrawingView>
        </td>
    </tr>
    <tr>
        <td class="Description">
            This example demonstrates how to use the NGraphDatasourceImporter to import and automatically arrange a graph data structures from a database.
        </td>
    </tr>
</table>