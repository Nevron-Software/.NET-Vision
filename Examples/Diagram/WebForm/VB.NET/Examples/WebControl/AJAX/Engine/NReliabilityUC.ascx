<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NReliabilityUC" CodeFile="NReliabilityUC.ascx.vb" %>
<%@ Register TagPrefix="ncwd" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 729px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: middle;">
		<!-- Diagram control placeholder BEGIN -->
		<ncwd:NDrawingView id="NDrawingView1" runat="server" Width="416px" Height="320px" AjaxEnabled="True" AsyncAutoRefreshEnabled="True" AsyncCallbackTimeout="1000" AsyncRefreshInterval="1000" AsyncRequestWaitCursorEnabled="False" AsyncRefreshEnabled="True" OnAsyncCustomCommand="NDrawingView1_AsyncCustomCommand" OnAsyncMouseMove="NDrawingView1_AsyncMouseMove" OnAsyncRefresh="NDrawingView1_AsyncRefresh" AsyncImageLoadTimeout="1000" OnQueryAjaxTools="NDrawingView1_QueryAjaxTools">
		</ncwd:NDrawingView>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" style="width: 300px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<b>Configuration</b><br />
		<asp:RadioButtonList ID="ajaxModeRadioButtonList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ajaxModeRadioButtonList_SelectedIndexChanged">
			<asp:ListItem Selected="True" Value="nevronInstantCallback">Nevron Instant Callback</asp:ListItem>
			<asp:ListItem Value="microsoftAJAXCallback">Microsoft AJAX Callback</asp:ListItem>
		</asp:RadioButtonList>
		<label for="mouseMoveCheckbox"><input id="mouseMoveCheckbox" name="mouseMoveCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse move event processing</label><br />
		<label for="autoRefreshCheckbox"><input id="autoRefreshCheckbox" name="autoRefreshCheckbox" type="checkbox" onclick="UpdateState();" /> Enable auto-refresh</label><br />
		&nbsp;<input id="refreshButton" onclick="Refresh();" type="button" value="Refresh" />
		<br />&nbsp;<br />
		<b>Simulation</b><br />
		1. Expired session state<br />
		<div id="comment1Paragraph" class="Nested" style="width: 230px; text-align: justify">
			To test the control behavior on expired session state, please disable auto-refresh,
			enable mouse move and wait 1 minute, before moving the mouse over the diagram image.
		</div>
		2. <input id="responseDelayButton" name="responseDelayButton" type="button" onclick="EnforceResponseDelay();"  value="&nbsp;Delay next response 6s" />
		<br />&nbsp;<br />
		3. <input id="restartApplicationButton" onclick="RestartApplication();" type="button" value="&nbsp;Restart the application&nbsp;" />
		<div id="comment2Paragraph" class="Nested" style="width: 230px; text-align: justify">
		Click this button to restart the web application on the web server by unloading the app-domain.
		</div>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
</table>
<table id="exampleControls2Table" class="Description" style="width: 729px; vertical-align: top; margin-top:10px;" summary="Diagnostics controls table">
<tr>
	<td id="exampleControls2LeftTitleCell" style="width: 80px; vertical-align: middle; background: WhiteSmoke; padding-bottom:10px; padding-top:10px; padding-left:12px;">
		<b>Current info:</b>
	</td>
	<td id="exampleControls2LeftCell" style="width: 559px; vertical-align: middle; background: WhiteSmoke; padding-bottom:10px; padding-top:10px;">
		<span id="infoSpan"> </span><br />
	</td>
</tr>
</table>
<table id="Table1" style="width: 729px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		You should think of an AJAX web page as of a classical client-server application.
		The client is implemented with JavaScript classes, running within the browser's DOM.
		The server is your ASP.NET AJAX-enabled web form. The client and the server communicate
		asynchronously and once initialized, the client runs independently
		from the server, and is operational even if the server is unavailable.
		<br />&nbsp;<br />
		This example simulates several possible conditions of communication breakdown:<br />
		1. When the session state expires - the session state is set to expire in 1 minute for this example.<br />
		2. When the web server response is delayed - artificial delay is introduced to the response and the callback timeout is set to 1s.<br />
		3. When the web application is restarted - the app-domain is unloaded to force the application to restart operation.
		<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder BEGIN -->
<script type="text/javascript" language="javascript">
<!--
	var timerId = window.setInterval( function () {DisplayTimer()}, 1000);
	var lastEventTime = null;

	function Refresh()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;

		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_NDrawingView1"
		//	rather than just "NDrawingView1". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		
		cs.Refresh();
	}
	
	function ReadState()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;

		var mouseMoveCheckbox = document.getElementById("mouseMoveCheckbox");
		var autoRefreshCheckbox = document.getElementById("autoRefreshCheckbox");
		
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_NDrawingView1"
		//	rather than just "NDrawingView1". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		
		mouseMoveCheckbox.checked = cs.controller.GetToolById(NMouseMoveCallbackTool.GetClassName()).GetEnabled();
		autoRefreshCheckbox.checked = cs.GetAutoRefreshEnabled();
	}

	function UpdateState()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;

		var mouseMoveCheckbox = document.getElementById("mouseMoveCheckbox");
		var autoRefreshCheckbox = document.getElementById("autoRefreshCheckbox");

		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_NDrawingView1"
		//	rather than just "NDrawingView1". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		var prevAutoRefreshState = cs.GetAutoRefreshEnabled();
		
		cs.controller.EnableTool(NMouseMoveCallbackTool.GetClassName(), mouseMoveCheckbox.checked);
		
		cs.SetAutoRefreshEnabled(autoRefreshCheckbox.checked);

		if(autoRefreshCheckbox.checked && prevAutoRefreshState == false)
			cs.Refresh();
	}
	
	function DisplayTimer()
	{
		if(!NReflection.IsInstance(lastEventTime))
			return;
		
		var infoSpan = document.getElementById("infoSpan");
		var curTime = new Date();
		var millisecondsElapsed = curTime.getTime() - lastEventTime.getTime();
		if(millisecondsElapsed > 60000)
		{
			infoSpan.innerHTML = "Session has expired, test the control now!";
			return;
		}
			
		var seconds = parseInt(millisecondsElapsed / 1000);
		infoSpan.innerHTML = "Session will expire in: " + (60 - seconds) + " s";
	}
	
	function RestartApplication()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;

		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		cs.InvokeCustomCommand('restartApplication');
	}
	
	function EnforceResponseDelay()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;

		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		cs.InvokeCustomCommand('enforceResponseDelay');
	}
	
	function CallbackSucceeded(self, result, context)
	{
		lastEventTime = new Date();
	}
	
	function CallbackRecoveryStateStarted(self, context)
	{
		lastEventTime = null;
		var infoSpan = document.getElementById("infoSpan");
		infoSpan.innerHTML = "RECOVERY STATE";
	}
	
	function CallbackRecoveryStateEnded(self, context)
	{
		var infoSpan = document.getElementById("infoSpan");
		infoSpan.innerHTML = "";
	}

	ReadState();
	document.counter = 0;
	NEventSinkService.AsyncCallbackSucceeded.Subscribe(null, CallbackSucceeded);
	NEventSinkService.AsyncCallbackRecoveryStateStarted.Subscribe(null, CallbackRecoveryStateStarted);
	NEventSinkService.AsyncCallbackRecoveryStateEnded.Subscribe(null, CallbackRecoveryStateEnded);
//-->
</script>
<!-- Custom JavaScript placeholder END -->
