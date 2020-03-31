<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NDiagnosticsUC" CodeFile="NDiagnosticsUC.ascx.cs" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 729px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: middle;">
		<!-- Diagram control placeholder BEGIN -->
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="416px" Height="320px" AjaxEnabled="True" AsyncAutoRefreshEnabled="True" AsyncRefreshInterval="1000" AsyncRequestWaitCursorEnabled="False" AsyncRefreshEnabled="True" OnQueryAjaxTools="nChartControl1_QueryAjaxTools" AjaxScriptBuild="Debug">
		</ncwc:NChartControl>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" style="width: 300px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		Debug Console Mode: <asp:DropDownList ID="consoleModeDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="consoleModeDropDownList_SelectedIndexChanged"></asp:DropDownList><br />
		<asp:Panel ID="hideConsoleButtonPanel" runat="server" Height="24px" Width="200px" Visible="false">
			<input id="hideConsoleButton" type="button" value="Hide Console" style="width:100px;margin-top:10px;" onclick="NDiagnostics.DebugConsoleVisible(false);" /><input id="clearConsoleButton" type="button" value="Clear Console" style="width:100px;margin-top:10px;" onclick="NDiagnostics.ClearDebugConsole();" />
		</asp:Panel>
		<p />
		<table width="100%">
		<tr>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNReflectionIsInstance');">NReflection.IsInstance</a>
			</td>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNDebugAssert');">NDebug.Assert</a>
			</td>
		</tr>
		<tr>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNReflectionHasProperty');">NReflection.HasProperty</a>
			</td>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNDebugFail');">NDebug.Fail</a>
			</td>
		</tr>
		<tr>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNReflectionIsOfType');">NReflection.IsOfType</a>
			</td>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNDebugTraceError');">NDebug.TraceError</a>
			</td>
		</tr>
		<tr>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNReflectionIsOfTag');">NReflection.IsOfTag</a>
			</td>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNDebugAssertIsDef');">NDebug.AssertIsDef</a>
			</td>
		</tr>
		<tr>
			<td style="padding:2px;" colspan="2">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNReflectionHasBaseClassOfType');">NReflection.HasBaseClassOfType</a>
			</td>
		</tr>
		<tr>
			<td style="padding:2px;font-size:1px;" colspan="2">
				&nbsp;
			</td>
		</tr>
		<tr>
			<td style="padding:2px;" colspan="2">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNDiagnosticsListMembers');">NDiagnostics.ListMembers</a>
			</td>
		</tr>
		<tr>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNDiagnosticsAlertProperties');">NDiagnostics.AlertProperties</a>
			</td>
			<td style="padding:2px;">
				<a style="font-size:8pt;" href="javascript:;" onclick="UseCodeSnippet('TestNDiagnosticsTrace');">NDiagnostics.Trace</a>
			</td>
		</tr>
		</table>
		<textarea style="font-family:Courier New; font-size:8pt;" id="sourceCodeTextBox" cols="33" rows="10"></textarea><br />
		<input id="executeCodeButton" onclick="ExecuteCode();" type="button" value="Execute Code" style="width: 200px;" /><br />
		<p />
		<label for="simulateErrorCheckbox"><input id="simulateErrorCheckbox" name="simulateErrorCheckbox" type="checkbox" /> Enable error simulation</label><br />
		<p />
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
</table>
<table id="descriptionTable" style="width: 729px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		<p>
			The Nevron JavaScript Framework comes with Debug and Release builds. The Release
			build is selected by default. This example makes use of the Debug build, which
			aids the developer to diagnose run-time issues, emerging from possible unexpected
			interaction with third-party JavaScript code.
		</p>
		<p>
			When using the Release build, all errors that could be generated
			from within the Nevron JavaScript Framework code are silently ignored.
			When using the Debug build, errors are reported via a Debug Console, which
			can be displayed as a pop-up window or embedded into the current HTML page.<p />
		</p>
		<p>
			The Debug Console and an Object Inspector are also available
			in Release mode for use by the JavaScript developer, to assist
			in the programming and extending of the Nevron web components.<p />
		</p>
		<p>
			To explore the diagnostic capabilities of the Nevron JavaScript Framework,
			please select one of the links. A code snippet will appear in the text box.
			Click on the "Execute Code" button to see the effect of the generated code.
		</p>
		<br />
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- JavaScript Snippets BEGIN -->
<span id="TestNReflectionIsInstance_snippet" style="display:none;">
var a = 0;
var b = "test";
var c = new Object();
var d = null;
if(!NReflection.IsInstance(a))
  NDiagnostics.Trace("a failed.");
if(!NReflection.IsInstance(b))
  NDiagnostics.Trace("b failed.");
if(!NReflection.IsInstance(c))
  NDiagnostics.Trace("c failed.");
