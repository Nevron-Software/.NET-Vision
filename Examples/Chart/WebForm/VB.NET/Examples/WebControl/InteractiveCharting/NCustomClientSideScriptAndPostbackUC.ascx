<%@ Control Language="vb" Inherits="Nevron.Examples.Chart.WebForm.NCustomClientSideScriptAndPostbackUC" CodeFile="NCustomClientSideScriptAndPostbackUC.ascx.vb" %>
<%@ Register TagPrefix="ncwc" Namespace="Nevron.Chart.WebForm" Assembly="Nevron.Chart.WebForm" %>
<!-- Fading images placeholder BEGIN -->
<table>
<tr>
	<td style="background: url(..\InteractiveCharting\bus.png);">
		<img name="bus" class="imgFader" style="position: absolute; left: 20px; top:50px;" src="../Images/emptyvehicle.png" />
		<img name="car" class="imgFader" style="position: absolute; left: 20px; top:50px;" src="../Images/emptyvehicle.png" />
		<img name="ship" class="imgFader" style="position: absolute; left: 20px; top:50px;" src="../Images/emptyvehicle.png" />
		<img name="train" class="imgFader" style="position: absolute; left: 20px; top:50px;" src="../Images/emptyvehicle.png" />
	</td>
</tr>
</table>
<!-- Fading images placeholder END -->

<!-- Example layout BEGIN -->
<table id="exampleRootTable" style="width: 420px; vertical-align: top;" summary="Example layout table">
<tr>
	<td id="exampleImageRootCell" style="width: 420px; vertical-align: top; padding: 3px;">
		<table id="exampleImageTable" style="width: 420px; vertical-align: top;" summary="Image and description table">
		<tr>
			<td id="exampleImageCell" style="width: 420px; vertical-align: top; padding: 3px;">
				<!-- Chart control placeholder BEGIN -->
				<ncwc:NChartControl id="nChartControl1" runat="server" Width="420px" Height="320px">
				</ncwc:NChartControl>
				<!-- Chart control placeholder END -->
			</td>
		</tr>
		<tr>
			<td style="width: 420px; vertical-align: top; padding: 3px;">
				<asp:Image id="SalesOverTimeImg" runat="server" Height="200px" Width="420px"></asp:Image>
				<a onmouseover="JSFX.fadeIn('bus')" onmouseout="JSFX.fadeOut('bus')" href="#"></a>
			</td>
		</tr>
		<tr>
			<td id="exampleDescriptionCell" style="width: 420px; vertical-align: top; padding: 3px;">
				<p id="exampleDescriptionParagraph" class="Description">
					<!-- Description box placeholder BEGIN -->
					The example demonstrates how to inject custom script in the generated image map 
					in order to show fading rollovers as well as some other features like server 
					side events and direct stream to browser.<br />
					<br />
					When the mouse hovers over the pie chart the appropriate image for the 
					transport type will fade in on the left top of the page. When you click on a 
					pie chart segment a server side event is triggered which modifies the pie 
					detachment and changes the ImageUrl property of the sales analysis image at the 
					bottom to an aspx page generating a direct stream to browser image.
					<!-- Description box placeholder END -->
				</p>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
<!-- Example layout END -->

<!-- Custom JavaScript placeholder BEGIN -->
<!-- *********************************************************
* You may use this code for free on any web page provided that 
* these comment lines and the following credit remain in the code.
* Fading Image Rollovers © from http://www.javascript-fx.com
********************************************************  -->
<script language="JavaScript" src="../Examples/WebControl/InteractiveCharting/JSFX_FadingRollovers.js" type="text/javascript"><!----></script>
<script language="JavaScript" type="text/javascript">
<!--
	FadeInStep=20;
	FadeOutStep=5;

	JSFX.Rollover("vehicle_preview",  "../Images/emptyvehicle.png");
	JSFX.Rollover("bus",    "../Images/bus.png");
	JSFX.Rollover("car",    "../Images/car.png");
	JSFX.Rollover("ship",   "../Images/ship.png");
	JSFX.Rollover("train",  "../Images/train.png");            
//-->
</script>
<!-- Custom JavaScript placeholder END -->
