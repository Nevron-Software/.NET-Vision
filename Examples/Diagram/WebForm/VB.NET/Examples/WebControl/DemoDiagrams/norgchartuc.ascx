<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NOrgChartUC" CodeFile="NOrgChartUC.ascx.vb" %>
<%@ Register TagPrefix="ncwd" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 720px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ncwd:NDrawingView id="NDrawingView1" runat="server" Width="720px" Height="450px" AjaxEnabled="True"
			AsyncCallbackTimeout="1000" OnAsyncClick="NDrawingView1_AsyncClick"
			OnQueryAjaxTools="NDrawingView1_QueryAjaxTools"
			OnAsyncQueryCommandResult="NDrawingView1_AsyncQueryCommandResult">
		</ncwd:NDrawingView>
		<!-- Diagram control placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description" style="text-align:center;">
		<!-- Description box placeholder BEGIN -->
		<table style="width:350px; height:150px; margin:auto; border:1px solid #000000;">
			<tr>
				<td rowspan="4" style="width:90px; padding:5px;"><img src="" alt="" width="80" height="100" id="photo" /></td>
				<td id="name" style="width:230px; padding:5px; font-weight:bold"></td>
			</tr>
			<tr>
				<td id="position" style="padding:5px; font-weight:bold"></td>
			</tr>
			<tr>
				<td id="birthdate" style="padding:5px"></td>
			</tr>
			<tr>
				<td id="salary" style="padding:5px"></td>
			</tr>
			<tr>
				<td colspan="2" id="biography" style="padding:5px; text-align:justify"></td>
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
	
	//  event handler that is invoked when an async command is completed successfully
	//  event handling code is provided for desired commands only
	//  this handler is attached to the AsyncCallbackSucceeded event at the end of the JavaScript block
	function CallbackSucceeded(self, result, context)
	{
		switch(context.command)
		{
			case 'mouseClick':
				var transport = new NAjaxXmlTransport();
				transport.Deserialize(result);

				var p = ["name", "position", "birthdate", "salary", "biography", "photo"];
				var i, count = p.length, value;
				for (i = 0; i < count; i++) {
					value = "";
					if (NReflection.IsInstance(transport.DataSections[p[i]])) {
						value = transport.DataSections[p[i]].Data;
					}

					if (p[i] == "photo") {
						document.getElementById(p[i]).src = value;
					}
					else {
						SetText(p[i], value);
					}
				}

				break;
		}
	}

	NEventSinkService.AsyncCallbackSucceeded.Subscribe(null, CallbackSucceeded);
//-->
</script>
<!-- Custom JavaScript placeholder END -->