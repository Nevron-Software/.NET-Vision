<%@ Control Language="c#" Inherits="Nevron.Examples.Chart.WebForm.NCustomToolsUC" CodeFile="NCustomToolsUC.ascx.cs" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>

<!-- Custom JavaScript placeholder BEGIN -->
<script type="text/javascript" language="javascript">
<!--
//	This code definese th following JavaScript types:
//		NCustomToolConfig
//		NCustomTool
//		NDisplayDetailedChartCommand
//		NHideDetailedChartCommand
//		NCustomToolFactory

////////////////////////////////
// class NCustomToolConfig
// A configuration object for the NCustomTool tool.
function NCustomToolConfig()
{
	//	Runtime type info initialization
	this.InitializeRuntimeTypeInfo(NCustomToolConfig.prototype);
	this.NAjaxToolConfig(false);
};
//	Inheritance
NCustomToolConfig.DeriveFrom(NAjaxToolConfig);

////////////////////////////////
// class NCustomTool
function NCustomTool(callbackService, toolConfig)
{
	//	Runtime type info initialization
	this.InitializeRuntimeTypeInfo(NCustomTool.prototype);
	this.NAjaxTool(callbackService, toolConfig);
	
	// Indicates, whether the tooltip is currently visible.
	this.tooltipVisible = false;
	// Contains a reference to the HTML div element that is used to display tooltips.
	this.tooltipDiv = null;
	// The image map object item, which tooltip is being currently displayed.
	this.currentImageMapObjectItem = null;
	
	//	constructor body
	if (NReflection.IsInstance(toolConfig.configurationObject))
		this.config = toolConfig.configurationObject;
	else
		this.config = new NCustomToolConfig();
};
//	Inheritance
NCustomTool.DeriveFrom(NAjaxTool);

// Provides feedback to the controller, whether or not the tool will
// process the mouse enter event.
NCustomTool.prototype.RequiresMouseEnterEvent = function(self)
{
	return true;
};

// Provides feedback to the controller, whether or not the tool will
// process the mouse leave event.
NCustomTool.prototype.RequiresMouseLeaveEvent = function(self)
{            
	return true;
};

// Provides feedback to the controller, whether or not the tool will
// process the mouse move event.
NCustomTool.prototype.RequiresMouseMoveEvent = function(self)
{            
	return true;
};

// Displays the tooltip.
NCustomTool.prototype.ProcessMouseEnter = function(self, commandQueue, eventData)
{            
	if (!NReflection.IsInstance(eventData.imageMapObjectItem))
		return;
	var imageMapItem = eventData.imageMapObjectItem;
	if (imageMapItem.userData == null)
		return;
	if (self.tooltipVisible)
		return;
	self.tooltipVisible = true;
	self.currentImageMapObjectItem = self.callbackService.currentOverElement;
	commandQueue.Enqueue(new NDisplayDetailedChartCommand(self.callbackService, self, commandQueue, eventData, imageMapItem.userData));
};

// Moves the tooltip along with the mouse cursor.
NCustomTool.prototype.ProcessMouseMove = function(self, commandQueue, eventData)
{            
	if (!self.tooltipVisible)
		return;
	var imageMapItem = eventData.imageMapObjectItem;
	if (imageMapItem == null)
		return;
	commandQueue.Enqueue(new NDisplayDetailedChartCommand(self.callbackService, self, commandQueue, eventData, imageMapItem.userData));
};

// Hides the tooltip.
NCustomTool.prototype.ProcessMouseLeave = function(self, commandQueue, eventData)
{            
	if (!self.tooltipVisible)
		return;
	self.tooltipVisible = false;
	self.currentImageMapObjectItem = null;
	commandQueue.Enqueue(new NHideDetailedChartCommand(self, commandQueue, eventData));
};

////////////////////////////////
// class NDisplayDetailedChartCommand
function NDisplayDetailedChartCommand(callbackService, tool, commandQueue, eventData, bookId)
{
	//	Runtime type info initialization
	this.InitializeRuntimeTypeInfo(NDisplayDetailedChartCommand.prototype);
	this.NCallbackCommand(callbackService, tool, commandQueue);

	// The event data, associated with the event that caused the command generation.
	this.eventData = null;
	// The text of the tooltip.
	this.bookId = -1;

	if (NReflection.IsInstance(eventData))
		this.eventData = eventData;
	if (NReflection.IsInstance(bookId))
		this.bookId = bookId;
};
//	Inheritance
NDisplayDetailedChartCommand.DeriveFrom(NCallbackCommand);

