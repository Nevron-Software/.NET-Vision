<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NRefreshUC" CodeFile="NRefreshUC.ascx.vb" %>
<%@ Register TagPrefix="cc1" Namespace="Nevron.Diagram.WebForm" Assembly="Nevron.Diagram.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 704px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<cc1:NDrawingView id="NDrawingView1" runat="server" Width="416px" Height="320px" AjaxEnabled="True" AsyncAutoRefreshEnabled="True" AsyncRefreshInterval="1000" OnAsyncRefresh="NDrawingView1_AsyncRefresh" AjaxImageMapMode="Never">
		</cc1:NDrawingView>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 249px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<label for="refreshCheckbox"><input id="refreshCheckbox" type="checkbox" checked="true" onclick="UpdateState();" /> Enable forced refresh</label><br />
		&nbsp;<input id="refreshButton" type="button" value="Refresh" onclick="Refresh();" /><p />
		<label for="autoRefreshCheckbox"><input id="autoRefreshCheckbox" type="checkbox" checked="true" onclick="UpdateState();" /> Enable auto-refresh</label><br />
		&nbsp;<select id="autoRefreshIntervalCombo" onChange="UpdateState();">
			<option value="1">1 ms</option>
			<option value="10">10 ms</option>
			<option value="20">20 ms</option>
			<option value="50">50 ms</option>
			<option value="100">100 ms</option>
			<option value="200">200 ms</option>
			<option value="500">500 ms</option>
			<option value="1000">1 s</option>
			<option value="2000">2 s</option>
			<option value="5000">5 s</option>
		</select><p />
		<label for="waitCursorCheckbox"><input id="waitCursorCheckbox" type="checkbox" onclick="UpdateState();" checked="CHECKED" /> Enable wait cursor</label><br />
		<br />
		&nbsp;<span id="infoSpan"></span>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates the refresh and auto-refresh AJAX capabilities of Nevron .NET
		controls.
		<br />&nbsp;<br />
		The high response time is a result of the large view state, generated by the web form,
		as well as by the time the server needs to recreate the web form on each callback request.
		When Microsoft AJAX callbacks are used, the complete view state of the web form is always
		sent to the server.
		<br />&nbsp;<br />
		Nevron offers as an alternative the optimized AJAX Nevron Instant Callback technology,
		which is demonstrated in the
		<b>Client Side Event Queueing</b>, 
		<b>Instant Auto-Refresh</b> and 
		<b>Instant Mouse Events</b>
		examples.
		<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder BEGIN -->
<script type="text/javascript" language="javascript">
<!--
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
			
		var refreshCheckbox = document.getElementById("refreshCheckbox");
		var autoRefreshCheckbox = document.getElementById("autoRefreshCheckbox");
		var waitCursorCheckbox = document.getElementById("waitCursorCheckbox");
		var autoRefreshIntervalCombo = document.getElementById("autoRefreshIntervalCombo");
		
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_NDrawingView1"
		//	rather than just "NDrawingView1". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		
		autoRefreshIntervalCombo.value = cs.GetAutoRefreshInterval();
		refreshCheckbox.checked = cs.GetRefreshEnabled();
		autoRefreshCheckbox.checked = cs.GetAutoRefreshEnabled();
		waitCursorCheckbox.checked = cs.GetWaitCursorEnabled();
	}

	function UpdateState()
	{
		if(typeof(NDiagramCallbackService) == "undefined")
			return;
			
		var refreshCheckbox = document.getElementById("refreshCheckbox");
		var autoRefreshCheckbox = document.getElementById("autoRefreshCheckbox");
		var waitCursorCheckbox = document.getElementById("waitCursorCheckbox");
		var autoRefreshIntervalCombo = document.getElementById("autoRefreshIntervalCombo");
		
		//	The full hierarchical id of the diagram control must be used, e.g. "ctl04_NDrawingView1"
		//	rather than just "NDrawingView1". The "ctl05" is the id generated by the ASP.NET framework 
		//	for the user control hosting the diagram control.
		var cs = NDiagramCallbackService.GetCallbackService('ctl04_NDrawingView1');
		var prevAutoRefreshState = cs.GetAutoRefreshEnabled();
		
		cs.SetRefreshEnabled(refreshCheckbox.checked);
		cs.SetAutoRefreshEnabled(autoRefreshCheckbox.checked);
		cs.SetWaitCursorEnabled(waitCursorCheckbox.checked);
		cs.SetAutoRefreshInterval(parseInt(autoRefreshIntervalCombo.options[autoRefreshIntervalCombo.selectedIndex].value));
		
		if(autoRefreshCheckbox.checked && prevAutoRefreshState == false)
		{
			var prevRefreshState = cs.GetRefreshEnabled();
			cs.SetRefreshEnabled(true);
			cs.Refresh();
			cs.SetRefreshEnabled(prevRefreshState);
		}
	}
	
	function CallbackSucceeded(self, result, context)
	{
		var infoSpan = document.getElementById("infoSpan");
				
		var t = context.callbackService.GetAvgCallbackTime();
		if(t == 0)
			return;
		infoSpan.innerHTML = "<i>Average response time: " + Math.round(t) + " ms</i>";
	}
	
	ReadState();
	NEventSinkService.AsyncCallbackSucceeded.Subscribe(null, CallbackSucceeded);
//-->
</script>
<!-- Custom JavaScript placeholder END -->