if(!NReflection.IsInstance(d))
  NDiagnostics.Trace("d failed.");
  
if(!NReflection.IsInstance(
  window.unexistingProperty))
  NDiagnostics.Trace(
  "unexistingProperty failed.");
</span>

<span id="TestNReflectionHasProperty_snippet" style="display:none;">
if(NReflection.HasProperty(window,
  "unexistingProperty"))
  NDiagnostics.Trace(
    "unexistingProperty found.");

if(NReflection.HasProperty(window,
  "document"))
  NDiagnostics.Trace(
    "document found.");
</span>

<span id="TestNReflectionHasBaseClassOfType_snippet" style="display:none;">
var cs =
NChartCallbackService.GetCallbackService(
"ctl04_nChartControl1");

if(NReflection.HasBaseClassOfType(
cs, "NCallbackService"))
NDiagnostics.Trace("NCallbackService");

if(NReflection.HasBaseClassOfType(
cs, "NHashtable"))
NDiagnostics.Trace("NHashtable");  
</span>

<span id="TestNReflectionIsOfType_snippet" style="display:none;">
var cs =
NChartCallbackService.GetCallbackService(
"ctl04_nChartControl1");

if(NReflection.IsOfType(
cs, "NCallbackService"))
NDiagnostics.Trace("NCallbackService");

if(NReflection.IsOfType(
cs, "NChartCallbackService"))
NDiagnostics.Trace("NChartCallbackService");  
</span>

<span id="TestNReflectionIsOfTag_snippet" style="display:none;">
var spanElm =
document.getElementById(
"TestNReflectionIsOfTag_snippet");

if(NReflection.IsOfTag(
  spanElm, "span"))
  NDiagnostics.Trace("span");

if(NReflection.IsOfTag(
  spanElm, "div"))
  NDiagnostics.Trace("div");
</span>

<span id="TestNDebugAssert_snippet" style="display:none;">
var myNumber = 0;

NDebug.Assert(null,
	"TestNDebugAssert",
	myNumber != 0,
	"myNumber cannot be zero");
	
NDebug.Assert(null,
	"TestNDebugAssert",
	myNumber == 0,
	"myNumber must be zero");
</span>

<span id="TestNDebugFail_snippet" style="display:none;">
NDebug.Fail(null,
	"TestNDebugFail",
	"Error message");
</span>

<span id="TestNDebugAssertIsDef_snippet" style="display:none;">
var myNumber = 0;

NDebug.AssertIsDef(null,
"TestNDebugAssertIsDef",
typeof(myNumber),
"myNumber is not defined",
"myNumber");
	
NDebug.AssertIsDef(null,
"TestNDebugAssertIsDef",
typeof(myNumber1),
"myNumber1 is not defined",
"myNumber1");
</span>

<span id="TestNDebugTraceError_snippet" style="display:none;">
NDebug.TraceError(null,
	"TestNDebugTraceError",
	"error occured");
	
try
{
	var x = null;
	x.test();
}
catch(ex)
{
	NDebug.TraceError(null,
	"TestNDebugTraceError",
	ex);
}
</span>

<span id="TestNDiagnosticsTrace_snippet" style="display:none;">
NDiagnostics.Trace("trace message");
</span>

<span id="TestNDiagnosticsListMembers_snippet" style="display:none;">
NDiagnostics.ListMembers(
  "document", document);
  
NDiagnostics.ListMembers(
  "window", window, 
  ENMemberFilter.Properties);
</span>

<span id="TestNDiagnosticsAlertProperties_snippet" style="display:none;">
NDiagnostics.AlertProperties(document);
</span>

<!-- JavaScript Snippets END -->

<!-- Custom JavaScript placeholder BEGIN -->
<script type="text/javascript" language="javascript">
<!--
	function ExecuteCode()
	{
		var codeElement = document.getElementById("sourceCodeTextBox");
		eval(codeElement.value);
	}

	function UseCodeSnippet(snippetSpanId)
	{
		var codeElement = document.getElementById("sourceCodeTextBox");
		var snippetSpan = document.getElementById(snippetSpanId + "_snippet");
		codeElement.value = snippetSpan.innerHTML.replace(/^\s+|\s+$/, "");
	}
	
	function CallbackSucceeded(self, result, context)
	{
		//	if error simulation is enabled, simulate an error during the callback processing
		var simulateErrorCheckbox = document.getElementById("simulateErrorCheckbox");
		if(simulateErrorCheckbox.checked == false)
			return;
			
		throw "simulated error";
	}
	
	NEventSinkService.AsyncCallbackSucceeded.Subscribe(null, CallbackSucceeded);
//-->
</script>
<!-- Custom JavaScript placeholder END -->