// Creates/shows the tooltip div and displays the tooltip text within.
NDisplayDetailedChartCommand.prototype.Execute = function(self)
{
	var base = NDisplayDetailedChartCommand.GetBase();
	var boxDiv;
	var boxDivHeight = 200;
	var boxDivDefaultWidth = 500;
	var t = self.tool;
	if (t.tooltipDiv == null)
	{
		boxDiv = document.createElement("div");
		boxDiv.style.fontFamily = "ms sans serif, arial, sans-serif";
		boxDiv.style.fontSize = "8pt";
		boxDiv.style.whiteSpace = "nowrap";
		boxDiv.style.height = NBrowserCaps.ToPixelLength(boxDivHeight);
		boxDiv.style.width = NBrowserCaps.ToPixelLength(boxDivDefaultWidth);
		if (self.cssClass != null)
			boxDiv.className = self.cssClass;
		boxDiv.style.position = "absolute";
		var boxDivChildren = boxDiv.childNodes;
		for (var i = 0; i < boxDivChildren.length; i++)
		{
			var childElement = boxDivChildren[i];
			childElement["CallbackService"] = self.callbackService;
		}
		document.body.appendChild(boxDiv);
		t.tooltipDiv = boxDiv;
		boxDiv["CallbackService"] = self.callbackService;
		boxDiv.onmousemove = NEventSinkService.MouseMoveHandler;
	}
	else
	{
		boxDiv = t.tooltipDiv;
	}
	
	if(boxDiv.style.display != "block")
	{
		boxDiv.style.display = "block";
		boxDiv.innerHTML = "<img src='~/NevronCustomTools.axd?id=" + self.bookId + "'><br />";
	}

	var left = self.eventData.pageOffset.offsetLeft + 10;
	var top = self.eventData.pageOffset.offsetTop - boxDivHeight - 10;
	var documentWidth = 0;
	
	if (document.documentElement != null && document.documentElement["clientWidth"] != null)
	{
		documentWidth = document.documentElement.clientWidth;
	}
	else if (document.body != null && document.body["clientWidth"] != null)
	{
		documentWidth = document.body.clientWidth;
	}
	
	if (documentWidth != 0)
	{
		var width = boxDiv.offsetWidth;
		var windowScrollPos = NBrowserCaps.GetScrollLeft();
		if (left + width > documentWidth + windowScrollPos)
			left = documentWidth - width + windowScrollPos;
	}
	
	if(top < 0)
		top = 0;
	
	boxDiv.style.left = NBrowserCaps.ToPixelLength(left);
	boxDiv.style.top = NBrowserCaps.ToPixelLength(top);
	
	base.Execute(self);
};

////////////////////////////////
// class NHideDetailedChartCommand
function NHideDetailedChartCommand(tool, commandQueue, eventData)
{
	//	Runtime type info initialization
	this.InitializeRuntimeTypeInfo(NHideDetailedChartCommand.prototype);
	this.NCommand(tool, commandQueue);

	// The event data, associated with the event that caused the command generation.
	this.eventData = null;

	if (NReflection.IsInstance(eventData))
		this.eventData = eventData;
};
//	Inheritance
NHideDetailedChartCommand.DeriveFrom(NCommand);

//Hides the tooltip div.
NHideDetailedChartCommand.prototype.Execute = function(self)
{
	var base = NHideDetailedChartCommand.GetBase();
	var t = self.tool;
	t.tooltipDiv.className = "";
	t.tooltipDiv.style.display = "none";
	base.Execute(self);
};


////////////////////////////////
// class NCustomToolFactory
//
// This class will be used as a tool factory, because in our control initialization
// the AjaxToolsFactoryType property of the web control is set to "NCustomToolFactory".
function NCustomToolFactory()
{
	//	Runtime type info initialization
	this.InitializeRuntimeTypeInfo(NCustomToolFactory.prototype);
	this.NToolFactory(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4], arguments[5], arguments[6], arguments[7], arguments[8], arguments[9]);
};
//	Inheritance
NCustomToolFactory.DeriveFrom(NToolFactory);

