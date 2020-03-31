<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NSVGAndClientSideScriptingUC" CodeFile="NSVGAndClientSideScriptingUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 669px; vertical-align: top;" summary="Example layout table">
	<tr>
		<td id="exampleImageCell" style="width: 420px; vertical-align: top; padding: 3px;">
			<!-- Chart control placeholder BEGIN -->    
				<ncwc:NChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
				</ncwc:NChartControl>
			<!-- Chart control placeholder END -->
			</td>
			<td id="exampleConfigurationCell" >
			<!-- Configuration controls panel placeholder BEGIN -->
			<div style="position:relative">
				<div id='toyota' style="visibility:hidden;position:absolute">
					<table>
						<tr><td>Great interior flexibility and space, well built cabin, neat styling</td></tr>
						<tr><td>Small boot with all seats in place, third row is cramped and tricky to access</td></tr>
					</table>
				</div>
				<div id='chevrolet' style="visibility:hidden;position:absolute">
					<table>
						<tr><td>Competitive pricing, lots of standard equipment, five-year warranty.</td></tr>
						<tr><td>Lacks steering feel, boot is relatively small with seats folded flat.</td></tr>
					</table>
				</div>
				<div id='ford' style="visibility:hidden;position:absolute">
					<table>
						<tr><td>Excellent ride and handling, spacious, strong petrol and diesels.</td></tr>
						<tr><td>Poor steering feedback, counter-intuitive Powershift, seats lack lateral support.</td></tr>
					</table>
				</div>
				<div id='volkswagen' style="visibility:hidden;position:absolute">
					<table>
						<tr><td>Large amounts of boot space, improved rear passenger space, cheaper alternative to Passat.</td></tr>
						<tr><td>Firm ride, lacks any real driving excitement, dull image.</td></tr>
					</table>
				</div>
				<div id='hyundai' style="visibility:hidden;position:absolute">
					<table>
						<tr><td>Good ride and a more precise gearchange than before.</td></tr>
						<tr><td>There's little grip and it's still not quite up to European standards.</td></tr>
					</table>
				</div>
				<div id='nissan' style="visibility:hidden;position:absolute">
					<table>
						<tr><td>Creature comforts, plenty of good deals around.</td></tr>
						<tr><td>Not quite enough rear legroom, feels flimsy.</td></tr>
					</table>
				</div>
				<div id='mazda' style="visibility:hidden;position:absolute">
					<table>
						<tr><td>Distinctive looks, neat interior design, good to drive.</td></tr>
						<tr><td>No small diesel, rivals more practical, lacks some sparkle</td></tr>
					</table>
				</div>
				<div id='other' style="visibility:hidden;position:absolute">
					Move the mouse over a car model to see the pros and cons.
				</div>
			</div>

			<script language ="javascript">
				function ShowDiv(divId) {
					var divIds = [
						"toyota",
						"chevrolet",
						"ford",
						"volkswagen",
						"hyundai",
						"nissan",
						"mazda",
						"other"];

					for (i = 0; i < divIds.length; i++) {
						var curDivId = divIds[i];

						if (curDivId != divId) {
							document.getElementById(curDivId).style.visibility = "hidden";
						}
					}

					if (divId != null) {
						document.getElementById(divId).style.visibility = "visible";
					}
				}
			</script>
			<!-- Configuration controls panel placeholder END -->
		</td>
	</tr>
	<tr>
	<td id="Td2" style="width: 420px;" class="Description">
		<!-- Description box placeholder BEGIN -->
		The example demonstrates how to create SVG charts with scripts that modify both the SVG document and the containing HTML document.
		<!-- Description box placeholder END -->
	</td>
</tr>
</table>
<!-- Example layout END -->
		
	

