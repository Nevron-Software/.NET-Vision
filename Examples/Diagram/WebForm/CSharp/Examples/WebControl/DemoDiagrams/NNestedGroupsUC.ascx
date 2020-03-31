<%@ Control Language="c#" Inherits="Nevron.Examples.Diagram.Webform.NNestedGroupsUC" CodeFile="NNestedGroupsUC.ascx.cs" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>
<table id="exampleRootTable" style="width:650px;vertical-align:top;" summary="Example layout table">
	<tr>
		<td id="exampleImageCell" class="ImageCell">
			<cc1:NDrawingView id="NDrawingView1" runat="server" Width="650px" Height="650px" AjaxEnabled="True"
				AsyncCallbackTimeout="1000" OnAsyncClick="NDrawingView1_AsyncClick"
				OnQueryAjaxTools="NDrawingView1_QueryAjaxTools"/>
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

