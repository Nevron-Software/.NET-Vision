<%@ Control Language="vb" Inherits="Nevron.Examples.Diagram.Webform.NPdfExportUC" CodeFile="NPdfExportUC.ascx.vb" %>

<!-- Example layout BEGIN -->
<table id="exampleImageTable" summary="Image and description table">
<tr>
	<td id="exampleImageCell" class="ImageCell">
		<img alt="" src="../Examples/PDF/NPdfExportRenderPage.aspx" />
	</td>
	<td id="exampleVDelimiterCell" class="DelimiterCell" rowspan="2">&nbsp;</td>
	<td id="exampleConfigurationCell" class="ControlsPanel" rowspan="2" style="width: 100px;">
		<!-- Configuration controls panel placeholder BEGIN -->
			 <table id="properties">
				<tr>
					<th colspan="2">PDF Settings (in mm)</th>
				</tr>
				<tr>
					<td style="padding:3px">Page Size</td>
					<td style="padding:3px">
						<select id="PaperSize" onchange="OnPaperSizeChanged()">
							<option value="-1,-1">Custom</option>
							
							<option value="841,1189">A0</option>
							<option value="594,841">A1</option>
							<option value="420,594">A2</option>
							<option value="297,420">A3</option>
							<option value="210,297" selected="selected">A4</option>
							<option value="148,210">A5</option>
							
							<option value="1030,1456">B0</option>
							<option value="728,1030">B1</option>
							<option value="515,728">B2</option>
							<option value="364,515">B3</option>
							<option value="257,364">B4</option>
							<option value="182,257">B5</option>

							<option value="216,279">Letter</option>
							<option value="216,356">Legal</option>
							<option value="432,279">Ledger</option>
							<option value="279,432">Tabloid</option>
						</select>
					</td>
				</tr>
				<tr>
					<td style="padding:3px">Page Width</td>
					<td style="padding:3px"><input type="text" id="PageWidth" value="210" maxlength="4" style="width:45px" disabled="disabled" onchange="ValidateTextBox(this, 'int', 210, 10, 9999)" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Page Height</td>
					<td style="padding:3px"><input type="text" id="PageHeight" value="297" maxlength="4" style="width:45px" disabled="disabled" onchange="ValidateTextBox(this, 'int', 297, 10, 9999)" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Left Margin</td>
					<td style="padding:3px"><input type="text" id="MarginsLeft" value="4" maxlength="4" style="width:45px" onchange="ValidateTextBox(this, 'int', 4, 0, 9999)" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Top Margin</td>
					<td style="padding:3px"><input type="text" id="MarginsTop" value="4" maxlength="4" style="width:45px" onchange="ValidateTextBox(this, 'int', 4, 0, 9999)" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Right Margin</td>
					<td style="padding:3px"><input type="text" id="MarginsRight" value="4" maxlength="4" style="width:45px" onchange="ValidateTextBox(this, 'int', 4, 0, 9999)" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Bottom&nbsp;Margin</td>
					<td style="padding:3px"><input type="text" id="MarginsBottom" value="4" maxlength="4" style="width:45px" onchange="ValidateTextBox(this, 'int', 4, 0, 9999)" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Zoom (in %)</td>
					<td style="padding:3px"><input type="text" id="ZoomPercent" value="100" maxlength="3" style="width:45px" onchange="ValidateTextBox(this, 'int', 100, 1, 999)" /></td>
				</tr>
				<tr>
					<td style="padding:3px">Fit to Page</td>
					<td><input type="checkbox" id="FitToPage" onclick="OnFitToPageClicked()" /></td>
				</tr>
			</table>
			<hr class="WhiteHr" />
			<p>
				<input type="button" id="btnExport" value="Export to PDF"  style="width:100%" onclick="OnExportButtonClick()"/>
			</p>
		<!-- Configuration controls panel placeholder END -->
	</td>
</tr>
<tr>
	<td id="exampleDescriptionCell" class="Description">
		<!-- Description box placeholder BEGIN -->
		Demonstrates the ability of Nevron Diagram for .NET to binary stream PDF documents
		to the browser without generating a file on the server.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder START -->
<script type="text/javascript" language="javascript">
<!--
	// Gets all properties name/value pairs as string in the format:
	// name1=value1
	// name2=value2
	// etc.
	function GetPropertiesAsString() {
		var el = document.getElementById("properties");
		if (typeof (el) == "undefined")
			return properties;

		var i, el, count;
		var inputs = el.getElementsByTagName("input");
		var selects = el.getElementsByTagName("select");
		var result = "";

		// The input elements
		count = inputs.length;
		for (i = 0; i < count; i++) {
			el = inputs[i];
			switch (el.type) {
				case "text":
					result += el.id + "=" + el.value + "\n";
					break;
				case "checkbox":
					result += el.id + "=" + el.checked + "\n";
					break;
				case "radio":
					if (el.checked) {
						result += el.name + "=" + el.value + "\n";
					}
					break;
			}
		}

		// The select elements
		count = selects.length;
		for (i = 0; i < count; i++) {
			el = selects[i];
			result += el.id + "=" + el.options[el.selectedIndex].value + "\n";
		}

		return result;
	}

	function OnPaperSizeChanged() {
		var value = document.getElementById("PaperSize").value;
		var arr = value.split(",");
		var pageWidthTextBox = document.getElementById("PageWidth");
		var pageHeightTextBox = document.getElementById("PageHeight");
		
		if (arr[0] == "-1") {
			// The user has selected a cutsom page size
			pageWidthTextBox.disabled = false;
			pageHeightTextBox.disabled = false;
		}
		else {
			// The user has selected a predefined page size
			pageWidthTextBox.disabled = true;
			pageHeightTextBox.disabled = true;

			pageWidthTextBox.value = arr[0];
			pageHeightTextBox.value = arr[1];
		}
	}
	function OnFitToPageClicked() {
		var fitToPage = document.getElementById("FitToPage").checked == true;
		document.getElementById("ZoomPercent").disabled = fitToPage;
	}
	function OnExportButtonClick() {
		// Read all properties as string
		var properties = GetPropertiesAsString();

		// Remove the last new line of the properties string
		properties = properties.substring(0, properties.length - 1);

		// Use a global regular expression to replace all new lines with ampersand
		properties = properties.replace(/\n/g, "&");

		// Create the pdf and load it in the current browser window
		window.location = "../Examples/PDF/NPdfExportRenderPage.aspx?format=pdf&" + properties;
	}
//-->
</script>
<!-- Custom JavaScript placeholder END -->