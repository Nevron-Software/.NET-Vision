<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NDatabaseSchemaImportUC" CodeFile="NDatabaseSchemaImportUC.ascx.vb" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<table style="width:755px;">
	<tr>
		<td>
			<div id="scrollDiv"  style="overflow: auto; width: 755px; height: 480px;">
				<cc1:NDrawingView id="NDrawingView1" runat="server"></cc1:NDrawingView>
			</div>
		</td>
	</tr>
	<tr>
		<td class="Description">
			 This example demonstrates how easy you can import the structure of a complex database in <b>Nevron Diagram</b>.
			 All you have to do is to create an instance of the <b>NDatabaseImporter</b> class and call its <b>Import</b> method
			 with the apropriate connection string. Currently the importer can draw the structure of DataSet objects,
			 XSD schemas, Access and SQL databases. You can control the importing process using the following properties:
			 <ul>
				<li><b>ImportInActiveLayer</b> - determines whether to import the schema in the active layer or in a new layer named after the data set. By default set to false.</li>
				<li><b>LinksBelowTables</b> - if set to true the links will be drawn below the tables, otherwise they will be drawn above them. By default set to true.</li>
				<li><b>ConnectorType</b> - determines the type of the connector to use for the data relations. By default set to ErmConnector, which is a connector that
				behaves as the connector used in Microsoft Access Relationships diagram.</li>
			 </ul>
		</td>
	</tr>
</table>