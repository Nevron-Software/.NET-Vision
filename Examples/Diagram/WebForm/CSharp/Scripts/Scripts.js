var BrowserDetect = {
    init: function () {
        this.browser = this.searchString(this.dataBrowser) || "An unknown browser";
        this.version = this.searchVersion(navigator.userAgent)
			|| this.searchVersion(navigator.appVersion)
			|| "an unknown version";
        this.OS = this.searchString(this.dataOS) || "an unknown OS";
    },
    searchString: function (data) {
        for (var i = 0; i < data.length; i++) {
            var dataString = data[i].string;
            var dataProp = data[i].prop;
            this.versionSearchString = data[i].versionSearch || data[i].identity;
            if (dataString) {
                if (dataString.indexOf(data[i].subString) != -1)
                    return data[i].identity;
            }
            else if (dataProp)
                return data[i].identity;
        }
    },
    searchVersion: function (dataString) {
        var index = dataString.indexOf(this.versionSearchString);
        if (index == -1) return;
        return parseFloat(dataString.substring(index + this.versionSearchString.length + 1));
    },
    dataBrowser: [
		{ string: navigator.userAgent,
		    subString: "OmniWeb",
		    versionSearch: "OmniWeb/",
		    identity: "OmniWeb"
		},
		{
		    string: navigator.vendor,
		    subString: "Apple",
		    identity: "Safari"
		},
		{
		    prop: window.opera,
		    identity: "Opera"
		},
		{
		    string: navigator.vendor,
		    subString: "iCab",
		    identity: "iCab"
		},
		{
		    string: navigator.vendor,
		    subString: "KDE",
		    identity: "Konqueror"
		},
		{
		    string: navigator.userAgent,
		    subString: "Firefox",
		    identity: "Firefox"
		},
		{
		    string: navigator.vendor,
		    subString: "Camino",
		    identity: "Camino"
		},
		{		// for newer Netscapes (6+)
		    string: navigator.userAgent,
		    subString: "Netscape",
		    identity: "Netscape"
		},
		{
		    string: navigator.userAgent,
		    subString: "MSIE",
		    identity: "Explorer",
		    versionSearch: "MSIE"
		},
		{
		    string: navigator.userAgent,
		    subString: "Gecko",
		    identity: "Mozilla",
		    versionSearch: "rv"
		},
		{ 		// for older Netscapes (4-)
		    string: navigator.userAgent,
		    subString: "Mozilla",
		    identity: "Netscape",
		    versionSearch: "Mozilla"
		}
	],
    dataOS: [
		{
		    string: navigator.platform,
		    subString: "Win",
		    identity: "Windows"
		},
		{
		    string: navigator.platform,
		    subString: "Mac",
		    identity: "Mac"
		},
		{
		    string: navigator.platform,
		    subString: "Linux",
		    identity: "Linux"
		}
	]

};
BrowserDetect.init();

//	configuration
var rootDivWidthAdjust = 0;
var rootDivHeightAdjust = 0;
var examplesViewWidthAdjust = -1; // -7-24;
var examplesViewHeightAdjust = -38; //-34;
var navPaneTreeWidthAdjust = -7 - 24;
var navPaneTreeHeightAdjust = -66;

//	implementation
function adjustPixelLengthString(lengthString) {
    var regex = /\W*px\W*$/gi
    if (lengthString.search(regex) != -1)
        return lengthString;
    return lengthString + "px";
}

function toPixelLength(lengthValue) {
    if (typeof (lengthValue) == typeof (""))
        return adjustPixelLengthString(lengthValue);

    return adjustPixelLengthString(new String(parseInt(lengthValue)));
}

function adjustRootDivSize() {
    resizeElement("rootDiv", rootDivWidthAdjust, rootDivHeightAdjust);
    sizeElementAsElement("TabControl_MultiViewHolder", "rootDiv", examplesViewWidthAdjust, examplesViewHeightAdjust);
    sizeElementAsElement("NavigationPane_MultiViewHolder", "rootDiv", navPaneTreeWidthAdjust, navPaneTreeHeightAdjust);
}

function resizeElement(elementId, widthAdjust, heightAdjust) {
    var element = document.getElementById(elementId);

    if (element == null)
        return;

    element.style.width = "100%";
    element.style.height = "100%";

    var width = element.offsetWidth;
    var height = element.offsetHeight;

    width += widthAdjust;
    height += heightAdjust;

    element.style.width = toPixelLength(width);
    element.style.height = toPixelLength(height);
}

