<%@ Register TagPrefix="ndwc" Namespace="Nevron.Diagram.ThinWeb" Assembly="Nevron.Diagram.ThinWeb" %> 
<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NBusinessCompanyUC" CodeFile="NBusinessCompanyUC.ascx.vb" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 720px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ndwc:NThinDiagramControl id="NThinDiagramControl1" runat="server" Width="720px" Height="450px">
		</ndwc:NThinDiagramControl>
		<!-- Diagram control placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description" style="text-align:center;">
		<!-- Description box placeholder BEGIN -->
		<table style="width:350px; height:150px; margin:auto; border:1px solid #000000;">
			<tr>
				<td rowspan="4" style="width:90px; padding:5px;"><img id="Photo" src="" alt="" width="80" height="100" /></td>
				<td id="Name" style="width:230px; padding:5px; font-weight:bold"></td>
			</tr>
			<tr>
				<td id="Position" style="padding:5px; font-weight:bold"></td>
			</tr>
			<tr>
				<td id="BirthDate" style="padding:5px"></td>
			</tr>
			<tr>
				<td id="Salary" style="padding:5px"></td>
			</tr>
			<tr>
				<td colspan="2" id="Biography" style="padding:5px; text-align:justify"></td>
			</tr>
		</table>
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder BEGIN -->
<script type="text/javascript" language="javascript">
<!--   
	function SetText(sId, sText)
	{
		var el;
		if (document.getElementById && (el = document.getElementById(sId)))
		{
			while (el.hasChildNodes())
			{
				el.removeChild(el.lastChild);
			}
			
			el.appendChild(document.createTextNode(sText));
		}    
	}

	$(document).ready()
	{
		var diagramHost = NClientNode.GetFromId("Diagram1");
		diagramHost.CustomCommandCallback = function (argument) {
			var arr = argument.split("\n");
			var i, count = arr.length;
			var entry, name, value;

			for (i = 0; i < count; i++) {
				entry = arr[i].split("=");
				name = entry[0];
				value = entry[1];

				if (name == "Photo") {
					document.getElementById(name).src = value;
				}
				else {
					SetText(name, value);
				}
			}
		};
	}
//-->
</script>
<!-- Custom JavaScript placeholder END -->