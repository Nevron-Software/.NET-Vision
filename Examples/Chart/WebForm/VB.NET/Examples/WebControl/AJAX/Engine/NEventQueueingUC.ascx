<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NEventQueueingUC" CodeFile="NEventQueueingUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 755px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="416px" Height="320px" AjaxEnabled="True" AsyncAutoRefreshEnabled="True" AsyncCallbackTimeout="10000" AsyncRefreshInterval="1000" AsyncRequestWaitCursorEnabled="False" AsyncRefreshEnabled="True" OnQueryAjaxTools="nChartControl1_QueryAjaxTools">
		</ncwc:NChartControl>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 300px; font-size: 8pt;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<label for="mouseClickCheckbox"><input id="mouseClickCheckbox" name="mouseClickCheckbox" type="checkbox" onclick="UpdateState();" value="on" /> Enable click </label><br />
		<label for="mouseDoubleClickCheckbox"><input id="mouseDoubleClickCheckbox" name="mouseDoubleClickCheckbox" type="checkbox" onclick="UpdateState();" /> Enable double click </label><br />
		<label for="mouseMoveCheckbox"><input id="mouseMoveCheckbox" name="mouseMoveCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse move </label><br />
		<label for="mouseDownCheckbox"><input id="mouseDownCheckbox" name="mouseDownCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse down </label><br />
		<label for="mouseUpCheckbox"><input id="mouseUpCheckbox" name="mouseUpCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse up </label><p />
		
		<label for="autoRefreshCheckbox"><input id="autoRefreshCheckbox" name="autoRefreshCheckbox" type="checkbox" onclick="UpdateState();" /> Enable auto-refresh</label><br />
		&nbsp;<select id="autoRefreshIntervalCombo" name="autoRefreshIntervalCombo" onchange="UpdateState();">
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
		</select> refresh interval<p />
		
		<label for="waitCursorCheckbox"><input id="waitCursorCheckbox" name="waitCursorCheckbox" type="checkbox" onclick="UpdateState();" value="on" /> Enable wait cursor</label><br />
		<label for="refreshCheckbox"><input id="refreshCheckbox" name="refreshCheckbox" type="checkbox" onclick="UpdateState();" value="on" /> Enable forced refresh</label><br />
		&nbsp;<input id="refreshButton" onclick="Refresh();" type="button" value="Refresh" />
		<br />&nbsp;<br />
		<asp:CheckBox ID="addResponseDelayCheckBox" runat="server" Text="Simulate larger response delay +600ms" OnCheckedChanged="addResponseDelayCheckBox_CheckedChanged" AutoPostBack="True" /><br />
		&nbsp;<span id="infoSpan"></span>
		<br />&nbsp;<br />&nbsp;<br />
		<b>Advanced Events Configuration</b>
		<hr class="WhiteHr" />
		<table width="100%">
		<tr>
			<td width="34%" style="padding-bottom:5px;">
				<b>Event Type</b>
			</td>
			<td width="33%" style="padding-bottom:5px;">
				<b>Priority</b>
			</td>
			<td width="33%" style="padding-bottom:5px;">
				<b>Queue Length</b>
			</td>
		</tr>
		<tr>
			<td>
				Mouse click
			</td>
			<td>
				<select id="mouseClickPriorityCombo" name="mouseClickPriorityCombo" onchange="UpdateState();">
					<option value="0">0 (lowest)</option>
					<option value="10">10</option>
					<option value="20">20</option>
					<option value="50">50</option>
					<option value="100">100</option>
					<option value="200">200</option>
					<option value="500">500</option>
					<option value="1000">1000 (highest)</option>
				</select>
			</td>
			<td>
				<select id="mouseClickQueueLengthCombo" name="mouseClickQueueLengthCombo" onchange="UpdateState();">
					<option value="0">0</option>
					<option value="1">1</option>
					<option value="2">2</option>
					<option value="3">3</option>
					<option value="4">4</option>
					<option value="5">5</option>
					<option value="6">6</option>
				</select>
			</td>
		</tr>
		<tr>
			<td>
				Double click
			</td>
			<td>
				<select id="mouseDoubleClickPriorityCombo" name="mouseDoubleClickPriorityCombo" onchange="UpdateState();">
					<option value="0">0 (lowest)</option>
					<option value="10">10</option>
					<option value="20">20</option>
					<option value="50">50</option>
					<option value="100">100</option>
					<option value="200">200</option>
					<option value="500">500</option>
					<option value="1000">1000 (highest)</option>
				</select>
			</td>
			<td>
				<select id="mouseDoubleClickQueueLengthCombo" name="mouseDoubleClickQueueLengthCombo" onchange="UpdateState();">
					<option value="0">0</option>
					<option value="1">1</option>
					<option value="2">2</option>
					<option value="3">3</option>
					<option value="4">4</option>
					<option value="5">5</option>
					<option value="6">6</option>
				</select>
			</td>
		</tr>
		<tr>
			<td>
				Mouse move
			</td>
			<td>
				<select id="mouseMovePriorityCombo" name="mouseMovePriorityCombo" onchange="UpdateState();">
					<option value="0">0 (lowest)</option>
					<option value="10">10</option>
					<option value="20">20</option>
					<option value="50">50</option>
					<option value="100">100</option>
					<option value="200">200</option>
					<option value="500">500</option>
					<option value="1000">1000 (highest)</option>
				</select>
			</td>
			<td>
				<select id="mouseMoveQueueLengthCombo" name="mouseMoveQueueLengthCombo" onchange="UpdateState();">
					<option value="0">0</option>
					<option value="1">1</option>
					<option value="2">2</option>
					<option value="3">3</option>
					<option value="4">4</option>
					<option value="5">5</option>
					<option value="6">6</option>
				</select>
			</td>
		</tr>
		<tr>
			<td>
				Mouse down
			</td>
			<td>
				<select id="mouseDownPriorityCombo" name="mouseDownPriorityCombo" onchange="UpdateState();">
					<option value="0">0 (lowest)</option>
					<option value="10">10</option>
					<option value="20">20</option>
					<option value="50">50</option>
					<option value="100">100</option>
					<option value="200">200</option>
					<option value="500">500</option>
					<option value="1000">1000 (highest)</option>
				</select>
			</td>
			<td>
				<select id="mouseDownQueueLengthCombo" name="mouseDownQueueLengthCombo" onchange="UpdateState();">
					<option value="0">0</option>
					<option value="1">1</option>
					<option value="2">2</option>
					<option value="3">3</option>
					<option value="4">4</option>
					<option value="5">5</option>
					<option value="6">6</option>
				</select>
			</td>
		</tr>
		<tr>
			<td>
				Mouse up
			</td>
			<td>
				<select id="mouseUpPriorityCombo" name="mouseUpPriorityCombo" onchange="UpdateState();">
					<option value="0">0 (lowest)</option>
					<option value="10">10</option>
					<option value="20">20</option>
					<option value="50">50</option>
					<option value="100">100</option>
					<option value="200">200</option>
					<option value="500">500</option>
					<option value="1000">1000 (highest)</option>
				</select>
			</td>
			<td>
				<select id="mouseUpQueueLengthCombo" name="mouseUpQueueLengthCombo" onchange="UpdateState();">
					<option value="0">0</option>
					<option value="1">1</option>
					<option value="2">2</option>
					<option value="3">3</option>
					<option value="4">4</option>
					<option value="5">5</option>
					<option value="6">6</option>
				</select>
			</td>
		</tr>
		<tr>
			<td>
				Auto refresh
			</td>
			<td style="padding-top: 4px; padding-bottom: 5px;">
				&nbsp;&nbsp;0 (lowest)
			</td>
			<td>
				&nbsp;&nbsp;0
			</td>
		</tr>
		<tr>
			<td>
				Forced refresh
			</td>
			<td>
				<select id="refreshPriorityCombo" name="refreshPriorityCombo" onchange="UpdateState();">
					<option value="0">0 (lowest)</option>
					<option value="10">10</option>
					<option value="20">20</option>
					<option value="50">50</option>
					<option value="100">100</option>
					<option value="200">200</option>
					<option value="500">500</option>
					<option value="1000">1000 (highest)</option>
				</select>
			</td>
			<td>
				<select id="refreshQueueLengthCombo" name="refreshQueueLengthCombo" onchange="UpdateState();">
					<option value="0">0</option>
					<option value="1">1</option>
					<option value="2">2</option>
					<option value="3">3</option>
					<option value="4">4</option>
					<option value="5">5</option>
					<option value="6">6</option>
				</select>
			</td>
		</tr>
		</table>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		Nevron AJAX engine provides a seamless client-to-server event routing mechanism.
		During the processing of an AJAX callback, client side events are enqueued and
		filtered by the web browser, providing a native behavior of the web control even
		over the unpredictable and possibly lagged transport over Internet.
		Prioritization of events and event queue length adjustment allow 
		for fine-tuning the way the web control responds to user interaction.
		Nevron Event Queueing makes mixing of mouse move, mouse click events and auto
		refresh possible and native to the web site visitors.
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
		if(typeof(NChartCallbackService) == "undefined")
			return;
			
		//	The full hierarchical id of the chart control must be used, e.g. "ctl04_nChartControl1"
		//	rather than just "nChartControl1". The "ctl04" is the id generated by the ASP.NET framework 
		//	for the user control hosting the chart control.
		var cs = NChartCallbackService.GetCallbackService('ctl04_nChartControl1');
		
		cs.Refresh();
	}
	
	function ReadState()
	{
		if(typeof(NChartCallbackService) == "undefined")
			return;
			
		var mouseClickCheckbox = document.getElementById("mouseClickCheckbox");
		var mouseDoubleClickCheckbox = document.getElementById("mouseDoubleClickCheckbox");
		var mouseMoveCheckbox = document.getElementById("mouseMoveCheckbox");
		var mouseDownCheckbox = document.getElementById("mouseDownCheckbox");
		var mouseUpCheckbox = document.getElementById("mouseUpCheckbox");
		var autoRefreshCheckbox = document.getElementById("autoRefreshCheckbox");
		var autoRefreshIntervalCombo = document.getElementById("autoRefreshIntervalCombo");
		var waitCursorCheckbox = document.getElementById("waitCursorCheckbox");
		var refreshCheckbox = document.getElementById("refreshCheckbox");
		
		var mouseClickPriorityCombo = document.getElementById("mouseClickPriorityCombo");
		var mouseClickQueueLengthCombo = document.getElementById("mouseClickQueueLengthCombo");
		var mouseDoubleClickPriorityCombo = document.getElementById("mouseDoubleClickPriorityCombo");
		var mouseDoubleClickQueueLengthCombo = document.getElementById("mouseDoubleClickQueueLengthCombo");
		var mouseMovePriorityCombo = document.getElementById("mouseMovePriorityCombo");
		var mouseMoveQueueLengthCombo = document.getElementById("mouseMoveQueueLengthCombo");
		var mouseDownPriorityCombo = document.getElementById("mouseDownPriorityCombo");
		var mouseDownQueueLengthCombo = document.getElementById("mouseDownQueueLengthCombo");
		var mouseUpPriorityCombo = document.getElementById("mouseUpPriorityCombo");
		var mouseUpQueueLengthCombo = document.getElementById("mouseUpQueueLengthCombo");

		var refreshPriorityCombo = document.getElementById("refreshPriorityCombo");
		var refreshQueueLengthCombo = document.getElementById("refreshQueueLengthCombo");

		//	The full hierarchical id of the chart control must be used, e.g. "ctl04_nChartControl1"
		//	rather than just "nChartControl1". The "ctl04" is the id generated by the ASP.NET framework 
		//	for the user control hosting the chart control.
		var cs = NChartCallbackService.GetCallbackService('ctl04_nChartControl1');
		
		mouseClickCheckbox.checked = cs.controller.GetToolById(NMouseClickCallbackTool.GetClassName()).GetEnabled();
		mouseDoubleClickCheckbox.checked = cs.controller.GetToolById(NMouseDoubleClickCallbackTool.GetClassName()).GetEnabled();
		mouseMoveCheckbox.checked = cs.controller.GetToolById(NMouseMoveCallbackTool.GetClassName()).GetEnabled();
		mouseDownCheckbox.checked = cs.controller.GetToolById(NMouseDownCallbackTool.GetClassName()).GetEnabled();
		mouseUpCheckbox.checked = cs.controller.GetToolById(NMouseUpCallbackTool.GetClassName()).GetEnabled();

		autoRefreshCheckbox.checked = cs.GetAutoRefreshEnabled();
		autoRefreshIntervalCombo.value = cs.GetAutoRefreshInterval();
		waitCursorCheckbox.checked = cs.GetWaitCursorEnabled();
		refreshCheckbox.checked = cs.GetRefreshEnabled();
		
		mouseClickPriorityCombo.value = cs.GetMouseClickPriority();
		mouseClickQueueLengthCombo.value = cs.GetMouseClickQueueLength();
		mouseDoubleClickPriorityCombo.value = cs.GetMouseDoubleClickPriority();
		mouseDoubleClickQueueLengthCombo.value = cs.GetMouseDoubleClickQueueLength();
		mouseMovePriorityCombo.value = cs.GetMouseMovePriority();
		mouseMoveQueueLengthCombo.value = cs.GetMouseMoveQueueLength();
		mouseDownPriorityCombo.value = cs.GetMouseDownPriority();
		mouseDownQueueLengthCombo.value = cs.GetMouseDownQueueLength();
		mouseUpPriorityCombo.value = cs.GetMouseUpPriority();
		mouseUpQueueLengthCombo.value = cs.GetMouseUpQueueLength();

		refreshPriorityCombo.value = cs.GetRefreshPriority();
		refreshQueueLengthCombo.value = cs.GetRefreshQueueLength();
	}

	function UpdateState()
	{
		if(typeof(NChartCallbackService) == "undefined")
			return;
			
		var mouseClickCheckbox = document.getElementById("mouseClickCheckbox");
		var mouseDoubleClickCheckbox = document.getElementById("mouseDoubleClickCheckbox");
		var mouseMoveCheckbox = document.getElementById("mouseMoveCheckbox");
		var mouseDownCheckbox = document.getElementById("mouseDownCheckbox");
		var mouseUpCheckbox = document.getElementById("mouseUpCheckbox");
		var autoRefreshCheckbox = document.getElementById("autoRefreshCheckbox");
		var autoRefreshIntervalCombo = document.getElementById("autoRefreshIntervalCombo");
		var waitCursorCheckbox = document.getElementById("waitCursorCheckbox");
		var refreshCheckbox = document.getElementById("refreshCheckbox");

		var mouseClickPriorityCombo = document.getElementById("mouseClickPriorityCombo");
		var mouseClickQueueLengthCombo = document.getElementById("mouseClickQueueLengthCombo");
		var mouseDoubleClickPriorityCombo = document.getElementById("mouseDoubleClickPriorityCombo");
		var mouseDoubleClickQueueLengthCombo = document.getElementById("mouseDoubleClickQueueLengthCombo");
		var mouseMovePriorityCombo = document.getElementById("mouseMovePriorityCombo");
		var mouseMoveQueueLengthCombo = document.getElementById("mouseMoveQueueLengthCombo");
		var mouseDownPriorityCombo = document.getElementById("mouseDownPriorityCombo");
		var mouseDownQueueLengthCombo = document.getElementById("mouseDownQueueLengthCombo");
		var mouseUpPriorityCombo = document.getElementById("mouseUpPriorityCombo");
		var mouseUpQueueLengthCombo = document.getElementById("mouseUpQueueLengthCombo");
		
		var refreshPriorityCombo = document.getElementById("refreshPriorityCombo");
		var refreshQueueLengthCombo = document.getElementById("refreshQueueLengthCombo");
		
		//	The full hierarchical id of the chart control must be used, e.g. "ctl04_nChartControl1"
		//	rather than just "nChartControl1". The "ctl04" is the id generated by the ASP.NET framework 
		//	for the user control hosting the chart control.
		var cs = NChartCallbackService.GetCallbackService('ctl04_nChartControl1');
		var prevAutoRefreshState = cs.GetAutoRefreshEnabled();
		
		cs.controller.EnableTool(NMouseClickCallbackTool.GetClassName(), mouseClickCheckbox.checked);
		cs.controller.EnableTool(NMouseDoubleClickCallbackTool.GetClassName(), mouseDoubleClickCheckbox.checked);
		cs.controller.EnableTool(NMouseMoveCallbackTool.GetClassName(), mouseMoveCheckbox.checked);
		cs.controller.EnableTool(NMouseDownCallbackTool.GetClassName(), mouseDownCheckbox.checked);
		cs.controller.EnableTool(NMouseUpCallbackTool.GetClassName(), mouseUpCheckbox.checked);

		cs.SetAutoRefreshEnabled(autoRefreshCheckbox.checked);
		cs.SetAutoRefreshInterval(parseInt(autoRefreshIntervalCombo.options[autoRefreshIntervalCombo.selectedIndex].value));
		cs.SetWaitCursorEnabled(waitCursorCheckbox.checked);
		cs.SetRefreshEnabled(refreshCheckbox.checked);

		cs.SetMouseClickPriority(parseInt(mouseClickPriorityCombo.options[mouseClickPriorityCombo.selectedIndex].value));
		cs.SetMouseClickQueueLength(parseInt(mouseClickQueueLengthCombo.options[mouseClickQueueLengthCombo.selectedIndex].value));
		cs.SetMouseDoubleClickPriority(parseInt(mouseDoubleClickPriorityCombo.options[mouseDoubleClickPriorityCombo.selectedIndex].value));
		cs.SetMouseDoubleClickQueueLength(parseInt(mouseDoubleClickQueueLengthCombo.options[mouseDoubleClickQueueLengthCombo.selectedIndex].value));
		cs.SetMouseMovePriority(parseInt(mouseMovePriorityCombo.options[mouseMovePriorityCombo.selectedIndex].value));
		cs.SetMouseMoveQueueLength(parseInt(mouseMoveQueueLengthCombo.options[mouseMoveQueueLengthCombo.selectedIndex].value));
		cs.SetMouseDownPriority(parseInt(mouseDownPriorityCombo.options[mouseDownPriorityCombo.selectedIndex].value));
		cs.SetMouseDownQueueLength(parseInt(mouseDownQueueLengthCombo.options[mouseDownQueueLengthCombo.selectedIndex].value));
		cs.SetMouseUpPriority(parseInt(mouseUpPriorityCombo.options[mouseUpPriorityCombo.selectedIndex].value));
		cs.SetMouseUpQueueLength(parseInt(mouseUpQueueLengthCombo.options[mouseUpQueueLengthCombo.selectedIndex].value));
		
		cs.SetRefreshPriority(parseInt(refreshPriorityCombo.options[refreshPriorityCombo.selectedIndex].value));
		cs.SetRefreshQueueLength(parseInt(refreshQueueLengthCombo.options[refreshQueueLengthCombo.selectedIndex].value));

		if(autoRefreshCheckbox.checked && prevAutoRefreshState == false)
			cs.Refresh();
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