// Resets the callback service controller tools and initializes the controller
// with new tools, created on the base of the tool configuration objects that are
// cached in the configurationItems hashtable.
NCustomToolFactory.prototype.InitializeTools = function(self, callbackService)
{
	var base = NCustomToolFactory.GetBase();
	
	//	initialize the built-in tools
	base.InitializeTools(self, callbackService);
	
	var dictionaryEntries = self.configurationItems.GetDictionaryEntries();
	var tools = callbackService.controller.GetTools();
	//	initialize the custom tools
	for (var i = 0; i < dictionaryEntries.length; i++)
	{
		var toolConfig = dictionaryEntries[i].val;
		var tool = null;
		
		if (toolConfig.toolId == NCustomTool.GetClassName())
		{
			tool = new NCustomTool(callbackService, toolConfig);
		}
			
		if (tool != null)
		{
			tools[tools.length] = tool;
			tool.controller = callbackService.controller;
		}
	}
};

//-->
</script>
<!-- Custom JavaScript placeholder END -->

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 729px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageCell" class="ImageCell" style="width: 442px; vertical-align: top;">
		<!-- Diagram control placeholder BEGIN -->
		<ncwc:NChartControl id="nChartControl1" runat="server" Width="416px" Height="416px"  AjaxEnabled="True" AsyncCallbackTimeout="10000" AsyncRequestWaitCursorEnabled="False" OnQueryAjaxTools="nChartControl1_QueryAjaxTools">
		</ncwc:NChartControl>
		<!-- Diagram control placeholder END -->
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleDescriptionCell" class="Description" rowspan="2" style="width: 300px;">
		<!-- Configuration controls panel placeholder BEGIN -->
		This example demonstrates how a custom client side tool can be created
		that runs as a part the Nevron JavaScript Framework.
        <br />&nbsp;<br />
		The task is acheived by implementing the server side C# class
		NAjaxCustomTool and setting the AjaxToolsFactoryType property of the web control
		to the name of the custom JavaScript tool factory: "NCustomToolFactory", and by
		implementing the client side JavaScript classes
		<ul>
			<li>NCustomToolConfig</li>
			<li>NCustomTool</li>
			<li>NDisplayBookInfoCommand</li>
			<li>NHideBookInfoCommand</li>
			<li>NCustomToolFactory</li>
		</ul>
		The image that appears inside the floating DIV element is generated dynamically
		through the NChartZoomHttpHandler class, which is located under the examples project
		inside App_Code\Examples\AJAX\Engine\NChartZoomHttpHandler.cs. The sample population
		data is acquired from Excel through OLEDB. You can find the code that reads the
		data in App_Code\Examples\AJAX\Engine\NCustomToolsData.cs. Both classes
		cannot be examined directly from the running examples, so please find them in the examples
		solution that Nevron .NET Vision has installed on your computer.
        <br />&nbsp;<br />
        Please look at the web.config file, where the NevronCustomTools.axd HTTP handler must
        defined for this example to run properly.
        <br />&nbsp;<br />
        The data displayed by this chart has been originally published by the
        <a target="_blank" href="http://factfinder.census.gov/servlet/DTTable?_bm=y&-geo_id=01000US&-ds_name=ACS_2007_3YR_G00_&-_lang=en&-mt_name=ACS_2007_3YR_G2000_B01001&-mt_name=ACS_2007_3YR_G2000_B01001A&-mt_name=ACS_2007_3YR_G2000_B01001B&-mt_name=ACS_2007_3YR_G2000_B01001C&-mt_name=ACS_2007_3YR_G2000_B01001D&-mt_name=ACS_2007_3YR_G2000_B01001E&-mt_name=ACS_2007_3YR_G2000_B01001F&-mt_name=ACS_2007_3YR_G2000_B01001G&-mt_name=ACS_2007_3YR_G2000_B01001H&-mt_name=ACS_2007_3YR_G2000_B01001I&-format=&-CONTEXT=dt">U.S. Census Bureau</a>
        and covers 3-year estimates survey for 2005-2007.
        <!-- Configuration controls panel placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
