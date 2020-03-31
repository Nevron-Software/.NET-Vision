<%@ Page language="vb" Inherits="Nevron.Examples.Diagram.Webform.GettingStarted.NPersonalInfoPage" CodeFile="NPersonalInfoPage.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NPersonalInfoPage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="VB" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link type='text/css' href='../../Themes/OrangeGrey/Styles.css' rel='stylesheet' />
	</HEAD>
	<body>
		<div class="Description" style="width: 461px; margin-top: 14px; margin-left: 14px;">
			<table style="width: 435px;">
			<tr>
				<td style="width: 80px;">
					<asp:Image id="PersonPicture" style="margin: 10px;" runat="server"></asp:Image>
				</td>
				<td style="width: 355px; font-size: 9pt;">
					<asp:Label id="NameLabel" runat="server"></asp:Label>
					<br />&nbsp;<br />
					<asp:Label id="PositionLabel" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td colspan="2" style="font-size: 9pt;">
					<asp:Label id="BiographyLabel" runat="server"></asp:Label>
					<br />&nbsp;<br />
					<a href="javascript:window.history.back();">&lt;&lt; Back</a>
				</td>
			</tr>
			</table>
		</div>
	</body>
</HTML>
