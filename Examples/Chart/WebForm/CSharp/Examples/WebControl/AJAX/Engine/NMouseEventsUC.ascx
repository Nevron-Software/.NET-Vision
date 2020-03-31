<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NMouseEventsUC" CodeFile="NMouseEventsUC.ascx.cs" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 755px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="420px" Height="320px" AjaxEnabled="True" AsyncAutoRefreshEnabled="False" AsyncClickEventEnabled="True" AsyncCallbackTimeout="10000" OnAsyncClick="nChartControl1_AsyncClick" OnAsyncDoubleClick="nChartControl1_AsyncDoubleClick" OnAsyncMouseDown="nChartControl1_AsyncMouseDown" OnAsyncMouseMove="nChartControl1_AsyncMouseMove" OnAsyncMouseUp="nChartControl1_AsyncMouseUp" AjaxImageMapMode="Never" OnQueryAjaxTools="nChartControl1_QueryAjaxTools">
		</ncwc:NChartControl>
		<!-- Chart control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 300px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		<label for="mouseClickCheckbox"><input id="mouseClickCheckbox" name="mouseClickCheckbox" type="checkbox" onclick="UpdateState();" checked="CHECKED" /> Enable click </label><br />
		<label for="mouseDoubleClickCheckbox"><input id="mouseDoubleClickCheckbox" name="mouseDoubleClickCheckbox" type="checkbox" onclick="UpdateState();" /> Enable double click </label><br />
		<label for="mouseMoveCheckbox"><input id="mouseMoveCheckbox" name="mouseMoveCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse move </label><br />
		<label for="mouseDownCheckbox"><input id="mouseDownCheckbox" name="mouseDownCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse down </label><br />
		<label for="mouseUpCheckbox"><input id="mouseUpCheckbox" name="mouseUpCheckbox" type="checkbox" onclick="UpdateState();" /> Enable mouse up </label><br />
		<label for="waitCursorCheckbox"><input id="waitCursorCheckbox" name="waitCursorCheckbox" type="checkbox" onclick="UpdateState();" checked="CHECKED" /> Enable wait cursor</label><br />
		<br />
		<hr class="WhiteHr" />
		<asp:Button ID="simulatePostbackButton" runat="server" OnClick="simulatePostbackButton_Click" Text="Simulate Postback" /><br />
		<asp:Label ID="simulatePostbackLabel" runat="server" Text=""></asp:Label>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		This example demonstrates AJAX processing of mouse events with Nevron Chart for .NET. The "Simulte Postback" button refreshes the page using postback, demonstrating
		the ability to combine Nevron AJAX callbacks with postback requests.<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder BEGIN -->
<script type="text/javascript" language="javascript">
<!--
	function ReadState()
	{
		if(typeof(NChartCallbackService) == "undefined")
			return;
			
		var mouseClickCheckbox = document.getElementById("mouseClickCheckbox");
		var mouseDoubleClickCheckbox = document.getElementById("mouseDoubleClickCheckbox");
		var mouseMoveCheckbox = document.getElementById("mouseMoveCheckbox");
		var mouseDownCheckbox = document.getElementById("mouseDownCheckbox");
		var mouseUpCheckbox = document.getElementById("mouseUpCheckbox");
		var waitCursorCheckbox = document.getElementById("waitCursorCheckbox");
		
		//	The full hierarchical id of the chart control must be used, e.g. "ctl04_nChartControl1"
		//	rather than just "nChartControl1". The "ctl04" is the id generated by the ASP.NET framework 
		//	for the user control hosting the chart control.
		var cs = NChartCallbackService.GetCallbackService('ctl04_nChartControl1');
		
		mouseClickCheckbox.checked = cs.controller.GetToolById(NMouseClickCallbackTool.GetClassName()).GetEnabled();
		mouseDoubleClickCheckbox.checked = cs.controller.GetToolById(NMouseDoubleClickCallbackTool.GetClassName()).GetEnabled();
		mouseMoveCheckbox.checked = cs.controller.GetToolById(NMouseMoveCallbackTool.GetClassName()).GetEnabled();
		mouseDownCheckbox.checked = cs.controller.GetToolById(NMouseDownCallbackTool.GetClassName()).GetEnabled();
		mouseUpCheckbox.checked = cs.controller.GetToolById(NMouseUpCallbackTool.GetClassName()).GetEnabled();

		waitCursorCheckbox.checked = cs.GetWaitCursorEnabled();
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
		var waitCursorCheckbox = document.getElementById("waitCursorCheckbox");
		
		//	The full hierarchical id of the chart control must be used, e.g. "ctl04_nChartControl1"
		//	rather than just "nChartControl1". The "ctl04" is the id generated by the ASP.NET framework 
		//	for the user control hosting the chart control.
		var cs = NChartCallbackService.GetCallbackService('ctl04_nChartControl1');
		
		cs.controller.EnableTool(NMouseClickCallbackTool.GetClassName(), mouseClickCheckbox.checked);
		cs.controller.EnableTool(NMouseDoubleClickCallbackTool.GetClassName(), mouseDoubleClickCheckbox.checked);
		cs.controller.EnableTool(NMouseMoveCallbackTool.GetClassName(), mouseMoveCheckbox.checked);
		cs.controller.EnableTool(NMouseDownCallbackTool.GetClassName(), mouseDownCheckbox.checked);
		cs.controller.EnableTool(NMouseUpCallbackTool.GetClassName(), mouseUpCheckbox.checked);

		cs.SetWaitCursorEnabled(waitCursorCheckbox.checked);
	}

	ReadState();
//-->
</script>
<!-- Custom JavaScript placeholder END -->
