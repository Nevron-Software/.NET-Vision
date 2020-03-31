<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="C#" Inherits="Nevron.Examples.Diagram.Webform.NNestedGroupsUC" CodeFile="NNestedGroupsUC.ascx.cs" %>

<table id="exampleRootTable" style="width:660px;vertical-align:top;" summary="Example layout table">
	<tr>
		<td id="exampleImageCell" class="ImageCell">
			<!-- Diagram control placeholder BEGIN -->
			<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="660px" Height="660px">
			</ndwc:NThinDiagramControl>
			<!-- Diagram control placeholder END -->
		</td>
	</tr>
	<tr>
		<td id="exampleDescriptionCell" class="Description">
			<p>
				This example demonstrates nested groups, expand/collapse and frame decorators.
			</p>
			<p>
				Groups are shapes, which contain other groups/shapes. In this example each main group
				has two nested groups and each nested group has two shapes. There are lines that connect
				the nested shapes and expand/collapse and frame decorators.
			</p>
			<p>
				Groups, like ordinary shapes, can too have multiple ports, labels and control points.
			</p>
		</td>
	</tr>
</p>