var repeatCount = 0;
function sizeElementAsElement(elementId, sizeSourceElementId, widthAdjust, heightAdjust) {
    repeatCount++;
    if (BrowserDetect.browser == "Explorer" && BrowserDetect.version == "6") {
        if (repeatCount > 100) {
            repeatCount = 0;
        }
        if (repeatCount > 10) {
            window.setInterval(function () { repeatCount = 0; }, 1000);
            return;
        }
    }

    var element = document.getElementById(elementId);
    var sizeSourceElement = document.getElementById(sizeSourceElementId);

    if (element == null || sizeSourceElement == null)
        return;

    var w = sizeSourceElement.offsetWidth + widthAdjust;
    if (w < 0) {
        w = 0;
    }
    element.style.width = toPixelLength(w);

    var h = sizeSourceElement.offsetHeight + heightAdjust;
    if (h < 0) {
        h = 0;
    }
    element.style.height = toPixelLength(h);
}

function sizeElement(elementId, width, height) {
    var element = document.getElementById(elementId);

    if (element == null)
        return;

    element.style.width = toPixelLength(width);
    element.style.height = toPixelLength(height);
}

function getTabsAndCaptionHeightSum() {
    var result = 0;

    var captionElement = document.getElementById("NavigationPaneCaption");
    if (captionElement != null)
        result = captionElement.offsetHeight;

    for (var i = 0; i < 100; i++) {
        var element = document.getElementById("Nevron_TabStrip_NavPane_TabStrip_Tab_" + i);
        if (element == null)
            return result;
        result += element.offsetHeight + 1;
    }

    return result;
}

function ReprogramTree(treeControlId) {
    var nodeSelected = false;
    for (var i = 0; i < 1000; i++) {
        var nodeLinkElementId = treeControlId + "t" + i;
        var nodeImageElementId = nodeLinkElementId + "i";
        var nodeLinkElement = document.getElementById(nodeLinkElementId);
        var nodeImageElement = document.getElementById(nodeImageElementId);

        if (nodeLinkElement != null) {
            var clickCode = String(nodeLinkElement.onclick);
            if (clickCode.indexOf("TreeView_SelectNode") != -1) {
                nodeLinkElement.onclick = TreeClickOverride;
                if (!nodeSelected) {
                    SelectNode(nodeLinkElement);
                    nodeSelected = true;
                }
            }
        }
        else {
            break;
        }

        if (nodeImageElement != null) {
            var clickCode = String(nodeImageElement.onclick);
            if (clickCode.indexOf("TreeView_SelectNode") != -1) {
                nodeImageElement.onclick = TreeClickOverride;
            }
        }
    }
}

var activeImage = null;
var activeLink = null;
function TreeClickOverride() {
    var eventObject = null;
    var eventTarget = null;

    if (arguments.length != 0)
        eventObject = arguments[0];
    else if (String(event) != "undefined")
        eventObject = event;
    else
        return;

    if (String(eventObject.srcElement) != "undefined")
        eventTarget = eventObject.srcElement;
    else if (String(eventObject.target) != "undefined")
        eventTarget = eventObject.target;
    else
        return;

    if (String(eventTarget) == "undefined" || eventTarget == null)
        return;

    SelectNode(eventTarget);
}

function SelectNode(eventTarget) {
    var imageElement;
    var linkElement;
    if (eventTarget.tagName.toLowerCase() == "img") {
        imageElement = eventTarget;
        linkElement = document.getElementById(eventTarget.parentElement.id.slice(0, eventTarget.parentElement.id.length - 1));
    }
    else {
        imageElement = document.getElementById(eventTarget.id + "i").firstChild;
        linkElement = eventTarget;
    }

    if (activeImage != null) {
        activeImage.src = imageElement.src;
    }
    if (activeLink != null) {
        activeLink.style.color = "";
    }

    imageElement.src = imageElement.src.replace("Blank", "Selected");
    activeImage = imageElement;

    linkElement.style.color = "#EA530E";
    activeLink = linkElement;
}

// Validates the given text box and sets it back to the default
// value if the new value is not valid
function ValidateTextBox(txt, type, defaultValue, minValue, maxValue) {
    var value;

    switch (type) {
        case "int":
            value = parseInt(txt.value);
            break;

        case "float":
            value = parseFloat(txt.value);
            break;

        default:
            return;
    }

    if (isNaN(value) || value < minValue || value > maxValue) {
        txt.value = defaultValue;
    }
}

// Gets all properties name/value pairs.
function GetProperties() {
    var properties = new Array();
    var el = document.getElementById("properties");
    if (typeof (el) == "undefined")
        return properties;

    var i, el, count;
    var inputs = el.getElementsByTagName("input");
    var selects = el.getElementsByTagName("select");

    // The input elements
    count = inputs.length;
    for (i = 0; i < count; i++) {
        el = inputs[i];
        switch (el.type) {
            case "text":
                properties[el.id] = el.value;
                break;

            case "checkbox":
                properties[el.id] = el.checked;
                break;

            case "radio":
                if (el.checked) {
                    properties[el.name] = el.value;
                }
                break;
        }
    }

    // The select elements
    count = selects.length;
    for (i = 0; i < count; i++) {
        el = selects[i];
        properties[el.id] = el.options[el.selectedIndex].value;
    }

    return properties;
}