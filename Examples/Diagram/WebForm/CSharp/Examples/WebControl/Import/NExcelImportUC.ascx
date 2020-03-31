<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NExcelImportUC" CodeFile="NExcelImportUC.ascx.cs" %>
<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 729px; vertical-align: top;" summary="Example layout table">
    <tr>
        <td id="exampleImageCell" class="ImageCell" style="width: 500px; vertical-align: top;">
            <!-- Diagram control placeholder BEGIN -->
			<cc1:NDrawingView ID="NDrawingView1" runat="server">
			</cc1:NDrawingView>
            <!-- Diagram control placeholder END -->
        </td>
    </tr>
    <tr>
        <td id="exampleDescriptionCell" class="Description">
            <!-- Description box placeholder BEGIN -->
            This example demonstrates how to import data from an Excel spreadsheet. It also shows how to
            make the importer create different shapes based on a value in the spreadsheet and how to attach
            symbols to the connectors. <a href="../Examples/Import/Data.xlsx" target="_blank">This Excel
            spreadsheet</a> is used in the example.
            <!-- Description box placeholder END -->
        </td>
    </tr>
</table>
<!-- Example layout END -->
